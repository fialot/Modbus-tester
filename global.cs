using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using Ini;
using myFunctions;

namespace ModBus
{

    #region Structures

    public enum eMBProtocol
    {
        RTU, ASCII, TCPIP
    }

    public enum eMBRegType
    {
        HoldingRegister, InputRegister, Coil, DiscreteInput, HoldingRegExt, InputRegExt
    }

    public enum eDataType
    {
        Short, UShort, Int, UInt, Float, Double, String8, ShortArray, UShortArray, IntArray, UIntArray, FloatArray, DoubleArray
    }

    [Serializable]
    struct DevData
    {
        public List<device_t> devices;
    }

    [Serializable]
    public struct device_t
    {
        public string name;
        public string port;
        public string IP;
        public int baudrate;
        public string parity;
        public int bits;
        public string stopbits;
        public byte address;
        public eMBProtocol protocol;

        public List<packet_t> packet;
    }

    [Serializable]
    public struct packet_t
    {
        public string name;
        public ushort address;
        public ushort len;
        public eMBRegType type;

        public List<reg_t> regs;

        public string device;
        public Guid GUID;
    }

    [Serializable]
    public struct reg_t
    {
        public string name;
        public ushort address;
        public ushort len;
        public string value;
        public eDataType dataType;

        public string group;
        public bool RW;
        public bool showChart;
        public Guid GUID;
    }

    public struct devItem_t
    {
        public bool edit;
        public int devIdx;
        public int packetIdx;
        public int regIdx;
    }

    public struct tRegLocation
    {
        public int devIdx;
        public int pacIdx;
        public int regIdx;
    }

    #endregion

    static class global
    {
        

        public static List<device_t> devices;
        public static devItem_t devItem;
        public static List<string> groupList;


        public static void Init()
        {
            devices = new List<device_t>();
            groupList = new List<string>();
        }

        public static void editReg(reg_t regItem)
        {
            tRegLocation idx = findReg(regItem.GUID);
            if (idx.regIdx >= 0)
            {
                devices[idx.devIdx].packet[idx.pacIdx].regs.RemoveAt(idx.regIdx);
                devices[idx.devIdx].packet[idx.pacIdx].regs.Insert(idx.regIdx, regItem);
            }
        }

        public static void delReg(reg_t regItem)
        {
            tRegLocation idx = findReg(regItem.GUID);
            if (idx.regIdx >= 0)
            {
                devices[idx.devIdx].packet[idx.pacIdx].regs.RemoveAt(idx.regIdx);
            }
        }

        public static void editPacket(packet_t packetItem)
        {
            tRegLocation idx = findPacket(packetItem.GUID);
            if (idx.pacIdx >= 0)
            {
                devices[idx.devIdx].packet.RemoveAt(idx.pacIdx);
                devices[idx.devIdx].packet.Insert(idx.pacIdx, packetItem);
            }
        }

        public static void delPacket(packet_t packetItem)
        {
            tRegLocation idx = findPacket(packetItem.GUID);
            if (idx.pacIdx >= 0)
            {
                devices[idx.devIdx].packet.RemoveAt(idx.pacIdx);
            }
        }

        public static void delDev(device_t devItem, int index)
        {
            if (index >= 0 && index < devices.Count)
            {
                devices.RemoveAt(index);
                devices.Add(devItem);
            }
        }

        public static void delDev(int index)
        {
            if (index >= 0 && index < devices.Count)
            {
                devices.RemoveAt(index);
            }
        }

        /*public static int findReg(reg_t regItem)
        {
            for (int i = 0; i < registers.Count; i++)
            {
                if (registers[i].GUID == regItem.GUID)
                {
                    return i;
                }
            }
            return -1;
        }*/

