using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BazaarChecker.Classes
{
    static class GlobalVariables
    {
        public static Bazaar bazaar = new Bazaar();
        public static Mutex bazaar_Mutex = new Mutex();
        public static ActiveAuctions activeAuctions = new ActiveAuctions();
        public static Mutex activeAuctions_Mutex = new Mutex();
    }
}
