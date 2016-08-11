using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk2
{
    public class VenueList : ObservableCollection<Venue>
    {
        public VenueList() : base()
        {
            Add(new Venue { Id = 0, Name = "Unknown" });
            int venueId = 100;
            var venuesStr = File.ReadAllLines("VenueNameList.txt");
            foreach (var venue in venuesStr)
            {
                Add(new Venue { Id = venueId++, Name = venue });
            }
        }
    }
}
