using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using WS_Hotline.DTOLibrary.Entities.Ecriture;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using WS_Hotline.DTOLibrary.Enum.Module;

namespace WS_Hotline.WPF.ViewModel
{
    /// <summary>
    /// ViewModel De l'interface de base
    /// </summary>
    /// <remarks>LOUIS Yoann 18/07/2016 création</remarks>
    public class MainViewModel : ViewModelBase
    {
        #region Property

        private EModule _ModuleEnCours;
        /// <summary>
        /// Module En cours
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par snippet v1.0</remarks>
        public EModule ModuleEnCours
        {
            get
            {
                return this._ModuleEnCours;
            }
            set
            {
                this._ModuleEnCours = value;
                RaisePropertyChanged("ModuleEnCours");
            }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks>LOUIS Yoann 18/07/2016 création</remarks>
        public MainViewModel()
        {
            // yl - Initialisation
            this.Initialisation();
        }

        #endregion

        #region Methode

        /// <summary>
        /// Initilisation 
        /// </summary>
        /// <remarks>LOUIS Yoann 18/07/2016 création</remarks>
        private void Initialisation()
        {
            // yl - De base en selectionne le module de selection des ecriture
            this.ModuleEnCours = EModule.SelectionEcriture;
            // yl - Gestion des abonnement
            this.GestionAbonnement();
        }

        /// <summary>
        /// Changeemnt de module
        /// </summary>
        /// <param name="pModule">Module appeler</param>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        private void ChangeModule(EModule pModule)
        {
            // yl - Affectation du module
            this.ModuleEnCours = pModule;
        }

        
        #endregion

        #region Register

        /// <summary>
        /// Abonnement au different message
        /// </summary>
        /// <remarks>LOUIS Yoann 06/09/2016</remarks>
        private void GestionAbonnement()
        {
            // yl - Abonnement Changement de module
            Messenger.Default.Register<EModule>(this, ChangeModule);
        }

        #endregion

        #region Command

        #endregion

    }
}
