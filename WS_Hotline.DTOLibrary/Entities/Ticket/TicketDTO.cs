using WS_Hotline.DTOLibrary.Entities.Projet;
using WS_Hotline.DTOLibrary.Entities.Statut;
using WS_Hotline.DTOLibrary.Entities.Temps;
using WS_Hotline.DTOLibrary.Entities.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Raison;
using WS_Hotline.DTOLibrary.Entities.TimeType;
using WS_Hotline.DTOLibrary.Entities.Resolution;
using WS_Hotline.DTOLibrary.Entities.Cause;
using WS_Hotline.DTOLibrary.Entities.Client;
using WS_Hotline.DTOLibrary.Entities.Composant;
using WS_Hotline.DTOLibrary.Entities.TicketLien;
using System.Collections.ObjectModel;
using WS_Hotline.DTOLibrary.Entities.CustomField;
using WS_Hotline.DTOLibrary.Entities.CodeContrat;
using WS_Hotline.DTOLibrary.Entities.Authentification;
using WS_Hotline.DTOLibrary.Entities.CodeAffaire;
using System.Diagnostics;
using WS_Hotline.Framework.Domain.Command;

namespace WS_Hotline.DTOLibrary.Entities.Ticket
{
    /// <summary>
    /// Classe permettant la gestion des tickets
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-17 - Création</remarks>
    [DebuggerDisplay("ID = {IdTicket} - Nom = {NomTicket} - % Avancement = {Avancement}")]
    [DataContract]
    public class TicketDTO : BaseDTO
    {
        #region PROPERTIES

        #region ACCESSEURS

        private int _IdTicket;
        /// <summary>
        /// Accesseur de l'identifiant du ticket
        /// </summary>
        [DataMember]
        public int IdTicket
        {
            get { return _IdTicket; }
            set { _IdTicket = value;}
        }

        private string _NomTicket;
        /// <summary>
        /// Accesseur du nom du ticket
        /// </summary
        [DataMember]
        public string NomTicket
        {
            get { return _NomTicket; }
            set { _NomTicket = value; }
        }

        private string _Avancement;
        /// <summary>
        /// Accesseur de l'avancement du ticket
        /// </summary>
        [DataMember]
        [Range(0,100, ErrorMessage="Value entre 0 et 100")]
        public string Avancement
        {
            get { return _Avancement; }
            set 
            {
                _Avancement = value;
                Validator.ValidateProperty(this.Avancement, new ValidationContext(this, null, null) { MemberName = "Avancement" });
            }
        }

