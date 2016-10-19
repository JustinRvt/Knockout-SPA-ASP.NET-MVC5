using System;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using System.Diagnostics;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.Ticket.Methodes
{
    /// <summary>
    /// Classe de param pour la gestion de la création de clarté tickets
    /// </summary>
    /// <remarks>JClaud 2015-07-28 Création</remarks>
    [DebuggerDisplay("User = {User.Login} - ID Ticket = {Ticket.IdTicket} - Clarte = {Clarte}")]
    [DataContract]
    public class ParamCreationClarteDTO : BaseDTO
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

        private int? _Clarte;
        /// <summary>
        /// Accesseur de l'ancien ticket en cours de traitement
        /// </summary>
        [DataMember]
        public int? Clarte
        {
            get { return _Clarte; }
            set { _Clarte = value; }
        }

        #endregion
    }
}
