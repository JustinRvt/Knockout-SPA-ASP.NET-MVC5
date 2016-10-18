using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DTOLibrary.Entities.Customer
{
    /// <summary>
    /// Classe de critère pour NomDTO
    /// </summary>
    /// <remark>[jravat] - [30092016] - Généré par snippet v1.0</remark>
    public class CritereCustomerDTO : CritereBaseDTO<CustomerDTO>
    {
        #region property

        private string _CustomerLastName;
        /// <summary>
        /// Filtre sur MonElementFiltre
        /// </summary>
        /// <remark>[jravat] - [30092016] - Généré par snippet v1.0</remark>
        [DataMember]
        public string CustomerLastName
        {
            get { return _CustomerLastName; }
            set
            {
                _CustomerLastName = value;
                // [Initiale] - Mise en place du filtre
                if (_CustomerLastName != null)
                    this.Filters["Nom"] = p => p.CustomerLastName.StartsWith(value);
            }
        }
        #endregion

        #region Liaison

        #endregion
    }
}
