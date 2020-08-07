namespace DL.Parameters
{
    public class ProductParameters
    {
        private const int MinItemsPerPage = 10;
        private const int MaxItemsPerPage = 50;

        public int PageNumber { get; set; } = 1;
        private int _itemsPerPage = MinItemsPerPage;

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
    }
}