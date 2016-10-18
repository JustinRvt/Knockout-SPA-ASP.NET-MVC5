using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using WS_Hotline.Framework.Domain.Command;

namespace WS_Hotline.DTOLibrary.Business.Ressource
{
    /// <summary>
    /// Classe DTO permettant de gérer Ressource
    /// </summary>
    /// <remark>ylouis - 19/02/2016 - Généré par snippet v1.0</remark>
    [DataContract]
    public class RessourceDTO : BaseDTO
    {
        #region property

        private string _Nom;
        /// <summary>
        /// Nom de la ressource
        /// </summary>
        /// <remarks>ylouis - 19/02/2016 - Généré par snippet v1.0</remarks>
        [DataMember]
        public string Nom
        {
            get { return _Nom; }
            set
            {
                _Nom = value;
            }
        }

        private string _Value;
        /// <summary>
        /// Valeur de la ressource
        /// </summary>
        /// <remarks>ylouis - 19/02/2016 - Généré par snippet v1.0</remarks>
        [DataMember]
        public string Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
            }
        }

        private string _Culture;
        /// <summary>
        /// Culture de la valeur
        /// </summary>
        /// <remarks>ylouis - 19/02/2016 - Généré par snippet v1.0</remarks>
        [DataMember]
        public string Culture
        {
            get { return _Culture; }
            set
            {
                _Culture = value;
            }
        }

        #endregion

    }
}
