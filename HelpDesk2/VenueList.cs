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
            int venueId = 121;      // Start at random number.
            var venuesStr = File.ReadAllLines("VenueNameList.txt");
            Array.Sort(venuesStr);
            foreach (var venue in venuesStr)
            {
                Add(new Venue { Id = venueId++, Name = venue });
            }
        }
    }
}
