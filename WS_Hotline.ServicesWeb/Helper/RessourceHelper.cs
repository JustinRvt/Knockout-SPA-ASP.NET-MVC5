using WS_Hotline.DTOLibrary.Business.Ressource;
using WS_Hotline.DTOLibrary.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Hotline.ServicesWeb.Helper
{
    /// <summary>
    /// Helper de gestion de resssource
    /// </summary>
    /// <remarks>LOUIS Yoann 19/02/2016</remarks>
    public static class RessourceHelper
    {
        #region Variable

        /// <summary>
        /// Object permettant de recuperer les resources
        /// </summary>
        /// <remarks>LOUIS Yoann 19/02/2016</remarks>
        private static System.Resources.ResourceManager _ResourceManager = new global::System.Resources.ResourceManager("WS_Hotline.ServicesWeb.Ressources.Resource", typeof(ServicesWeb.Ressources.Resource).Assembly);

        #endregion

        #region Methode

        /// <summary>
        /// Recupere  la resource dans la langue de definie dans la session
        /// </summary>
        /// <param name="pNom">Resssource rechercher</param>
        /// <param name="pInfoSession">Info sur la sessions</param>
        /// <returns>Ressource traduide dans la langue de la session</returns>
        /// <remarks>LOUIS Yoann 19/02/2016</remarks>
        public static string GetRessource(string pNom, InfoSessionDTO pInfoSession)
        {
            // yl - SI pas de culture eon retourn du français
            var lCulture = pInfoSession.Culture;

            // yl - Recuperation de la ressource
            return _ResourceManager.GetString(pNom, System.Globalization.CultureInfo.GetCultureInfo(lCulture));
        }


        /// <summary>
        /// Recupere les resources dans la langue de la session
        /// </summary>
        /// <param name="pCritere">Critere de recherche</param>
        /// <param name="pInfoSession">Information sur la session</param>
        /// <returns>Liste de RessourceDTO</returns>
        /// <remarks>LOUIS Yoann 19/02/2016</remarks>
        public static List<RessourceDTO> GetListRessources(CritereRessourceDTO pCritere, InfoSessionDTO pInfoSession)
        {
            var lResult = new List<RessourceDTO>();

            var lCulture = System.Globalization.CultureInfo.GetCultureInfo(pInfoSession.Culture);

            pCritere.ListNomRessource.ToList().ForEach(pNom =>
            {
                // yl - Recuperation de la ressource
                lResult.Add(new RessourceDTO()
                {
                    Value = _ResourceManager.GetString(pNom, lCulture),
                    Nom = pNom,
                    Culture = pInfoSession.Culture
                });
            });

            return lResult;
        }

        #endregion

    }
}