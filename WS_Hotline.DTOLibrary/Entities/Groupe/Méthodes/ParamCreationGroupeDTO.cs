using System;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Cause;
using WS_Hotline.DTOLibrary.Entities.Groupe;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.Groupes.Méthodes
{
    /// <summary>
    /// Classe de gestion pour la création des groupes
    /// </summary>
    [DebuggerDisplay("User = {User.Login} - ID Ticket = {Ticket.IdTicket} - Groupe = {Groupe}")]
    [DataContract]
    public class ParamCreationGroupeDTO : BaseDTO
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

        private GroupeDTO _Groupe;
        /// <summary>
        /// Accesseur du groupe
        /// </summary>
        [DataMember]
        public GroupeDTO Groupe
        {
            get { return _Groupe; }
            set { _Groupe = value; }
        }

        #endregion

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {
            /// <summary>
            /// <para>Description : Fonction permettant de retourner la liste des groupes</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamCreationGroupeDTO</para>
            /// </summary>
            GetGroupes
        }
    }
}
