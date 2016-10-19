using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DTOLibrary.Entities.TimeTracking
{
    /// <summary>
    /// Classe de DTO pour la gestion des TimeTracking dans Gemini
    /// </summary>
    /// <remarks>JClaud 2015-03-19 Création</remarks>
    [DebuggerDisplay("ID du TimeTracking = {IdTimeTracking} - ID Projet = {IdProjet} - ID User = {UtilisateurId}")]
   [DataContract]
   public class TimeTrackingDTO : BaseDTO
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

        #endregion

        #region CTORS

        /// <summary>
        /// Constructeur vide pour le timeTracking
        /// </summary>
        /// <remarks>JClaud 2015-04-09 Création</remarks>
        public TimeTrackingDTO()
        {

        }

        #endregion 

        #region ENUM METHODES

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {
            /// <summary>
            /// <para>Description : Fonction permettant de créer un nouveau Time Tracking pour le ticket en cours</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamTimeTrackingDTO</para>
            /// </summary>
            CreateTimeTracking,
            /// <summary>
            /// <para>Description : Fonction permettant de retourner le temps total loggé pour un utilisateur et une date</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamTotalLoggedDTO</para>
            /// </summary>
            GetTotalLogged
        }

        #endregion
    }
}
