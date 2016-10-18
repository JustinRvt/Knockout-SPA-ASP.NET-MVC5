using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.DataAccessLayer.Entities.Dossier;
using Demo.DTOLibrary.Entities.Dossier;

namespace UnitTestDAL.Entities.Dossier
{
    /// <summary>
    /// Classe de test unitaire sur la classe DossierDAL
    /// </summary>
    /// <remarks>ylouis - 06/09/2016 - Généré par Template T4 v1.0</remarks>
    [TestClass]
    public class DossierDALTest
    {
        /// <summary>
        /// Test sur la configuration du DossierDAL
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
		[ExpectedException(typeof(System.NullReferenceException), "La fonction n'as pas lever l'exception alors que le DossierDAL n'es pas configurer dans le proxy.")]
        public void ConfigurationDossierDALTest()
        {
            // yl - Creation du context
            var lContext = new Demo.DataAccessLayer.BDD.DemoDbContext();
            // yl -  On oublie volontairement de mettre le context
            // yl - Creation de l'object DAL
            DossierDAL lService = new DossierDAL(lContext);
            // yl - Recuperation d'items
            var lListeDossier = lService.GetItems(new CritereDossierDTO());
        }
    }
}

		