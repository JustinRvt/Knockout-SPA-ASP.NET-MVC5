using System;
using System.Linq;
using UnityConfiguration;

namespace WS_Hotline.Framework.InversionOfControl
{   
    /// <summary>
    /// Define Interface convention to unity Demon
    /// </summary>
    public class InterfaceConvention : IAssemblyScannerConvention
    {
        /// <summary>
        /// Register All interface from Xconso Namespace. 
        /// </summary>
        /// <param name="pType"></param>
        /// <param name="pRegistry"></param>
        public void Process(Type pType, IUnityRegistry pRegistry)
        {
            foreach (var lInterface in pType.GetInterfaces().Where(pX => pX.Namespace != null && pX.Namespace.StartsWith("WS_Hotline")))
            {
                pRegistry.Register(lInterface, pType).AsSingleton();
            }
        }
    }
}