using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using WS_Hotline.Framework.Domain.Command;

namespace WS_Hotline.DTOLibrary.Methodes
{
    /// <summary>
    /// Classe DTO permettant de gérer Method
    /// </summary>
    /// <remark> ylouis - 05/10/2015 - généré par snippet v1.0 </remark>
    [DataContract]
    public class MethodDTO : BaseDTO
    {
        #region PROPERTY

        private string _NomMethode;
        /// <summary>
        /// Accesseur du nom de la méthode
        /// </summary>
        [DataMember]
        public string NomMethode
        {
            get { return _NomMethode; }
            set
            {
                _NomMethode = value;
                OnPropertyChanged("NomMethode");
            }
        }

        private string _DTOStringType;
        /// <summary>
        /// Accesseur du type de DTO
        /// </summary>
        [DataMember]
        public string DTOStringType
        {
            get { return _DTOStringType; }
            set
            {
                _DTOStringType = value;
                OnPropertyChanged("DTOType");
            }
        }

        private object _Parametrage;
        /// <summary>
        /// Accesseur du paramètre
        /// </summary>
        [DataMember]
        public object Parametrage
        {
            get { return _Parametrage; }
            set
            {
                _Parametrage = value;
                OnPropertyChanged("Parametrage");
            }
        }

        #endregion

    }
}
