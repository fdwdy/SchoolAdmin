using System;
using System.Collections.Generic;
using FluentValidation;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Web.Models;

namespace ItAcademy.SchoolAdmin.Web.Validators
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private static Dictionary<Type, IValidator> _validators = new Dictionary<Type, IValidator>();

        static ValidatorFactory()
        {
            _validators.Add(typeof(IValidator<Employee>), new EmployeeValidator());
            _validators.Add(typeof(IValidator<PhoneViewModel>), new PhoneValidator());
            _validators.Add(typeof(IValidator<CreateEmployeeViewModel>), new EmployeeValidator());
            _validators.Add(typeof(IValidator<SubjectViewModel>), new SubjectViewModelValidator());
            _validators.Add(typeof(IValidator<PositionViewModel>), new PositionViewModelValidator());
            _validators.Add(typeof(IValidator<MessageViewModel>), new MessageViewModelValidator());
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