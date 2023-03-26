using ContryRoutePractice.Enum;
using ContryRoutePractice.Entity;


namespace ContryRoutePractice.Factory
{
    public static class CountryFactory
    {
        private static int Id = 1;

        private static readonly Dictionary<CountryEnum, Country> countryDict = 
            new Dictionary<CountryEnum, Country>()
            {
                {CountryEnum.US, new UnitedStateCountry("United States") },
                {CountryEnum.UK, new UnitedKingdomCountry("United Kingdom") },
                {CountryEnum.India, new IndiaCountry("India") },
                {CountryEnum.Japan, new JapanCountry("Japan") },
                {CountryEnum.Canada, new CanadaCountry("Canada") }
            };

        private static Dictionary<CountryEnum, Country> countryEnumCountry = new Dictionary<CountryEnum, Country>()
        {
                {CountryEnum.US, CreateCountry(CountryEnum.US) },
                {CountryEnum.UK,CreateCountry(CountryEnum.UK) },
                {CountryEnum.India, CreateCountry(CountryEnum.India) },
                {CountryEnum.Japan, CreateCountry(CountryEnum.Japan) },
                {CountryEnum.Canada, CreateCountry(CountryEnum.Canada) }
        };

        public static Country CreateCountry(CountryEnum name)
        {
            if (countryDict.ContainsKey(name))
            {
                var country = countryDict[name];
                country.Id = Id++;
                return country;
            }
            return new DefaultCountry("Default Class");
        }

        public static Dictionary<CountryEnum, Country> Countries() => countryEnumCountry;
    }
}
