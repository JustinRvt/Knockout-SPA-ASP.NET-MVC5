using WS_Hotline.Framework.AccesDonnees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DataAccessLayer.BDD
{
    /// <summary>
    /// Classe correspondant au context de base de données
    /// </summary>
    /// <remarks>ylouis 08/07/2016 - Création</remarks>
    public class HotlineDbContext : DbContextBase<HotlineDbContext>
    {
        #region CSTR

        /// <summary>
        /// Definie BDDEMO comme contexte de base de données
        /// </summary>
        /// <remarks>ylouis 08/07/2016 - Création</remarks>
        public HotlineDbContext()
            : base("BDHotline")
        {

        }

        #endregion
    }
}
