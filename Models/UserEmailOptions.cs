using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApp.Models
{
    public class UserEmailOptions
    {
        // List of all the receivers of the e-mail
        public List<string> ToEmails { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<KeyValuePair<string,string>> PlaceHolders { get; set; }

    }
}
