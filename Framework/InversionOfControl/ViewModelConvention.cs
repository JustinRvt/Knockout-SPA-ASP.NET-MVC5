using System;
using GalaSoft.MvvmLight;
using UnityConfiguration;

namespace WS_Hotline.Framework.InversionOfControl
{
    public class ViewModelConvention : IAssemblyScannerConvention
    {
        /// <summary>
        /// Register All interface from Xconso Namespace. 
        /// </summary>
        /// <param name="pType"></param>
        /// <param name="pRegistry"></param>
        public void Process(Type pType, IUnityRegistry pRegistry)
        {
            if (pType.BaseType == typeof(ViewModelBase))
            {
                pRegistry.Register(pType, pType).AsSingleton();
            }
        }
    }
}
