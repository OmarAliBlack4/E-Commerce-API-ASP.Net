using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductSpesificationParameters
    {
        private const int MAXPAGESIZE = 10;
        private const int DEFAULTPAGESIZE = 5;
        public ProductSortingOptions? sort {  get; set; }
        public int? brandId { get; set; }
        public int? typeId { get; set; }

        public int pageIndex { get; set; } = 1;
        private int _pageSize = DEFAULTPAGESIZE;
        public int pageSize 
        {
            get=>_pageSize ;
            set=> _pageSize = value > MAXPAGESIZE ? MAXPAGESIZE : value; 
        }

        public string? Search {  get; set; } 
    }
        public enum ProductSortingOptions 
        { 
            NameAsc,
            NameDesc,
            PriceAsc,
            PriceDesc,
        }
}
