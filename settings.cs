using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using Ini;

namespace ModBus
{
    static class settings
    {
        

        public static string lastDevices = "";


        public static void LoadSettings()
        {
            IniFile ini;
            ini = new IniFile("./config.ini");

            lastDevices = ini.Read("Path", "lastDevices", "");
        }

        public static void SaveSettings()
        {
            IniFile ini;
            ini = new IniFile("./config.ini");

            ini.Write("Path", "lastDevices", lastDevices);
        }
    }
}
