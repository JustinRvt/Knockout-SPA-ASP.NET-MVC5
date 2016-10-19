using System;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Cause;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace DTOLibrary.Entities.DetailType.Methodes
{
    /// <summary>
    /// Classe de param pour la création d'un type detail DTO
    /// </summary>
    [DebuggerDisplay("User = {User.Login} - ID Ticket = {Ticket.IdTicket} - Detail Type = {DetailType}")]
    [DataContract]
    public class ParamCreationDetailTypeDTO : BaseDTO
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

        private DetailTypeDTO _DetailType;
        /// <summary>
        /// Accesseur du detail type
        /// </summary>
        [DataMember]
        public DetailTypeDTO DetailType
        {
            get { return _DetailType; }
            set { _DetailType = value; }
        }

        #endregion
    }
}
