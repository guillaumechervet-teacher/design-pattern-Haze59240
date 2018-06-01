namespace Basket.Domain
{
    public class BasketLine
    {
        private readonly Article _article;
        private readonly int _numberArticle;

        public BasketLine(Article article, int numberArticle)
        {
            _article = article;
            _numberArticle = numberArticle;
        }

        public int Calculate()
        {
            return _article.Calculate() * _numberArticle;
        }
    }
}