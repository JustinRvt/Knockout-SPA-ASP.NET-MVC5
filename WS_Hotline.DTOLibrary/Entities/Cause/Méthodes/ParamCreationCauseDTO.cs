using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.Cause.Méthodes
{
    /// <summary>
    /// Classe de paramètre pour la création d'une cause
    /// </summary>
    /// <remarks>JClaud 2015-03-20 Création</remarks>
    [DebuggerDisplay("User = {User.Login} - Nom Ticket = {Ticket.NomTicket} - Nom Cause = {Cause.NomCause}")]
    [DataContract]
    public class ParamCreationCauseDTO : BaseDTO
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

        private CauseDTO _Cause;
        /// <summary>
        /// Accesseur de la cause
        /// </summary>
        [DataMember]
        public CauseDTO Cause
        {
            get { return _Cause; }
            set { _Cause = value; }
        }

        #endregion
    }
}
