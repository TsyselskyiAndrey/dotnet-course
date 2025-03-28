using Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
