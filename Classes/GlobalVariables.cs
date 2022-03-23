//  Bazaar Checker
//  Copyright (C) 2022 AlvaroBajceps(marcinwal9@gmail.com)
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//  
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//  Source: https://github.com/AlvaroBajceps/BazaarChecker
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
        public static GroupedAuctions groupedAuctions = new GroupedAuctions();
        public static Mutex activeAuctions_Mutex = new Mutex();

        public static Items allItems = new Items();
        //it will be used only in Form therad so no need for mutex
        //public static Mutex allItems_Mutex = new Mutex();
    }
}
