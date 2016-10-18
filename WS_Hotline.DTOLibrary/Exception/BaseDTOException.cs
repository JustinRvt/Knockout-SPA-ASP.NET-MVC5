using WS_Hotline.Framework.AccesDonnees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DTOLibrary.Exception
{
    /// <summary>
    /// Exception de type DTO
    /// </summary>
    /// <typeparam name="DTOType">DTO sur lequel l'erreur se leve</typeparam>
    public class BaseDTOException<DTOType> : System.Exception where DTOType : IBaseDTO
    {
        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks>LOUIS Yoann - 18-02-2016</remarks>
        public BaseDTOException()
            : base()
        { }

        /// <summary>
        /// Constructeur avec message
        /// </summary>
        /// <param name="pMessage">Message de l'exception</param>
        /// <remarks>LOUIS Yoann - 18-02-2016</remarks>
        public BaseDTOException(string pMessage)
            : base(pMessage)
        { }

        /// <summary>
        /// Constructeur avec innner exception, message generer en automatique
        /// </summary>
        /// <param name="pInnrException">Inner exception</param>
        /// <remarks>LOUIS Yoann - 18-02-2016</remarks>
        public BaseDTOException(System.Exception pInnrException)
            : base(GetMessage(), pInnrException)
        { }

        /// <summary>
        /// Constructeur avec message et inner exception
        /// </summary>
        /// <param name="pMessage">Message</param>
        /// <param name="pInnrException">Inner exception</param>
        /// <remarks>LOUIS Yoann - 18-02-2016</remarks>
        public BaseDTOException(string pMessage, System.Exception pInnrException)
            : base(pMessage, pInnrException)
        { }

        /// <summary>
        /// Constructeur pour serialisation
        /// </summary>
        /// <param name="pInfo">Info</param>
        /// <param name="pContext">Context</param>
        /// <remarks>LOUIS Yoann - 18-02-2016</remarks>
        protected BaseDTOException(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        { }

        #endregion

        #region Methode

        /// <summary>
        /// Recuperation Type
        /// </summary>
        /// <returns>Message</returns>
        /// <remarks>LOUIS Yoann 18/02/2016</remarks>
        public static string GetMessage()
        {
            var lNomObject = typeof(DTOType).Name.Replace("DTO", "");
            return lNomObject + " non valide";
        }

        #endregion

    }
}
