using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using WS_Hotline.Framework.AccesDonnees;
using WS_Hotline.Framework.Domain.Command;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WS_Hotline.Framework.Domain.Command
{
    /// <summary>
    /// Il s'agit de la classe de base pour tous les DTO.
    /// </summary>
    /// <remarks>Version 1.0.1</remarks>
    public abstract class BaseDTO : DomainObject, IBaseDTO
    {
        #region PROPERTY

        private State _CurrentState;
        /// <summary>
        /// Accesseur du statut de l'objet
        /// </summary>
        [NotMapped]
        public State CurrentState
        {
            get { return _CurrentState; }
            set { _CurrentState = value; }
        }

        #endregion

        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Guillaume Bécard - 2015-06-24 - Création</remarks>
        public BaseDTO()
        {

        }

        #endregion

        #region METHODS

        /// <summary>
        /// serialisation
        /// </summary>
        /// <returns></returns>
        /// <remarks>LOUIS Yoann 17/06/2014</remarks>
        public string SerializeDTO()
        {
            this.ValidationDTO();
            return null;
        }

        /// <summary>
        /// validation du DTO
        /// Si il y a une erreur une exception est levée
        /// </summary>
        /// <remarks>LOUIS Yoann 17/06/2014</remarks>
        public virtual void ValidationDTO()
        {

        }

        /// <summary>
        /// Fonction permettant de vérifier le DTO
        /// </summary>
        /// <returns>True si correcte</returns>
        /// <remarks>Guillaume Bécard - 2015-02-18 - Craétion</remarks>
        public virtual bool IsValideDTO()
        {
            try
            {
                //gb - Appel la méthode de validation du DTO
                ValidationDTO();

                //gb - Indique que le DTO est valide
                return true;
            }
            catch (Exception)
            {
                //gb - Indique que le DTO n'est pas valide
                return false;
            }
        }
        
        /// <summary>
        /// Méthode permettant de valider la valeur du champ
        /// </summary>
        /// <param name="pValue">Valeur</param>
        /// <param name="validationContext">Context de validation</param>
        /// <remarks>Guillaume Bécard - 2017-07-08 - Création</remarks>
        public virtual void ValidateProperty(object pValue, ValidationContext pValidationContext)
        {
            //gb - Si l'objet n'est pas en mode suppression
            if(this.CurrentState != State.Delete)
                //gb - Validation du champ
                Validator.ValidateProperty(pValue, pValidationContext);
        }

        #endregion

        #region enum

        /// <summary>
        /// Classe permettant de gérer l'état d'un objet DTO
        /// </summary>
        public enum State
        {
            Default,
            Delete
        }

        #endregion

        #region Notify Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Permet de déclencher l'évenement de notification de propriété lors d'une modification de celle-ci
        /// </summary>
        /// <param name="pName">nom de la propriété</param>
        /// <remarks>mt- 02/12/2010 Création</remarks>
        public void OnPropertyChanged(String pName)
        {
            //mt - Vérifie si la propriété est non null
            if (PropertyChanged != null)
            {
                //mt - Notifie le changement de valeur de la propriété
                PropertyChanged(this, new PropertyChangedEventArgs(pName));
            }
        }
        #endregion
    }
}
