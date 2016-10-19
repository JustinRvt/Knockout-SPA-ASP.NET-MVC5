using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using System.Diagnostics;

namespace DTOLibrary.Entities.Resolution.Methodes
{
    /// <summary>
    /// Classe contenant les paramètres nécessaires
    /// pour mettre à jour les informations générales d'un ticket
    /// </summary>
    /// <remarks>JClaud 2015-03-10 - Création</remarks>
    [DebuggerDisplay("User = {User.Login} - ID Critere Ticket = {CritereTicket.IdTicket} - ID Resolution = {Resolution.IdResolution}")]
     [DataContract]
    public class ParamResolutionDTO : BaseDTO
    {
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

        private ResolutionDTO _Resolution;
        /// <summary>
        /// Accesseur de la resolution choisie
        /// </summary>
        [DataMember]
        public ResolutionDTO Resolution
        {
            get { return _Resolution; }
            set { _Resolution = value; }
        }
    }
}
