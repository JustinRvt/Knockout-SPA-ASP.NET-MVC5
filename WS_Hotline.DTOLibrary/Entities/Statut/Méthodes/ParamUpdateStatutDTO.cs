using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.Framework.Domain.Command;


namespace WS_Hotline.DTOLibrary.Entities.Statut.Méthodes
{
    /// <summary>
    /// Classe contenant les paramètres nécessaires
    /// pour mettre à jour le statut d'un ticket sur Gemini
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
    [DebuggerDisplay("User = {User.login} - Libelle Statut = {Statut.LibelleStatut} - ID CritereTicket = {CriteteTicket.IdTicket}")]
    [DataContract]
    public class ParamUpdateStatutDTO : BaseDTO
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

        private StatutDTO _Statut;
        /// <summary>
        /// Accesseur du nouveau statut
        /// </summary>
        [DataMember]
        public StatutDTO Statut
        {
            get { return _Statut; }
            set { _Statut = value; }
        }

        private CritereTicketDTO _CriteteTicket;
        /// <summary>
        /// Accesseur du critère pour le ticket
        /// </summary>
        [DataMember]
        public CritereTicketDTO CriteteTicket
        {
            get { return _CriteteTicket; }
            set { _CriteteTicket = value; }
        }

        #endregion
    }
}
