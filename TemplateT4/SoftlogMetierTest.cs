using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.DTOLibrary.Entities.Softlog;
using Demo.DTOLibrary.Exception.SoftlogException;
using Demo.DomainLibrary.Metier.Softlog;
using Demo.DTOLibrary.Exception.Generique;

namespace UnitTestDomain.Metier.Softlog
{
    /// <summary>
    /// Classe de test unitaire dédié a la classe SoftlogMetier
    /// </summary>
    /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
    [TestClass]
    public class SoftlogMetierTest
    {
		#region Validation DTO

        /// <summary>
        /// Test que la méthode "ValidatedDTO" de SoftlogMetier retourne bien une erreur de type SoftlogException.
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
        [ExpectedException(typeof(SoftlogException),
            "La fonction n'as pas lever l'exception SoftlogException.")]
        public void ValidationSoftlogDTOThrowExceptionTest()
        {
            // yl - initialisation metier.
            var lMetier = new SoftlogMetier();
            // yl - On lance la methode "ValidatedDTO" avec un paramettre invalide. => Une exception de type SoftlogException doit etre lever
            lMetier.ValidatedDTO(new CritereSoftlogDTO());
        }

		#endregion

        #region Validation Critere DTO
		
        /// <summary>
        /// Test que la méthode de ValidatedCritere de SoftlogMetier retourne bien une Exception.
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
        public void ValidationSoftlogCritereDTOThrowExceptionTest()
        {
			try
            {
                // yl - initialisation metier.
                var lMetier = new SoftlogMetier();
                // yl - On lance la methode "ValidatedCritere" avec un paramettre invalide.
                lMetier.ValidatedCritere(new SoftlogDTO());
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
		