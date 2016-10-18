using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.DTOLibrary.Entities.Dossier;
using Demo.DTOLibrary.Exception.DossierException;
using Demo.DomainLibrary.Metier.Dossier;
using Demo.DTOLibrary.Exception.Generique;

namespace UnitTestDomain.Metier.Dossier
{
    /// <summary>
    /// Classe de test unitaire dédié a la classe DossierMetier
    /// </summary>
    /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
    [TestClass]
    public class DossierMetierTest
    {
		#region Validation DTO

        /// <summary>
        /// Test que la méthode "ValidatedDTO" de DossierMetier retourne bien une erreur de type DossierException.
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
        [ExpectedException(typeof(DossierException),
            "La fonction n'as pas lever l'exception DossierException.")]
        public void ValidationDossierDTOThrowExceptionTest()
        {
            // yl - initialisation metier.
            var lMetier = new DossierMetier();
            // yl - On lance la methode "ValidatedDTO" avec un paramettre invalide. => Une exception de type DossierException doit etre lever
            lMetier.ValidatedDTO(new CritereDossierDTO());
        }

		#endregion

        #region Validation Critere DTO
		
        /// <summary>
        /// Test que la méthode de ValidatedCritere de DossierMetier retourne bien une Exception.
        /// </summary>
        /// <remarks>ylouis - 11/07/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
        public void ValidationDossierCritereDTOThrowExceptionTest()
        {
			try
            {
                // yl - initialisation metier.
                var lMetier = new DossierMetier();
                // yl - On lance la methode "ValidatedCritere" avec un paramettre invalide.
                lMetier.ValidatedCritere(new DossierDTO());
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
		