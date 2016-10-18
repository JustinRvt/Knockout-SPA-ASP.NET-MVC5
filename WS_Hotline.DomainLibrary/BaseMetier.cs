using WS_Hotline.DomainLibrary.Helper;
using WS_Hotline.DTOLibrary.Info;
using WS_Hotline.DTOLibrary.Exception;
using WS_Hotline.Framework.AccesDonnees;
using WS_Hotline.Framework.Domain.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DomainLibrary
{
    /// <summary>
    /// Classe modèle pour les classes métier
    /// </summary>
    /// <typeparam name="DALType">Classe de DAL à utiliser</typeparam>
    /// <typeparam name="DTOType">Object DTO en relation avec le métier</typeparam>
    /// <typeparam name="CritereDTOType">Critère de sélection des DTO</typeparam>
    /// <remarks>LOUIS YOANN - 2015-09-24 - Création Via Reprise d'EFORM</remarks>
    public abstract class BaseMetier<DALType, DTOType, CritereDTOType, ExceptionType> : IBaseMetier
        where DALType : IRepository<DTOType>, new()
        where DTOType : IBaseDTO, new()
        where CritereDTOType : SearchCriteria<DTOType>, new()
        where ExceptionType : BaseDTOException<DTOType>, new()
    {
        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remarks>Guillaume Bécard - 2015-06-24 - Création</remarks>
        public BaseMetier()
        {

        }

        #endregion

        #region VIRTUAL METHODS

        /// <summary>
        /// Fonction permettant de retourner la liste des items
        /// en fonction du critère de sélection
        /// </summary>
        /// <param name="pCritere">Critère de sélection</param>
        /// <returns>Liste d'objet DTO</returns>
        /// <remarks>Guillaume Bécard - 2015-06-24 - Création</remarks>
        public virtual IEnumerable<IBaseDTO> GetItems(InfoSessionDTO pInfoSession, IBaseDTO pCritere)
        {
            try
            {
                // yl - Log
                WriteDebugLogger(pInfoSession);

                // yl - Validation Critere
                this.ValidatedCritere(pCritere);

                //gb - Déclaration du service
                DALType lService = new DALType();
                //gb - Appel de la fonction de récupération des items
                return lService.GetItems(pCritere as CritereDTOType).List.Cast<IBaseDTO>();
            }
            catch (Exception lEx)
            {
                // yl - ecriture d'un log d'erreur
                WriteErrorLogger(pInfoSession, lEx);
                // yl - on leve une exception de type ExceptionType avec en iner exception l'exception catcher
                throw (ExceptionType)Activator.CreateInstance(typeof(ExceptionType),lEx);
            }
        }

        /// <summary>
        /// Fonction permettant de retourner l'objet
        /// correspondant au critère de sélection
        /// </summary>
        /// <param name="pCritere">Critère de sélection</param>
        /// <returns>Objet DTO</returns>
        /// <remarks>Guillaume Bécard - 2015-06-24 - Création</remarks>
        public virtual IBaseDTO GetItem(InfoSessionDTO pInfoSession, IBaseDTO pCritere)
        {
            try
            {
                // yl - Log
                WriteDebugLogger(pInfoSession);

                // yl - Validation Critere
                this.ValidatedCritere(pCritere);

                //gb - Déclaration du service
                DALType lService = new DALType();
                //gb - Appel de la fonction de récupération de l'item
                return lService.GetItem(pCritere as CritereDTOType);
            }
            catch (Exception lEx)
            {
                WriteErrorLogger(pInfoSession, lEx);
                throw (ExceptionType)Activator.CreateInstance(typeof(ExceptionType), lEx);
            }
        }

        /// <summary>
        /// Fonction permettant d'appeler la fonction correspondant
        /// au critère en paramètre
        /// </summary>
        /// <param name="pMethod">Fonction à appeler</param>
        public virtual IBaseDTO AddItem(InfoSessionDTO pInfoSession, IBaseDTO pEntity)
        {

            try
            {
                // yl - Log
                WriteDebugLogger(pInfoSession);

                // yl - Validation Entity
                this.ValidatedDTO(pEntity);

                // yl - msie en place du service
                DALType lService = new DALType();
                // yl - Cast
                var lEntity = (DTOType)pEntity;
                // yl - Ajout
                return lService.AddItem(lEntity);
            }
            catch (Exception lEx)
            {
                WriteErrorLogger(pInfoSession, lEx);
                throw (ExceptionType)Activator.CreateInstance(typeof(ExceptionType), lEx);
            }
        }

        /// <summary>
        /// Ajouter d'une liste de DTO 
        /// </summary>
        /// <param name="pEntities">Liste de DTO</param>
        /// <remarks>LOUIS YOANN 24/06/2015</remarks>
        public virtual void AddItems(InfoSessionDTO pInfoSession, IEnumerable<IBaseDTO> pEntities)
        {
            try
            {
                // yl - Log
                WriteDebugLogger(pInfoSession);

                // yl - Validation Entity
                pEntities.ToList().ForEach(this.ValidatedDTO);

                // yl - msie en place du service
                DALType lService = new DALType();
                // yl - Cast
                var lEntity = pEntities.Cast<DTOType>();
                // yl - Ajout
                lService.AddItems(lEntity);
            }
            catch (Exception lEx)
            {
                WriteErrorLogger(pInfoSession, lEx);
                throw (ExceptionType)Activator.CreateInstance(typeof(ExceptionType), lEx);
            }
        }

        /// <summary>
        /// Update un DTO
        /// </summary>
        /// <param name="pEntity">DTO a lmettre a jour</param>
        /// <remarks>LOUIS YOANN 24/06/2015</remarks>
        public virtual void UpdateItem(InfoSessionDTO pInfoSession, IBaseDTO pEntity)
        {
            try
            {
                // yl - Log
                WriteDebugLogger(pInfoSession);

                // yl - Validation Entity
                this.ValidatedDTO(pEntity);

                // yl - msie en place du service
                DALType lService = new DALType();
                // yl - Cast
                var lEntity = (DTOType)pEntity;
                // yl - Update
                lService.UpdateItem(lEntity);
            }
            catch (Exception lEx)
            {
                WriteErrorLogger(pInfoSession, lEx);
                throw (ExceptionType)Activator.CreateInstance(typeof(ExceptionType), lEx);
            }
        }

        /// <summary>
        /// Update une liste de DTO
        /// </summary>
        /// <param name="pEntities">liste de DTO a mettre a jour</param>
        /// <remarks>LOUIS YOANN 24/06/2015</remarks>
        public virtual void UpdateItems(InfoSessionDTO pInfoSession, IEnumerable<IBaseDTO> pEntities)
        {
            try
            {
                // yl - Log
                WriteDebugLogger(pInfoSession);

                // yl - Validation Entity
                pEntities.ToList().ForEach(this.ValidatedDTO);

                // yl - msie en place du service
                DALType lService = new DALType();
                // yl - Cast
                var lEntity = pEntities.Cast<DTOType>();
                // yl - Update
                lService.UpdateItems(lEntity);
            }
            catch (Exception lEx)
            {
                WriteErrorLogger(pInfoSession, lEx);
                throw (ExceptionType)Activator.CreateInstance(typeof(ExceptionType), lEx);
            }
        }

        /// <summary>
        /// Supprimer des elment
        /// </summary>
        /// <param name="pCritere">Critere des element a suppruimer</param>
        /// <remarks>LOUIS YOANN 24/06/2015</remarks>
        public virtual void RemoveItems(InfoSessionDTO pInfoSession, IBaseDTO pCritere)
        {
            try
            {
                // yl - Log
                WriteDebugLogger(pInfoSession);

                DALType lService = new DALType();
                // yl - remove
                lService.RemoveItems(pCritere as CritereDTOType);
            }
            catch (Exception lEx)
            {
                WriteErrorLogger(pInfoSession, lEx);
                throw (ExceptionType)Activator.CreateInstance(typeof(ExceptionType), lEx);
            }
        }

        public virtual object ExecuteFunction(InfoSessionDTO pInfoSession, DTOLibrary.Methodes.MethodDTO pMethod)
        {
            try
            {
                // yl - Log
                WriteDebugLogger(pInfoSession);

                //gb - Récupération du type en cours
                Type lType = this.GetType();
                //gb - Récupération de la méthode à appeler
                MethodInfo lInfoMethod = lType.GetMethod(pMethod.NomMethode, BindingFlags.NonPublic | BindingFlags.Instance);
                //gb - Appel de la méthode
                return lInfoMethod.Invoke(this, new object[] { pMethod.Parametrage });
            }
            catch (Exception lEx)
            {
                WriteErrorLogger(pInfoSession, lEx);
                throw (ExceptionType)Activator.CreateInstance(typeof(ExceptionType), lEx);
            }
        }

        /// <summary>
        /// Méthode permettant d'appeler la méthode correspondante
        /// au critère en paramètre
        /// </summary>
        /// <param name="pMethod">Méthode à appeler</param>
        /// <remarks>Guillaume Bécard - 2015-06-24 - Création</remarks>
        public virtual void ExecuteVoid(InfoSessionDTO pInfoSession, DTOLibrary.Methodes.MethodDTO pMethod)
        {
            try
            {
                // yl - Log
                WriteDebugLogger(pInfoSession);

                //gb - Récupération du type en cours
                Type lType = this.GetType();
                //gb - Récupération de la méthode à appeler
                MethodInfo lInfoMethod = lType.GetMethod(pMethod.NomMethode, BindingFlags.NonPublic | BindingFlags.Instance);
                //gb - Appel de la méthode
                lInfoMethod.Invoke(this, new object[] { pMethod.Parametrage });
            }
            catch (Exception lEx)
            {
                WriteErrorLogger(pInfoSession, lEx);
                throw (ExceptionType)Activator.CreateInstance(typeof(ExceptionType), lEx);
            }
        }

        /// <summary>
        /// Valide le Critere de recherche
        /// </summary>
        /// <param name="pCritere">Critere de recherche du DTO</param>
        /// <remarks>LOUIS Yoann 11/02/2016</remarks>
        public virtual void ValidatedCritere(IBaseDTO pCritere)
        {
            // yl - test que le type de l'object et bien du type CritereDTOType
            ValidateType<CritereDTOType>(pCritere);
        }

        /// <summary>
        /// Valide le DTO 
        /// </summary>
        /// <param name="pEntity">Entité a valider</param>
        /// <remarks>LOUIS Yoann 11/02/2016</remarks>
        public virtual void ValidatedDTO(IBaseDTO pEntity)
        {
            // yl - test que le type de l'object et bien du type DTOType
            ValidateType<DTOType>(pEntity);
        }

        /// <summary>
        /// Fonction de validation de Type
        /// </summary>
        /// <typeparam name="T">Type attendu</typeparam>
        /// <param name="pObject">Objet a test</param>
        /// <remarks>LOUIS Yoann 12/02/2016</remarks>
        public static void ValidateType<T>(IBaseDTO pObject)
        {
            if ((pObject is T) == false) throw new DTOLibrary.Exception.GeneriqueException.TypeException<T>();
        }

        #endregion

        #region Log

        /// <summary>
        /// Ecrie un log avec le nom de la methode et le DTO qui va avec
        /// </summary>
        /// <param name="pInfoSession">info sur la session</param>
        /// <param name="pNameMethode">Nom de la methode</param>
        /// <remarks>LOUIS Yoann 24/09/2015</remarks>
        private void WriteDebugLogger(InfoSessionDTO pInfoSession)
        {
            // yl - Ecrie le log
            CLogger.WriteDebugLog(pInfoSession, this.GetType().Name + ".<" + typeof(DTOType).Name + ">" + CLogger.GetCallingMethodeName(), "Debug");
        }

        /// <summary>
        /// Ecrie un log avec le nom de la methode et le DTO qui va avec
        /// </summary>
        /// <param name="pInfoSession">info sur la session</param>
        /// <param name="pNameMethode">Nom de la methode</param>
        /// <remarks>LOUIS Yoann 24/09/2015</remarks>
        private void WriteErrorLogger(InfoSessionDTO pInfoSession, Exception pEx)
        {
            // yl - Ecrie le log
            CLogger.WriteErrorLog(pInfoSession, this.GetType().Name + ".<" + typeof(DTOType).Name + ">" + CLogger.GetCallingMethodeName(), CLogger.GetMessageException(pEx));
        }



        /// <summary>
        /// Ecrie un log avec le nom de la methode et le DTO qui va avec
        /// </summary>
        /// <param name="pInfoSession">info sur la session</param>
        /// <param name="pNameMethode">Nom de la methode</param>
        /// <remarks>LOUIS Yoann 24/09/2015</remarks>
        private void WriteInfoLogger(InfoSessionDTO pInfoSession, string pMessage)
        {
            // yl - Ecrie le log
            CLogger.WriteInfoLog(pInfoSession, this.GetType().Name + ".<" + typeof(DTOType).Name + ">" + CLogger.GetCallingMethodeName(), pMessage);
        }

        #endregion


        public object lEx { get; set; }
    }
}
