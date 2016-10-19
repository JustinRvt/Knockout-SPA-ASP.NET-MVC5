using System;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Projet;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace DTOLibrary.Entities.Composant.Methodes
{
    [DebuggerDisplay("User = {User.Login} - ID Ticket = {Ticket.IdTicket} - Nom Composant = {Composant.NomComposant}")]
    [DataContract]
    public class ParamCreationComposantDTO : BaseDTO
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
        /// Accesseur du ticket
        /// </summary>
        [DataMember]
        public TicketDTO Ticket
        {
            get { return _Ticket; }
            set { _Ticket = value; }
        }

        private ComposantDTO _Composant;
        /// <summary>
        /// Accesseur du composant
        /// </summary>
        [DataMember]
        public ComposantDTO Composant
        {
            get { return _Composant; }
            set { _Composant = value; }
        }

        #endregion

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {
            /// <summary>
            /// <para>Description : Fonction permettant de retourner la liste des composants</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamCreationComposantDTO</para>
            /// </summary>
            GetListeComposant
        }
    }
}
