using WS_Hotline.DTOLibrary.Business.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DTOLibrary.Helper
{
    public class ExceptionToExceptionDTOHelper
    {
        /// <summary>
        /// Convert Exception in ExceptionDTO
        /// </summary>
        /// <param name="pEx">Exception</param>
        /// <returns>ExceptionDTO</returns>
        /// <remarks>LOUIS Yoann 18/02/2016</remarks>
        public static ExceptionDTO ConvertToExceptionDTO(System.Exception pEx)
        {
            // yl - initialisaton de la variable
            var lException = new ExceptionDTO();
            // yl - Recuperation du type
            lException.Type = pEx.GetType().Name;
            // yl - Recuperation du message
            lException.Message = pEx.Message;
            // yl - si il y a une inner exception
            if (pEx.InnerException != null)
                lException.InnerException = ConvertToExceptionDTO(pEx.InnerException);
            // yl - retourne ExceptionDTO
            return lException;
        }
    }
}
