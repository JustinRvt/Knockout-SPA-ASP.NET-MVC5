using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DTOLibrary.Business.Ressource
{
    /// <summary>
    /// Classe de critère pour RessourceDTO
    /// </summary>
    /// <remarks>ylouis - 19/02/2016 - Généré par snippet v1.0</remarks>
    [DataContract]
    public class CritereRessourceDTO : CritereBaseDTO<RessourceDTO>
    {
        #region property

        private ICollection<string> _ListNomRessource;
        /// <summary>
        /// Filtre sur le nom de la ressource
        /// </summary>
        /// <remarks>ylouis - 19/02/2016 - Généré par snippet v1.0</remarks>
        [DataMember]
        public ICollection<string> ListNomRessource
        {
            get { return _ListNomRessource; }
            set
            {
                _ListNomRessource = value;
            }
        }

        private string _Culture;
        /// <summary>
        /// Filtre sur culture
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
