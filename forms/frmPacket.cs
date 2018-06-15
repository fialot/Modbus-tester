using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using myFunctions;

namespace ModBus
{
    public partial class frmPacket : Form
    {
        List<reg_t> registers;
        Guid GUID;

        public frmPacket()
        {
            InitializeComponent();
        }

        private void frmReg_Load(object sender, EventArgs e)
        {
            // ----- Init ComboBoxes -----
            var list = Enum.GetValues(typeof(eMBRegType));
            cbType.Items.Clear();
            foreach (var item in list)
                this.cbType.Items.Add(item.ToString());
            cbType.SelectedIndex = 0;

            for (int i = 0; i < global.devices.Count; i++)
                cbDevice.Items.Add(global.devices[i].name);
            if (cbDevice.Items.Count > 0) cbDevice.SelectedIndex = 0;


            // ----- Fill Values -----

            if (global.devItem.packetIdx >= 0 && global.devItem.packetIdx >= 0)
            {
                txtName.Text = global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].name;
                cbType.SelectedIndex = (int)global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].type;
                cbDevice.Text = global.devices[global.devItem.devIdx].name;
                txtAddress.Text = global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].address.ToString();
                txtLen.Text = global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].len.ToString();

                registers = global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].regs;
                if (global.devItem.edit)
                {
                    GUID = global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].GUID;
                }
                else
                {
                    GUID = Guid.NewGuid();
                    registers = new List<reg_t>();
                }   
            }
            else
            {
                registers = new List<reg_t>();
                GUID = Guid.NewGuid();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            packet_t packetItem;

            packetItem.name = txtName.Text;
            packetItem.type = (eMBRegType)cbType.SelectedIndex;
            if (Conv.IsPositiveShort(txtAddress.Text))
                packetItem.address = (ushort)Conv.ToShortDef(txtAddress.Text, 0);
            else
            {
                Dialogs.ShowErr("Wrong address!", "Error");
                return;
            }
            if (Conv.IsPositiveShort(txtLen.Text))
                packetItem.len = Convert.ToUInt16(txtLen.Text);
            else
            {
                Dialogs.ShowErr("Wrong length!", "Error");
                return;
            }
            packetItem.regs = registers;
            packetItem.device = cbDevice.Text;
            packetItem.GUID = GUID;

            if (packetItem.type == eMBRegType.HoldingRegister || packetItem.type == eMBRegType.InputRegister)
            {
                if (packetItem.len > 120 && packetItem.len < 0xFFFF)
                {
                    if (Dialogs.ShowQuest("Too big packet length(> 120 registers)! Realy use this value?", "") != DialogResult.Yes)
                        return;
                }
                else if (packetItem.len > 120)
                {
                    Dialogs.ShowErr("Too big packet length (>120 registers)!", "Error");
                    return;
                }    
            }
            else
            {
                if (packetItem.len > 1968)
                {
                    Dialogs.ShowErr("Too big packet length (>1968 coils/inputs)!", "Error");
                    return;
                }
            }

            if (global.devItem.edit)
            {
                //if (global.devices[global.devItem.devIdx].name == cbDevice.Text)
                if (global.devItem.devIdx == cbDevice.SelectedIndex)
                {
                    global.devices[global.devItem.devIdx].packet.RemoveAt(global.devItem.packetIdx);
                    global.devices[global.devItem.devIdx].packet.Insert(global.devItem.packetIdx, packetItem);
                }
                else
                {
                    int index = global.findDev(cbDevice.Text);
                    if (index < 0)
                    {
                        Dialogs.ShowErr("Selected device not exist!", "");
                        return;
                    }
                    else
                    {
                        global.devices[global.devItem.devIdx].packet.RemoveAt(global.devItem.packetIdx);
                        global.devices[index].packet.Add(packetItem);
                    }
                }
                
            }
            else
            {
                int index = global.findDev(cbDevice.Text);
                if (index < 0)
                {
                    Dialogs.ShowErr("Selected device not exist!", "");
                    return;
                } else
                {
                    global.devices[index].packet.Add(packetItem);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

       

    }
}
