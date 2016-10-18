using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.DTOLibrary.Exception.GeneriqueException
{
    /// <summary>
    /// Exeption sur le Type, probléme quand l'object passer ne correspond pas au type attendu
    /// </summary>
    /// <typeparam name="T">Type attendu</typeparam>
    [Serializable]
    public class TypeException<T> : System.Exception
    {
        #region Constructeur

        public TypeException()
            : base("Le type attendu est : " + typeof(T))
        { }

        public TypeException(string pMessage)
            : base("Le type attendu est : " + typeof(T) + "\n" + pMessage)
        { }

        public TypeException(string pMessage, System.Exception pInnrException)
            : base("Le type attendu est : " + typeof(T) + "\n" + pMessage, pInnrException)
        { }

        protected TypeException(SerializationInfo pInfo, StreamingContext pContext)
            : base(pInfo, pContext)
        { }

        #endregion
    }
}
