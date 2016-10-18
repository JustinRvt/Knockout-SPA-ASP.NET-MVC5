using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.DTOLibrary.Entities.User;
using Demo.DTOLibrary.Exception.UserException;
using Demo.DomainLibrary.Metier.User;
using Demo.DTOLibrary.Exception.Generique;

namespace UnitTestDomain.Metier.User
{
    /// <summary>
    /// Classe de test unitaire dédié a la classe UserMetier
    /// </summary>
    /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
    [TestClass]
    public class UserMetierTest
    {
		#region Validation DTO

        /// <summary>
        /// Test que la méthode "ValidatedDTO" de UserMetier retourne bien une erreur de type UserException.
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
        [ExpectedException(typeof(UserException),
            "La fonction n'as pas lever l'exception UserException.")]
        public void ValidationUserDTOThrowExceptionTest()
        {
            // yl - initialisation metier.
            var lMetier = new UserMetier();
            // yl - On lance la methode "ValidatedDTO" avec un paramettre invalide. => Une exception de type UserException doit etre lever
            lMetier.ValidatedDTO(new CritereUserDTO());
        }

		#endregion

        #region Validation Critere DTO
		
        /// <summary>
        /// Test que la méthode de ValidatedCritere de UserMetier retourne bien une Exception.
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
        public void ValidationUserCritereDTOThrowExceptionTest()
        {
			try
            {
                // yl - initialisation metier.
                var lMetier = new UserMetier();
                // yl - On lance la methode "ValidatedCritere" avec un paramettre invalide.
                lMetier.ValidatedCritere(new UserDTO());
            }
            catch(Exception ex)
            {
                // yl - une exception est lever. le test est réussi.
                return;
            }
            // yl - si aucune exception lever c'est un FAIL.
            Assert.Fail("Aucune exception lever");
        }

        #endregion
    }
}
		