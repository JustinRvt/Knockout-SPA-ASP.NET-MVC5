using System;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Cause;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace WS_Hotline.DTOLibrary.Entities.Version.Methodes
{
    /// <summary>
    /// Classe de paramètre pour la création d'une version affected
    /// </summary>
    /// <remarks>JClaud 2015-03-20 Création</remarks>
    [DebuggerDisplay("User = {User.Login} - ID Ticket = {Ticket.IdTicket} - VersionAffected = {VersionAffected.IdAffectedVersion}")]
    [DataContract]
    public class ParamCreationVersionAffectedDTO : BaseDTO
    {
        #region ATTRIBUTS

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

        private TicketDTO _Ticket;
        /// <summary>
        /// Accesseur du ticket
        /// </summary>
        [DataMember]
        public TicketDTO Ticket
        {
            get { return _Ticket; }
            set { _Ticket = value; }
        }

        private VersionAffectedDTO _VersionAffected;
        /// <summary>
        /// Accesseur de la VersionAffected
        /// </summary>
        [DataMember]
        public VersionAffectedDTO VersionAffected
        {
            get { return _VersionAffected; }
            set { _VersionAffected = value; }
        }

        #endregion
    }
}
