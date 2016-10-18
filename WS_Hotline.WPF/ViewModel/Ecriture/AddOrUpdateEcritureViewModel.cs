using WS_Hotline.DomainLibrary.Metier.Compte;
using WS_Hotline.DomainLibrary.Metier.Dossier;
using WS_Hotline.DomainLibrary.Metier.Ecriture;
using WS_Hotline.DTOLibrary.Business.Navigation;
using WS_Hotline.DTOLibrary.Entities.Compte;
using WS_Hotline.DTOLibrary.Entities.Dossier;
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
    public class AddOrUpdateEcritureViewModel : ViewModelBase
    {
        #region Property

        private EcritureDTO _Ecriture;
        /// <summary>
        /// Ecriture
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par snippet v1.0</remarks>
        public EcritureDTO Ecriture
        {
            get
            {
                return this._Ecriture;
            }
            set
            {
                this._Ecriture = value;
                RaisePropertyChanged("Ecriture");
            }
        }
            
        private ObservableCollection<DossierDTO> _ListDossier;
        /// <summary>
        /// Liste de dossier
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par snippet v1.0</remarks>
        public ObservableCollection<DossierDTO> ListDossier
        {
            get
            {
                return this._ListDossier;
            }
            set
            {
                this._ListDossier = value;
                RaisePropertyChanged("ListDossier");
            }
        }   

        private ObservableCollection<CompteDTO> _ListCompte;
        /// <summary>
        /// Liste de compte
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par snippet v1.0</remarks>
        public ObservableCollection<CompteDTO> ListCompte
        {
            get
            {
                return this._ListCompte;
            }
            set
            {
                this._ListCompte = value;
                RaisePropertyChanged("ListCompte");
            }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur du viewModel d'ajout ou de modification d'ecriture
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par snippet v1.0</remarks>
        public AddOrUpdateEcritureViewModel()
        {
            // yl - Inisilisation
            this.Initalisation();
        }

        #endregion

        #region Methode

        private void Initalisation()
        {
            // yl - GEstion des abonnement 
            this.GestionAbonnement();

            // yl - Chargement des dossier
            this.LoadDossier();
            // yl - chargement des compte 
            this.LoadCompte();
        }

        /// <summary>
        /// Chargement des dossiers
        /// </summary>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        private void LoadDossier()
        {
            // yl - recuperation de la liste
            this.ListDossier = Helper.ServiceMetierHelper.GetItems<DossierDTO, DossierMetier>(new CritereDossierDTO());
        }

        /// <summary>
        /// Chargement des Comptes
        /// </summary>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        private void LoadCompte()
        {
            // yl - recuperation de la liste
            this.ListCompte = Helper.ServiceMetierHelper.GetItems<CompteDTO, CompteMetier>(new CritereCompteDTO());
        }

        /// <summary>
        /// Affectation ecriture
        /// </summary>
        /// <param name="pEcriture">Ecriture a affecter</param>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        private void AffectationEcriture(EcritureDTO pEcriture)
        {
            // yl - si c'est un update
            if (pEcriture.IdEcriture != 0)
            {
                // yl - On recupere en Bdd La Ligne d'ecriture
                this.Ecriture = Helper.ServiceMetierHelper.GetItem<EcritureDTO, EcritureMetier>(new CritereEcritureDTO() { IdEcriture = pEcriture.IdEcriture });
            }
            else
            {
                // yl - Affectation
                this.Ecriture = pEcriture;
            }
        }

        /// <summary>
        /// Sauvegarder l'ecriture saisie
        /// </summary>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        private void Sauvegarde()
        {
            if(Ecriture.IdEcriture!=0){
                Helper.ServiceMetierHelper.UpdateItem<EcritureDTO, EcritureMetier>(this.Ecriture);
            }
            else{
                Helper.ServiceMetierHelper.AddItem<EcritureDTO, EcritureMetier>(this.Ecriture);
            }
            // yl - retour a l'ecran de selection
            this.Retour();
        }

        /// <summary>
        /// Annuler la saisie
        /// </summary>
        /// <remarks>LOUIS YOANN 06/09/2016</remarks>
        private void Annuler()
        {
            // yl - Retour a l'ecran de slection
            this.Retour();
        }

        /// <summary>
        /// Retour vers l'ecran de slection
        /// </summary>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        private void Retour()
        {
            Messenger.Default.Send<NavigationDTO<EcritureDTO>>(new NavigationDTO<EcritureDTO>() { Module = DTOLibrary.Enum.Module.EModule.SelectionEcriture, ObjectDTO = this.Ecriture });
        }

        #endregion

        #region Regsiter

        /// <summary>
        /// Abonnement au different message
        /// </summary>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        private void GestionAbonnement()
        {
            // yl - Abonnement Changement de module
            Messenger.Default.Register<EcritureDTO>(this, AffectationEcriture);
        }

        #endregion

        #region Command

        public ICommand SauvegardeCommand
        {
            get { return new RelayCommand(Sauvegarde); }
        }

        public ICommand AnnulerCommand
        {
            get { return new RelayCommand(Annuler); }
        }

        #endregion
    }
}
