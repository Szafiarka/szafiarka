using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szafiarka.Classes
{
    public static class Messages
    {
        public enum warnings
        {
            [Description("Nie wybrałeś elementu do usunięcia")]
            DELETE,
            [Description("Nie wybrałeś elementu do edycji")]
            EDIT,
        }

        public enum errors
        {
            [Description("Nie można zapisać, popraw dane")]
            SAVE,
        }

        public enum ok
        {
            [Description("Rzecz zapisana")]
            SAVE,
        }
    }
}
