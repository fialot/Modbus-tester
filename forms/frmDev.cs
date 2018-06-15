using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace ModBus
{
    public partial class frmDev : Form
    {
        List<packet_t> packets;

        public frmDev()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            device_t devItem;

            devItem.name = txtName.Text;
            devItem.bits = Convert.ToInt32(cbDataBits.Text);
            devItem.parity = cbParity.Text;
            devItem.stopbits = cbStopBits.Text;
            devItem.baudrate = Convert.ToInt32(cbBaud.Text);
            devItem.port = cbbCOMPorts.Text;
            devItem.address = Convert.ToByte(txtAddress.Text);
            devItem.IP = txtIP.Text + ":" + txtPort.Text;
            devItem.protocol = (eMBProtocol)cbProtocol.SelectedIndex;
            devItem.packet = packets;

            packet_t[] packetArray = devItem.packet.ToArray();
            for (int i = 0; i < packetArray.Length; i++)
            {
                packetArray[i].device = devItem.name;
                reg_t[] regArray = packetArray[i].regs.ToArray();
                for (int j = 0; j < regArray.Length; j++)
                {
                    regArray[j].group = packetArray[i].name;
                }
                packetArray[i].regs = regArray.ToList();
            }
            devItem.packet = packetArray.ToList();


            if (global.devItem.edit)
            {
                global.devices.RemoveAt(global.devItem.devIdx);
                global.devices.Insert(global.devItem.devIdx, devItem);
            }
            else
            {
                global.devices.Add(devItem);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void frmDev_Load(object sender, EventArgs e)
        {
            // ----- Init ComboBoxes -----
            string[] ports = SerialPort.GetPortNames();         // check COM ports
            for (int i = 0; i < ports.Length; i++)
            {
                this.cbbCOMPorts.Items.Add(ports[i]);
            }
            if ((cbbCOMPorts.Items.Count > 0) & cbbCOMPorts.Text == "")
            {
                cbbCOMPorts.Text = cbbCOMPorts.Items[0].ToString();
            }

            var list = Enum.GetValues(typeof(eMBProtocol));     // init combo Protocol
            foreach (var item in list)
                this.cbProtocol.Items.Add(item.ToString());
            cbProtocol.SelectedIndex = 0;

            cbBaud.Text = cbBaud.Items[0].ToString();           // init combo Baud

            cbParity.Items.Clear();                             // init combo Parity
            cbParity.Items.Add(Parity.None.ToString());
            cbParity.Items.Add(Parity.Even.ToString());
            cbParity.Items.Add(Parity.Odd.ToString());
            cbParity.Items.Add(Parity.Mark.ToString());
            cbParity.Items.Add(Parity.Space.ToString());

            cbDataBits.Items.Clear();                           // init combo DataBits
            for (int i = 5; i <= 8; i++)
                cbDataBits.Items.Add(i.ToString());

            cbStopBits.Items.Clear();                           // init combo StopBits
            cbStopBits.Items.Add(StopBits.One.ToString());
            cbStopBits.Items.Add(StopBits.OnePointFive.ToString());
            cbStopBits.Items.Add(StopBits.Two.ToString());
            cbStopBits.Items.Add(StopBits.None.ToString());

            cbDataBits.Text = "8";                              // fill default values
            cbStopBits.Text = "One";
            cbParity.Text = "Even";

            txtIP.Text = "";
            txtPort.Text = "502";


            // ----- Fill Values -----

            if (global.devItem.edit)
            {
                txtName.Text = global.devices[global.devItem.devIdx].name;
                cbDataBits.Text = global.devices[global.devItem.devIdx].bits.ToString();
                cbParity.Text = global.devices[global.devItem.devIdx].parity;
                cbStopBits.Text = global.devices[global.devItem.devIdx].stopbits;
                cbBaud.Text = global.devices[global.devItem.devIdx].baudrate.ToString();
                cbbCOMPorts.Text = global.devices[global.devItem.devIdx].port;
                txtAddress.Text = global.devices[global.devItem.devIdx].address.ToString();
                cbProtocol.SelectedIndex = (int)global.devices[global.devItem.devIdx].protocol;
                packets = global.devices[global.devItem.devIdx].packet;

                string[] IP = global.devices[global.devItem.devIdx].IP.Split(new string[] { ":" }, StringSplitOptions.None);
                if (IP.Length == 2)
                {
                    txtIP.Text = IP[0];
                    txtPort.Text = IP[1];
                }
                else
                {
                    txtIP.Text = global.devices[global.devItem.devIdx].IP;
                    txtPort.Text = "502";
                }
                
            }
            else packets = new List<packet_t>();

            //cbDataBits.Text = settings.SP.bits.ToString();
            //cbStopBits.Text = settings.SP.stopbits.ToString();
            //cbParity.Text = settings.SP.parity;
            //chbDTR.Checked = settings.SP.DTR;
            //chbRTS.Checked = settings.SP.RTS;
        }

        void refreshForm()
        {
            if (cbProtocol.SelectedIndex == (int)eMBProtocol.TCPIP)
            {
                lblPort.Visible = false;
                cbbCOMPorts.Visible = false;
                lblBaud.Visible = false;
                cbBaud.Visible = false;
                lblParity.Visible = false;
                cbParity.Visible = false;
                lblDataBits.Visible = false;
                cbDataBits.Visible = false;
                lblStopBits.Visible = false;
                cbStopBits.Visible = false;

                lblIP.Visible = true;
                txtIP.Visible = true;
                lblTCPPort.Visible = true;
                txtPort.Visible = true;

            } else
            {
                lblPort.Visible = true;
                cbbCOMPorts.Visible = true;
                lblBaud.Visible = true;
                cbBaud.Visible = true;
                lblParity.Visible = true;
                cbParity.Visible = true;
                lblDataBits.Visible = true;
                cbDataBits.Visible = true;
                lblStopBits.Visible = true;
                cbStopBits.Visible = true;

                lblIP.Visible = false;
                txtIP.Visible = false;
                lblTCPPort.Visible = false;
                txtPort.Visible = false;
            }

        }

        private void cbProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshForm();
        }
    }
}
