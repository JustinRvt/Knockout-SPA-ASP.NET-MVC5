using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.Framework.Web
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class BindAliasAttribute : Attribute
    {
        public BindAliasAttribute(string alias)
        {
            // ommitted: parameter checking
            this.Alias = alias;
        }

        public string Alias { get; private set; }
    }
}
