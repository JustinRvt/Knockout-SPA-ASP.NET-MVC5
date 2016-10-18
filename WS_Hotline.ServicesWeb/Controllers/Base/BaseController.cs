using WS_Hotline.DomainLibrary;
using WS_Hotline.DTOLibrary.Info;
using WS_Hotline.DTOLibrary.Methodes;
using WS_Hotline.Framework.AccesDonnees;
using WS_Hotline.ServicesWeb.Ressources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WS_Hotline.ServicesWeb.Controllers.Base
{
    /// <summary>
    /// Contrôleur de base qui implémente toutes les fonctions pour accéder au metier
    /// </summary>
    /// <typeparam name="MetierType">Classe metier</typeparam>
    /// <typeparam name="DTOType">Classe DTO</typeparam>
    /// <typeparam name="CritereDTOType">Classe Critère DTO</typeparam>
    /// <remarks>YL/GB 06/10/2015</remarks>
    public abstract class BaseController<MetierType, DTOType, CritereDTOType> : Controller
        where MetierType : IBaseMetier, new()
        where DTOType : IBaseDTO
        where CritereDTOType : IBaseDTO, new()
    {

        //gb - Déclaration de la variable contenant le chemin complet des types d'objet
        const string FormatStringDTO = "SCA.DTOLibrary.Methodes.Parametres.{0}, SCA.DTOLibrary";

        #region METHODS

        /// <summary>
        /// Recuperation de la Sessions
        /// </summary>
        /// <returns>InfoSessionDTO</returns>
        /// <remarks>LOUIS Yoann 29/06/2015</remarks>
        protected InfoSessionDTO GetInfoSession()
        {
            // yl - recuperation de la session
            var lInfoSession = Session["InfoSession"] as InfoSessionDTO ?? new InfoSessionDTO();
            // yl - intancie l'infoSession
            if (lInfoSession.ParamsSession == null)
                lInfoSession.ParamsSession = new Dictionary<string, object>();
            // yl - Update de la session
            this.SaveInfoSession(lInfoSession);
            // yl - return l'info sessions
            return lInfoSession;
        }

        /// <summary>
        /// Recuperation de la Sessions
        /// </summary>
        /// <param name="pCulture">Culture</param>
        /// <returns>InfoSessionDTO</returns>
        /// <remarks>LOUIS Yoann 29/06/2015</remarks>
        protected InfoSessionDTO GetInfoSession(string pCulture)
        {
            // yl - recuperation de la session
            var lInfoSession = Session["InfoSession"] as InfoSessionDTO ?? new InfoSessionDTO();
            // yl - intancie l'infoSession
            if (lInfoSession.ParamsSession == null)
                lInfoSession.ParamsSession = new Dictionary<string, object>();
            //am - Affecter de la langue selectionnée a notre Resource
            Resource.Culture = new System.Globalization.CultureInfo(pCulture);
            // yl - gestion de la culture
            lInfoSession.Culture = pCulture;
            // yl - Update de la session
            this.SaveInfoSession(lInfoSession);
            // yl - return l'info sessions
            return lInfoSession;
        }

        /// <summary>
        /// Sauvegarde de l'infoSession
        /// </summary>
        /// <param name="pInfoSession">InfoSession A sauvegarder</param>
        protected void SaveInfoSession(InfoSessionDTO pInfoSession)
        {
            // yl - Sauvegarde de l'infosession
            Session["InfoSession"] = pInfoSession;
        }

        #region GetItem

        /// <summary>
        /// Fonction permettant de récupérer un item en fonction du critère
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        public virtual ActionResult GetItem(CritereDTOType pCritere)
        {
            var data = GetItemInternal(pCritere);
            return View(data);
        }

        /// <summary>
        /// Fonction permettant de récupérer un item en fonction du critère
        /// au format JSON
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        public virtual ActionResult GetItemJson(CritereDTOType pCritere)
        {
            try
            {
                var data = GetItemInternal(pCritere);
                return JsonResult(data);
            }
            catch (Exception Ex)
            {
                // yl - retourne l'erreur en JSON
                return ThrowJSONError(Ex);
            }
        }

        /// <summary>
        /// Fonction générique de récupération un item an fonction du critère
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        private DTOType GetItemInternal(CritereDTOType pCritere)
        {
            var objetMetier = new MetierType();
            return (DTOType)objetMetier.GetItem(this.GetInfoSession(), pCritere);
        }

        #endregion

        #region GetItems

        /// <summary>
        /// Fonction permettant de récupérer les items
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        public virtual ActionResult GetItems()
        {
            return GetItems(new CritereDTOType());
        }

        /// <summary>
        /// Fonction générique de récupération des items en fonction du critère
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        [HttpPost]
        public virtual ActionResult GetItems(CritereDTOType pCritere)
        {
            var data = GetItemsInternal(pCritere);
            return View(data);
        }

        /// <summary>
        /// Fonction permettant de récupérer les items en fonction du critère
        /// au format JSON
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        public virtual ActionResult GetItemsJson(CritereDTOType pCritere)
        {
            try
            {
                var data = GetItemsInternal(pCritere);
                return JsonResult(data);
            }
            catch (Exception Ex)
            {
                // yl - retourne l'erreur en JSON
                return ThrowJSONError(Ex);
            }
        }

        /// <summary>
        /// Fonction générique de récupération les items en fonction du critère
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        private IEnumerable<DTOType> GetItemsInternal(CritereDTOType pCritere)
        {
            var objetMetier = new MetierType();
            return objetMetier.GetItems(this.GetInfoSession(), pCritere).Cast<DTOType>();
        }

        #endregion

        #region UpdateItem

        /// <summary>
        /// Méthode de mise à jour d'un Item
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        [HttpPost]
        public virtual void UpdateItem(DTOType pItem)
        {
            try
            {
                UpdateItemInternal(pItem);
            }
            catch (Exception Ex)
            {
                // yl - retourne l'erreur en JSON
                ThrowJSONError(Ex);
            }
        }

        /// <summary>
        /// Méthode générique de mise à jour d'un Item
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        private void UpdateItemInternal(DTOType pItem)
        {
            var objetMetier = new MetierType();
            objetMetier.UpdateItem(this.GetInfoSession(), pItem);
        }

        #endregion

        #region UpdateItems

        /// <summary>
        /// Méthode de mise à jour de plusieurs items
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        [HttpPost]
        public virtual void UpdateItems(IEnumerable<DTOType> pItems)
        {
            try
            {
                UpdateItemsInternal(pItems);
            }
            catch (Exception Ex)
            {
                // yl - retourne l'erreur en JSON
                ThrowJSONError(Ex);
            }
        }

        /// <summary>
        /// Méthode générique de mise à jour de plusieurs items
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        private void UpdateItemsInternal(IEnumerable<DTOType> pItems)
        {
            var objetMetier = new MetierType();
            objetMetier.UpdateItems(this.GetInfoSession(), pItems.Cast<IBaseDTO>());
        }

        #endregion

        #region AddItem

        /// <summary>
        /// Méthode d'ajout d'un item
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        [HttpPost]
        public virtual ActionResult AddItem(DTOType pItem)
        {
            try
            {
                var lData = AddItemInternal(pItem);
                return JsonResult(lData);
            }
            catch (Exception Ex)
            {
                // yl - retourne l'erreur en JSON
                return ThrowJSONError(Ex);
            }
        }

        /// <summary>
        /// Méthode générique d'ajout d'un item
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        private DTOType AddItemInternal(DTOType pItem)
        {
            var objetMetier = new MetierType();
            return (DTOType)objetMetier.AddItem(this.GetInfoSession(), pItem);
        }

        #endregion

        #region AddItems

        /// <summary>
        /// Méthode d'ajout d'une liste d'item
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        [HttpPost]
        public virtual void AddItems(IEnumerable<DTOType> pItems)
        {
            try
            {
                AddItemsInternal((IEnumerable<DTOType>)pItems);
            }
            catch (Exception Ex)
            {
                // yl - retourne l'erreur en JSON
                ThrowJSONError(Ex);
            }
        }

        /// <summary>
        /// Méthode générique d'ajout d'une liste d'item
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        private void AddItemsInternal(IEnumerable<DTOType> pItems)
        {
            var objetMetier = new MetierType();
            objetMetier.AddItems(this.GetInfoSession(), pItems.Cast<IBaseDTO>());
        }

        #endregion

        #region RemoveItems

        /// <summary>
        /// Méthode de suppression d'un item en fonction du critère
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        [HttpPost]
        public virtual void RemoveItems(CritereDTOType pCritere)
        {
            try
            {
                RemoveItemsInternal(pCritere);
            }
            catch (Exception Ex)
            {
                // yl - retourne l'erreur en JSON
                ThrowJSONError(Ex);
            }
        }

        /// <summary>
        /// Méthode générique de suppression d'un item en fonction du critère
        /// </summary>
        /// <returns>Item</returns>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        private void RemoveItemsInternal(CritereDTOType pCritere)
        {
            var objetMetier = new MetierType();
            objetMetier.RemoveItems(this.GetInfoSession(), pCritere);
        }

        #endregion

        #region ExecuteVoid

        /// <summary>
        /// Méthode permettant d'appeler une méthode de la classe métier
        /// via un appel AJAX
        /// </summary>
        /// <param name="pMethode">Méthode à appeler</param>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        [HttpPost]
        public virtual void ExecuteVoidAJAX(MethodDTO pMethode)
        {
            //gb - Récupération de l'objet au format string
            string lValue = ((string[])(pMethode.Parametrage))[0];
            //gb - Convertion de l'objet au format JObject
            Newtonsoft.Json.Linq.JObject lData = JsonConvert.DeserializeObject<dynamic>(lValue);
            //gb - Convertion de l'objet au format choisi
            pMethode.Parametrage = lData.ToObject(Type.GetType(String.Format(FormatStringDTO, pMethode.DTOStringType)));
            //gb - Appel la méthode ExecuteVoid du métier
            ExecuteVoidInternal(pMethode);
        }

        /// <summary>
        /// Méthode permettant d'appeler une méthode de la classe métier
        /// </summary>
        /// <param name="pMethode">Méthode à appeler</param>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        [HttpPost]
        public virtual void ExecuteVoid(MethodDTO pMethode)
        {
            ExecuteVoidInternal(pMethode);
        }

        /// <summary>
        /// Méthode générique permettant d'appeler une méthode de la classe métier
        /// </summary>
        /// <param name="pMethode">Méthode à appeler</param>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        private void ExecuteVoidInternal(MethodDTO pMethode)
        {
            var objetMetier = new MetierType();
            objetMetier.ExecuteVoid(this.GetInfoSession(), pMethode);
        }

        #endregion

        #region ExecuteFunction

        /// <summary>
        /// Fonction permettant d'appeler une fonction de la classe métier
        /// et de retourner la vue correspondante
        /// </summary>
        /// <param name="pMethode">Fonction à appeler</param>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        [HttpPost]
        public virtual void ExecuteFunction(MethodDTO pMethode)
        {

            var data = ExecuteFunctionInternal(pMethode);

        }

        /// <summary>
        /// Fonction permettant d'appeler une fonction de la classe métier
        /// et de retourner le résultat au format JSON
        /// </summary>
        /// <param name="pMethode">Fonction à appeler</param>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        [HttpPost]
        public virtual ActionResult ExecuteFunctionJson(MethodDTO pMethode)
        {
            try
            {
                var data = ExecuteFunctionInternal(pMethode);
                return JsonResult(data);
            }
            catch (Exception Ex)
            {
                // yl - retourne l'erreur en JSON
                return ThrowJSONError(Ex);
            }
        }

        /// <summary>
        /// Fonction générique permettant d'appeler une fonction de la classe métier
        /// </summary>
        /// <param name="pMethode">Fonction à appeler</param>
        /// <remarks>GB / YL - 2015-06-24 - Création</remarks>
        private object ExecuteFunctionInternal(MethodDTO pMethode)
        {
            var objetMetier = new MetierType();
            return objetMetier.ExecuteFunction(this.GetInfoSession(), pMethode);
        }

        #endregion

        #endregion

        #region Fonction Serialisation JSON

        /// <summary>
        /// Fonction de serialisation JSON pour contourner le probléme de Reference circulaire
        /// </summary>
        /// <param name="data">Element a sériazliser</param>
        /// <returns>Element serialiser en JSON</returns>
        /// <remarks>LOUIS Yoann 26/06/2015</remarks>
        protected ContentResult JsonResult(object data)
        {
            // yl - Initialisation des varaiables
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            var lResult = new ContentResult();
            // yl - On ignore les reference circulaire
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            // yl - Serialisation
            lResult.Content = JsonConvert.SerializeObject(data, Formatting.None, jsSettings);
            // yl - on indique le retour en JSON
            lResult.ContentType = "application/json";
            // yl - Retour
            return lResult;
        }

        /// <summary>
        /// Lever une exception JSON
        /// </summary>
        /// <param name="e">Exception</param>
        /// <returns>Exception JSON</returns>
        /// <remarks>LOUIS Yoann 18/02/2016</remarks>
        protected ContentResult ThrowJSONError(Exception pEx)
        {
            // yl - on indique qu'un probléme est survenu
            Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            //yl - SerialisationJSon de l'erreur
            return JsonResult(Helper.ExceptionDTOHelper.GetExceptionDTO(pEx, this.GetInfoSession()));

        }

        #endregion

    }
}