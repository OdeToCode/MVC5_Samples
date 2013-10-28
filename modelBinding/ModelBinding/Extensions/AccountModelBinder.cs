using System;
using System.ComponentModel;
using System.Web.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Extensions
{
    public class AccountModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, 
                                              ModelBindingContext bindingContext, Type modelType)
        {
            return new Account("Default");
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {            
            return base.BindModel(controllerContext, bindingContext);
        }

        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext,
            PropertyDescriptor propertyDescriptor)
        {
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }

        protected override PropertyDescriptorCollection GetModelProperties(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return base.GetModelProperties(controllerContext, bindingContext);
        }

        protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext,
            PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
        {
            return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
        }

        protected override ICustomTypeDescriptor GetTypeDescriptor(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return base.GetTypeDescriptor(controllerContext, bindingContext);
        }

        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            base.OnModelUpdated(controllerContext, bindingContext);
        }

        protected override bool OnModelUpdating(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return base.OnModelUpdating(controllerContext, bindingContext);
        }

        protected override void OnPropertyValidated(ControllerContext controllerContext, ModelBindingContext bindingContext,
            PropertyDescriptor propertyDescriptor, object value)
        {
            base.OnPropertyValidated(controllerContext, bindingContext, propertyDescriptor, value);
        }

        protected override bool OnPropertyValidating(ControllerContext controllerContext, ModelBindingContext bindingContext,
            PropertyDescriptor propertyDescriptor, object value)
        {
            return base.OnPropertyValidating(controllerContext, bindingContext, propertyDescriptor, value);
        }

        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext,
            PropertyDescriptor propertyDescriptor, object value)
        {
            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
        }
    }
}