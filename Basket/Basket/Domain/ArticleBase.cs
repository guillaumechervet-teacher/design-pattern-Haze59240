namespace Basket.Domain
{
    public abstract class ArticleBase
    {
        protected int _price;
        protected string _category;

        public ArticleBase(int price, string category)
        {
            _price = price;
            _category = category;
        }

        public abstract int Calculate();
    }
}