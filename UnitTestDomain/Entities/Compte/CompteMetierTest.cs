using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.DTOLibrary.Entities.Compte;
using Demo.DTOLibrary.Exception.CompteException;
using Demo.DomainLibrary.Metier.Compte;
using Demo.DTOLibrary.Exception.GeneriqueException;

namespace UnitTestDomain.Metier.Compte
{
    /// <summary>
    /// Classe de test unitaire dédié a la classe CompteMetier
    /// </summary>
    /// <remarks>ylouis - 06/09/2016 - Généré par Template T4 v1.0</remarks>
    [TestClass]
    public class CompteMetierTest
    {
		#region Validation DTO

        /// <summary>
        /// Test que la méthode "ValidatedDTO" de CompteMetier retourne bien une erreur de type CompteException.
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
        [ExpectedException(typeof(CompteException),
            "La fonction n'as pas lever l'exception CompteException.")]
        public void ValidationCompteDTOThrowExceptionTest()
        {
            // yl - initialisation metier.
            var lMetier = new CompteMetier();
            // yl - On lance la methode "ValidatedDTO" avec un paramettre invalide. => Une exception de type CompteException doit etre lever
            lMetier.ValidatedDTO(new CritereCompteDTO());
        }

		#endregion

        #region Validation Critere DTO
		
        /// <summary>
        /// Test que la méthode de ValidatedCritere de CompteMetier retourne bien une Exception.
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
        public void ValidationCompteCritereDTOThrowExceptionTest()
        {
			try
            {
                // yl - initialisation metier.
                var lMetier = new CompteMetier();
                // yl - On lance la methode "ValidatedCritere" avec un paramettre invalide.
                lMetier.ValidatedCritere(new CompteDTO());
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
		