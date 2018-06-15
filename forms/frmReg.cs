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
    public partial class frmReg : Form
    {
        Guid GUID;

        public frmReg()
        {
            InitializeComponent();
        }

        private void frmReg_Load(object sender, EventArgs e)
        {
            // ----- Init ComboBoxes -----
            var list = Enum.GetValues(typeof(eDataType));
            cbType.Items.Clear();
            foreach (var item in list)
                this.cbType.Items.Add(item.ToString());
            cbType.SelectedIndex = 0;

            cbPacket.Items.Clear();
            foreach (device_t devItm in global.devices)
            {
                if (devItm.packet != null)
                {
                    foreach (packet_t packetItm in devItm.packet)
                    {
                        cbPacket.Items.Add(packetItm.name);
                    }
                }
            }
            if (cbPacket.Items.Count > 0) cbPacket.SelectedIndex = 0;

            // ----- Fill Values -----

            if (global.devItem.packetIdx >= 0 && global.devItem.packetIdx >= 0 && global.devItem.regIdx >= 0)
            {
                txtName.Text = global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].regs[global.devItem.regIdx].name;
                cbPacket.Text = global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].name;
                cbType.SelectedIndex = (int) global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].regs[global.devItem.regIdx].dataType;
                txtAddress.Text = global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].regs[global.devItem.regIdx].address.ToString();
                txtLen.Text = global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].regs[global.devItem.regIdx].len.ToString();
                txtGroup.Text = global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].regs[global.devItem.regIdx].group;
                chbShowChart.Checked = global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].regs[global.devItem.regIdx].showChart;
                if (global.devItem.edit)
                    GUID = global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].regs[global.devItem.regIdx].GUID;
                else
                {
                    GUID = Guid.NewGuid();
                    txtGroup.Text = global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].name;
                }
                    
            } else
            {
                GUID = Guid.NewGuid();
            }
            cbPacket_SelectedIndexChanged(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            reg_t regItem;

            regItem.name = txtName.Text;
            regItem.dataType = (eDataType)cbType.SelectedIndex;
            regItem.address = (ushort)Conv.ToShortDef(txtAddress.Text, 0);
            if (functions.IsInteger(txtLen.Text))
                regItem.len = Convert.ToUInt16(txtLen.Text);
            else
                regItem.len = 1;
            regItem.value = "";
            regItem.group = txtGroup.Text;
            regItem.showChart = chbShowChart.Checked;
            regItem.GUID = GUID;

            tRegLocation index = global.findPacket(cbPacket.SelectedIndex);
            //if (index.devIdx >= 0) regItem.group = global.devices[index.devIdx].packet[index.pacIdx].name;


            if (global.devItem.edit)
            {
                if (global.devItem.devIdx == index.devIdx && global.devItem.packetIdx == index.pacIdx)
                {
                    eMBRegType pType = global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].type;
                    if (pType == eMBRegType.Coil || pType == eMBRegType.HoldingRegister) regItem.RW = true;
                    else regItem.RW = false;

                    global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].regs.RemoveAt(global.devItem.regIdx);
                    global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].regs.Insert(global.devItem.regIdx, regItem);
                }
                else
                {
                    if (index.devIdx < 0 || index.pacIdx < 0)
                    {
                        Dialogs.ShowErr("Selected device not exist!", "");
                        return;
                    }
                    else
                    {
                        eMBRegType pType = global.devices[index.devIdx].packet[index.pacIdx].type;
                        if (pType == eMBRegType.Coil || pType == eMBRegType.HoldingRegister) regItem.RW = true;
                        else regItem.RW = false;
                        global.devices[global.devItem.devIdx].packet[global.devItem.packetIdx].regs.RemoveAt(global.devItem.regIdx);
                        global.devices[index.devIdx].packet[index.pacIdx].regs.Add(regItem);
                    }
                }
            }
            else
            {
                if (index.devIdx < 0 || index.pacIdx < 0)
                {
                    Dialogs.ShowErr("Selected packet not exist!", "");
                    return;
                }
                else
                {
                    eMBRegType pType = global.devices[index.devIdx].packet[index.pacIdx].type;
                    if (pType == eMBRegType.Coil || pType == eMBRegType.HoldingRegister) regItem.RW = true;
                    else regItem.RW = false;
                    global.devices[index.devIdx].packet[index.pacIdx].regs.Add(regItem);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((eDataType)cbType.SelectedIndex)
            {
                case eDataType.String8:
                case eDataType.ShortArray:
                case eDataType.UShortArray:
                case eDataType.IntArray:
                case eDataType.UIntArray:
                case eDataType.FloatArray:
                case eDataType.DoubleArray:
                    txtLen.Visible = true;
                    lblLen.Visible = true;
                    break;
                default:
                    txtLen.Text = "1";
                    txtLen.Visible = false;
                    lblLen.Visible = false;
                    break;
            }
        }

        private void cbPacket_SelectedIndexChanged(object sender, EventArgs e)
        {
            tRegLocation index = global.findPacket(cbPacket.SelectedIndex);
            if (global.devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.Coil || global.devices[index.devIdx].packet[index.pacIdx].type == eMBRegType.DiscreteInput)
            {
                cbType.Visible = false;
                lblType.Visible = false;
                txtLen.Visible = true;
                lblLen.Visible = true;
            } else
            {
                cbType.Visible = true;
                lblType.Visible = true;
                cbType_SelectedIndexChanged(null, null);
            }

        }
    }
}
