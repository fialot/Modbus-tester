using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ini
{
    /// <summary>
    /// Create a New INI file to store or load data
    /// </summary>
    public class IniFile
    {
        public string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        /// <summary>
        /// INIFile Constructor.
        /// </summary>
        /// <PARAM name="INIPath"></PARAM>
        public IniFile(string INIPath)
        {
            path = INIPath;
        }
        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name
        /// <PARAM name="Value"></PARAM>
        /// Value Name
        public void Write(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string Read(string Section, string Key, string DefValue)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, DefValue, temp,
                                            255, this.path);
            return temp.ToString();
        }

        public int ReadInt(string Section, string Key, int DefValue)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, DefValue.ToString(), temp,
                                            255, this.path);
            try
            {
                int res = Convert.ToInt32(temp.ToString());
                return res;

            }
            catch { return DefValue; }
        }

        public byte ReadByte(string Section, string Key, byte DefValue)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, DefValue.ToString(), temp,
                                            255, this.path);
            try
            {
                byte res = Convert.ToByte(temp.ToString());
                return res;

            }
            catch { return DefValue; }
        }

        public uint ReadUInt(string Section, string Key, uint DefValue)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, DefValue.ToString(), temp,
                                            255, this.path);
            try
            {
                uint res = Convert.ToUInt32(temp.ToString());
                return res;

            }
            catch { return DefValue; }
        }

        public bool ReadBool(string Section, string Key, bool DefValue)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, DefValue.ToString(), temp,
                                            255, this.path);
            try
            {
                bool res = Convert.ToBoolean(temp.ToString());
                return res;
            }
            catch { return DefValue; }
        }

        public Guid ReadGUID(string Section, string Key, Guid DefValue)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, DefValue.ToString(), temp,
                                            255, this.path);
            try
            {
                Guid res = new Guid(temp.ToString());
                return res;
            }
            catch { return DefValue; }
        }
    }
}