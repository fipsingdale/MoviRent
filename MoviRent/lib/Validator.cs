using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviRent.lib
{
    public class Validator
    {
        private readonly String[] validInputDisplayMenue = {"c", "d", "e", "s", "v", "q"};
        private readonly String[] validInputShowMenue = {"a", "b", "g", "l", "m", "u"};

        public bool valitadeInputFromSearchMenue(String input) {
            if (Int32.Parse(input) >= 0) {
                return true;
            } else { 
                return false;
            }
        }

        public bool valitadeInputFromShowMenue(String input) {
            return !validInputShowMenue.Contains<String>(input);
        }

        public bool valitadeInputFromDisplayMenue(String input) {
            return !validInputDisplayMenue.Contains<String>(input);
        }
    }
}