using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using WS_Hotline.DTOLibrary.Entities.TimeType;
using System.Diagnostics;

namespace DTOLibrary.Entities.TimeTracking.Méthodes
{
    /// <summary>
    /// Classe contenant les paramètres nécessaires pour les MAJ et création de Time Tracking
    /// </summary>
    /// <remarks>JClaud 2015-03-19 - Création</remarks>
    [DebuggerDisplay("User = {User.Login} - ID Ticket = {Ticket.IdTicket} - ID TimeType = {TimeType.IdTimeType}")]
    [DataContract]
    public class ParamTimeTrackingDTO : BaseDTO
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

        private AuthentificationDTO _UserCreation;
        /// <summary>
        /// Accesseur de l'utilisateur pour l'authentification en base
        /// </summary>
        [DataMember]
        public AuthentificationDTO UserCreation
        {
            get { return _UserCreation; }
            set { _UserCreation = value; }
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

        private TimeTypeDTO _TimeType;
        /// <summary>
        /// Accesseur du time type
        /// </summary>
        [DataMember]
        public TimeTypeDTO TimeType
        {
            get { return _TimeType; }
            set { _TimeType = value; }
        }

        private TimeTrackingDTO _TimeTracking;
        /// <summary>
        /// Accesseur du time tracking
        /// </summary>
        [DataMember]
        public TimeTrackingDTO TimeTracking
        {
            get { return _TimeTracking; }
            set { _TimeTracking = value; }
        }

        #endregion
    }
}
