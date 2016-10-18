using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WS_Hotline.DTOLibrary.Entities.Customer;

namespace WS_Hotline.DTOLibrary.Exception.CustomerException
{
        /// <summary>
            /// Exception sur le Type NomObject
            /// </summary>
            /// <remarks>jravat - 30092016 - Généré par snippet v1.0 </remarks>
    [Serializable]
    public class CustomerException : BaseDTOException<CustomerDTO>
    {
        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks>jravat - 30092016 - Généré par snippet v1.0 </remarks>
        public CustomerException()
            : base()
        { }

        /// <summary>
        /// Constructeur avec message
        /// </summary>
        /// <param name="pMessage">Message de l'exception</param>
        /// <remarks>jravat - 30092016 - Généré par snippet v1.0 </remarks>
        public CustomerException(string pMessage)
            : base(pMessage)
        { }

        /// <summary>
        /// Constructeur avec innner exception, message generer en automatique
        /// </summary>
        /// <param name="pInnrException">Inner exception</param>
        /// <remarks>jravat - 30092016 - Généré par snippet v1.0 </remarks>
        public CustomerException(System.Exception pInnrException)
            : base(pInnrException)
        { }

        /// <summary>
        /// Constructeur avec message et inner exception
        /// </summary>
        /// <param name="pMessage">Message</param>
        /// <param name="pInnrException">Inner exception</param>
        /// <remarks>jravat - 30092016 - Généré par snippet v1.0 </remarks>
        public CustomerException(string pMessage, System.Exception pInnrException)
            : base(pMessage, pInnrException)
        { }

        /// <summary>
        /// Constructeur pour serialisation
        /// </summary>
        /// <param name="pInfo">Info</param>
        /// <param name="pContext">Context</param>
        /// <remarks>jravat - 30092016 - Généré par snippet v1.0 </remarks>
        protected CustomerException(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        { }

        #endregion
    }
}

