using WS_Hotline.DomainLibrary.Metier.Ecriture;
using WS_Hotline.DTOLibrary.Entities.Ecriture;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WS_Hotline.WPF.ViewModel.Ecriture
{
    /// <summary>
    /// ViewModel gerant les recherche sur la liste des ecritureDTO
    /// </summary>
    /// <remarks>LOUIS Yoann 06/09/2016</remarks>
    public class RechercheEcritureViewModel : ViewModelBase
    {
        #region Property

        private CritereEcritureDTO _CritereSelectionEcriture;
        /// <summary>
        /// Critere de selection des ecriture
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par snippet v1.0</remarks>
        public CritereEcritureDTO CritereSelectionEcriture
        {
            get
            {
                return this._CritereSelectionEcriture;
            }
            set
            {
                this._CritereSelectionEcriture = value;
                RaisePropertyChanged("CritereSelectionEcriture");
            }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks>LOUIS Yoann 06/09/2016 création</remarks>
        public RechercheEcritureViewModel()
        {
            // yl - Initialisation
            this.Initialisation();
        }

        #endregion

        #region Methode

        /// <summary>
        /// Initilisation 
        /// </summary>
        /// <remarks>LOUIS Yoann 06/09/2016 création</remarks>
        private void Initialisation()
        {
            // yl - GEstion des abonnement
            this.GestionAbonnement();
            // yl - Initalisation des critere de recherche
            this.InitialiseRechercheEcriture();
            // yl - LAncement de la recherche 
            this.LoadEcriture();
        }

        /// <summary>
        /// Chargement des ligne d'ecriture
        /// </summary>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        private void LoadEcriture()
        {
            // yl - Creation de la variable de la liste des ecritures
            var lListEcritures = Helper.ServiceMetierHelper.GetItems<EcritureDTO, EcritureMetier>(this.CritereSelectionEcriture);

            // yl - Envoie du message
            this.SendListEcritures(lListEcritures);
        }

        /// <summary>
        /// Abonnement au different message
        /// </summary>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        private void GestionAbonnement()
        {
            // yl - Abonnement Changement de module
            Messenger.Default.Register<EcritureDTO>(this, p => { this.LoadEcriture(); });
        }

        /// <summary>
        /// initialise un critere de selection des ecriture
        /// </summary>
        /// <remarks>LOUIS Yoann 06/09/2016 création</remarks>
        private void InitialiseRechercheEcriture()
        {
            // yl - Initalisation varaible recherche
            this.CritereSelectionEcriture = new CritereEcritureDTO();
            this.CritereSelectionEcriture.TakeDossier = true;
            this.CritereSelectionEcriture.TakeCompte = true;
            // yl - envoie message
            this.SendListEcritures(new ObservableCollection<EcritureDTO>());
        }

        #region SendMessage

        /// <summary>
        /// Envoie d'un message avec la liste des ecriture
        /// </summary>
        /// <param name="pListEcritures">Liste des ecriture a envoyer dans le message</param>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        private void SendListEcritures(ObservableCollection<EcritureDTO> pListEcritures)
        {
            // yl - Envoie du message
            Messenger.Default.Send<ObservableCollection<EcritureDTO>>(pListEcritures);
        }

        

        #endregion

        #endregion

        #region Command

        /// <summary>
        /// Lance un recherche d'ecriture
        /// </summary>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        public ICommand RechercheEcritureCommand
        {
            get { return new RelayCommand(() => { this.LoadEcriture(); }); }
        }


        /// <summary>
        /// Réinitalise
        /// </summary>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        public ICommand ReinitialiseCommand
        {
            get { return new RelayCommand(() => { this.InitialiseRechercheEcriture(); }); }
        }

        #endregion
    }
}
