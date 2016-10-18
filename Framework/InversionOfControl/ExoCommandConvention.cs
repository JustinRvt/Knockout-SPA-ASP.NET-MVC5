using System;
using WS_Hotline.Framework.Domain.Command;
using UnityConfiguration;

namespace WS_Hotline.Framework.InversionOfControl
{
    public class ExoCommandConvention : IAssemblyScannerConvention
    {
        public void Process(Type pType, IUnityRegistry pRegistry)
        {
            if (pType.BaseType != null && pType.BaseType.IsAssignableFrom(typeof(ExoCommand)))
            {
                pRegistry.Register(pType, pType).AsSingleton();
            }
        }
    }
}