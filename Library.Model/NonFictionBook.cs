using Library.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class NonFictionBook : Book
    {
        public NonfictionGenre Genre { get; set; }
        public string? HistoricalSignificance { get; set; }
    }
}
