using FluentValidation;
using System.Resources;

namespace OBiletCase.WebUI.Models.Validators
{
    public class BusJourneySearchViewModelValidator : AbstractValidator<BusJourneySearchViewModel>
    {
        public BusJourneySearchViewModelValidator()
        {
            RuleFor(x => x.OriginId)
             .NotNull()
             .NotEmpty();

            RuleFor(x => x.DestinationId)
                   .NotNull()
                   .NotEmpty();

            RuleFor(x => x.OriginId).Must((instance, OriginId) => OriginId != instance.DestinationId)
                                    .WithMessage("Kalkış ve varış noktası aynı olamaz");

            RuleFor(x => x.DepartureDate)
                .Must(date => date.Date < DateTime.Now.Date)
                .WithMessage("Tarih bugünden küçük olamaz.");
        }
    }
}
