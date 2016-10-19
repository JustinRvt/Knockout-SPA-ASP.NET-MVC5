using WS_Hotline.DTOLibrary.Entities.Authentification;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.Ticket.Methodes
{
    /// <summary>
    /// Classe de param pour la gestion de la création de tickets
    /// </summary>
    /// <remarks>JClaud 2015-03-20 Création</remarks>
    [DebuggerDisplay("User = {User.Login} - ID Ticket = {Ticket.IdTicket} - OldTicket = {OldTicket.NomTicket}")]
    [DataContract]
    public class ParamCreationTicketDTO : BaseDTO
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

        private TicketDTO _OldTicket;
        /// <summary>
        /// Accesseur de l'ancien ticket en cours de traitement
        /// </summary>
        [DataMember]
        public TicketDTO OldTicket
        {
            get { return _OldTicket; }
            set { _OldTicket = value; }
        }

        #endregion
    }
}
