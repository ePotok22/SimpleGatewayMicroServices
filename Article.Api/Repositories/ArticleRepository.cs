using Article.Api.Repositories.Interfaces;
using ArticleModel = Article.Api.Models.Article;

namespace Article.Api.Repositories
{
    public class ArticleRepository : List<ArticleModel>, IArticleRepository
    {
        private readonly static List<ArticleModel> _articles = Populate();

        private static List<ArticleModel> Populate() =>
             new List<ArticleModel>()
            {
                new ArticleModel
                {
                    Id = 1,
                    Title = "First Article",
                    WriterId = 1,
                    LastUpdate = DateTime.Now
                },
                new ArticleModel
                {
                    Id = 2,
                    Title = "Second title",
                    WriterId = 2,
                    LastUpdate = DateTime.Now
                },
                new ArticleModel
                {
                    Id = 3,
                    Title = "Third title",
                    WriterId = 3,
                    LastUpdate = DateTime.Now
                }
            };

        public List<ArticleModel> GetAll() =>
            _articles;

        public ArticleModel? Get(int id) =>
            _articles.FirstOrDefault(x => x.Id == id);

        public int Delete(int id)
        {
            ArticleModel? removed = _articles.SingleOrDefault(x => x.Id == id);

            if (removed != null)
                _articles.Remove(removed);

            return removed?.Id ?? 0;
        }
    }
}