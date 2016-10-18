using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.DTOLibrary.Entities.Ecriture;
using Demo.DTOLibrary.Exception.EcritureException;
using Demo.DomainLibrary.Metier.Ecriture;
using Demo.DTOLibrary.Exception.GeneriqueException;

namespace UnitTestDomain.Metier.Ecriture
{
    /// <summary>
    /// Classe de test unitaire dédié a la classe EcritureMetier
    /// </summary>
    /// <remarks>ylouis - 06/09/2016 - Généré par Template T4 v1.0</remarks>
    [TestClass]
    public class EcritureMetierTest
    {
		#region Validation DTO

        /// <summary>
        /// Test que la méthode "ValidatedDTO" de EcritureMetier retourne bien une erreur de type EcritureException.
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
        [ExpectedException(typeof(EcritureException),
            "La fonction n'as pas lever l'exception EcritureException.")]
        public void ValidationEcritureDTOThrowExceptionTest()
        {
            // yl - initialisation metier.
            var lMetier = new EcritureMetier();
            // yl - On lance la methode "ValidatedDTO" avec un paramettre invalide. => Une exception de type EcritureException doit etre lever
            lMetier.ValidatedDTO(new CritereEcritureDTO());
        }

		#endregion

        #region Validation Critere DTO
		
        /// <summary>
        /// Test que la méthode de ValidatedCritere de EcritureMetier retourne bien une Exception.
        /// </summary>
        /// <remarks>ylouis - 06/09/2016 - Généré par Template T4 v1.0</remarks>
        [TestMethod]
        public void ValidationEcritureCritereDTOThrowExceptionTest()
        {
			try
            {
                // yl - initialisation metier.
                var lMetier = new EcritureMetier();
                // yl - On lance la methode "ValidatedCritere" avec un paramettre invalide.
                lMetier.ValidatedCritere(new EcritureDTO());
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
		