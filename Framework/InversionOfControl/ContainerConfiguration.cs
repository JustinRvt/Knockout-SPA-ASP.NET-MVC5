using System.Reflection;
using Microsoft.Practices.Unity;
using UnityConfiguration;

namespace WS_Hotline.Framework.InversionOfControl
{
    /// <summary>
    /// Container IoC
    /// </summary>
    public static class ContainerConfiguration
    {

        /// <summary>
        /// Configurer IoC Container
        /// </summary>
        /// <param name="pUnityContainer"></param>
        /// <returns></returns>
        public static IUnityContainer Configure(IUnityContainer pUnityContainer = null)
        {
            try
            {
                var lContainer = pUnityContainer ?? new UnityContainer();
                // Configuration de L'IoC celon les conventions de résolution.
                lContainer.Configure(pX => pX.AddRegistry<ConventionRegistry>());
                return lContainer;
            }
            catch (ReflectionTypeLoadException lE)
            {
                var lIErreur = 1;
                // Affichage des execptions levé lors de la configuration de l'IoC
                foreach (var lOaderException in lE.LoaderExceptions)
                {
                    lIErreur++;
                }

                throw;
            }
        }
    }
}