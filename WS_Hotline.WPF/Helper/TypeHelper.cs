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
    /// Classe Helper Sur les Type
    /// </summary>
    /// <remarks>LOUIS YOann 06/09/2016</remarks>
    public class TypeHelper
    {
        /// <summary>
        /// Convertie une liste de IBaseDTO en un Type DTO 
        /// </summary>
        /// <typeparam name="T">Type du DTO</typeparam>
        /// <param name="pList">Liste de IBaseDTO</param>
        /// <returns>ObservableCOllection De T</returns>
        /// <remarks>LOUIS YOann 06/09/2016</remarks>
        public static ObservableCollection<T> ListIToObservableObject<T>(List<IBaseDTO> pList) where T : IBaseDTO
        {
            // yl - Initalisation de l'observable Collection
            var lListResult = new ObservableCollection<T>();
            // yl - Convertion de l'objet
            pList.ForEach(pDTO =>
            {
                lListResult.Add((T)pDTO);
            });
            // yl - Retour du resultat
            return lListResult;
        }
    }
}
