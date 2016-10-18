using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WS_Hotline.DataAccessLayer.Entities.Softlog;
using WS_Hotline.DTOLibrary.Entities.Softlog;

namespace UnitTestDAL.Entities.Softlog
{
    /// <summary>
    /// Classe de test unitaire sur la classe SoftlogDAL
    /// </summary>
    /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
    [TestClass]
    public class SoftlogDALTest
    {
        /// <summary>
        /// Test sur la configuration du SoftlogDAL
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
		[ExpectedException(typeof(System.NullReferenceException), "La fonction n'as pas lever l'exception alors que le SoftlogDAL n'es pas configurer dans le proxy.")]
        public void ConfigurationSoftlogDALTest()
        {
            // yl - Creation du context
            var lContext = new WS_Hotline.DataAccessLayer.BDD.HotlineDbContext();
            // yl -  On oublie volontairement de mettre le context
            // yl - Creation de l'object DAL
            SoftlogDAL lService = new SoftlogDAL(lContext);
            // yl - Recuperation d'items
            var lListeSoftlog = lService.GetItems(new CritereSoftlogDTO());
        }
    }
}

		