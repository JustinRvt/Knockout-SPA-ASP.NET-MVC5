using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Cause;
using WS_Hotline.DTOLibrary.Entities.DetailType;
using WS_Hotline.DTOLibrary.Entities.KeyWord;
using WS_Hotline.DTOLibrary.Entities.Projet;
using WS_Hotline.DTOLibrary.Entities.Resolution;
using WS_Hotline.DTOLibrary.Entities.Statut;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using WS_Hotline.DTOLibrary.Entities.TimeType;
using WS_Hotline.DTOLibrary.Helper;
using WS_Hotline.DTOLibrary.Entities.TypeStatutProgress;
using System.Diagnostics;
using WS_Hotline.Framework.Domain.Command;

namespace WS_Hotline.DTOLibrary.Entities.Blocage
{
    [DebuggerDisplay("ID Ticket = {CurrentTicket.IdTicket} - ID Cause = {CurrentCause.IdCause} - Libelle Statut = {CurrentStatut.LibelleStatut}")]
    [DataContract]
    public class BlocageDTO : BaseDTO
    {
        #region PROPERTIES

        #region ACCESSEURS

        private TicketDTO _CurrentTicket;
        /// <summary>
        /// Accesseur du ticket en cours
        /// </summary>
        [DataMember]
        public TicketDTO CurrentTicket
        {
            get { return _CurrentTicket; }
            set { _CurrentTicket = value; }
        }

        private CauseDTO _CurrentCause;
        /// <summary>
        /// Accesseur de la cause en cours
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Cause error")]
        public CauseDTO CurrentCause
        {
            get { return _CurrentCause; }
            set
            {
                _CurrentCause = value;
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CurrentCause" });
            }
        }

        private TimeTypeDTO _CurrentTimeType;
        /// <summary>
        /// Accesseur du type de temps en cours
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "TimeType error")]
        public TimeTypeDTO CurrentTimeType
        {
            get { return _CurrentTimeType; }
            set
            {
                _CurrentTimeType = value;
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CurrentTimeType" });
            }
        }

        private ResolutionDTO _CurrentResolution;
        /// <summary>
        /// Accesseur de la resolution en cours
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Resolution error")]
        public ResolutionDTO CurrentResolution
        {
            get { return _CurrentResolution; }
            set
            {
                _CurrentResolution = value;
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CurrentResolution" });
            }
        }

        private StatutDTO _CurrentStatut;
        /// <summary>
        /// Accesseur du statut en cours
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Statut error")]
        public StatutDTO CurrentStatut
        {
            get { return _CurrentStatut; }
            set
            {
                _CurrentStatut = value;
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CurrentStatut" });
            }
        }

        private DateTime _CurrentTimer;
        /// <summary>
        /// Accesseur du timer en cours
        /// </summary>
        [DataMember]
        [DateTimeValidationExo(MessagePeriode = "Le temps doit être compris entre 1min et 8h",
                                             MessageConversion = "Mauvais format")]
        public DateTime CurrentTimer
        {
            get { return _CurrentTimer; }
            set
            {
                _CurrentTimer = value;
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CurrentTimer" });
            }
        }

        private KeyWordDTO _CurrentKeyWord;
        /// <summary>
        /// Accesseur du mot clé en cours
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Key Word Error")]
        public KeyWordDTO CurrentKeyWord
        {
            get { return _CurrentKeyWord; }
            set
            {
                _CurrentKeyWord = value;
                //Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CurrentKeyWord" });
            }
        }

        private DetailTypeDTO _CurrentDetailType;
        /// <summary>
        /// Accesseur du type de détail en cours
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Detail Type Error")]
        public DetailTypeDTO CurrentDetailType
        {
            get { return _CurrentDetailType; }
            set
            {
                _CurrentDetailType = value;
                //Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CurrentDetailType" });
            }
        }

        private ProjetDTO _CurrentProjet;
        /// <summary>
        /// Accesseur du projet concerné en cours
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Projet Error")]
        public ProjetDTO CurrentProjet
        {
            get { return _CurrentProjet; }
            set
            {
                _CurrentProjet = value;
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CurrentProjet" });
            }
        }

        private string _CurrentClarte;
        /// <summary>
        /// Accesseur de la clarté en cours
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Clarte Error")]
        public string CurrentClarte
        {
            get { return _CurrentClarte; }
            set
            {
                _CurrentClarte = value;
                //Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CurrentClarte" });
            }
        }

        private StatutProgressDTO _StatutProgress;
        /// <summary>
        /// Accesseur du statut progress
        /// </summary>
        [Required(ErrorMessage = "Statut error")]
        public StatutProgressDTO StatutProgress
        {
            get { return _StatutProgress; }
            set
            {
                _StatutProgress = value;
            }
        }


        #endregion

        #region PUBLICS VARIABLES


        #endregion

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Jclaud 2015-03-10 - Création</remarks>
        public BlocageDTO()
        {

        }

        #endregion

        #region MTDHS

        /// <summary>
        /// Méthode permettant de valider le DTO
        /// Si il y a une erreur, une exception est levée
        /// </summary>
        /// <remarks>JClaud 2015-04-08 - Création</remarks>
        public override void ValidationDTO()
        {
            //jc - Appel les méthodes de validation des DTO
            base.ValidationDTO();
            this.CurrentTicket.ValidationDTO();
            Validator.ValidateProperty(this.CurrentStatut, new ValidationContext(this, null, null) { MemberName = "CurrentStatut" });
            Validator.ValidateProperty(this.CurrentResolution, new ValidationContext(this, null, null) { MemberName = "CurrentResolution" });
            Validator.ValidateProperty(this.CurrentTimeType, new ValidationContext(this, null, null) { MemberName = "CurrentTimeType" });

            //jc- on ne gère la validation des data que si le projet est 'Support ACA' - ProjectId = 101
            if (this.CurrentTicket.Projet.IdProjet == 101)
            {
                //jc-on ne gère la validation pour la cause que si le type du ticket de hotline est 'Dev (bug' ou 'Réseau (problème)'
                if (this.CurrentTicket.Type.IdType == 76 || this.CurrentTicket.Type.IdType == 94)
                {
                    //tbh - Si la résolution sélectionné par l'utilisateur sont terminé/fait
                    if ((CurrentResolution.IdResolution == StatutProgress.Resolution.IdResolution) /*&& (CurrentStatut.IdStatut == StatutProgress.Statut.IdStatut)*/)
                    {
                        Validator.ValidateProperty(this.CurrentCause, new ValidationContext(this, null, null) { MemberName = "CurrentCause" });
                    }
                }
                Validator.ValidateProperty(this.CurrentProjet, new ValidationContext(this, null, null) { MemberName = "CurrentProjet" });
            }

            Validator.ValidateProperty(this.CurrentTimer, new ValidationContext(this, null, null) { MemberName = "CurrentTimer" });
        }

        #endregion

        #region ENUM METHODES

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {
        }

        #endregion
    }
}
