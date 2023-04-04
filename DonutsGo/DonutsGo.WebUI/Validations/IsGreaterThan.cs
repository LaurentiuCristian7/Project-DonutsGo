using System.ComponentModel.DataAnnotations;

namespace DonutsGo.WebUI.Validations
{
    public class IsGreaterThan : ValidationAttribute
    {
        public double Value { get; set; }   
        public override bool IsValid(object? value)
        {
            var intValue = value as double?;

            if (intValue == null)
            {
                return false;
            }

            if (intValue == 0)
            {
                return false;
            } 
            if (intValue < Value)
            {
                return false;
            }
           return true;
        }
    }
}
