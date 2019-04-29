using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace td3.Views
{
    public class MainPageMenuItem
    {
        public MainPageMenuItem()
        {
            TargetType = typeof(UtilisateursPage);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
