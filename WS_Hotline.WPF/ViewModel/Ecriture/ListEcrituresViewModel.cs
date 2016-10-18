using WS_Hotline.DTOLibrary.Business.Navigation;
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
    /// ViewModel gerant une liste d'ecriture DTO
    /// </summary>
    public class ListEcrituresViewModel : ViewModelBase
    {
        #region Property

        private ObservableCollection<EcritureDTO> _ListEcritures;
        /// <summary>
        /// Liste des ecritures
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par snippet v1.0</remarks>
        public ObservableCollection<EcritureDTO> ListEcritures
        {
            get
            {
                return this._ListEcritures;
            }
            set
            {
                this._ListEcritures = value;
                RaisePropertyChanged("ListEcritures");
            }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur Viewmodel ListEcriture
        /// </summary>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        public ListEcrituresViewModel()
        {
            // yl - Abonnement au message
            this.Register();
        }

        #endregion

        #region Methode

        #region Register

        /// <summary>
        /// ABoinnement au different message
        /// </summary>
        /// <remarks>LOUIS Yoann 06/096/2016</remarks>
        private void Register()
        {
            // yl - Abonnement ecritureDTO
            Messenger.Default.Register<ObservableCollection<EcritureDTO>>(this, AffectationListEcritures);
        }

        #endregion

        /// <summary>
        /// Affectation de la liste des ecritures a la propriété ListEcritures
        /// </summary>
        /// <param name="pListEcritures">Liste des ecritures à affecter</param>
        /// <remarks>LOUIS Yoann 06/09/2016 Création</remarks>
        private void AffectationListEcritures(ObservableCollection<EcritureDTO> pListEcritures)
        {
            // yl - Affectation
            this.ListEcritures = pListEcritures;
        }


        #endregion

        #region SendMessage

        /// <summary>
        /// Envoie du message d'ajout ou de modification d'une ligne
        /// </summary>
        /// <param name="pEcriture">Ligne a ajouter ou modifier</param>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        private void SendAddOrUpdateEcriture(EcritureDTO pEcriture)
        {
            Messenger.Default.Send<NavigationDTO<EcritureDTO>>(new NavigationDTO<EcritureDTO>() { Module = DTOLibrary.Enum.Module.EModule.AddOrUpdateEcriture, ObjectDTO = pEcriture});
        }

        #endregion

        #region Command

        /// <summary>
        /// Commande de modification d'une ligne d'ecriture
        /// </summary>
        /// <remarks>LOUIS Yoann 07/09/2016</remarks>
        public ICommand ModifCommand
        {
            get
            {
                return new RelayCommand<EcritureDTO>(SendAddOrUpdateEcriture);
            }
        }


        /// <summary>
        /// Commande de Ajouter une ligne d'ecriture
        /// </summary>
        /// <remarks>LOUIS Yoann 07/09/2016</remarks>
        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(() => { SendAddOrUpdateEcriture(new EcritureDTO()); });
            }
        }

        #endregion
    }
}
