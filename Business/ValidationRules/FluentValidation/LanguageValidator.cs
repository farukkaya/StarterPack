using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class LanguageValidator : AbstractValidator<Language>
	{
		public LanguageValidator()
		{
			RuleFor(p => p.LangKey).NotEmpty();
			RuleFor(p => p.Name).NotEmpty();
			RuleFor(p => p.UpdatedDate).NotEmpty().When(p=>p.Id>0);
        }
	}
}

