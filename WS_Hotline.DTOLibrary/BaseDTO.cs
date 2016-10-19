using WS_Hotline.DTOLibrary.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;


namespace WS_Hotline.DTOLibrary
{
    /// <summary>
    /// Il s'agit de la classe de base pour tous les DataTransferObjects.
    /// </summary>
    /// <remarks>Version 1.0.1</remarks>
    [DataContract]
    public abstract class BaseDTO : IBaseDTO, ICloneable
    {
        #region Property


        /// <summary>
        /// nom de la classe metier
        /// </summary>
        /// <remarks>ylouis 16/01/2015 générer par snippet V 1.0</remarks>
        [DataMember]
        public string NameClassNoSufix
        {
            get
            {
                return this.GetType().Name.Replace("DTO", "Metier");
            }
            set
            {
                OnPropertyChanged("NameClassMetier");
            }

        }

        #endregion

        #region Contructeur

        public BaseDTO()
        {

        }


        #endregion

        #region Methode

        /// <summary>
        /// serialisation
        /// </summary>
        /// <returns></returns>
        /// <remarks>LOUIS Yoann 17/06/2014</remarks>
        public string SerializeDTO()
        {
            this.ValidationDTO();
            return DTOSerializerHelper.SerializeDTO(this);
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
       /// Méthode permettant de cloner l'objet en cours
       /// </summary>
       /// <returns>Objet cloné sans la même référence</returns>
       /// <remarks>Guillaume Bécard - 2015-10-14 - Création</remarks>
       public virtual object Clone()
       {
           //gb - Retourne l'objet cloné
           return (BaseDTO)this.MemberwiseClone();
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
