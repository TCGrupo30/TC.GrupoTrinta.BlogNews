using Bogus;
using TC.GrupoTrinta.BlogNews.Domain.Entity;

namespace TC.GrupoTrinta.BlogNews.Api.Tests.Fixtures
{
    public class NewsTestFixture
    {
        private readonly Faker _faker;

        public NewsTestFixture()
        {
            _faker = new Faker();
        }

        public News BuildEmpty() => new(string.Empty, string.Empty, string.Empty, DateTime.Now);

        public News Build() => new(_faker.Random.AlphaNumeric(100), _faker.Random.AlphaNumeric(1000), _faker.Random.String2(40), DateTime.Now);
    }
}
