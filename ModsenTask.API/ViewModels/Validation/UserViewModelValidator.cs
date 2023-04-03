using FluentValidation;

namespace ModsenTask.API.ViewModels.Validation
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .MinimumLength(10);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);
                
        }

    }
} 
