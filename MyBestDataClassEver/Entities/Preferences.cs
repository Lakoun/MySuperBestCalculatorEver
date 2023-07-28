using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestDataClassEver.Entities {
    public class UserPreferences {
        public string CurentBrowserId { get; set; }

        public List<string> LastResults { get; set; } = new List<string>();
    }
}
