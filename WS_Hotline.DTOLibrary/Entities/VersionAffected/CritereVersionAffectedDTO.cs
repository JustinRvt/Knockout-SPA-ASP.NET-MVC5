using System;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace DTOLibrary.Entities.Version
{
    //jc- classe de critère pour VersionAffectedDTO
    [DebuggerDisplay("ID AffectedVersion = {IdAffectedVersion} - ID Issue = {IdIssue} - ID Version = {IdVersion}")]
    [DataContract]
    public class CritereVersionAffectedDTO : CritereBaseDTO
    {
        private int _IdAffectedVersion;
        /// <summary>
        /// Accesseur IdAffectedVersion
        /// </summary>
        [DataMember]
        public int IdAffectedVersion
        {
            get { return _IdAffectedVersion; }
            set { _IdAffectedVersion = value; }
        }

        private int _IdIssue;
        /// <summary>
        /// Accesseur IdIssue
        /// </summary>
        [DataMember]
        public int IdIssue
        {
            get { return _IdIssue; }
            set { _IdIssue = value; }
        }

        private int _IdVersion;
        /// <summary>
        /// Accesseur IdVersion
        /// </summary>
        [DataMember]
        public int IdVersion
        {
            get { return _IdVersion; }
            set { _IdVersion = value; }
        }

        private DateTime _Created;
        /// <summary>
        /// Accesseur Created
        /// </summary>
        [DataMember]
        public DateTime Created
        {
            get { return _Created; }
            set { _Created = value; }
        }

        private AuthentificationDTO _User;
        /// <summary>
        /// Accesseur de l'utilisateur en cours
        /// </summary>
        [DataMember]
        public AuthentificationDTO User
        {
            get { return _User; }
            set { _User = value; }
        }

        private TicketDTO _Ticket;
        /// <summary>
        /// Accesseur du ticket en cours
        /// </summary>
        [DataMember]
        public TicketDTO Ticket
        {
            get { return _Ticket; }
            set { _Ticket = value; }
        }
    }
}
