using System.Collections.Generic;
using WS_Hotline.Framework.Domain.Query;

namespace WS_Hotline.Framework.AccesDonnees
{
    /// <summary>
    /// Interface for repostirory template
    /// </summary>
    /// <returns>Paged result</returns>
    public interface IRepository<T>
    {
        /// <summary>
        /// Get items corresponding to the given <see cref="SearchCriteria{T}"/>.
        /// </summary>
        /// <param name="pSearchCriteria">Criteria (including sort and paging)</param>
        /// <returns>Paged result</returns>
        QueryResult<T> GetItems(SearchCriteria<T> pSearchCriteria = null);

        /// <summary>
        /// Get single item corresponding to the given <see cref="SearchCriteria{T}"/>.
        /// </summary>
        /// <param name="pSearchCriteria">Criteria that should target only one Domain Object</param>
        /// <returns>Single item</returns>
        T GetItem(SearchCriteria<T> pSearchCriteria);

        /// <summary>
        /// Get single item based on its unique key (code).
        /// </summary>
        /// <param name="pEntityCode">Unique key</param>
        /// <returns>Single object with <see cref="pEntityCode"/></returns>
        T GetItem(string pEntityCode);

        /// <summary>
        /// Add single item to DB
        /// </summary>
        /// <param name="pEntity">Unique key</param>
        T AddItem(T pEntity);

        /// <summary>
        /// Add many item to DB
        /// </summary>
        /// <param name="pEntities">Unique key</param>
        void AddItems(IEnumerable<T> pEntities);


        /// <summary>
        /// update single item to DB
        /// </summary>
        /// <param name="pEntity">Unique key</param>
        void UpdateItem(T pEntity);


        /// <summary>
        /// Update many item to DB
        /// </summary>
        /// <param name="pEntities">Unique key</param>
        void UpdateItems(IEnumerable<T> pEntities);

        /// <summary>
        /// Remove many item to DB
        /// </summary>
        /// <param name="pSearchCriteria">Unique key</param>
        void RemoveItems(SearchCriteria<T> pSearchCriteria);
    }
}