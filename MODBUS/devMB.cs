using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using ModBus;

using myFunctions;
using Protocols;

namespace MODBUS
{
    class devMB
    {
        ModbusProtocolExt MB;
        List<device_t> devices;
        bool readAll;

        public devMB(bool readAll = false)
        {
            MB = new ModbusProtocolExt();
            this.readAll = readAll;
        }

        public void SetDevices(List<device_t> devices)
        {
            this.devices = devices;
        }

        private void connect(int devIndex)
        {
            // ----- Connecting -----
            if (MB.isConnected())
            {
                if (devices[devIndex].protocol == eMBProtocol.TCPIP)
                {
                    if (MB.getPort() != devices[devIndex].IP)
                    {
                        MB.Disconnect();
                        string[] split = devices[devIndex].IP.Split(new string[] { ":" }, StringSplitOptions.None);
                        if (split.Length == 2)
                            MB.ConnectTCP(split[0], Conv.ToIntDef(split[0],502));
                        else
                            MB.ConnectTCP(split[0]);
                    }
                }
                else
                {
                    if (MB.getPort() != devices[devIndex].port)
                    {
                        MB.Disconnect();
                        MB.Connect(devices[devIndex].port);
                    }
                }
            }
            else
            {
                if (devices[devIndex].protocol == eMBProtocol.TCPIP)
                {
                    string[] split = devices[devIndex].IP.Split(new string[] { ":" }, StringSplitOptions.None);
                    if (split.Length == 2)
                        MB.ConnectTCP(split[0], Conv.ToIntDef(split[0], 502));
                    else
                        MB.ConnectTCP(split[0]);
                }
                else
                    MB.Connect(devices[devIndex].port);
            }
            MB.SetSerialParam(devices[devIndex].baudrate, ToParity(devices[devIndex].parity), devices[devIndex].bits, ToStopBits(devices[devIndex].stopbits));
            MB.SetAddress(devices[devIndex].address);
        }

        public bool GetDevValues(int index)
        {
            for (int i = 0; i < devices[index].packet.Count; i++)
            {
                if (!GetPacketValue(devices[index].packet[i]))
                    return false;
            }
            return true;
        }

