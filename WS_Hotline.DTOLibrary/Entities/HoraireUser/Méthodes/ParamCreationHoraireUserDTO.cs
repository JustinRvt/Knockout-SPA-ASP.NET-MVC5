using System;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.HoraireJour;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace DTOLibrary.Entities.HoraireUser.Méthodes
{
    /// <summary>
    /// Classe de gestion pour la création des HorairesUserDTO
    /// </summary>
    /// <remarks>JClaud 2015-08-04 Création</remarks>
    [DebuggerDisplay("User = {User.Login} - ID Ticket = {Ticket.IdTicket} - Horaire User = {HoraireUser.Id}")]
    [DataContract]
    public class ParamCreationHoraireUserDTO : BaseDTO
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

        private HoraireUserDTO _HoraireUser;
        /// <summary>
        /// Accesseur de l'horaire user
        /// </summary>
        [DataMember]
        public HoraireUserDTO HoraireUser
        {
            get { return _HoraireUser; }
            set { _HoraireUser = value; }
        }

        #endregion
    }
}
