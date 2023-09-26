using ArticleModel = Article.Api.Models.Article;

namespace Article.Api.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        List<ArticleModel> GetAll();
        ArticleModel? Get(int id);
        int Delete(int id);
    }
}