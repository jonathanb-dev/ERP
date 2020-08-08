namespace DL.Parameters
{
    public class ProductParameters
    {
        private const int MinItemsPerPage = 10;
        private const int MaxItemsPerPage = 50;

        public int PageNumber { get; set; } = 1;
        private int _itemsPerPage = MinItemsPerPage;
        private decimal _minPrice { get; set; }
        private decimal _maxPrice { get; set; } = decimal.MaxValue;
        public string OrderBy { get; set; }

        public int ItemsPerPage
        {
            get { return _itemsPerPage; }
            set
            {
                if (value < MinItemsPerPage)
                {
                    _itemsPerPage = MinItemsPerPage;
                }
                else if (value > MaxItemsPerPage)
                {
                    _itemsPerPage = MaxItemsPerPage;
                }
                else
                {
                    _itemsPerPage = value;
                }
            }
        }

        public decimal MinPrice
        {
            get { return _minPrice; }
            set
            {
                if (value < 0 || value > _maxPrice)
                {
                    _minPrice = 0M;
                }
                else
                {
                    _minPrice = value;
                }
            }
        }

        public decimal MaxPrice
        {
            get { return _maxPrice; }
            set
            {
                if (value < 0 || value < _minPrice)
                {
                    _maxPrice = decimal.MaxValue;
                }
                else
                {
                    _maxPrice = value;
                }
            }
        }
    }
}