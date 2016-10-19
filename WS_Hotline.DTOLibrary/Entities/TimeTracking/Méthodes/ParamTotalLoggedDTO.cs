using WS_Hotline.DTOLibrary.Entities.Authentification;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.TimeTracking.Méthodes
{
    /// <summary>
    /// Classe contenant les paramètres nécessaires pour récupérer le temps
    /// total loggés en minute pour un utilisateur et une date
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-06-08 - Création</remarks>
    [DebuggerDisplay("User = {User.Login} - Date à utiliser = {DateLogged}")]
    [DataContract]
    public class ParamTotalLoggedDTO : BaseDTO
    {
        #region PROPERTIES

        private AuthentificationDTO _User;
        /// <summary>
        /// Accesseur de l'utilisateur
        /// </summary>
        [DataMember]
        public AuthentificationDTO User
        {
            get { return _User; }
            set { _User = value; }
        }

        private DateTime _DateLogged;
        /// <summary>
        /// Accesseur de la date à utiliser
        /// </summary>
        [DataMember]
        public DateTime DateLogged
        {
            get { return _DateLogged; }
            set { _DateLogged = value; }
        }

        #endregion
    }
}
