using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using System.Diagnostics;

namespace DTOLibrary.Entities.TimeTracking
{
    /// <summary>
    /// Classe de critère pour TimeTrackingDTO
    /// </summary>
    /// <remarks>JClaud 2015-03-19 Création</remarks>
    [DebuggerDisplay("ID du TimeTracking = {IdTimeTracking} - ID Projet = {IdProjet} - ID User = {UtilisateurId}")]
    [DataContract]
    public class CritereTimeTrackingDTO : CritereBaseDTO
    {
        #region PROPERTIES

        private int _IdTimeTracking;
        /// <summary>
        /// Accesseur de l'id du timetracking
        /// </summary>
        [DataMember]
        public int IdTimeTracking
        {
            get { return _IdTimeTracking; }
            set { _IdTimeTracking = value; }
        }

        private int _IdProjet;
        /// <summary>
        /// Accesseur de l'id du projet lié
        /// </summary>
        [DataMember]
        public int IdProjet
        {
            get { return _IdProjet; }
            set { _IdProjet = value; }
        }

        private int _TicketId;
        /// <summary>
        /// Accesseur de l'id du ticket lié
        /// </summary>
        [DataMember]
        public int TicketId
        {
            get { return _TicketId; }
            set { _TicketId = value; }
        }

        private int _UtilisateurId;
        /// <summary>
        /// Accesseur de l'id de l'utilisateur lié
        /// </summary>
        [DataMember]
        public int UtilisateurId
        {
            get { return _UtilisateurId; }
            set { _UtilisateurId = value; }
        }

        private int _TimeTypeId;
        /// <summary>
        /// Accesseur de l'id du time type lié
        /// </summary>
        [DataMember]
        public int TimeTypeId
        {
            get { return _TimeTypeId; }
            set { _TimeTypeId = value; }
        }

        private int _Heures;
        /// <summary>
        /// Accesseur du nombre d'heures saisies
        /// </summary>
        [DataMember]
        public int Heures
        {
            get { return _Heures; }
            set { _Heures = value; }
        }

        private int _Minutes;
        /// <summary>
        /// Accesseur du nombre de Minutes saisies
        /// </summary>
        [DataMember]
        public int Minutes
        {
            get { return _Minutes; }
            set { _Minutes = value; }
        }

        private string _CommentaireTimeTracking;
        /// <summary>
        /// Accesseur du commentaire du timeTracking
        /// </summary>
        [DataMember]
        public string CommentaireTimeTracking
        {
            get { return _CommentaireTimeTracking; }
            set { _CommentaireTimeTracking = value; }
        }

        private DateTime _DateSaisieTT_Ticket;
        /// <summary>
        /// Accesseur de la date de saisie du temps sur le ticket
        /// </summary>
        [DataMember]
        public DateTime DateSaisieTT_Ticket
        {
            get { return _DateSaisieTT_Ticket; }
            set { _DateSaisieTT_Ticket = value; }
        }

        private DateTime _DateAjoutTT_BDD;
        /// <summary>
        /// Accesseur de la date de création du timeTracking en BDD
        /// </summary>
        [DataMember]
        public DateTime DateAjoutTT_BDD
        {
            get { return _DateAjoutTT_BDD; }
            set { _DateAjoutTT_BDD = value; }
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

        #endregion
    }
}
