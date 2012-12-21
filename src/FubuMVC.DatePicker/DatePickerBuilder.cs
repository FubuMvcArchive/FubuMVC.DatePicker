using System;
using FubuCore;
using FubuMVC.Core;
using FubuMVC.Core.Assets;
using FubuMVC.Core.UI;
using FubuMVC.Core.UI.Elements;
using HtmlTags;

namespace FubuMVC.DatePicker
{
    public class DatePickerRegistryExtension : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Import<HtmlConventionRegistry>(x => x.Editors.Add(new DatePickerBuilder()));
        }
    }

    public class DatePickerBuilder : ElementTagBuilder
    {
        public override bool Matches(ElementRequest token)
        {
            return token.Accessor.PropertyType.IsDateTime() && token.Accessor.Name.EndsWith("Date");
        }

        public override HtmlTag Build(ElementRequest request)
        {
            // Add the DatePickerActivator.js into the asset pipeline for this page
            request.Get<IAssetRequirements>().Require("DatePickerActivator.js");

            string text = null == request.RawValue || DateTime.MinValue.Equals(request.RawValue)
                              ? ""
                              : request.RawValue.As<DateTime>().ToShortDateString();

            return new HtmlTag("input").Text(text).Attr("type", "text").AddClass("datepicker");
        }
    }
}