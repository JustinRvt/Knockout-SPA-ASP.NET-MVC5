using System;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.KeyWord;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.HoraireJour.Méthodes
{
    /// <summary>
    /// Classe de gestion pour la création des horairesJourDTO
    /// </summary>
    /// <remarks>JClaud 2015-08-04 Création</remarks>
    [DebuggerDisplay("User = {User.login} - ID Ticket = {Ticket.IdTicket} - Horaire jour = {HoraireJour}")]
    [DataContract]
    public  class ParamCreationHoraireJourDTO : BaseDTO
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

        private HoraireJourDTO _HoraireJour;
        /// <summary>
        /// Accesseur de l'horaire jour
        /// </summary>
        [DataMember]
        public HoraireJourDTO HoraireJour
        {
            get { return _HoraireJour; }
            set { _HoraireJour = value; }
        }

        #endregion
    }
}
