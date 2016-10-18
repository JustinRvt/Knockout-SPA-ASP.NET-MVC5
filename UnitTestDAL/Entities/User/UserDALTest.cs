using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WS_Hotline.DataAccessLayer.Entities.User;
using WS_Hotline.DTOLibrary.Entities.User;

namespace UnitTestDAL.Entities.User
{
    /// <summary>
    /// Classe de test unitaire sur la classe UserDAL
    /// </summary>
    /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
    [TestClass]
    public class UserDALTest
    {
        /// <summary>
        /// Test sur la configuration du UserDAL
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
		[ExpectedException(typeof(System.NullReferenceException), "La fonction n'as pas lever l'exception alors que le UserDAL n'es pas configurer dans le proxy.")]
        public void ConfigurationUserDALTest()
        {
            // yl - Creation du context
            var lContext = new WS_Hotline.DataAccessLayer.BDD.HotlineDbContext();
            // yl -  On oublie volontairement de mettre le context
            // yl - Creation de l'object DAL
            UserDAL lService = new UserDAL(lContext);
            // yl - Recuperation d'items
            var lListeUser = lService.GetItems(new CritereUserDTO());
        }
    }
}

		