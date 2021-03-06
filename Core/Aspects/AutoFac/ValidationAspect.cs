using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;

namespace Core.Aspects.AutoFac
{
    public class ValidationAspect :MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if(typeof(IValidator).IsAssignableFrom(validatorType))
                throw new Exception(AspectMessages.WrongValidationType);


            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator) Activator.CreateInstance(_validatorType);
            if (_validatorType.BaseType != null)
            {
                var entityType = _validatorType.BaseType.GetGenericArguments()[0];
                var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
                foreach (var entity in entities)
                {
                    ValidationTool.Validate(validator,entity);
                }
            }
            else
            {
                throw new Exception(AspectMessages.NullBaseType);
            }
        }
    }
}
