using System;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Cause;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace DTOLibrary.Entities.Version.Methodes
{
    /// <summary>
    /// Classe de paramètre pour la création d'une version
    /// </summary>
    /// <remarks>JClaud 2015-03-20 Création</remarks>
    [DebuggerDisplay("User = {User.Login} - ID Ticket = {Ticket.IdTicket} - Nom Version = {Version.VersionName}")]
    [DataContract]
    public class ParamCreationVersionDTO : BaseDTO
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

        private VersionDTO _Version;
        /// <summary>
        /// Accesseur de la Version
        /// </summary>
        [DataMember]
        public VersionDTO Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        #endregion

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {
            /// <summary>
            /// <para>Description : Fonction permettant de retourner la liste des versions</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamCreationVersionDTO</para>
            /// </summary>
            GetListeVersion
        }
    }
}
