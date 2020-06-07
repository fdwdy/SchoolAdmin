using System;
using System.Collections.Generic;
using FluentValidation;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;

namespace ItAcademy.SchoolAdmin.Web.Validators
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private static Dictionary<Type, IValidator> _validators = new Dictionary<Type, IValidator>();

        static ValidatorFactory()
        {
            _validators.Add(typeof(IValidator<Employee>), new EmployeeValidator());
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            if (_validators.TryGetValue(validatorType, out IValidator validator))
            {
                return validator;
            }

            return validator;
        }
    }
}