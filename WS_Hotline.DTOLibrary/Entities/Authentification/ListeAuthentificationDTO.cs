using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.Authentification
{
    /// <summary>
    /// DTO correspondant au liste d'authentification
    /// dans le fichier XML
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-17 - Création</remarks>
    [DataContract]
    public class ListeAuthentificationDTO : BaseDTO
    {
        #region PROPERTIES

        private List<AuthentificationDTO> _ListeAuth = new List<AuthentificationDTO>();
        /// <summary>
        /// Accesseur de la liste des AuthentificationDTO
        /// </summary>
        [DataMember]
        public List<AuthentificationDTO> ListeAuth
        {
            get { return _ListeAuth; }
            set { _ListeAuth = value; }
        }

        #endregion
    }
}
