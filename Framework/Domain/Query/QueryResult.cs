using System.Collections.Generic;
using System.Linq;

namespace WS_Hotline.Framework.Domain.Query
{
    /// <summary>
    /// Template query result from database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryResult<T>
    {
        /// <summary>
        /// Intiation query result from query
        /// </summary>
        /// <param name="pList"></param>
        /// <param name="pFilteredItems"></param>
        public QueryResult(IQueryable<T> pList, IQueryable<T> pFilteredItems)
        {
            this.FilteredItems = pFilteredItems;
            this.List = pList.ToList();
            if (pFilteredItems == null)
            {
                this.Total = this.List.Count();
            }
            else
            {
                this.Total = pFilteredItems.Count();
            }
            
        }

        /// <summary>
        /// All item not filtered
        /// </summary>
        public IEnumerable<T> List
        {
            get;
            private set;
        }

        /// <summary>
        /// Total of item filtered
        /// </summary>
        public int Total
        {
            get;
            private set;
        }

        /// <summary>
        /// All item filtered
        /// </summary>
        public IQueryable<T> FilteredItems
        {
            get;
            set;
        }
    }
}
