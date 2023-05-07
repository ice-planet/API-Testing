using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APITestingDemo2.Objects
{
    public class GetUsers1
    {
        public long page { get; set; }

        public long per_page { get; set; }

        public long total { get; set; }

        public long total_pages { get; set; }

      
        public List<Data> data { get; set; }

        public Support support { get; set; }
    }

    public partial class Data
    {
        
        public long id { get; set; }

      
        public string email { get; set; }

        
        public string first_name { get; set; }

        
        public string last_name { get; set; }

       
        public Uri avatar { get; set; }
    }

    public partial class Support
    {
      
        public Uri url { get; set; }

        
        public string text { get; set; }
    }
}

