using WS_Hotline.DTOLibrary.Helper;
using WS_Hotline.Framework.AccesDonnees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DTOLibrary
{
    /// Classe de base pour les critères DTO
    /// </summary>
    /// <remarks>Version 1.0.1</remarks>
    [DataContract]
    public class CritereBaseDTO<DTOType> : WS_Hotline.Framework.Domain.Query.SearchCriteria<DTOType>, IBaseDTO
        where DTOType : IBaseDTO, new()
    {
        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Guillaume Bécard - 2015-06-24 - Création</remarks>
        public CritereBaseDTO()
            : base()
        {

        }

        #endregion

        #region METHODS

        /// <summary>
        /// serialisation
        /// </summary>
        /// <returns></returns>
        /// <remarks>LOUIS Yoann 17/06/2014</remarks>
        public virtual string SerializeDTO()
        {
            this.ValidationDTO();
            return DTOSerializerHelper.SerializeDTO(this);
        }


        /// <summary>
        /// Validation du dto
        /// </summary>
        /// <remarks>LOUIS Yoann 24/06/2015</remarks>
        public void ValidationDTO()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Indique si le DTO est valide
        /// </summary>
        /// <returns>Vrai si valide</returns>
        /// <remarks>LOUIS Yoann 24/06/2015</remarks>
        public bool IsValideDTO()
        {
            throw new NotImplementedException();
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
