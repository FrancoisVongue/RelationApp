using RelationApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationApp.Models
{
    public class TableInfo
    {
        public int? CurrentPageNumber { get; set; }

        public int? RelationsPerPage  { get; set; }

        public int? AmountOfPages { get; set; }

        public IEnumerable<DisplayRelationViewModel> Relations { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
