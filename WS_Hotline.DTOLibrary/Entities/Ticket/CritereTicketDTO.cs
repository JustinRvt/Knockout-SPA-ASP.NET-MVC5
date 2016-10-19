using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.Projet;
using WS_Hotline.DTOLibrary.Entities.Statut;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WS_Hotline.DTOLibrary.Entities.Ticket
{
    /// <summary>
    /// Classe de critère pour TicketDTO
    /// </summary>
    [DebuggerDisplay("ID Ticket = {IdTicket} - User = {User.Login} - Date du Traitement = {DateTraitement}")]
    [DataContract]
    public class CritereTicketDTO : CritereBaseDTO
    {
        #region PROPERTIES

        private string _IdTicket;
        /// <summary>
        /// Accesseur du champ IdTicket
        /// </summary>
        [DataMember]
        public string IdTicket
        {
            get { return _IdTicket; }
            set { _IdTicket = value; }
        }

        private DateTime? _DateTraitement;
        /// <summary>
        /// Accesseur de la date de traitement
        /// </summary>
        [DataMember]
        public DateTime? DateTraitement
        {
            get { return _DateTraitement; }
            set { _DateTraitement = value; }
        }

        private string _DescriptionTicket;
        /// <summary>
        /// Accesseur de la description du ticket
        /// </summary>
        [DataMember]
        public string DescriptionTicket
        {
            get { return _DescriptionTicket; }
            set { _DescriptionTicket = value; }
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

        private bool _AffichageQuestion;
        /// <summary>
        /// Accesseur de la classe de critère affichage question
        /// </summary>
        [DataMember]
        public bool AffichageQuestion
        {
            get { return _AffichageQuestion; }
            set { _AffichageQuestion = value; }
        }

        private List<string> _RestrictionTemplates;
        /// <summary>
        /// Accesseur des restrictions sur les templates 
        /// </summary>
        [DataMember]
        public List<string> RestrictionTemplates
        {
            get { return _RestrictionTemplates; }
            set { _RestrictionTemplates = value; }
        }

        #endregion
    }
}
