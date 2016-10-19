using System;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace DTOLibrary.Entities.Version
{
    //jc- classe de critère pour VersionDTO
    [DebuggerDisplay("ID Version = IdVersion - ID Projet = {IdProjet} - Nom de Version = {VersionName} - Numéro de version = {VersionNumber}")]
    [DataContract]
    public class CritereVersionDTO : CritereBaseDTO
    {
        #region PROPERTIES

        private int _IdVersion;
        /// <summary>
        /// Accesseur de l'id de la version
        /// </summary>
        [DataMember]
        public int IdVersion
        {
            get { return _IdVersion; }
            set { _IdVersion = value; }
        }

        private int _IdProjet;
        /// <summary>
        /// Accesseur de l'id du projet
        /// </summary>
        [DataMember]
        public int IdProjet
        {
            get { return _IdProjet; }
            set { _IdProjet = value; }
        }

        private string _VersionName;
        /// <summary>
        /// Accesseur VersionName
        /// </summary>
        [DataMember]
        public string VersionName
        {
            get { return _VersionName; }
            set { _VersionName = value; }
        }

        private string _VersionNumber;
        /// <summary>
        /// Accesseur VersionNumber
        /// </summary>
        [DataMember]
        public string VersionNumber
        {
            get { return _VersionNumber; }
            set { _VersionNumber = value; }
        }

        private string _VersionDescr;
        /// <summary>
        /// Accesseur VersionDescr
        /// </summary>
        [DataMember]
        public string VersionDescr
        {
            get { return _VersionDescr; }
            set { _VersionDescr = value; }
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
        #endregion
    }
}
