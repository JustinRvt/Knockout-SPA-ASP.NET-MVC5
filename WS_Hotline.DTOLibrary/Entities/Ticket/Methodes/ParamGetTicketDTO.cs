using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Projet;
using WS_Hotline.DTOLibrary.Entities.Statut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.Ticket.Methodes
{
    /// <summary>
    /// Classe contenant les paramètres nécessaires
    /// pour la récupération des tickets
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-20 - Création</remarks>
    [DataContract]
    public class ParamGetTicketDTO : BaseDTO
    {
        #region PROPERTIES

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

        private CritereTicketDTO _CritereTicket;
        /// <summary>
        /// Accesseur de la classe de critère pour les tickets
        /// </summary>
        [DataMember]
        public CritereTicketDTO CritereTicket
        {
            get { return _CritereTicket; }
            set { _CritereTicket = value; }
        }

        private CritereStatutDTO _CritereStatut;
        /// <summary>
        /// Accesseur de la classe de critere pour les statuts
        /// </summary>
        [DataMember]
        public CritereStatutDTO CritereStatut
        {
            get { return _CritereStatut; }
            set { _CritereStatut = value; }
        }

        private CritereProjetDTO _CritereProjet;
        /// <summary>
        /// Accesseur de la classe de critère pour les projets
        /// </summary>
        [DataMember]
        public CritereProjetDTO CritereProjet
        {
            get { return _CritereProjet; }
            set { _CritereProjet = value; }
        }

        #endregion
    }
}
