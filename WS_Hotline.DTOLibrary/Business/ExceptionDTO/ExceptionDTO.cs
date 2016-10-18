using WS_Hotline.Framework.Domain.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DTOLibrary.Business.Exception
{
    /// <summary>
    /// Classe DTO permettant de gérer Exception
    /// </summary>
    /// <remark>ylouis - 18/02/2016 - Généré par snippet v1.0</remark>
    [DataContract]
    public class ExceptionDTO : BaseDTO
    {
        #region property

        private string _Type;
        /// <summary>
        /// Type de l'exception
        /// </summary>
        /// <remarks>ylouis - 18/02/2016 - Généré par snippet v1.0</remarks>
        [DataMember]
        public string Type
        {
            get { return _Type; }
            set
            {
                _Type = value;
            }
        }

        private string _Message;
        /// <summary>
        /// Message erreur
        /// </summary>
        /// <remarks>ylouis - 18/02/2016 - Généré par snippet v1.0</remarks>
        [DataMember]
        public string Message
        {
            get { return _Message; }
            set
            {
                _Message = value;
            }
        }

        #endregion

        #region Liaison

        private ExceptionDTO _InnerException;
        /// <summary>
        /// InnerException
        /// </summary>
        /// <remarks>ylouis - 18/02/2016 - Généré par snippet v1.0</remarks>
        [DataMember]
        public ExceptionDTO InnerException
        {
            get { return _InnerException; }
            set
            {
                _InnerException = value;
            }
        }

        #endregion
    }
}
