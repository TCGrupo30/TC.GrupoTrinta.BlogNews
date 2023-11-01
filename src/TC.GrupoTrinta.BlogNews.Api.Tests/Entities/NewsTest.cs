using Bogus;
using TC.GrupoTrinta.BlogNews.Api.Tests.Fixtures;
using TC.GrupoTrinta.BlogNews.Domain.Entity;
using TC.GrupoTrinta.BlogNews.Domain.SeedWork;

namespace TC.GrupoTrinta.BlogNews.Api.Tests.Entities
{
    [Collection(nameof(NewsTestFixtureCollection))]
    public class NewsTest
    {
        private readonly Faker _faker;
        public readonly NewsTestFixture _newsTestFixture;

        public NewsTest(NewsTestFixture newsTestFixture)
        {
            _faker = new Faker();
            _newsTestFixture = newsTestFixture;
        }

        [Theory(DisplayName = "Avalia se as propriedades da classe operam corretamente para definir e recuperar valores")]
        [Trait("News", "Validando operações")]
        [InlineData("Faculdade Fiap", "Faculdade de Tecnologia", "Grupo Trinta")]
        public void NewsProperties_SetAndGetProperties_WorkAsExpected(string title, string content, string author)
        {
            // arrange
            var dateNow = DateTime.Now;

            // act
            var news = new News(title, content, author, dateNow);

            // assert
            Assert.Equal(news.Title, title);
            Assert.Equal(news.Content, content);
            Assert.Equal(news.Author, author);
        }

        [Fact(DisplayName = "Verifica se um título com o tamanho mínimo permitido (5 caracteres) é validado com sucesso")]
        [Trait("News", "Validando operações")]
        public void NewsTitle_MinimumLength_PassesValidation()
        {
            // arrange 
            var data = _newsTestFixture.Build();

            // act
            var news = new News("Maria", data.Content, data.Author, data.PublicationDate);

            // act & assert
            Assert.NotEmpty(news.Title);
        }

        [Fact(DisplayName = "Confirma se um título com o tamanho máximo permitido (255 caracteres) é validado com sucesso")]
        [Trait("News", "Validando operações")]
        public void NewsTitle_MaximumLength_PassesValidation()
        {
            // arrange 
            var data = _newsTestFixture.Build();

            // act
            var news = new News("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has ss", data.Content, data.Author, data.PublicationDate);

            // act & assert
            Assert.NotEmpty(news.Title);
        }

        [Fact(DisplayName = "Testa se um título com menos de 5 caracteres lança uma exceção de domínio")]
        [Trait("News", "Validando operações")]
        public void NewsTitle_ShorterThanMinimum_ThrowsDomainException()
        {
            // arrange
            var title = "Lore";
            var content = "Conteúdo";
            var author = "Grupo Trinta";
            var dateNow = DateTime.Now;

            // act & assert
            Assert.Throws<DomainExceptionValidation>(() => new News(title, content, author, dateNow));
        }

        [Fact(DisplayName = "Avalia se um título com mais de 255 caracteres lança uma exceção de domínio")]
        [Trait("News", "Validando operações")]
        public void NewsTitle_LongerThanMaximum_ThrowsDomainException()
        {
            // arrange
            var title = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            var content = "Conteúdo";
            var author = "Grupo Trinta";
            var dateNow = DateTime.Now;

            // act & assert
            Assert.Throws<DomainExceptionValidation>(() => new News(title, content, author, dateNow));
        }
    }
}
