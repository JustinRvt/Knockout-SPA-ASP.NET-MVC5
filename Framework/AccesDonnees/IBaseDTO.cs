using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WS_Hotline.Framework.AccesDonnees
{
    /// <summary>
    /// Interface de base pour les DTO
    /// </summary>
    /// <remarks>Version 1.0.1</remarks>
    public interface IBaseDTO : INotifyPropertyChanged
    {
        #region Methode

        /// <summary>
        /// serialisation
        /// </summary>
        /// <returns></returns>
        /// <remarks>LOUIS Yoann 17/06/2014</remarks>
        string SerializeDTO();

        /// <summary>
        /// validation du DTO
        /// Si il y a une erreur une exception est levée
        /// </summary>
        /// <remarks>LOUIS Yoann 17/06/2014</remarks>
        void ValidationDTO();

        /// <summary>
        /// Fonction permettant de vérifier le DTO
        /// </summary>
        /// <returns>True si correcte</returns>
        /// <remarks>Guillaume Bécard - 2015-02-18 - Craétion</remarks>
        bool IsValideDTO();

        #endregion

        #region Notify Property Changed

        /// <summary>
        /// Permet de déclencher l'évenement de notification de propriété lors d'une modification de celle-ci
        /// </summary>
        /// <param name="pName">nom de la propriété</param>
        /// <remarks>mt- 02/12/2010 Création</remarks>
        void OnPropertyChanged(String pName);

        #endregion
    }
}
