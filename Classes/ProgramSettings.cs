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
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace BazaarChecker
{
    static class ProgramSettings
    {
        public struct SettingsData
        {
            public bool BazzarRefresh { get; set; }
            public int BazzarRefreshInterval { get; set; }

            public bool AuctionHouseRefresh { get; set; }
            public int AuctionHouseRefreshInterval { get; set; }
        }

        public static SettingsData settings;

        static ProgramSettings()
        {
            BackToDefault();
        }

        public static bool Save()
        {
            FileStream file;
            try
            {
                file = File.Create("settings.json");
            }
            catch {
                return false;
            }

            var dataToSave = JsonSerializer.SerializeToUtf8Bytes<SettingsData>(settings);
            file.Write(dataToSave);
            file.Close();

            return true;
        }

        public static bool Read()
        {
            FileStream file;
            try
            {
                file = File.OpenRead("settings.json");
            }
            catch
            {
                return false;
            }

            Span<Byte> readed = new byte[file.Length];
            file.Read(readed);
            file.Close();
            settings = JsonSerializer.Deserialize<SettingsData>(readed);

            return true;
        }

        public static void BackToDefault()
        {
            settings.BazzarRefresh = false;
            settings.BazzarRefreshInterval = 30000;
            settings.AuctionHouseRefresh = false;
            settings.AuctionHouseRefreshInterval = 60000;
        }
    }
}
