using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.DataAccessLayer.Entities.Ecriture;
using Demo.DTOLibrary.Entities.Ecriture;

namespace UnitTestDAL.Entities.Ecriture
{
    /// <summary>
    /// Classe de test unitaire sur la classe EcritureDAL
    /// </summary>
    /// <remarks>ylouis - 06/09/2016 - Généré par Template T4 v1.0</remarks>
    [TestClass]
    public class EcritureDALTest
    {
        /// <summary>
        /// Test sur la configuration du EcritureDAL
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
		[ExpectedException(typeof(System.NullReferenceException), "La fonction n'as pas lever l'exception alors que le EcritureDAL n'es pas configurer dans le proxy.")]
        public void ConfigurationEcritureDALTest()
        {
            // yl - Creation du context
            var lContext = new Demo.DataAccessLayer.BDD.DemoDbContext();
            // yl -  On oublie volontairement de mettre le context
            // yl - Creation de l'object DAL
            EcritureDAL lService = new EcritureDAL(lContext);
            // yl - Recuperation d'items
            var lListeEcriture = lService.GetItems(new CritereEcritureDTO());
        }
    }
}

		