        public static int findDev(string name)
        {
            for (int i = 0; i < devices.Count; i++)
            {
                if (devices[i].name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        

        public static tRegLocation findPacket(string name)
        {
            tRegLocation res = new tRegLocation();
            res.devIdx = -1;
            res.pacIdx = -1;
            res.regIdx = -1;

            for (int i = 0; i < devices.Count; i++)
            {
                if (devices[i].packet != null)
                {
                    for (int j = 0; j < devices[i].packet.Count; j++)
                    {
                        if (devices[i].packet[j].name == name)
                        {
                            res.devIdx = i;
                            res.pacIdx = j;
                            return res;
                        }
                    }
                }
            }
            return res;
        }

        public static tRegLocation findPacket(int index)
        {
            tRegLocation res = new tRegLocation();
            res.devIdx = -1;
            res.pacIdx = -1;
            res.regIdx = -1;

            int pos = -1;

            for (int i = 0; i < devices.Count; i++)
            {
                if (devices[i].packet != null)
                {
                    for (int j = 0; j < devices[i].packet.Count; j++)
                    {
                        pos++;
                        if (index == pos)
                        {
                            res.devIdx = i;
                            res.pacIdx = j;
                            return res;
                        }
                    }
                }
            }
            return res;
        }

        public static tRegLocation findPacket(Guid GUID)
        {
            tRegLocation res = new tRegLocation();
            res.devIdx = -1;
            res.pacIdx = -1;
            res.regIdx = -1;

            for (int i = 0; i < devices.Count; i++)
            {
                if (devices[i].packet != null)
                {
                    for (int j = 0; j < devices[i].packet.Count; j++)
                    {
                        if (devices[i].packet[j].GUID == GUID)
                        {
                            res.devIdx = i;
                            res.pacIdx = j;
                            return res;
                        }
                    }
                }
            }
            return res;
        }

        public static tRegLocation findReg(Guid GUID)
        {
            tRegLocation res = new tRegLocation();
            res.devIdx = -1;
            res.pacIdx = -1;
            res.regIdx = -1;

            for (int i = 0; i < devices.Count; i++)
            {
                if (devices[i].packet != null)
                {
                    for (int j = 0; j < devices[i].packet.Count; j++)
                    {
                        if (devices[i].packet[j].regs != null)
                        {
                            for (int k = 0; k < devices[i].packet[j].regs.Count; k++)
                            {
                                if (devices[i].packet[j].regs[k].GUID == GUID)
                                {
                                    res.devIdx = i;
                                    res.pacIdx = j;
                                    res.regIdx = k;
                                    return res;
                                }
                            }
                        }
                        
                    }
                }
            }
            return res;
        }

        public static List<packet_t> GetPacketList()
        {
            List<packet_t> res = new List<packet_t>();
            foreach (device_t devItm in devices)
            {
                if (devItm.packet != null)
                {
                    foreach (packet_t pacItm in devItm.packet)
                    {
                        res.Add(pacItm);
                    }
                }
            }

            return res;
        }

        public static List<reg_t> GetRegList()
        {
            List<reg_t> res = new List<reg_t>();
            foreach (device_t devItm in devices)
            {
                if (devItm.packet != null)
                {
                    foreach (packet_t pacItm in devItm.packet)
                    {
                        if (pacItm.regs != null)
                        {
                            foreach (reg_t regItm in pacItm.regs)
                            {
                                res.Add(regItm);
                            }
                        }
                    }
                }
            }

            return res;
        }

        public static void RefreshGroupList()
        {

            groupList.Clear();
            foreach (device_t devItm in devices)
            {
                if (devItm.packet != null)
                {
                    foreach (packet_t pacItm in devItm.packet)
                    {
                        if (pacItm.regs != null)
                        {
                            foreach (reg_t regItm in pacItm.regs)
                            {
                                if (IsInGroupList(regItm.group) < 0)
                                    groupList.Add(regItm.group);
                            }
                        }
                    }
                }
            }

        }

        public static int IsInGroupList(string group)
        {
            for (int i = 0; i < groupList.Count; i++)
            {
                if (groupList[i] == group) return i;
            }
            return -1;
        }

        public static bool IsArrayType(reg_t reg)
        {
            if (reg.dataType == eDataType.ShortArray
                    || reg.dataType == eDataType.UShortArray
                    || reg.dataType == eDataType.IntArray
                    || reg.dataType == eDataType.UIntArray
                    || reg.dataType == eDataType.FloatArray
                    || reg.dataType == eDataType.DoubleArray)
            {
                return true;
            }
            return false;
        }

        public static bool SaveDevices(string filename)
        {
            if (Path.GetExtension(filename) == ".ini")
            {
                /*IniFile ini;
                ini = new IniFile(filename);
                int devCount = global.devices.Count;
                int regsCount = global.registers.Count;

                ini.Write("Dev", "Count", devCount.ToString());
                ini.Write("Regs", "Count", regsCount.ToString());

                for (int i = 0; i < devCount; i++)
                {
                    ini.Write("dev" + i.ToString(), "Name", global.devices[i].name);
                    ini.Write("dev" + i.ToString(), "Baud", global.devices[i].baudrate.ToString());
                    ini.Write("dev" + i.ToString(), "Bits", global.devices[i].bits.ToString());
                    ini.Write("dev" + i.ToString(), "Parity", global.devices[i].parity);
                    ini.Write("dev" + i.ToString(), "Port", global.devices[i].port);
                    ini.Write("dev" + i.ToString(), "StopBits", global.devices[i].stopbits);
                    ini.Write("dev" + i.ToString(), "Address", global.devices[i].address.ToString());
                }

                for (int i = 0; i < regsCount; i++)
                {
                    ini.Write("reg" + i.ToString(), "Name", global.registers[i].name);
                    ini.Write("reg" + i.ToString(), "Type", global.registers[i].type.ToString());
                    ini.Write("reg" + i.ToString(), "Reg", global.registers[i].reg.ToString());
                    ini.Write("reg" + i.ToString(), "Device", global.registers[i].device.ToString());
                    ini.Write("reg" + i.ToString(), "Address", global.registers[i].address.ToString());
                    ini.Write("reg" + i.ToString(), "Length", global.registers[i].len.ToString());
                    ini.Write("reg" + i.ToString(), "GUID", global.registers[i].GUID.ToString());
                }*/
                return true;
            }
            else
            {
                DevData data = new DevData();
                data.devices = devices;
                return Files.ExportXml(filename, data);
            }
        }

        public static bool SaveDevice(string filename, int index)
        {
            if (Path.GetExtension(filename) == ".ini")
            {
                return true;
            }
            else
            {
                DevData data = new DevData();
                data.devices = new List<device_t>();
                data.devices.Add(devices[index]);
                return Files.ExportXml(filename, data);
            }
        }

        public static bool LoadDevices(string filename, bool append = false)
        {
            string x = Path.GetExtension(filename);
            if (Path.GetExtension(filename) == ".ini")
            {
                /*IniFile ini;
                ini = new IniFile(filename);
                int devCount = ini.ReadInt("Dev", "Count", 0);
                int regsCount = ini.ReadInt("Regs", "Count", 0);

                global.devices = new List<device_t>();

                for (int i = 0; i < devCount; i++)
                {
                    device_t devItem = new device_t();
                    devItem.name = ini.Read("dev" + i.ToString(), "Name", "dev" + i.ToString());
                    devItem.baudrate = ini.ReadInt("dev" + i.ToString(), "Baud", 9600);
                    devItem.bits = ini.ReadInt("dev" + i.ToString(), "Bits", 8);
                    devItem.parity = ini.Read("dev" + i.ToString(), "Parity", "Even");
                    devItem.port = ini.Read("dev" + i.ToString(), "Port", "COM1");
                    devItem.stopbits = ini.Read("dev" + i.ToString(), "StopBits", "One");
                    devItem.address = ini.ReadByte("dev" + i.ToString(), "Address", 1);

                    global.devices.Add(devItem);
                }

                for (int i = 0; i < regsCount; i++)
                {
                    reg_t regItem = new reg_t();
                    regItem.name = ini.Read("reg" + i.ToString(), "Name", "reg" + i.ToString());
                    regItem.type = ini.ReadInt("reg" + i.ToString(), "Type", 0);
                    regItem.reg = ini.ReadInt("reg" + i.ToString(), "Reg", 0);
                    regItem.device = ini.Read("reg" + i.ToString(), "Device", "");
                    regItem.address = (ushort)ini.ReadInt("reg" + i.ToString(), "Address", 0);
                    regItem.len = (ushort)ini.ReadInt("reg" + i.ToString(), "Length", 1);
                    regItem.value = "";
                    regItem.GUID = ini.ReadGUID("reg" + i.ToString(), "GUID", Guid.NewGuid());
                    global.registers.Add(regItem);
                }*/
                return true;
            }
            else
            {
                DevData data = new DevData();
                try
                {
                    data = (DevData)Files.ImportXml(filename, data);
                    // ----- Clear last values & generate new Guid -----
                    for (int j = 0; j < data.devices.Count; j++)
                    {
                        if (data.devices[j].packet != null)
                        {
                            for (int k = 0; k < data.devices[j].packet.Count; k++)
                            {
                                packet_t pItem = data.devices[j].packet[k];
                                pItem.GUID = Guid.NewGuid();
                                data.devices[j].packet.RemoveAt(k);
                                data.devices[j].packet.Insert(k, pItem);

                                if (data.devices[j].packet[k].regs != null)
                                {
                                    for (int i = 0; i < data.devices[j].packet[k].regs.Count; i++)
                                    {
                                        reg_t item = data.devices[j].packet[k].regs[i];
                                        item.value = "";
                                        item.GUID = Guid.NewGuid();
                                        data.devices[j].packet[k].regs.RemoveAt(i);
                                        data.devices[j].packet[k].regs.Insert(i, item);
                                    }
                                }
                            }
                        }
                        
                    }
                    
                }catch (Exception)
                {
                    return false;
                }
                if (append)
                {
                    foreach (var devItem in data.devices)
                        devices.Add(devItem);
                }
                else
                    devices = data.devices;
                RefreshGroupList();
                return true;
            }


        }
        
    }
}
