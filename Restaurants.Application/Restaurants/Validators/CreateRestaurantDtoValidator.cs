using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators;
public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    private readonly List<string> validCategories = ["Italian", "Mexican", "Greek", "Fast Food", "Fine Dining", "Desserts"];
    public CreateRestaurantDtoValidator()
    {

        RuleFor(dto => dto.Name)
            .Length(3, 100);

        RuleFor(dto => dto.Category)
            .Must(validCategories.Contains);
            //.Custom((value, context) =>
            //{
            //    var isValidCategory = validCategories.Contains(value);
            //    if (!isValidCategory)
            //    {
            //        context.AddFailure("Category", "Invalid Category. Please choose from the valid categories.");
            //    }
            //});

        RuleFor(dto => dto.ContactEmail)
            .EmailAddress()
            .WithMessage("Please provide a valid email address.");

        RuleFor(dto => dto.ContactNumber)
            .Matches(@"^\+?[1-9]\d{1,14}$")
            .WithMessage("Please provide a valid phone number.");

        RuleFor(dto => dto.PostalCode)
            .Matches(@"\d{5}")
            .WithMessage("Please provide a valid postal code (XXXXX).");

    }
}