        public bool GetPacketValue(packet_t packet)
        {
            
            bool res = true;

            tRegLocation index = global.findPacket(packet.GUID);
            
            try
            {
                connect(index.devIdx);

                // ------ Read MB packet -----
                ushort[] data = new ushort[0];
                bool[] bdata = new bool[0];
                if (devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.HoldingRegister)
                {
                    data = MB.ReadHoldingRegisters(devices[index.devIdx].packet[index.pacIdx].address, devices[index.devIdx].packet[index.pacIdx].len);
                }
                else if (devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.InputRegister)
                {

                    data = MB.ReadInputRegisters(devices[index.devIdx].packet[index.pacIdx].address, devices[index.devIdx].packet[index.pacIdx].len);
                }
                else if (devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.DiscreteInput)
                {
                    bdata = MB.ReadDiscreteInputs(devices[index.devIdx].packet[index.pacIdx].address, devices[index.devIdx].packet[index.pacIdx].len);
                }
                else if (devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.Coil)
                {
                    bdata = MB.ReadCoils(devices[index.devIdx].packet[index.pacIdx].address, devices[index.devIdx].packet[index.pacIdx].len);
                }
                else if (devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.HoldingRegExt)
                {
                    data = MB.ReadHoldingRegistersExt(devices[index.devIdx].packet[index.pacIdx].address, devices[index.devIdx].packet[index.pacIdx].len);
                }
                else if (devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.InputRegExt)
                {

                    data = MB.ReadInputRegistersExt(devices[index.devIdx].packet[index.pacIdx].address, devices[index.devIdx].packet[index.pacIdx].len);
                }
                else return false;

                // ----- Fill regs -----
                for (int i = 0; i < devices[index.devIdx].packet[index.pacIdx].regs.Count; i++)
                {
                    int startAddr = devices[index.devIdx].packet[index.pacIdx].address;
                    int pos = devices[index.devIdx].packet[index.pacIdx].regs[i].address - startAddr;
                    ushort len = devices[index.devIdx].packet[index.pacIdx].regs[i].len;
                    if (pos < 0) break;

                    reg_t regItem = devices[index.devIdx].packet[index.pacIdx].regs[i];
                    if (devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.InputRegister || devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.HoldingRegister ||
                       devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.InputRegExt || devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.HoldingRegExt)
                    {
                        switch (regItem.dataType)
                        {
                            case eDataType.Short:
                                regItem.value = ((short)data[pos]).ToString();
                                break;
                            case eDataType.Int:
                                regItem.value = MB.GetInt(data, pos).ToString();
                                break;
                            case eDataType.UInt:
                                regItem.value = MB.GetUInt(data, pos).ToString();
                                break;
                            case eDataType.Float:
                                regItem.value = MB.GetFloat(data, pos).ToString();
                                break;
                            case eDataType.Double:
                                regItem.value = MB.GetDouble(data, pos).ToString();
                                break;
                            case eDataType.String8:
                                regItem.value = MB.GetString8(data, pos, len).ToString();
                                break;
                            case eDataType.ShortArray:
                                regItem.value = Conv.ArrToStr(MB.GetShortArray(data, pos, len));
                                break;
                            case eDataType.UShortArray:
                                regItem.value = Conv.ArrToStr(MB.GetUShortArray(data, pos, len));
                                break;
                            case eDataType.IntArray:
                                regItem.value = Conv.ArrToStr(MB.GetIntArray(data, pos, len));
                                break;
                            case eDataType.UIntArray:
                                regItem.value = Conv.ArrToStr(MB.GetUIntArray(data, pos, len));
                                break;
                            case eDataType.FloatArray:
                                regItem.value = Conv.ArrToStr(MB.GetFloatArray(data, pos, len));
                                break;
                            case eDataType.DoubleArray:
                                regItem.value = Conv.ArrToStr(MB.GetDoubleArray(data, pos, len));
                                break;
                            default:
                                regItem.value = data[pos].ToString();
                                break;
                        }
                    }
                    else
                    {
                        bool[] bres = new bool[len];
                        Array.Copy(bdata, pos, bres, 0, len);
                        regItem.value = Conv.ArrToStr(bres);
                    }
                   

                    devices[index.devIdx].packet[index.pacIdx].regs.RemoveAt(i);
                    devices[index.devIdx].packet[index.pacIdx].regs.Insert(i, regItem);
                }
            }
            catch (Exception err)
            {
                res = false;
            }
            System.Threading.Thread.Sleep(10);
            return res;
        }

        public bool GetPacketsValues()
        {
            for (int i = 0; i < devices.Count; i++)
            {
                if (devices[i].packet != null)
                {
                    for (int j = 0; j < devices[i].packet.Count; j++)
                    {
                        if (!GetPacketValue(devices[i].packet[j])) return false;
                    }
                }
            }
            return true;
        }

        public bool GetRegValue(reg_t register)
        {
            bool res = true;

            tRegLocation index = global.findReg(register.GUID);

            try
            {
                connect(index.devIdx);

                // ------ Read MB packet -----
                ushort[] data = new ushort[0];
                if (devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.HoldingRegister || devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.InputRegister ||
                    devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.HoldingRegExt || devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.InputRegExt)
                {
                    switch (register.dataType)
                    {
                        case eDataType.Short:
                            register.value = ((short)MB.ReadRegister(register.address, !register.RW)).ToString();
                            break;
                        case eDataType.Int:
                            register.value = MB.ReadInt(register.address, !register.RW).ToString();
                            break;
                        case eDataType.UInt:
                            register.value = MB.ReadUInt(register.address, !register.RW).ToString();
                            break;
                        case eDataType.Float:
                            register.value = MB.ReadFloat(register.address, !register.RW).ToString();
                            break;
                        case eDataType.Double:
                            register.value = MB.ReadDouble(register.address, !register.RW).ToString();
                            break;
                        case eDataType.String8:
                            register.value = MB.ReadString8(register.address, register.len, !register.RW);
                            break;
                        case eDataType.UShortArray:
                            register.value = Conv.ArrToStr(MB.ReadRegisters(register.address, register.len, !register.RW));
                            break;
                        case eDataType.ShortArray:
                            register.value = Conv.ArrToStr(MB.GetShortArray(MB.ReadRegisters(register.address, register.len, !register.RW), 0, register.len));
                            break;
                        case eDataType.IntArray:
                            register.value = Conv.ArrToStr(MB.GetIntArray(MB.ReadRegisters(register.address, (ushort)(2*register.len), !register.RW), 0, register.len));
                            break;
                        case eDataType.UIntArray:
                            register.value = Conv.ArrToStr(MB.GetUIntArray(MB.ReadRegisters(register.address, (ushort)(2 * register.len), !register.RW), 0, register.len));
                            break;
                        case eDataType.FloatArray:
                            register.value = Conv.ArrToStr(MB.GetFloatArray(MB.ReadRegisters(register.address, (ushort)(2 * register.len), !register.RW), 0, register.len));
                            break;
                        case eDataType.DoubleArray:
                            register.value = Conv.ArrToStr(MB.GetDoubleArray(MB.ReadRegisters(register.address, (ushort)(4 * register.len), !register.RW), 0, register.len));
                            break;
                        default:
                            register.value = MB.ReadRegister(register.address, !register.RW).ToString();
                            break;
                    }
                    
                }
                else
                {
                    switch (register.dataType)
                    {
                        default:
                            register.value = Conv.ArrToStr(MB.ReadBools(register.address, register.len, !register.RW));
                            break;
                    }
                }

               

                devices[index.devIdx].packet[index.pacIdx].regs.RemoveAt(index.regIdx);
                devices[index.devIdx].packet[index.pacIdx].regs.Insert(index.regIdx, register);
            }
            catch (Exception err)
            {
                res = false;
            }
            System.Threading.Thread.Sleep(10);
            return res;
        }

