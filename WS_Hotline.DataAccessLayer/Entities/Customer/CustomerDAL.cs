using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using WS_Hotline.DTOLibrary.Entities.Customer;
using WS_Hotline.Framework.AccesDonnees;
using WS_Hotline.DataAccessLayer.BDD;

namespace UnitTestDAL.Entities.Customer
{
    /// <summary>
    /// Classe data acess layer de Name
    /// </summary>
    /// <remark>[jravat] - [30092016] - Généré par snippet v1.0</remark>
    public class CustomerDAL : Repository<CustomerDTO, HotlineDbContext>
    {
        #region CSTR

        /// <summary>
        /// Constructeur vide
        /// </summary>
        /// <remark>[jravat] - [30092016] - Généré par snippet v1.0</remark>
        public CustomerDAL()
            : base(new HotlineDbContext())
        {
            // [Initiale] - Gestion des liens vers les autres tables
            this.GestionInclude();
        }

        /// <summary>
        /// Constructeur avec paramètre
        /// </summary>
        /// <param name="pContext">Context de base de données</param>
        /// <remark>[jravat] - [30092016] - Généré par snippet v1.0</remark>
        public CustomerDAL(HotlineDbContext pContext)
            : base(pContext)
        {
            // [Initiale] - Gestion des liens vers les autres tables
            this.GestionInclude();
        }

        #endregion

        #region Include

        /// <summary>
        /// Gestion des liens vers les autres tables
        /// </summary>
        /// <remark>[jravat] - [30092016] - Généré par snippet v1.0</remark>
        private void GestionInclude()
        {
            // Exemple d'include
            //this.Add(p => p.Dossier, this.IncludeDossiers);
        }

        /*/// <summary>
        /// Include des dossiers
        /// </summary>
        /// <param name="pSource">Source</param>
        /// <returns>Include</returns>
       /// <remark>[jravat] - [30092016] - Généré par snippet v1.0</remark>
        private IQueryable<DossierSousCatDTO> IncludeDossiers(IQueryable<DossierSousCatDTO> pSource, Expression<Func<DossierSousCatDTO, object>> arg2, Framework.Domain.Query.SearchCriteria<DossierSousCatDTO> arg3)
        {
            // [Initiale] - Retourne liens
            return pSource.Include(p => p.Dossier);
        }*/

        #endregion

    }
}
