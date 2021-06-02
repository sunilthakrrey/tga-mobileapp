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

    }
}
