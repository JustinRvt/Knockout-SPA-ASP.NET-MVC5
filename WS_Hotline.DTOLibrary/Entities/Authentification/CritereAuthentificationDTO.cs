using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.Authentification
{
    /// <summary>
    /// Classe de critères pour les DTO de type Authentification
    /// </summary>
    /// <remarks>JClaud 2015-11-12 Création</remarks>
    [DebuggerDisplay("Authentification = {AuthentificationDTO.Login}")]
    [DataContract]
    public class CritereAuthentificationDTO : CritereBaseDTO
    {
        private AuthentificationDTO _AuthentificationDTO;
        /// <summary>
        /// Accesseur de l'authentificationDTO en cours
        /// </summary>
        [DataMember]
        public AuthentificationDTO AuthentificationDTO
        {
            get { return _AuthentificationDTO; }
            set { _AuthentificationDTO = value; }
        }
    }
}
