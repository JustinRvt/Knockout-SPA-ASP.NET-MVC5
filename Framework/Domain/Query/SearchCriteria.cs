using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WS_Hotline.Framework.Domain.Query
{
    /// <summary>
    /// Base class for search criteria.
    /// Encapsulates paging, ordering and filtering.
    /// Implementors use <see cref="Filters"/> to add filters applied when requesting data from data source.
    /// </summary>
    /// <typeparam name="T">Type of Domain Model criteria apply to</typeparam>
    public class SearchCriteria<T>
    {
        private Dictionary<string, Expression<Func<T, object>>> _includes;

        public SearchCriteria()
        {
            this.SkippedItems = 0;
            this.PageSize = Int32.MaxValue;
            this.Filters = new Dictionary<string, Expression<Func<T, bool>>>();
            this.RelatedProperties = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets requested page
        /// </summary>
        public int SkippedItems { get; set; }

        /// <summary>
        /// Gets or sets page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets order by clause
        /// </summary>
        public string OrderBy { get; set; }

        public IDictionary<string, string> RelatedProperties { get; set; }

        public virtual string EntityCode { get; set; }

        protected Dictionary<string, Expression<Func<T, bool>>> Filters { get; private set; }

        /// <summary>
        /// Apply filters, paging and ordering to given <see cref="pSource"/>
        /// </summary>
        /// <param name="pSource">Data source</param>
        /// <returns>Items corresponding to criteria</returns>
        public IQueryable<T> ToQueryable(IQueryable<T> pSource)
        {
            var lResult = this.Filters.Aggregate(pSource, (pCurrent, pFilter) => pCurrent.Where(pFilter.Value));
            
            return this.Order(lResult);
        }

        /// <summary>
        /// Define all property needed to be included in aggregate
        /// </summary>
        /// <param name="pRoperty"></param>
        /// <returns></returns>
        public SearchCriteria<T> Include(Expression<Func<T, object>> pRoperty)
        {
            if (this._includes == null)
            {
                this._includes = new Dictionary<string, Expression<Func<T, object>>>();
            }

            this._includes.Add(pRoperty.ToString(), pRoperty);
            return this;
        }

        internal bool FilterAny(IQueryable<T> pSource)
        {
            return this.Filters.Aggregate(pSource, (pCurrent, pFilter) => pCurrent.Where(pFilter.Value)).Any();
        }

        /// <summary>
        /// Construct query
        /// </summary>
        /// <param name="pSource"></param>
        /// <param name="pFetchings"></param>
        /// <returns></returns>
        internal QueryResult<T> QueryInternal(IQueryable<T> pSource, Dictionary<string, Func<IQueryable<T>, Expression<Func<T, object>>, SearchCriteria<T>, IQueryable<T>>> pFetchings)
        {
            var lFilteredSource = this.ToQueryable(pSource);
            var lPagedResults = this.PageSize != int.MaxValue
                                   ? lFilteredSource.Skip(this.SkippedItems).Take(this.PageSize)
                                   : lFilteredSource;
            lPagedResults = this.ApplyIncludes(lPagedResults, pFetchings);
            return new QueryResult<T>(
                lPagedResults,
                lFilteredSource);
        }

        protected virtual IQueryable<T> DefaultOrderBy(IQueryable<T> pSource)
        {
            return pSource;
        }

        /// <summary>
        /// Configure query order (sql order by)
        /// </summary>
        /// <param name="pResult"></param>
        /// <returns></returns>
        private IQueryable<T> Order(IQueryable<T> pResult)
        {
            if (string.IsNullOrEmpty(this.OrderBy))
            {
                return this.DefaultOrderBy(pResult);
            }

            var lOrderedQuery = pResult;
            var lFields = this.OrderBy.Split('~');
            var lOrderMethodName = "OrderBy";
            foreach (var lMembers in lFields
                .Select(pField => pField.Split('-'))
                /*.Where(pMembers => pMembers.Count() == 2)*/)
            {
                if (lMembers.Last().Equals("desc"))
                {
                    lOrderMethodName += "Descending";
                }

                //gb - Si la valeur est définie
                if (lMembers.First() != "undefined")
                {
                    var lParameter = Expression.Parameter(typeof(T));
                    Type lPropertyType;
                    var lProperty = this.GetPropertyFor(lMembers.First(), lParameter, out lPropertyType);
                    Expression lExpression = Expression.Lambda(lProperty, lParameter);
                    lExpression = Expression.Call(
                        typeof(Queryable),
                        lOrderMethodName,
                        new[] { lOrderedQuery.ElementType, lPropertyType },
                        lOrderedQuery.Expression,
                        lExpression);
                    lOrderedQuery = lOrderedQuery.Provider.CreateQuery<T>(lExpression);
                    lOrderMethodName = "ThenBy";
                }
            }

            return lOrderedQuery;
        }

        private Expression GetPropertyFor(string pRopertyName, Expression pArameter, out Type pRopertyType)
        {
            string[] lProperties;
            string lRelatedProperty;
            if (this.RelatedProperties.TryGetValue(pRopertyName, out lRelatedProperty))
            {
                lProperties = lRelatedProperty.Split('.');
                pRopertyType = lProperties.Aggregate(typeof(T), (pType, pS) => pType.GetProperty(pS).PropertyType);
                return lProperties.Aggregate(pArameter, Expression.Property);
            }

            lProperties = pRopertyName.Split('.');
            var lPropertyInfo = typeof(T).GetProperty(lProperties[0]);
            if (lPropertyInfo != null)
            {
                pRopertyType = lProperties.Aggregate(typeof(T), (pType, pS) => pType.GetProperty(pS).PropertyType);
                return lProperties.Aggregate(pArameter, Expression.Property);
            }

            throw new NotImplementedException(string.Format("You are trying to sort on a property {0} unknown on type {1}. Give additional information through RelatedProperties.", pRopertyName, typeof(T).Name));
        }

        /// <summary>
        /// Include all property needed in aggregate 
        /// </summary>
        /// <param name="pPagedResults"></param>
        /// <param name="pFetchings"></param>
        /// <returns></returns>
        private IQueryable<T> ApplyIncludes(IQueryable<T> pPagedResults, Dictionary<string, Func<IQueryable<T>, Expression<Func<T, object>>, SearchCriteria<T>, IQueryable<T>>> pFetchings)
          {
            
            if (this._includes == null)
            {
                return pPagedResults;
            }
            
            if (pFetchings == null)
            {
                throw new NotImplementedException("Search Criteria was used with Include but no fetchings are given in parameters (see in repository typically).");
            }

            return this._includes.Aggregate(pPagedResults, (current, include) => pFetchings[include.Key](current, include.Value, this));
        }
    }
}
