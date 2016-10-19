using System;
using System.Linq;
using System.Runtime.Serialization;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.KeyWord;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.TimeGemAcces.Méthodes
{
    /// <summary>
    /// Classe de gestion pour la création des TimeGemAccesDTO
    /// </summary>
    /// <remarks>JClaud 2016-01-12 Création</remarks>
    [DebuggerDisplay("User = {User.Login} - ID Ticket = {Ticket.IdTicket} - Gestion Acces = {GestionAcces}")]
    [DataContract]
    public class ParamCreationHTimeGemAccesDTO : BaseDTO
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

        private TimeGemAccesDTO _GestionAcces;
        /// <summary>
        /// Accesseur de la gestion des accès
        /// </summary>
        [DataMember]
        public TimeGemAccesDTO GestionAcces
        {
            get { return _GestionAcces; }
            set { _GestionAcces = value; }
        }

        #endregion
    }
}
