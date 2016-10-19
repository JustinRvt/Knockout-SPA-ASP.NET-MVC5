using System;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Commentaire;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace DTOLibrary.Entities.TicketLien.Méthodes
{
    [DebuggerDisplay("User = {User.Login} - ID Ticket = {Ticket.IdTicket}")]
    [DataContract]
    public class ParamCreationTicketLienDTO : BaseDTO
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

        private TicketDTO _Ticket;
        /// <summary>
        /// Accesseur du critère pour le ticket
        /// </summary>
        [DataMember]
        public TicketDTO Ticket
        {
            get { return _Ticket; }
            set { _Ticket = value; }
        }

        private TicketLienDTO _TicketLien;
        /// <summary>
        /// Accesseur du critère pour le lien du ticket
        /// </summary>
        [DataMember]
        public TicketLienDTO TicketLien
        {
            get { return _TicketLien; }
            set { _TicketLien = value; }
        }

        #endregion
    }
}
