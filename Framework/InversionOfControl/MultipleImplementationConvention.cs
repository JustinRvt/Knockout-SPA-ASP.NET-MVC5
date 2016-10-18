using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using UnityConfiguration;

namespace WS_Hotline.Framework.InversionOfControl
{
    public class MultipleImplementationConvention : IAssemblyScannerConvention, ILifetimePolicyExpression
    {
        private Func<Type, string> _getName = pT => pT.FullName;
        private Type[] _typesInterfaces;
        private Action<ILifetimePolicyExpression> _lifetimePolicyAction;

        public MultipleImplementationConvention TypesImplementing(params Type[] pTypes)
        {
            this._typesInterfaces = pTypes;
            return this;
        }

        public MultipleImplementationConvention WithName(Func<Type, string> pFunc)
        {
            this._getName = pFunc;
            return this;
        }

        public void Using<T>() where T : LifetimeManager, new()
        {
            this._lifetimePolicyAction = pX => pX.Using<T>();
        }

        public void Process(Type pType, IUnityRegistry pRegistry)
        {
            foreach (var lTypeInterface in this._typesInterfaces)
            {
                IEnumerable<Type> lTypesFrom = null;
                if (pType.CanBeCastTo(lTypeInterface))
                {
                    lTypesFrom = new[] { lTypeInterface };
                }
                else if (pType.ImplementsInterfaceTemplate(lTypeInterface))
                {
                    Type lInterface = lTypeInterface;
                    lTypesFrom = pType.GetInterfaces().Where(pI => pI.IsGenericType && pI.GetGenericTypeDefinition() == lInterface);
                }

                if (lTypesFrom == null)
                {
                    continue;
                }

                foreach (var lTypeFrom in lTypesFrom.Where(t => !t.CanBeCreated()))
                {
                    var lExpression = pRegistry.Register(lTypeFrom, pType).WithName(this._getName(pType));

                    if (this._lifetimePolicyAction != null)
                        this._lifetimePolicyAction(lExpression);
                }
            }
        }
    }
}