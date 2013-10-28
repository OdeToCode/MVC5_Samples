using System;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ModelBinding.Extensions
{
    public class DateTimeModelBinder : IModelBinder
    {
        public object BindModel(
            ControllerContext controllerContext, 
            ModelBindingContext bindingContext)
        {
            var name = bindingContext.ModelName;
            var valueResult = bindingContext.ValueProvider.GetValue(name);
            bindingContext.ModelState.SetModelValue(name, valueResult);

            var attemptedValue = valueResult.AttemptedValue;
                                   
            int year;
            if (int.TryParse(attemptedValue, out year))
            {
                return new DateTime(year, 1, 1);
            }

            DateTime date;
            if (DateTime.TryParse(attemptedValue, out date))
            {
                return date;
            }

            bindingContext.ModelState.AddModelError(name, "Could not make a date out of what you typed");
            return null;
        }
    }
}