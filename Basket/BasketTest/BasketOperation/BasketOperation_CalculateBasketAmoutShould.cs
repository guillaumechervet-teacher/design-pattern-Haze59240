using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Basket;
using Basket.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

static internal class BasketOperation_CalculateBasketAmoutShould
{
    public static int CalculateBasketAmout(IList<BasketLineArticle> basketLineArticles)
    {
        var amountTotal = 0;
        foreach (var basketLineArticle in basketLineArticles)
        {
// Retrive article from database
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var assemblyDirectory = Path.GetDirectoryName(path);
            var jsonPath = Path.Combine(assemblyDirectory, "article-database.json");
            IList<ArticleDatabase> articleDatabases =
                JsonConvert.DeserializeObject<List<ArticleDatabase>>(File.ReadAllText(jsonPath));
            var article = articleDatabases.First(articleDatabase =>
                articleDatabase.Id == basketLineArticle.Id);
// Calculate amount
            var amount = 0;
            switch (article.Category)
            {
                case "food":
                    amount += article.Price * 100 + article.Price * 12;
                    break;
                case "electronic":
                    amount += article.Price * 100 + article.Price * 20 + 4;
                    break;
                case "desktop":
                    amount += article.Price * 100 + article.Price * 20;
                    break;
            }

            amountTotal += amount * basketLineArticle.Number;
        }

        return amountTotal;
    }
    
    [TestMethod]
    [DynamicData("Baskets")]
    public static void ReturnCorrectAmoutGivenBasket(BasketTest.BasketOperation_CalculateBasketAmoutShould.BasketTest basketTest)
    {
        var basKetService = new BasketService();
        var basketOperation = new BasketOperation(basKetService);
        var amountTotal = basketOperation.CalculateAmout(basketTest.BasketLineArticles);
        Assert.AreEqual(amountTotal, basketTest.ExpectedPrice);
    }
}