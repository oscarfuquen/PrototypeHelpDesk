using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk2
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<string> Users { get; set; }
    }
}
