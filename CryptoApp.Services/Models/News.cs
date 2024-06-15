using CryptoApp.Shared.LanguageStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Services.Models
{
    public class News
    {
        public Dictionary<Language, string>? Title { get; set; }
        public Dictionary<Language, string>? Description { get; set; }
    }
}
