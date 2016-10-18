using WS_Hotline.DomainLibrary;
using WS_Hotline.Framework.AccesDonnees;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.WPF.Helper
{
    /// <summary>
    /// Permet de facilité l'appel au metier
    /// </summary>
    /// <remarks>LOUIS YOANN 06/09/2016</remarks>
    public class ServiceMetierHelper
    {
        /// <summary>
        /// Retoune une liste d'items
        /// </summary>
        /// <typeparam name="TDTO">Type de dto</typeparam>
        /// <typeparam name="TMETIER">Type du metier</typeparam>
        /// <param name="pCritere">Critere de recherche</param>
        /// <returns>ObservableCollection de TDTO</returns>
        /// <remarks>LOUIS YOANN 06/09/2016</remarks>
        public static ObservableCollection<TDTO> GetItems<TDTO,TMETIER>(IBaseDTO pCritere)  
            where TDTO : IBaseDTO
            where TMETIER : IBaseMetier, new()
        {
            // yl - Initalisation Metier
            var lMetier = new TMETIER();
            var lListTmp = lMetier.GetItems(new DTOLibrary.Info.InfoSessionDTO(), pCritere).ToList();

            // yl - Convertir la liste
            return Helper.TypeHelper.ListIToObservableObject<TDTO>(lListTmp);
        }

        /// <summary>
        /// Permet de retourner un seul item
        /// </summary>
        /// <typeparam name="TDTO">Type de dto</typeparam>
        /// <typeparam name="TMETIER">type du metier</typeparam>
        /// <param name="pCritere">cvritere de recherche</param>
        /// <returns>TDTO</returns>
        /// <remarks>LOUIS YOANN 06/09/2016</remarks>
        public static TDTO GetItem<TDTO,TMETIER>(IBaseDTO pCritere)
            where TDTO : IBaseDTO
            where TMETIER : IBaseMetier, new()
        {
            // yl - Initalisation Metier
            var lMetier = new TMETIER();
            // yl - Convertir la liste
            return (TDTO)lMetier.GetItem(new DTOLibrary.Info.InfoSessionDTO(), pCritere);
        }

        /// <summary>
        /// pemret d'ajouter un nouvelle enregistrement
        /// </summary>
        ///  <typeparam name="TDTO">Type de dto</typeparam>
        /// <typeparam name="TMETIER">type du metier</typeparam>
        /// <param name="pEntity">Element a enregister</param>
        /// <returns>TDTO</returns>
        /// <remarks>LOUIS YOANN 06/09/2016</remarks>
        public static TDTO AddItem<TDTO, TMETIER>(TDTO pEntity)
            where TDTO : IBaseDTO
            where TMETIER : IBaseMetier, new()
        {
            // yl - Initalisation Metier
            var lMetier = new TMETIER();
            // yl - ajout de l'item
            return (TDTO)lMetier.AddItem(new DTOLibrary.Info.InfoSessionDTO(), pEntity);
        }

        /// <summary>
        /// pemret d'ajouter un nouvelle enregistrement
        /// </summary>
        ///  <typeparam name="TDTO">Type de dto</typeparam>
        /// <typeparam name="TMETIER">type du metier</typeparam>
        /// <param name="pEntity">Element a enregister</param>
        /// <remarks>LOUIS YOANN 06/09/2016</remarks>
        public static void UpdateItem<TDTO, TMETIER>(TDTO pEntity)
            where TDTO : IBaseDTO
            where TMETIER : IBaseMetier, new()
        {
            // yl - Initalisation Metier
            var lMetier = new TMETIER();
            // yl - modification de l'item
            lMetier.UpdateItem(new DTOLibrary.Info.InfoSessionDTO(), pEntity);
        }


        public void RemoveItems(DTOLibrary.Info.InfoSessionDTO pInfoSession, Framework.AccesDonnees.IBaseDTO pCritere)
        {
            throw new NotImplementedException();
        }

    }
}
