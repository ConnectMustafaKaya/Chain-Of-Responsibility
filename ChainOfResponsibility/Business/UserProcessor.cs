using ChainofResponsibility.Business.Exceptions;
using ChainofResponsibility.Business.Handlers.UserValidation;
using ChainofResponsibility.Business.Models;

namespace ChainofResponsibility.Business
{
    public class UserProcessor
    {
        public static bool Register(User user)
        {
            try
            {
                var handler = new SocialSecurityNumberValidatorHandler();

                handler.SetNext(new AgeValidationHandler())
                    .SetNext(new NameValidationHandler())
                    .SetNext(new CitizenshipRegionValidationHandler());

                handler.Handle(user);
            }
            catch (UserValidationException)
            {
                return false;
            }

            return true;
        }
    }
}
