using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using WS_Hotline.Framework.Domain.Command;
using WS_Hotline.Framework.Domain.Query;

namespace WS_Hotline.Framework.AccesDonnees
{
    public static class SearchCriteriaExtensions
    {
        public static string SearchCriteriaEventSourceKey = "SearchCriteria";

        public static QueryResult<T> Query<T>(this SearchCriteria<T> pSearchCriteria, IQueryable<T> pSource, Dictionary<string, Func<IQueryable<T>, Expression<Func<T, object>>, SearchCriteria<T>, IQueryable<T>>> pFetchings)
        {
            var lNullSafeSearchCriteria = pSearchCriteria ?? new AnySearchCriteria<T>();
            return lNullSafeSearchCriteria.QueryInternal(pSource, pFetchings);
        }

        public static T QuerySingle<T>(
            this SearchCriteria<T> pSearchCriteria,
            IQueryable<T> pSource,
            Dictionary<string, Func<IQueryable<T>, Expression<Func<T, object>>, SearchCriteria<T>, IQueryable<T>>> pFetchings)
        {
            return Query(pSearchCriteria, pSource, pFetchings).List.SingleOrDefault();
        }
    }

    public abstract class Repository<TDomainObject, TDbContext> : IRepository<TDomainObject>
        where TDomainObject : BaseDTO
        where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;

        private Dictionary<string, Func<IQueryable<TDomainObject>, Expression<Func<TDomainObject, object>>, SearchCriteria<TDomainObject>, IQueryable<TDomainObject>>> _fetchings;

        protected Repository(TDbContext pContext)
        {
            this._dbContext = pContext;
        }

        /// <summary>
        /// Get a queryResult with search Criteria.
        /// </summary>
        /// <param name="pSearchCriteria"></param>
        /// <returns></returns>
        public virtual QueryResult<TDomainObject> GetItems(SearchCriteria<TDomainObject> pSearchCriteria = null)
        {
            IQueryable<TDomainObject> lQuery = this._dbContext.Set<TDomainObject>();
            // Build sql query from SearchCriteria.
            return pSearchCriteria.Query(lQuery, this._fetchings);
        }

        /// <summary>
        /// Get a entity with search Criteria.
        /// </summary>
        /// <param name="pSearchCriteria"></param>
        /// <returns></returns>
        public virtual TDomainObject GetItem(SearchCriteria<TDomainObject> pSearchCriteria)
        {
            return this.GetItems(pSearchCriteria).List.SingleOrDefault();
        }

        /// <summary>
        /// Get a entity with unique entity Code
        /// </summary>
        /// <param name="pEntityCode"></param>
        /// <returns></returns>
        public TDomainObject GetItem(string pEntityCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add an entity into database
        /// </summary>
        /// <param name="pEntity"></param>
        public virtual TDomainObject AddItem(TDomainObject pEntity)
        {
            this._dbContext.Set<TDomainObject>().Add(pEntity);
            this._dbContext.SaveChanges();
            return pEntity;
        }

        /// <summary>
        /// Add many entities into database
        /// </summary>
        /// <param name="pEntities"></param>
        public virtual void AddItems(IEnumerable<TDomainObject> pEntities)
        {
            using (var lScope = new TransactionScope())
            {
                this._dbContext.Set<TDomainObject>().AddRange(pEntities); 
                // TODO : Le bulkInsert ne marche plus depuis l'ajout des dossier unitaire!
                //this._dbContext.BulkInsert(pEntities);
                this._dbContext.SaveChanges();
                lScope.Complete();
            }
        }


        /// <summary>
        /// Add an entity into database
        /// </summary>
        /// <param name="pEntity">Entity a modifier</param>
        public virtual void UpdateItem(TDomainObject pEntity)
        {

            this._dbContext.Entry(pEntity).State = EntityState.Modified;

            this._dbContext.SaveChanges();
        }

        /// <summary>
        /// Add many entities into database
        /// </summary>
        /// <param name="pEntities">Entity a modifier</param>
        public virtual void UpdateItems(IEnumerable<TDomainObject> pEntities)
        {
            using (var lScope = new TransactionScope())
            {
                foreach (var lEntity in pEntities)
                {
                    this._dbContext.Entry(lEntity).State = EntityState.Modified;
                }

                // TODO : Le bulkInsert ne marche plus depuis l'ajout des dossier unitaire!
                //this._dbContext.BulkInsert(pEntities);
                this._dbContext.SaveChanges();
                lScope.Complete();
            }
        }

        /// <summary>
        /// Remove many entities into database
        /// </summary>
        /// <param name="pSearchCriteria"></param>
        public virtual void RemoveItems(SearchCriteria<TDomainObject> pSearchCriteria)
        {
            var lEntities = this.GetItems(pSearchCriteria);

            if (lEntities.Total <= 0) return;

            //gb - Change le statut des lignes
            foreach (TDomainObject lItem in lEntities.List)
            {
                //gb - Change le statut de l'objet
                lItem.CurrentState = BaseDTO.State.Delete;
            }

            //gb - Suppression de l'objet
            this._dbContext.Set<TDomainObject>().RemoveRange(lEntities.List);
            this._dbContext.SaveChanges();
        }

        protected void Add(Expression<Func<TDomainObject, object>> pRoperty, Func<IQueryable<TDomainObject>, Expression<Func<TDomainObject, object>>, SearchCriteria<TDomainObject>, IQueryable<TDomainObject>> pFetching)
        {
            if (this._fetchings == null)
            {
                this._fetchings = new Dictionary<string, Func<IQueryable<TDomainObject>, Expression<Func<TDomainObject, object>>, SearchCriteria<TDomainObject>, IQueryable<TDomainObject>>>();
            }

            this._fetchings.Add(pRoperty.ToString(), pFetching);
        }
    }
}