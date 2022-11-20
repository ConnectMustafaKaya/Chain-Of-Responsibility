using ChainofResponsibility.Business.Exceptions;
using System.Globalization;

namespace ChainofResponsibility.Business.Validators
{
    public class SocialSecurityNumberValidator
    {
        public static bool Validate(string socialSecurityNumber, RegionInfo region)
        {
            return region.TwoLetterISORegionName switch
            {
                "SE" => ValidateSwedishSocialSecurityNumber(socialSecurityNumber),
                "US" => ValidateUnitedStatesSocialSecurityNumber(socialSecurityNumber),
                _ => throw new UnsupportedSocialSecurityNumberException(),
            };
        }

        private static bool ValidateSwedishSocialSecurityNumber(string socialSecurityNumber)
        {
            return socialSecurityNumber.Length > 1;
        }

        private static bool ValidateUnitedStatesSocialSecurityNumber(string socialSecurityNumber)
        {
            return socialSecurityNumber.Length > 2;
        }
    }
}
