using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMaster.DLL;

namespace WordMaster.UI
{
    public static class AppManager
    {
        readonly internal static GlobalContext CurrentContext = new GlobalContext( );
        internal static Game CurrentGame = null;
    }
}
