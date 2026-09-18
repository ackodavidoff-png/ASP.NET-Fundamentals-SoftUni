namespace WebApplication1.Common
{
    public class EntityConstraints
    {
        //car
        public const int CarBrandNameMaxLength = 50;
        public const int CarBrandNameMinLength = 1;
        public const int CarModelNameMaxLength = 50;
        public const int CarModelNameMinLength = 1;
        public const int CarProductionYearMinValue = 1900;
        //Application user
        public const int UserFirstNameMaxLength = 50;
        public const int UserFirstNameMinLength = 1;
        public const int UserLastNameMaxLength = 50;
        public const int UserLastNameMinLength = 1;
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 50;
        public const string PhoneNumberRegexPattern = @"0\d{9}";
    }
}
