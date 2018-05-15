using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBackUp.Models
{
    public class ApplicationJson
    {
        public ApplicationSettings Application { get; set; }
        public List<ServerSettings> Server { get; set; }
    }
}
