using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WS_Hotline.Framework.Web
{
    public class ModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (!modelType.IsValueType && modelType.Namespace != null && !modelType.Namespace.StartsWith("System"))
            {
                return DependencyResolver.Current.GetService(modelType);
            }

            return base.CreateModel(controllerContext, bindingContext, modelType);
        }

        protected override PropertyDescriptorCollection GetModelProperties(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var toReturn = base.GetModelProperties(controllerContext, bindingContext);

            var additional = new List<PropertyDescriptor>();

            // now look for any aliasable properties in here
            foreach (var p in
              this.GetTypeDescriptor(controllerContext, bindingContext)
              .GetProperties().Cast<PropertyDescriptor>())
            {
                foreach (var attr in p.Attributes.OfType<BindAliasAttribute>())
                {
                    additional.Add(new AliasedPropertyDescriptor(attr.Alias, p));

                    if (bindingContext.PropertyMetadata.ContainsKey(p.Name))
                    {
                        bindingContext.PropertyMetadata.Add(attr.Alias, bindingContext.PropertyMetadata[p.Name]);
                    }
                }
            }

            return new PropertyDescriptorCollection(toReturn.Cast<PropertyDescriptor>().Concat(additional).ToArray());
        }
    }
}
