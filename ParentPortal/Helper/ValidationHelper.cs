using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace ParentPortal.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsFormValid(object model)
        {
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(model);
            bool isValid = Validator.TryValidateObject(model, context, errors, true);
            if (!isValid)
            {
                return false;
            }
            return true;
        }


        public static bool IsValid(object model, View view)
        {
            HideValidationFields(model, view);
            var errors = new List<ValidationResult>();
            var context = new ValidationContext(model);
            bool isValid = Validator.TryValidateObject(model, context, errors, true);
            if (!isValid)
            {
                ShowValidationFields(errors, model, view);
            }
            return errors.Count() == 0;
        }

        private static void HideValidationFields
           (object model, View view, string validationLabelSuffix = "Error")
        {
            if (model == null) { return; }
            var properties = GetValidatablePropertyNames(model);
            foreach (var propertyName in properties)
            {
                var errorControlName =
                $"{propertyName.Replace(".", "_")}{validationLabelSuffix}";
                var control = view.FindByName<Label>(errorControlName);
                if (control != null)
                {
                    control.IsVisible = false;

                }

            }

            var generalErrorLabel = view.FindByName<Label>($"{model.GetType().Name}{validationLabelSuffix}");
            if (generalErrorLabel != null)
            {
                generalErrorLabel.IsVisible = false;
            }
        }

        private static void ShowValidationFields
       (List<ValidationResult> errors,
       object model, View view, string validationLabelSuffix = "Error")
        {
            if (model == null) { return; }
            foreach (var error in errors)
            {
                var memberName = $"{model.GetType().Name}_{error.MemberNames.FirstOrDefault()}";
                memberName = memberName.Replace(".", "_");
                var errorControlName = $"{memberName}{validationLabelSuffix}";
                var control = view.FindByName<Label>(errorControlName);
                if (control != null)
                {
                    control.Text = $"{error.ErrorMessage}";
                    control.IsVisible = true;
                }
                else
                {
                    var generalErrorLabel = view.FindByName<Label>($"{model.GetType().Name}{validationLabelSuffix}");
                    generalErrorLabel.Text = $"{error.ErrorMessage}";
                    generalErrorLabel.IsVisible = true;
                }
            }
        }

        private static IEnumerable<string> GetValidatablePropertyNames(object model)
        {
            var validatableProperties = new List<string>();
            var properties = GetValidatableProperties(model);
            foreach (var propertyInfo in properties)
            {
                var errorControlName = $"{propertyInfo.DeclaringType.Name}.{propertyInfo.Name}";
                validatableProperties.Add(errorControlName);
            }
            return validatableProperties;
        }
        private static List<PropertyInfo> GetValidatableProperties(object model)
        {
            var properties = model.GetType().GetProperties().Where(prop => prop.CanRead
                && prop.GetCustomAttributes(typeof(ValidationAttribute), true).Any()
                && prop.GetIndexParameters().Length == 0).ToList();
            return properties;
        }

    }
}
