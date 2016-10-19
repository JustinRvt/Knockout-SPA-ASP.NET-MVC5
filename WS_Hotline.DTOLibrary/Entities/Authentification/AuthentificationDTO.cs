using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WS_Hotline.DTOLibrary.Entities.Groupe;
using WS_Hotline.DTOLibrary.Entities.HoraireUser;
using WS_Hotline.DTOLibrary.Entities.TimeGemAcces;
using System.Diagnostics;
using WS_Hotline.Framework.Domain.Command;

namespace WS_Hotline.DTOLibrary.Entities.Authentification
{
    /// <summary>
    /// Classe permettant la gestion de l'authentification
    /// </summary>
    /// <remarks>Guillaume Bécard - 2015-02-17 - Création</remarks>
    [DebuggerDisplay("ID Gemini = {IdGemini} - Login = {Login} - Password = {Password}")]
    [DataContract]
    public class AuthentificationDTO : BaseDTO
    {
        #region PROPERTIES

        private string _IdGemini;
        /// <summary>
        /// Accesseur de l'identifiant Gemini de l'utilisateur
        /// </summary>
        [DataMember]
        public string IdGemini
        {
            get { return _IdGemini; }
            set { _IdGemini = value; }
        }

        private string _Login;
        /// <summary>
        /// Accesseur du login de l'utilisateur
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Login error")]
        public string Login
        {
            get { return _Login; }
            set {
                _Login = value;
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Login" });
            }
        }

        private string _Password;
        /// <summary>
        /// Accesseur du mot de passe
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Password error")]
        public string Password
        {
            get { return _Password; }
            set {
                _Password = value;
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Password" });
            }
        }

        private string _Url;
        /// <summary>
        /// Accesseur de l'url de connexion
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "Url error")]
        [RegularExpression(@"https?:\/\/w{0,3}\w*?\.(\w*?\.)?\w{2,3}\S*|www\.(\w*?\.)?\w*?\.\w{2,3}\S*|(\w*?\.)?\w*?\.\w{2,3}[\/\?]\S*", ErrorMessage = "Invalid url")]
        public string Url
        {
            get { return _Url; }
            set {
                _Url = value;
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Url" });
            }
        }

        private string _Proxy;
        /// <summary>
        /// Accesseur du proxy de connexion
        /// </summary>
        [DataMember]
        public string Proxy
        {
            get { return _Proxy; }
            set { _Proxy = value; }
        }

        private bool _IsAutoConnect;
        /// <summary>
        /// Accesseur du bool qui indique si on s'authentification automatiquement
        /// </summary>
        [DataMember]
        public bool IsAutoConnect
        {
            get { return _IsAutoConnect; }
            set { _IsAutoConnect = value; }
        }

        private double _Opacity = 1;
        /// <summary>
        /// Accesseur de la valeur de l'opacité
        /// </summary>
        [DataMember]
        public double Opacity
        {
            get { return _Opacity; }
            set { _Opacity = value; }
        }

        private DateTime _LastConnexion;
        /// <summary>
        /// Accesseur de la date de dernière connexion
        /// </summary>
        [DataMember]
        public DateTime LastConnexion
        {
            get { return _LastConnexion; }
            set { _LastConnexion = value; }
        }

        private string _ApiKey;
        /// <summary>
        /// Accesseur de l'API Key de Gemini
        /// </summary>
        [DataMember]
        public string ApiKey
        {
            get { return _ApiKey; }
            set { _ApiKey = value; }
        }

        private HoraireUserDTO _HoraireUserEnCours;
        /// <summary>
        /// Accesseur du horaire user en cours
        /// </summary>
        [DataMember]
        public HoraireUserDTO HoraireUserEnCours
        {
            get { return _HoraireUserEnCours; }
            set { _HoraireUserEnCours = value; }
        }

        private TimeGemAccesDTO _AccesUser;
        /// <summary>
        /// Accesseur de la gestion d'accès pour l'utilisateur
        /// </summary>
        [DataMember]
        public TimeGemAccesDTO AccesUser
        {
            get { return _AccesUser; }
            set { _AccesUser = value; }
        }

        private ObservableCollection<HoraireUserDTO> _JoursErreurSaisie;
        /// <summary>
        /// Accesseur des journée avec erreur de saisie
        /// </summary>
        [DataMember]
        public ObservableCollection<HoraireUserDTO> JoursErreurSaisie
        {
            get { return _JoursErreurSaisie; }
            set { _JoursErreurSaisie = value; }
        }

        private ObservableCollection<GroupeDTO> _Groupes;
        /// <summary>
        /// Accesseur des groupes liés à l'utilisateur
        /// </summary>
        [DataMember]
        public ObservableCollection<GroupeDTO> Groupes
        {
            get { return _Groupes; }
            set { _Groupes = value; }
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
            Validator.ValidateProperty(this.Login, new ValidationContext(this, null, null) { MemberName = "Login" });
            Validator.ValidateProperty(this.Password, new ValidationContext(this, null, null) { MemberName = "Password" });
            Validator.ValidateProperty(this.Url, new ValidationContext(this, null, null) { MemberName = "Url" });
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
            ///<para>Description : Fonction permettant de tester l'authentification vers Gemini. Si celle-ci fonctionne l'Id de l'utilisateur est retourné</para>
            ///<para>Paramètre : Cette fonction prend un paramètre un objet de type AuthentificationDTO</para>
            /// </summary>
            GetUtilisateurGemini,
            /// <summary>
            ///<para>Description : Fonction permettant de retourner si un utilisateur fait partit du groupe administrateur ou non</para>
            ///<para>Paramètre : Cette fonction prend un paramètre un objet de type AuthentificationDTO</para>
            /// </summary>
            IsUtilisateurAdministrator,
            /// <summary>
            ///<para>Description : Fonction permettant de tester l'authentification vers Gemini. Si celle-ci fonctionne la liste des users est retournée</para>
            ///<para>Paramètre : Cette fonction prend un paramètre un objet de type AuthentificationDTO</para>
            /// </summary>
            GetUtilisateurs
        }

        #endregion
    }
}
