using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fileExemple.Helpers
{
    public class ExcelFileBuilderDtoHelper<T>
    {
        public ExcelFileBuilderDtoHelper(string workSheet, int headerRow, int headerStartColumn, IEnumerable<string> headerTitles, int itemsStartRow, int itemsStartColumn, IEnumerable<T> items)
        {
            WorkSheet = workSheet;
            HeaderRow = headerRow;
            HeaderStartColumn = headerStartColumn;
            HeaderTitles = headerTitles;
            ItemsStartRow = itemsStartRow;
            ItemsStartColumn = itemsStartColumn;
            Items = items;
        }

        public string WorkSheet { get; set; }
        public int HeaderRow { get; set; }
        public int HeaderStartColumn { get; set; }
        public IEnumerable<string> HeaderTitles {get; set;}
        public int ItemsStartRow { get; set; }
        public int ItemsStartColumn { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}