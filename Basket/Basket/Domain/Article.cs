namespace Basket.Domain
{
    public class Article
    {
        private readonly int _price;
        private readonly string _category;

        public Article(int price, string category)
        {
            _price = price;
            _category = category;
        }

        public int Calculate()
        {
            var amount = 0;
            switch (_category)
            {
                case "food":
                    amount += _price * 100 + _price * 12;
                    break;
                case "electronic":
                    amount += _price * 100 + _price * 20 + 4;
                    break;
                case "desktop":
                    amount += _price * 100 + _price * 20;
                    break;
            }
            return amount;
        }
    }
}