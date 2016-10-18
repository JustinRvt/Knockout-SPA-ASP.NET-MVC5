using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_Hotline.Framework.Web
{
    internal sealed class AliasedPropertyDescriptor : PropertyDescriptor
    {
        public AliasedPropertyDescriptor(string alias, PropertyDescriptor inner)
            : base(alias, null)
        {
            this.Inner = inner;
        }

        public PropertyDescriptor Inner { get; private set; }

        public override Type ComponentType
        {
            get { return this.Inner.ComponentType; }
        }

        public override bool IsReadOnly
        {
            get { return this.Inner.IsReadOnly; }
        }

        public override Type PropertyType
        {
            get { return this.Inner.PropertyType; }
        }

        public override bool CanResetValue(object component)
        {
            return this.Inner.CanResetValue(component);
        }

        public override object GetValue(object component)
        {
            return this.Inner.GetValue(component);
        }

        public override void ResetValue(object component)
        {
            this.Inner.ResetValue(component);
        }

        public override void SetValue(object component, object value)
        {
            this.Inner.SetValue(component, value);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return this.Inner.ShouldSerializeValue(component);
        }
    }
}
