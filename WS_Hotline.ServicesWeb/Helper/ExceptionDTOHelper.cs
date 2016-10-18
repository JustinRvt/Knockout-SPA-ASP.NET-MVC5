using WS_Hotline.DTOLibrary.Business.Exception;
using WS_Hotline.DTOLibrary.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Hotline.ServicesWeb.Helper
{
    /// <summary>
    /// Helper permetant de generer des ExceptionDTO a partir d'Exception
    /// </summary>
    /// <remarks>LOUIS Yoann 19/02/2016</remarks>
    public static class ExceptionDTOHelper
    {
        /// <summary>
        /// Convertie une exception en ExceptionDTO et effectue la 
        /// </summary>
        /// <param name="pEx">Exception</param>
        /// <param name="pInfoSession">information sur la session en cours</param>
        /// <returns>ExceptionDTO</returns>
        /// <remarks>LOUIS Yoann 19/02/2016</remarks>
        public static ExceptionDTO GetExceptionDTO(Exception pEx, InfoSessionDTO pInfoSession)
        {
            // yl - convertie l'exception en DTO
            var lDTO = DTOLibrary.Helper.ExceptionToExceptionDTOHelper.ConvertToExceptionDTO(pEx);
            // yl - convertie le message dans la bonne lange et le revoie.
            return GetExceptionRecupMessage(lDTO, pInfoSession);
        }

        /// <summary>
        /// Traduit les message de l'exception et de ses innerexception de manierre recurcive
        /// </summary>
        /// <param name="pEx">ExceptionDTO</param>
        /// <param name="pInfoSession">Information sur la session</param>
        /// <returns>ExceptionDTO traduit</returns>
        /// <remarks>LOUIS Yoann 19/02/2016</remarks>
        private static ExceptionDTO GetExceptionRecupMessage(ExceptionDTO pEx, InfoSessionDTO pInfoSession)
        {
            // yl - Gestion de l'onner exception
            if (pEx.InnerException != null)
                pEx.InnerException = GetExceptionRecupMessage(pEx.InnerException, pInfoSession);
            // yl - Traduction du message (uniquement si besoin)
            if (pEx.Message.Contains("[Ressource]"))
                pEx.Message = GetMessage(pEx.Message, pInfoSession);

            return pEx;
        }

        /// <summary>
        /// Recupere le message traduit si besoins
        /// </summary>
        /// <param name="pMessage">message a traduire eventuellemnt</param>
        /// <param name="pInfoSession">Information sur la session</param>
        /// <returns>message traduit</returns>
        /// <remarks>LOUIS Yoann - 18/02/2016</remarks>
        private static string GetMessage(string pMessage, InfoSessionDTO pInfoSession)
        {
            var lResult = "";
            // yl - Split du message
            var lListMessage = pMessage.Split('|');
            // yl - pour chaque message
            lListMessage.ToList().ForEach(p =>
            {
                // yl - si il y a la balise [Ressource]
                if (p.Contains("[Ressource]"))
                {
                    // yl - on traduit et on rajoute au message déjà recuperer
                    lResult = lResult + RessourceHelper.GetRessource(p.Replace("[Ressource]", ""), pInfoSession);
                }
                else
                {
                    // yl - on rajoute au message déjà recuperer
                    lResult = lResult + p;
                }
            });
            // yl - on retourne le message
            return lResult;
        }
    }
}