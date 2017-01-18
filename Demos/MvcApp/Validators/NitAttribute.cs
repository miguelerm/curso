using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Validators
{
    public class NitAttribute : ValidationAttribute, IClientValidatable
    {

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            var nit = value as string;

            if (nit == null) return false;

            return nit.EndsWith("3");
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = FormatErrorMessage(metadata.DisplayName ?? metadata.PropertyName);

            ModelClientValidationRule nitRule = new ModelClientValidationRule();
            nitRule.ErrorMessage = errorMessage;
            nitRule.ValidationType = "nit";

            yield return nitRule;
        }
    }
}