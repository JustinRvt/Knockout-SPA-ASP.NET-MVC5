using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.DataAccessLayer.Entities.Compte;
using Demo.DTOLibrary.Entities.Compte;

namespace UnitTestDAL.Entities.Compte
{
    /// <summary>
    /// Classe de test unitaire sur la classe CompteDAL
    /// </summary>
    /// <remarks>ylouis - 06/09/2016 - Généré par Template T4 v1.0</remarks>
    [TestClass]
    public class CompteDALTest
    {
        /// <summary>
        /// Test sur la configuration du CompteDAL
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
		[ExpectedException(typeof(System.NullReferenceException), "La fonction n'as pas lever l'exception alors que le CompteDAL n'es pas configurer dans le proxy.")]
        public void ConfigurationCompteDALTest()
        {
            // yl - Creation du context
            var lContext = new Demo.DataAccessLayer.BDD.DemoDbContext();
            // yl -  On oublie volontairement de mettre le context
            // yl - Creation de l'object DAL
            CompteDAL lService = new CompteDAL(lContext);
            // yl - Recuperation d'items
            var lListeCompte = lService.GetItems(new CritereCompteDTO());
        }
    }
}

		