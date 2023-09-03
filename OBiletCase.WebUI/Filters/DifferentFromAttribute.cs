using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OBiletCase.WebUI.Filters
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DifferentFromAttribute : ValidationAttribute
    {
        private readonly string _otherProperty;

        public DifferentFromAttribute(string otherProperty)
        {
            _otherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(_otherProperty);

            if (otherPropertyInfo == null)
            {
                return new ValidationResult($"Property '{_otherProperty}' is not defined.");
            }

            var otherValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            if (value != null && value.Equals(otherValue))
            {
                // If the 'Display' attribute is used, take its value, otherwise use the property name
                var displayAttribute = otherPropertyInfo.GetCustomAttribute<DisplayAttribute>();
                var otherDisplayName = displayAttribute?.GetName() ?? _otherProperty;

                displayAttribute = validationContext.ObjectType.GetProperty(validationContext.MemberName).GetCustomAttribute<DisplayAttribute>();
                var thisDisplayName = displayAttribute?.GetName() ?? validationContext.MemberName;

                return new ValidationResult($"'{thisDisplayName}' should not be equal to '{otherDisplayName}'.");
            }

            return ValidationResult.Success;
        }
    }
}
