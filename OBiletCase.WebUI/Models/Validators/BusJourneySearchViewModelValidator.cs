using FluentValidation;

namespace OBiletCase.WebUI.Models.Validators
{
    public class BusJourneySearchViewModelValidator : AbstractValidator<BusJourneySearchViewModel>
    {
        public BusJourneySearchViewModelValidator()
        {
            RuleFor(x => x.OriginId)
             .NotEmpty()
             .WithMessage("{PropertyName} Gerekli!");

            RuleFor(x => x.DestinationId)
                .NotEmpty()
                .WithMessage("{PropertyName} Gerekli!");

            RuleFor(x => x)
                .Custom((model, context) =>
                {
                    if (model.OriginId == model.DestinationId)
                    {
                        context.AddFailure("Nereden ve Nereye değerleri aynı olamaz.");
                    }
                });

            RuleFor(x => x.DepartureDate)
                .Must(date => date.Date <= DateTime.Now.Date)
                .WithMessage("Tarih bugünden küçük olamaz.");
        }
    }
}