        private int _Priorite;
        /// <summary>
        /// Accesseur de la priorité
        /// </summary>
        [DataMember]
        public int Priorite
        {
            get { return _Priorite; }
            set { _Priorite = value; }
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

        private string _DescriptionTimeTracking;
        /// <summary>
        /// Accesseur de la description du temps lié au ticket
        /// </summary>
        [DataMember]
        public string DescriptionTimeTracking
        {
            get { return _DescriptionTimeTracking; }
            set { _DescriptionTimeTracking = value; }
        }

        private string _DescriptionCommentTicket;
        /// <summary>
        /// Accesseur du commentaire lié au ticket
        /// </summary>
        [DataMember]
        public string DescriptionCommentTicket
        {
            get { return _DescriptionCommentTicket; }
            set { _DescriptionCommentTicket = value; }
        }

        private string _Ressources;
        /// <summary>
        /// Accesseur des ressources liées au ticket
        /// </summary>
        [DataMember]
        public string Ressources
        {
            get { return _Ressources; }
            set { _Ressources = value; }
        }

        private int _VersionAffectee;
        /// <summary>
        /// Accesseur de la version affectée du ticket
        /// </summary>
        [DataMember]
        public int VersionAffectee
        {
            get { return _VersionAffectee; }
            set { _VersionAffectee = value; }
        }

        private int _RegleDansLaVersion;
        /// <summary>
        /// Accesseur du réglé dans la version du ticket
        /// </summary>
        [DataMember]
        public int RegleDansLaVersion
        {
            get { return _RegleDansLaVersion; }
            set { _RegleDansLaVersion = value; }
        }

        private TempsDTO _Temps;
        /// <summary>
        /// Accesseur des temps du ticket
        /// </summary>
        [DataMember]
        public TempsDTO Temps
        {
            get { return _Temps; }
            set { _Temps = value; }
        }

        private StatutDTO _Statut;
        /// <summary>
        /// Accesseur du statut du ticket
        /// </summary>
        [DataMember]
        public StatutDTO Statut
        {
            get { return _Statut; }
            set { _Statut = value; }
        }

        private ProjetDTO _Projet;
        /// <summary>
        /// Accesseur du projet
        /// </summary>
        [DataMember]
        public ProjetDTO Projet
        {
            get { return _Projet; }
            set { _Projet = value; }
        }

        private TypeDTO _Type;
        /// <summary>
        /// Accesseur du type
        /// </summary>
        [DataMember]
        public TypeDTO Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private ResolutionDTO _Resolution;
        /// <summary>
        /// Accesseur de la resolution
        /// </summary>
        [DataMember]
        public ResolutionDTO Resolution
        {
            get { return _Resolution; }
            set { _Resolution = value; }
        }

        private TimeTypeDTO _TypeTemp;
        /// <summary>
        /// Accesseur du type de temps
        /// </summary>
        [DataMember]
        public TimeTypeDTO TypeTemp
        {
            get { return _TypeTemp; }
            set { _TypeTemp = value; }
        }

        private RaisonDTO _Raison;
        /// <summary>
        /// Accesseur de la Raison
        /// </summary>
        [DataMember]
        public RaisonDTO Raison
        {
            get { return _Raison; }
            set { _Raison = value; }
        }

        private CauseDTO _Cause;
        /// <summary>
        /// Accesseur de la cause (pour les tickets de support)
        /// </summary>
        [DataMember]
        public CauseDTO Cause
        {
            get { return _Cause; }
            set { _Cause = value; }
        }

        private ClientDTO _Client;
        /// <summary>
        /// Accesseur du client
        /// </summary>
        [DataMember]
        public ClientDTO Client
        {
            get { return _Client; }
            set { _Client = value; }
        }

        private ComposantDTO _Composant;
        /// <summary>
        /// Accesseur du composant
        /// </summary>
        [DataMember]
        public ComposantDTO Composant
        {
            get { return _Composant; }
            set { _Composant = value; }
        }

        private TicketLienDTO _TicketLien;
        /// <summary>
        /// Accesseur du lien du ticket
        /// </summary>
        [DataMember]
        public TicketLienDTO TicketLien
        {
            get { return _TicketLien; }
            set { _TicketLien = value; }
        }

        private ObservableCollection<CustomFieldDTO> _ListeCustomField = new ObservableCollection<CustomFieldDTO>();
        /// <summary>
        /// Accesseur de la liste des customsField
        /// </summary>
        [DataMember]
        public ObservableCollection<CustomFieldDTO> ListeCustomField
        {
            get { return _ListeCustomField; }
            set { _ListeCustomField = value; }
        }

        private CodeContratDTO _CodeContrat;
        /// <summary>
        /// Accesseur du code contrat du ticket
        /// </summary>
        [DataMember]
        public CodeContratDTO CodeContrat
        {
            get { return _CodeContrat; }
            set { _CodeContrat = value; }
        }

        private CodeAffaireDTO _CodeAffaire;
        /// <summary>
        /// Accesseur du code affaire du ticket
        /// </summary>
        [DataMember]
        public CodeAffaireDTO CodeAffaire
        {
            get { return _CodeAffaire; }
            set { _CodeAffaire = value; }
        }

        private AuthentificationDTO _Declarant;
        /// <summary>
        /// Accesseur du déclarant du ticket
        /// </summary>
        [DataMember]
        public AuthentificationDTO Declarant
        {
            get { return _Declarant; }
            set { _Declarant = value; }
        }

        private AuthentificationDTO _Ressource;
        /// <summary>
        /// Accesseur de la ressource du ticket
        /// </summary>
        [DataMember]
        public AuthentificationDTO Ressource
        {
            get { return _Ressource; }
            set { _Ressource = value; }
        }

        private ProjetDTO _ProjetConcerne;
        /// <summary>
        /// Accesseur du projet concerne
        /// </summary>
        [DataMember]
        public ProjetDTO ProjetConcerne
        {
            get { return _ProjetConcerne; }
            set { _ProjetConcerne = value; }
        }

        private int _Ordre;
        /// <summary>
        /// Accesseur de l'ordre du ticket
        /// </summary>
        [DataMember]
        public int Ordre
        {
            get { return _Ordre; }
            set { _Ordre = value; }
        }

        private string _SearchTicket;
        /// <summary>
        /// Accesseur du texte de recherche
        /// </summary>
        [DataMember]
        public string SearchTicket
        {
            get { return _SearchTicket; }
            set { _SearchTicket = value; }
        }

        #endregion

        #region PUBLICS VARIABLES

        /// <summary>
        /// Accesseur de la variable permettant d'indiquer les temps passés et loggés
        /// </summary>
        public string ResumeTemps
        {
            get 
            {
                //return String.Format("{0:00} : {1:00} / {2:00} : {3:00}", this.Temps.EstimateHours, this.Temps.EstimateMinutes,
                //    this.Temps.LoggedHours + (this.Temps.LoggedMinutes / 60), this.Temps.LoggedMinutes % 60);

                return String.Format("{0:00} : {1:00} / {2}", this.Temps.EstimateHours, this.Temps.EstimateMinutes,
                    this.Restant.ToString()); 
            }
        }

        /// <summary>
        /// Accesseur de la variable contenant le temps restant / dépassé sur le ticket
        /// </summary>
        public string Restant
        {
            get 
            {
                        //gb - Déclaration des variables
                int lTempsTotal = this.Temps.EstimateHours * 60 + this.Temps.EstimateMinutes;
                int lTempsLogge = this.Temps.LoggedHours * 60 + this.Temps.LoggedMinutes;
                
                //gb - Calcul du temps restants
                int lTempsRestant = lTempsTotal - lTempsLogge;

                //jc- si le temps restant est négatif mais inférieur à 1h alors on met un moins devant
                if ((int)(lTempsRestant / 60) == 0 && lTempsRestant < 0)
                    return String.Format("-{0:00} : {1:00}", lTempsRestant / 60, Math.Abs(lTempsRestant % 60)); 
               //jc- sinon on retourne la chaine classique
                else
                    return String.Format("{0:00} : {1:00}", lTempsRestant / 60, Math.Abs(lTempsRestant % 60));  
            }
        }

        /// <summary>
        /// Accesseur de la variables indiquant l'avancement estimatif
        /// </summary>
        public double EstimatePercent
        {
            get 
            {
                //gb - Déclaration des variables
                int lTempsTotal = this.Temps.EstimateHours * 60 + this.Temps.EstimateMinutes;
                int lTempsLogge = this.Temps.LoggedHours * 60 + this.Temps.LoggedMinutes;

                //jc- si le temps total affecté est de 0
                if (lTempsTotal != 0)
                    //gb - Calcul de l'avancement estimatif
                    return lTempsLogge * 100 / lTempsTotal;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Accesseur du bool qui indique si le ticket est en retard ou non
        /// </summary>
        public bool IsRetard
        {
            get 
            {
                //gb - Déclaration des variables
                int lTempsTotal = this.Temps.EstimateHours * 60 + this.Temps.EstimateMinutes;
                int lTempsLogge = this.Temps.LoggedHours * 60 + this.Temps.LoggedMinutes;

                //gb - Calcul de l'avancement estimatif
                return lTempsLogge > lTempsTotal;
            }
        }

        #endregion

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Guillaume Bécard - 2015-02-23 - Création</remarks>
        public TicketDTO()
        {

        }

        #endregion

        #region METHODES / FONCTIONS

        #region VALIDATION DTO

        /// <summary>
        /// Méthode permettant de valider le DTO
        /// Si il y a une erreur, une exception est levée
        /// </summary>
        /// <remarks>Guillaume Bécard - 2015-02-18 - Création</remarks>
        public override void ValidationDTO()
        {
            //gb - Appel les méthodes de validation des DTO
            base.ValidationDTO();
            Validator.ValidateProperty(this.Avancement, new ValidationContext(this, null, null) { MemberName = "Avancement" });
        }

        #endregion

        #endregion

        #region ENUM METHODES

        /// <summary>
        /// Classe d'enum permettant de lister les méthodes disponibles
        /// </summary>
        public enum Methods
        {
            /// <summary>
            /// <para>Description : Fonction permettant de retourner la liste des tickets pour l'utilisateur en cours</para>
            /// <para>Paramètre : Cette fonction prend en paramètre un objet de type ParamGetTicketDTO</para>
            /// </summary>
            GetData,
            /// <summary>
            /// <para>Description : Méthode permettant de mettre à jour l'avancement d'un ticket</para>
            /// <para>Paramètre : Cette méthode prend en paramètre un objet de type ParamUpdateAvancementDTO</para>
            /// </summary>
            UpdateAvancement,
            /// <summary>
            /// <para>Description : Méthode permettant de mettre à jour l'utilisateur d'un ticket</para>
            /// <para>Paramètre : Cette méthode prend en paramètre un objet de type ParamUpdateTicketDTO</para>
            /// </summary>
            UpdateTicketUser,
            /// <summary>
            /// <para>Description : Méthode permettant de mettre à jour le statut du ticket</para>
            /// <para>Paramètre : Cette méthode prend en paramètre un objet de type ParamUpdateStatutDTO</para>
            /// </summary>
            UpdateStatut,
            /// <summary>
            /// <para>Description : Méthode permettant de mettre à jour la résolution du ticket</para>
            /// <para>Paramètre : Cette méthode prend en paramètre un objet de type ParamUpdateStatutDTO</para>
            /// </summary>
            UpdateResolution,
            /// <summary>
            /// <para>Description : Méthode permettant la création d'un nouveau ticket</para>
            /// <para>Paramètre : Cette méthode prend en paramètre un objet de type ParamCreationTicketDTO</para>
            /// </summary>
            CreateTicket,
            /// <summary>
            /// <para>Description : Méthode permettant la création d'une clarte pour le ticket</para>
            /// <para>Paramètre : Cette méthode prend en paramètre un objet de type ParamCreationClarteDTO</para>
            /// </summary>
            CreateClarte,
            /// <summary>
            /// <para>Description : Méthode permettant la création d'un nouveau tache hors ticket</para>
            /// <para>Paramètre : Cette méthode prend en paramètre un objet de type ParamCreationTicketDTO</para>
            /// </summary>
            CreateTacheHorsTicket,
            /// <summary>
            /// <para>Description : Méthode permettant la création d'un ticket de question</para>
            /// <para>Paramètre : Cette méthode prend en paramètre un objet de type ParamCreationTicketDTO</para>
            /// </summary>
            CreateTicketQuestion
        }

        #endregion
    }
}
