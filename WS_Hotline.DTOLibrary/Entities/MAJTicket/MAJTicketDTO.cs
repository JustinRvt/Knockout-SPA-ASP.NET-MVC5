using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Raison;
using WS_Hotline.DTOLibrary.Entities.Ticket;
using WS_Hotline.DTOLibrary.Entities.Client;
using WS_Hotline.DTOLibrary.Entities.Version;
using WS_Hotline.DTOLibrary.Entities.TimeType;
using System.Diagnostics;

namespace DTOLibrary.Entities.MAJTicket
{
    [DebuggerDisplay("ID CurrentTicket = {CurrentTicket.IdTicket} - Titre CurrentRaison = {CurrentRaison.TitreRaison} - Identifiant CurrentClient = {CurrentClient.Identifiant}")]
    [DataContract]
    public class MAJTicketDTO : BaseDTO
    {
        #region PROPERTIES

        #region ACCESSEURS

        private TicketDTO _CurrentTicket;
        /// <summary>
        /// Accesseur du ticket en cours
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Ticket error")]
        public TicketDTO CurrentTicket
        {
            get { return _CurrentTicket; }
            set
            {
                _CurrentTicket = value;
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CurrentTicket" });
            }
        }

        private RaisonDTO _CurrentRaison;
        /// <summary>
        /// Accesseur de  la raison en cours
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Raison error")]
        public RaisonDTO CurrentRaison
        {
            get { return _CurrentRaison; }
            set
            {
                _CurrentRaison = value;
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CurrentRaison" });
            }
        }

        private ClientDTO _CurrentClient;
        /// <summary>
        /// Accesseur du client en cours
        /// </summary>
        [DataMember]
        public ClientDTO CurrentClient
        {
            get { return _CurrentClient; }
            set
            {
                _CurrentClient = value;
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CurrentClient" });
            }
        }

        private VersionDTO _CurrentVersion;
        /// <summary>
        /// Accesseur CurrentVersion
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Version error")]
        public VersionDTO CurrentVersion
        {
            get { return _CurrentVersion; }
            set
            {
                _CurrentVersion = value;
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CurrentVersion" });
            }
        }

        private string _NbMinutesSaisies = "";
        /// <summary>
        /// Accesseur du nombre de minutes saisies par l'utilisateur
        /// </summary>
        [DataMember]
        [Range(1, 480, ErrorMessage = "Valeur entre 1 et 480")]
        public string NbMinutesSaisies
        {
            get { return _NbMinutesSaisies; }
            set
            {
                _NbMinutesSaisies = value;
                if(value != "")
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "NbMinutesSaisies" });
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

        #endregion

        #region PUBLICS VARIABLES


        #endregion

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Jclaud 2015-03-10 - Création</remarks>
        public MAJTicketDTO()
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

            Validator.ValidateProperty(this.CurrentTicket, new ValidationContext(this, null, null) { MemberName = "CurrentTicket" });
            Validator.ValidateProperty(this.CurrentRaison, new ValidationContext(this, null, null) { MemberName = "CurrentRaison" });
            Validator.ValidateProperty(this.CurrentClient, new ValidationContext(this, null, null) { MemberName = "CurrentClient" });
            
            //jc- on ne controle le nombre de minutes saisies par l'utilisateur que si différent de vide
            if(this.NbMinutesSaisies != "")
                Validator.ValidateProperty(this.NbMinutesSaisies, new ValidationContext(this, null, null) { MemberName = "NbMinutesSaisies" });
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
