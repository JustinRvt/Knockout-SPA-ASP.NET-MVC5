using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WS_Hotline.Framework.Web
{
    public static class HtmlHelperExtensions
    {
        public static HtmlHelper<TModel> Model<TModel>(this HtmlHelper htmlHelper)
        {
            return Model(htmlHelper, default(TModel));
        }

        public static HtmlHelper<TModel> Model<TModel>(this HtmlHelper htmlHelper, TModel model)
        {
            return Model(htmlHelper, model, null);
        }

        public static HtmlHelper<TModel> Model<TModel>(this HtmlHelper htmlHelper, TModel model, string htmlFieldPrefix)
        {
            var viewDataContainer = CreateViewDataContainer(htmlHelper.ViewData, model);

            var templateInfo = viewDataContainer.ViewData.TemplateInfo;

            if (!string.IsNullOrEmpty(htmlFieldPrefix))
            {
                templateInfo.HtmlFieldPrefix = templateInfo.GetFullHtmlFieldName(htmlFieldPrefix);
            }

            var viewContext = htmlHelper.ViewContext;
            var newViewContext = new ViewContext(viewContext.Controller.ControllerContext, viewContext.View, viewDataContainer.ViewData, viewContext.TempData, viewContext.Writer);

            return new HtmlHelper<TModel>(newViewContext, viewDataContainer, htmlHelper.RouteCollection);
        }

        private static IViewDataContainer CreateViewDataContainer(ViewDataDictionary viewData, object model)
        {
            var newViewData = new ViewDataDictionary(viewData)
            {
                Model = model
            };

            newViewData.TemplateInfo = new TemplateInfo
            {
                HtmlFieldPrefix = newViewData.TemplateInfo.HtmlFieldPrefix
            };

            return new ViewDataContainer
            {
                ViewData = newViewData
            };
        }

        private class ViewDataContainer : IViewDataContainer
        {
            public ViewDataDictionary ViewData { get; set; }
        }
    }
}
