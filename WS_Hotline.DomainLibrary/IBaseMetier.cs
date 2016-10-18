using WS_Hotline.DTOLibrary.Info;
using WS_Hotline.Framework.AccesDonnees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DomainLibrary
{
    /// <summary>
    /// Interface des classes métiers
    /// </summary>
    /// <remarks>LOUIS YOANN - 2016-07-08 - Création Via Reprise d'EFORM</remarks>
    public interface IBaseMetier
    {
        /// <summary>
        /// Recuperer une liste de DTO selon les critere passer en paramettre
        /// </summary>
        /// <param name="pCritere">Critere de recherche du DTO</param>
        /// <returns>List de DTO</returns>
        /// <remarks>LOUIS YOANN 24/06/2015</remarks>
        IEnumerable<IBaseDTO> GetItems(InfoSessionDTO pInfoSession, IBaseDTO pCritere);

        /// <summary>
        /// Recuperer un DTO selon les critere passer en paramettre
        /// </summary>
        /// <param name="pCritere">Critere de recherche du DTO</param>
        /// <returns>DTO</returns>
        /// <remarks>LOUIS YOANN 24/06/2015</remarks>
        IBaseDTO GetItem(InfoSessionDTO pInfoSession, IBaseDTO pCritere);

        /// <summary>
        /// Ajouter un DTO 
        /// </summary>
        /// <param name="pEntity">DTO</param>
        /// <remarks>LOUIS YOANN 24/06/2015</remarks>
        IBaseDTO AddItem(InfoSessionDTO pInfoSession, IBaseDTO pEntity);

        /// <summary>
        /// Ajouter d'une liste de DTO 
        /// </summary>
        /// <param name="pEntities">Liste de DTO</param>
        /// <remarks>LOUIS YOANN 24/06/2015</remarks>
        void AddItems(InfoSessionDTO pInfoSession, IEnumerable<IBaseDTO> pEntities);

        /// <summary>
        /// Update un DTO
        /// </summary>
        /// <param name="pEntity">DTO a mettre a jour</param>
        /// <remarks>LOUIS YOANN 24/06/2015</remarks>
        void UpdateItem(InfoSessionDTO pInfoSession, IBaseDTO pEntity);

        /// <summary>
        /// Update une liste de DTO
        /// </summary>
        /// <param name="pEntities">liste de DTO a mettre a jour</param>
        /// <remarks>LOUIS YOANN 24/06/2015</remarks>
        void UpdateItems(InfoSessionDTO pInfoSession, IEnumerable<IBaseDTO> pEntities);

        /// <summary>
        /// Supprimer des elment
        /// </summary>
        /// <param name="pCritere">Critere des element a suppruimer</param>
        /// <remarks>LOUIS YOANN 24/06/2015</remarks>
        void RemoveItems(InfoSessionDTO pInfoSession, IBaseDTO pCritere);

        /// <summary>
        /// Execution Fonction metier avec retour
        /// </summary>
        /// <param name="pMethod">Methode</param>
        /// <returns>retour</returns>
        /// <remarks>LOUIS YOANN 24/06/2015</remarks>
        object ExecuteFunction(InfoSessionDTO pInfoSession, DTOLibrary.Methodes.MethodDTO pMethod);

        /// <summary>
        /// Execution sans retour
        /// </summary>
        /// <param name="pMethod">Methode</param>
        /// <remarks>LOUIS YOANN 24/06/2015</remarks>
        void ExecuteVoid(InfoSessionDTO pInfoSession, DTOLibrary.Methodes.MethodDTO pMethod);

        /// <summary>
        /// Valide le Critere de recherche
        /// </summary>
        /// <param name="pCritere">Critere de recherche du DTO</param>
        /// <remarks>LOUIS Yoann 11/02/2016</remarks>
        void ValidatedCritere(IBaseDTO pCritere);

        /// <summary>
        /// Valide le DTO 
        /// </summary>
        /// <param name="pEntity">Entité a valider</param>
        /// <remarks>LOUIS Yoann 11/02/2016</remarks>
        void ValidatedDTO(IBaseDTO pEntity);
    }
}
