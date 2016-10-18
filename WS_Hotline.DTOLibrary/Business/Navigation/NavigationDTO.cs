using WS_Hotline.Framework.AccesDonnees;
using WS_Hotline.Framework.Domain.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DTOLibrary.Business.Navigation
{
    /// <summary>
    /// Classe permetant la navigation dans l'application WPF
    /// </summary>
    /// <remarks>LOUIS Yoann 06/09/2016</remarks>
    public class NavigationDTO<T> : BaseDTO where T : IBaseDTO
    {
        #region Property
            
        private Enum.Module.EModule _Module;
        /// <summary>
        /// Module
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par snippet v1.0</remarks>
        [DataMember]
        public Enum.Module.EModule Module
        {
            get { return _Module; }
            set
            {
                _Module = value;
            }
        }

        private T _ObjectDTO;
        /// <summary>
        /// ObjectDTO
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par snippet v1.0</remarks>
        [DataMember]
        public T ObjectDTO
        {
            get { return _ObjectDTO; }
            set
            {
                _ObjectDTO = value;
            }
        }

        #endregion

    }
}