        public bool SetRegValue(reg_t register, string value)
        {
            bool res = true;

            tRegLocation index = global.findReg(register.GUID);

            try
            {
                connect(index.devIdx);

                // ------ Read MB packet -----
                ushort[] data = new ushort[0];
                if (devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.HoldingRegister ||
                    devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.HoldingRegExt)
                {
                    switch (register.dataType)
                    {
                        case eDataType.Short:
                            MB.WriteRegister(register.address, (ushort)Convert.ToInt16(value));
                            register.value = value;
                            break;
                        case eDataType.Int:
                            MB.WriteInt(register.address, Convert.ToInt32(value));
                            register.value = value;
                            break;
                        case eDataType.UInt:
                            MB.WriteUInt(register.address, Convert.ToUInt32(value));
                            register.value = value;
                            break;
                        case eDataType.Float:
                            MB.WriteFloat(register.address, Convert.ToSingle(value));
                            register.value = value;
                            break;
                        case eDataType.Double:
                            MB.WriteDouble(register.address, Convert.ToDouble(value));
                            register.value = value;
                            break;
                        case eDataType.String8:
                            MB.WriteString8(register.address, value, register.len);
                            register.value = value;
                            break;
                        default:
                            MB.WriteRegister(register.address, Convert.ToUInt16(value));
                            register.value = value;
                            break;
                    }

                }
                else if (devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.Coil)
                {
                    switch (register.dataType)
                    {
                        default:
                            MB.WriteBools(register.address, Conv.StrToBool(value));
                            register.value = value;
                            break;
                    }
                }
                else return false;
                
                devices[index.devIdx].packet[index.pacIdx].regs.RemoveAt(index.regIdx);
                devices[index.devIdx].packet[index.pacIdx].regs.Insert(index.regIdx, register);
            }
            catch (Exception err)
            {
                res = false;
            }
            System.Threading.Thread.Sleep(10);
            return res;
        }
        
        public bool WriteReg(ushort address, ushort value)
        {
            try
            {
                MB.WriteRegister(address, value);
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool WriteCoil(ushort address, bool value)
        {
            try
            {
                MB.WriteBool(address, value);
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        private Parity ToParity(string name)
        {
            switch (name)
            {
                case "Even":
                    return Parity.Even;
                case "Mark":
                    return Parity.Mark;
                case "None":
                    return Parity.None;
                case "Odd":
                    return Parity.Odd;
                case "Space":
                    return Parity.Space;
                default:
                    return Parity.None;
            }
        }

        private StopBits ToStopBits(string name)
        {
            switch (name)
            {
                case "None":
                    return StopBits.None;
                case "One":
                    return StopBits.One;
                case "OnePointFive":
                    return StopBits.OnePointFive;
                case "Two":
                    return StopBits.Two;
                default:
                    return StopBits.One;
            }
        }
    }
}
