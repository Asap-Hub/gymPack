using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Extentions.Exceptions
{
    public class ValidException : ApplicationException
    {
        public List<string> Errors { set; get; } = new List<string>();

        public ValidException(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
