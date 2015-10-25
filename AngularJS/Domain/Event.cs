using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public Location Location { get; set; }
        public string ImageUrl { get; set; }
        public List<Session> Sessions { get; set; }


    }
}
