namespace Basket.Domain
{
    public class ArticleFood : ArticleBase
    {
        public ArticleFood(int price, string category) : base(price, category)
        {
        }

        public override int Calculate()
        {
            var amount = 0;
            amount += _price * 100 + _price * 12;
            return amount;
        }
    }
}