﻿namespace Article.Tests.Mock.Models
{
    public class ArticleMock
    {
        public List<Api.Models.Article> GetAll() =>
            new List<Api.Models.Article>()
            {
                new Api.Models.Article
                {
                    Id = 1,
                    LastUpdate = DateTime.Now,
                    Title = "First Article",
                    WriterId = 1
                },
                new Api.Models.Article
                {
                    Id = 2,
                    LastUpdate = DateTime.Now,
                    Title = "Second Article",
                    WriterId = 3
                }
            };

        public Api.Models.Article Get() =>
             new Api.Models.Article
             {
                 Id = 1,
                 LastUpdate = DateTime.Now,
                 Title = "First Article",
                 WriterId = 1
             };

        public Api.Models.Article? GetNotFound() =>
            default;
    }
}