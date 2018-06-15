using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;
using MODBUS;
using Ini;
using myFunctions;

namespace ModBus
{



    public partial class frmMain : Form
    {
        devMB MB;
        bool sending;

        frmReg formReg;
        frmDev formDev;
        frmPacket formPacket;

        List<packet_t> packetList;
        List<reg_t> regList;

        bool devChanged = false;


        public frmMain()
        {
            InitializeComponent();
        }

        #region Form init

        private void frmMain_Load(object sender, EventArgs e)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string ver = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            this.Text += " - v" + ver.Substring(0, ver.Length - 2);

            global.Init();
            initOLV();

            // ----- Load Settings -----
            settings.LoadSettings();
            global.LoadDevices(settings.lastDevices);
            showDev();
            showRegs();


            MB = new devMB();                                                                                                                                                   

            MB.SetDevices(global.devices);


            //chart1.Series[0].XValueType = ChartValueType.DateTime;
            //chart1.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";
            sending = false;

            

            // ----- Create "/devices" folder -----
            string AppPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (!Directory.Exists(AppPath + Path.DirectorySeparatorChar + "devices"))
                Directory.CreateDirectory(AppPath + Path.DirectorySeparatorChar + "devices");

            devChanged = false;

        }

        private void initOLV()
        {
            olvColName.AspectGetter = delegate(object x) { return ((reg_t)x).name; };
            olvColAddress.AspectGetter = delegate(object x) { return ((reg_t)x).address; };
            olvColDevice.AspectGetter = delegate(object x) { return ((reg_t)x).group; };
            olvColRW.AspectGetter = delegate(object x) {
                if (((reg_t)x).RW) return "RW";
                else return "R";
            };
            olvColType.AspectGetter = delegate(object x) { return ((reg_t)x).dataType.ToString(); };
            olvColValue.AspectGetter = delegate(object x) { return ((reg_t)x).value; };

            this.olvColPacket.AspectGetter = delegate (object x) { return ((packet_t)x).name; };
            this.olvColPRange.AspectGetter = delegate (object x) { return ((packet_t)x).address.ToString() + " - " + (((packet_t)x).address + ((packet_t)x).len-1).ToString(); };
            this.olvColPType.AspectGetter = delegate (object x) { return ((packet_t)x).type.ToString(); };

            olvRegisters.SetObjects(regList);
            olvPacket.SetObjects(packetList);

            this.olvColName.GroupKeyGetter = delegate(object x) { return ((reg_t)x).group; };
            this.olvColAddress.GroupKeyGetter = delegate(object x) { return ((reg_t)x).group; };
            this.olvColDevice.GroupKeyGetter = delegate(object x) { return ((reg_t)x).group; };
            this.olvColRW.GroupKeyGetter = delegate(object x) { return ((reg_t)x).group; };
            this.olvColType.GroupKeyGetter = delegate(object x) { return ((reg_t)x).group; };
            this.olvColValue.GroupKeyGetter = delegate(object x) { return ((reg_t)x).group; };



            this.olvColPacket.GroupKeyGetter = delegate (object x) { return ((packet_t)x).device; };
            this.olvColPRange.GroupKeyGetter = delegate (object x) { return ((packet_t)x).device; };
            this.olvColPType.GroupKeyGetter = delegate (object x) { return ((packet_t)x).device; };

            olvRegisters.ShowGroups = true;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true) timer1.Enabled = false;
            else timer1.Enabled = true;



        }

        #region Graph

        private void lvChart_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Index < chart1.Series.Count)
                chart1.Series[e.Item.Index].Enabled = e.Item.Checked;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (btnRun.Tag != "1")
            {
                btnRun.Tag = "1";
                timer1.Enabled = true;
                btnRun.Text = "Stop";
            }
            else
            {
                btnRun.Tag = "0";
                timer1.Enabled = false;
                btnRun.Text = "Run";
            }

        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval = Convert.ToInt32(txtPeriod.Text);
            }
            catch (Exception err) { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!sending)
            {
                sending = true;
                try
                {
                    List<packet_t> selectPackets = new List<packet_t>();
                    int regI = 0;
                    for (int i = 0; i < lvChart.Items.Count; i++)
                    {
                        while ((regI < regList.Count) && !regList[regI].showChart)
                        {
                            regI++;
                        }
                        if (lvChart.Items[i].Checked)
                        {
                            
                            reg_t regItem = regList[regI];
                            tRegLocation loc = global.findReg(regItem.GUID);

                            bool isHere = false;
                            for (int j = 0; j < selectPackets.Count; j++)
                            {
                                if (selectPackets[j].GUID == global.devices[loc.devIdx].packet[loc.pacIdx].GUID)
                                {
                                    isHere = true;
                                    break;
                                }
                            }
                            if (!isHere) selectPackets.Add(global.devices[loc.devIdx].packet[loc.pacIdx]);
                        }
                        regI++;
                    }

                    bool procOK = true;
                    foreach (packet_t item in selectPackets)
                    {
                        procOK = MB.GetPacketValue(item);
                        if (!procOK) break;
                    }

                    showValues();

                    regI = 0;
                    for (int i = 0; i < lvChart.Items.Count; i++)
                    {
                        while ((regI < regList.Count) && !regList[regI].showChart)
                        {
                            regI++;
                        }
                        if (lvChart.Items[i].Checked)
                        {
                            if (procOK)
                            {
                                
                                reg_t regItem = regList[regI];
                                lvChart.Items[i].SubItems[1].Text = regItem.value;
                                addChart(i, regItem.value);
                            }
                        }
                        regI++;
                    }

                }
                catch (Exception err)
                {
                    timer1.Enabled = false;
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sending = false;
                
            }
        }

        private void CreateChart()
        {
            chart1.Series.Clear();
            string txt = "";

            for (int j = 0; j < lvChart.Items.Count; j++)
            {
                try
                {
                    txt = lvChart.Items[j].Text + " (" + lvChart.Items[j].Group.ToString() + ")";
                    chart1.Series.Add(txt);
                    chart1.Series[j].ChartType = SeriesChartType.FastLine;
                    chart1.Series[j].BorderWidth = 2;
                    chart1.Series[j].XValueType = ChartValueType.DateTime;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";
                }
                catch
                {
                    try
                    {
                        chart1.Series.Add("item " + j.ToString());
                        chart1.Series[j].ChartType = SeriesChartType.FastLine;
                        chart1.Series[j].BorderWidth = 2;
                        chart1.Series[j].XValueType = ChartValueType.DateTime;
                        chart1.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";
                    }
                    catch
                    {

                    }
                }
            }

            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            // --- Spectrum ----
            chart2.Series.Clear();
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            for (int j = 0; j < lvSpectrum.Items.Count; j++)
            {
                try
                {
                    txt = lvSpectrum.Items[j].Text;
                    chart2.Series.Add(txt);
                    chart2.Series[j].ChartType = SeriesChartType.FastLine;
                    chart2.Series[j].BorderWidth = 2;
                    chart2.Series[j].XValueType = ChartValueType.UInt32;
                    //chart2.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";
                }
                catch
                {
                    try
                    {
                        chart2.Series.Add("item " + j.ToString());
                        chart2.Series[j].ChartType = SeriesChartType.FastLine;
                        chart2.Series[j].BorderWidth = 2;
                        chart2.Series[j].XValueType = ChartValueType.UInt32;
                        //chart2.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";
                    }
                    catch
                    {

                    }
                }
            }
        }



        private void addChart(int index, string value)
        {
            try
            {
                double dvalue = Convert.ToDouble(value);
                chart1.Series[index].Points.AddXY(DateTime.Now, dvalue);
            }
            catch
            {

            }
        }

        private void showArray(int index, string value)
        {
            try
            {
                chart2.Series[index].Points.Clear();
                float[] y = Conv.ToFloatArr(value);
                for (int i = 0; i < y.Length; i++) 
                    chart2.Series[index].Points.AddXY(i, y[i]);
            }
            catch
            {

            }
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            /*string rad1;
            string rad2;
            int t1 = 0, t2 = 0, t3 = 0, t4 = 0 ;
            sending = true;
            try
            {
                MB.SetConnection(9600, Parity.None, 8, StopBits.One);
                MB.OpenConnection("COM4", true, 3);
                rad1 = textBox1.Text;
                //MB.WriteInt(101, 68);
                MB.WriteString(100,rad1,rad1.Length);
                rad2 = textBox2.Text;
                MB.WriteString(200,rad2,rad2.Length);
                //t1 = MB.ReadIInt(0);
                //t2 = MB.ReadIInt(1);
                //t3 = MB.ReadIInt(2);
                //t4 = MB.ReadIInt(3);

                //t1 = MB.ReadInt(1);
                //t2 = MB.ReadInt(2);
                //t3 = MB.ReadInt(4);
                //t4 = MB.ReadInt(5);

                label3.Text = t1.ToString() + " - " + t2.ToString() + " - " + t3.ToString() + " - " + t4.ToString();

              
            }
            catch (Exception err)
            {
                timer1.Enabled = false;
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MB.CloseConnection();
            sending = false;*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true) timer2.Enabled = false;
            else timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            /*if (!sending)
            {
                string rad1;
                string rad2;
                int x = 0;
                sending = true;
                try
                {
                    MB.SetConnection(9600, Parity.None, 8, StopBits.One);
                    MB.OpenConnection("COM4", true, 3);

                    rad1 = DateTime.Now.ToShortTimeString();
                    MB.WriteString(101, rad1, rad1.Length);
                    rad2 = "inteligentni";
                    //MB.WriteString(201, rad2, rad2.Length);
                    //x = MB.ReadInt(18);


                }
                catch (Exception err)
                {
                    timer1.Enabled = false;
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MB.CloseConnection();
                sending = false;
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*string rad1;
            string rad2;
            int t1 = 0, t2 = 0, t3 = 0, t4 = 0;
            sending = true;
            float f1;
            try
            {
                MB.SetConnection(115200, Parity.Even, 8, StopBits.One);
                MB.OpenConnection("COM5", true, 2);
                //rad1 = textBox1.Text;
                //MB.WriteInt(101, 68);
                //MB.WriteString(100, rad1, rad1.Length);
                //rad2 = textBox2.Text;
                //MB.WriteString(200, rad2, rad2.Length);
                //t1 = MB.ReadIInt(0);
                //t2 = MB.ReadIInt(1);
                //t3 = MB.ReadIInt(2);
                //t4 = MB.ReadIInt(3);

                //t1 = MB.ReadInt(1);
                //t2 = MB.ReadInt(2);
                //t3 = MB.ReadInt(4);
                //t4 = MB.ReadInt(5);

                //label3.Text = t1.ToString() + " - " + t2.ToString() + " - " + t3.ToString() + " - " + t4.ToString();

                t1 = MB.ReadInt(1,false);
                t2 = MB.ReadInt(2, false);
                f1 = MB.ReadFloat(3, false);
                rad1 = MB.ReadString(5, 12, false);

                t1 = MB.ReadInt(1);
                MB.WriteInt(1, 1);
                //t2 = MB.ReadInt(2);
                //MB.WriteInt(2, 3);


            }
            catch (Exception err)
            {
                timer1.Enabled = false;
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MB.CloseConnection();
            sending = false;*/
        }


        #region Table


        #region Context Menu

        // ===== Device Menu ==================================================

        private void mnuDevItem_Opening(object sender, CancelEventArgs e)
        {
            if (lbDevices.SelectedIndex < 0)
            {
                mnuDevItem.Items[1].Visible = false;
                mnuDevItem.Items[2].Visible = false;
                //mnuDevItem.Items[3].Visible = false;
                //mnuDevItem.Items[4].Visible = false;
                mnuDevItem.Items[5].Visible = false;
                mnuDevItem.Items[6].Visible = false;
                mnuDevItem.Items[7].Visible = false;
            }
            else
            {
                mnuDevItem.Items[1].Visible = true;
                mnuDevItem.Items[2].Visible = true;
                //mnuDevItem.Items[3].Visible = true;
                //mnuDevItem.Items[4].Visible = true;
                mnuDevItem.Items[5].Visible = true;
                mnuDevItem.Items[6].Visible = true;
                mnuDevItem.Items[7].Visible = true;
            }
        }

        private void mnuAdd_Click(object sender, EventArgs e)
        {
            global.devItem.edit = false;
            global.devItem.devIdx = -1;
            formDev = new frmDev();
            if (formDev.ShowDialog() == DialogResult.OK)
            {
                showDev();
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            global.devItem.edit = true;
            global.devItem.devIdx = lbDevices.SelectedIndex;


            formDev = new frmDev();
            if (formDev.ShowDialog() == DialogResult.OK)
            {
                showDev();
            }

        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            global.delDev(lbDevices.SelectedIndex);

            showDev();
        }

        private void mnuImport_Click(object sender, EventArgs e)
        {
            string AppPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (openDialog1.InitialDirectory == "") openDialog1.InitialDirectory = AppPath + Path.DirectorySeparatorChar + "devices";
            if (openDialog1.ShowDialog() == DialogResult.OK)
            {
                openDialog1.InitialDirectory = Path.GetDirectoryName(openDialog1.FileName);
                global.LoadDevices(openDialog1.FileName, true);
                showDev();
                showRegs();
            }
        }

        private void mnuExport_Click(object sender, EventArgs e)
        {
            string AppPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (saveDialog1.InitialDirectory == "") saveDialog1.InitialDirectory = AppPath + Path.DirectorySeparatorChar + "devices";
            if (saveDialog1.ShowDialog() == DialogResult.OK)
            {
                saveDialog1.InitialDirectory = Path.GetDirectoryName(saveDialog1.FileName);
                global.SaveDevice(saveDialog1.FileName, lbDevices.SelectedIndex);
            }
        }

        private void mnuDevRead_Click(object sender, EventArgs e)
        {
            if (!MB.GetDevValues(lbDevices.SelectedIndex))
                Dialogs.ShowErr("Read error", "Read Error");

            showValues();
        }

        // ===== Packet Menu ==================================================

        private void mnuPacketItem_Opening(object sender, CancelEventArgs e)
        {
            if (global.devices.Count == 0)
                e.Cancel = true;

            if (olvPacket.SelectedIndex < 0)
            {
                //e.Cancel = true;
                mnuPacketItem.Items[1].Visible = false;
                mnuPacketItem.Items[2].Visible = false;
                mnuPacketItem.Items[3].Visible = false;
                mnuPacketItem.Items[4].Visible = false;
            }
            else
            {
                mnuPacketItem.Items[1].Visible = true;
                mnuPacketItem.Items[2].Visible = true;
                mnuPacketItem.Items[3].Visible = true;
                mnuPacketItem.Items[4].Visible = true;
            }
        }

        private void mnuPacAdd_Click(object sender, EventArgs e)
        {
            global.devItem.edit = false;
            global.devItem.devIdx = -1;
            global.devItem.packetIdx = -1;

            formPacket = new frmPacket();
            if (formPacket.ShowDialog() == DialogResult.OK)
            {
                showDev();
            }
        }

        private void mnuPacEdit_Click(object sender, EventArgs e)
        {
            global.devItem.edit = true;
            tRegLocation index = global.findPacket(((packet_t)olvPacket.SelectedItem.RowObject).GUID);
            global.devItem.devIdx = index.devIdx;
            global.devItem.packetIdx = index.pacIdx;
            global.devItem.regIdx = index.regIdx;

            formPacket = new frmPacket();
            if (formPacket.ShowDialog() == DialogResult.OK)
            {
                showDev();
            }
        }

        private void mnuPacDuplicate_Click(object sender, EventArgs e)
        {
            global.devItem.edit = false;
            tRegLocation index = global.findPacket(((packet_t)olvPacket.SelectedItem.RowObject).GUID);
            global.devItem.devIdx = index.devIdx;
            global.devItem.packetIdx = index.pacIdx;
            global.devItem.regIdx = index.regIdx;

            formPacket = new frmPacket();
            if (formPacket.ShowDialog() == DialogResult.OK)
            {
                showDev();
            }
        }

        private void mnuPacDel_Click(object sender, EventArgs e)
        {
            global.delPacket((packet_t)olvPacket.SelectedItem.RowObject);

            showDev();
        }

        private void mnuPacRead_Click(object sender, EventArgs e)
        {
            if (!MB.GetPacketValue((packet_t)olvPacket.SelectedItem.RowObject))
                Dialogs.ShowErr("Read error", "Read Error");

            showValues();
        }

        // ===== Register Menu ==================================================
        private void mnuRegItem_Opening(object sender, CancelEventArgs e)
        {
            if (global.devices.Count == 0 || packetList.Count == 0)
                e.Cancel = true;

            if (olvRegisters.SelectedItems.Count == 0)
            {
                mnuRegItem.Items[1].Visible = false;
                mnuRegItem.Items[2].Visible = false;
                mnuRegItem.Items[3].Visible = false;
                mnuRegItem.Items[4].Visible = false;
                mnuRegItem.Items[5].Visible = false;
                mnuRegItem.Items[6].Visible = false;
            }
            else
            {
                mnuRegItem.Items[1].Visible = true;
                mnuRegItem.Items[2].Visible = true;
                mnuRegItem.Items[3].Visible = true;
                mnuRegItem.Items[4].Visible = true;
                mnuRegItem.Items[5].Visible = true;

                if (((reg_t)olvRegisters.SelectedItem.RowObject).RW)
                {
                    mnuRegItem.Items[6].Visible = true;
                }
                else
                {
                    mnuRegItem.Items[6].Visible = false;
                }

            }
        }

        private void mnuRegAdd_Click(object sender, EventArgs e)
        {
            global.devItem.edit = false;
            global.devItem.devIdx = -1;
            global.devItem.packetIdx = -1;
            global.devItem.regIdx = -1;

            formReg = new frmReg();
            if (formReg.ShowDialog() == DialogResult.OK)
            {
                showDev();
            }
        }

        private void mnuRegEdit_Click(object sender, EventArgs e)
        {
            try
            {
                global.devItem.edit = true;
                tRegLocation index = global.findReg(((reg_t)olvRegisters.SelectedItem.RowObject).GUID);
                global.devItem.devIdx = index.devIdx;
                global.devItem.packetIdx = index.pacIdx;
                global.devItem.regIdx = index.regIdx;

                formReg = new frmReg();
                if (formReg.ShowDialog() == DialogResult.OK)
                {
                    showDev();
                }
            }
            catch (Exception) { }
        }

        private void mnuRegDelete_Click(object sender, EventArgs e)
        {
            try
            {
                global.delReg((reg_t)olvRegisters.SelectedItem.RowObject);
                showRegs();
            }
            catch (Exception) { }
        }

        private void mnuRegCopy_Click(object sender, EventArgs e)
        {
            try
            {
                global.devItem.edit = false;
                tRegLocation index = global.findReg(((reg_t)olvRegisters.SelectedItem.RowObject).GUID);
                global.devItem.devIdx = index.devIdx;
                global.devItem.packetIdx = index.pacIdx;
                global.devItem.regIdx = index.regIdx;

                formReg = new frmReg();
                if (formReg.ShowDialog() == DialogResult.OK)
                {
                    showDev();
                }
            }
            catch (Exception) { }
        }

        private void mnuRegRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (!MB.GetRegValue((reg_t)olvRegisters.SelectedItem.RowObject))
                    Dialogs.ShowErr("Read error", "Read Error");

                showValues();
            } catch (Exception) { }
        }

        private void mnuRegWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string value = ((reg_t)olvRegisters.SelectedItem.RowObject).value;
                if (functions.InputBox("Register - " + ((reg_t)olvRegisters.SelectedItem.RowObject).name, "New value:", ref value) == DialogResult.OK)
                {
                    if (!MB.SetRegValue((reg_t)olvRegisters.SelectedItem.RowObject, value))
                        Dialogs.ShowErr("Write error", "Write Error");

                    showValues();
                }
            }
            catch (Exception) { }
        }

        #endregion


        #region Table Buttons

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (!MB.GetPacketsValues())
                Dialogs.ShowErr("Read error", "Read Error");

            showValues();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string AppPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (openDialog1.InitialDirectory == "") openDialog1.InitialDirectory = AppPath + Path.DirectorySeparatorChar + "devices";
            if (openDialog1.ShowDialog() == DialogResult.OK)
            {
                openDialog1.InitialDirectory = Path.GetDirectoryName(openDialog1.FileName);
                global.LoadDevices(openDialog1.FileName);
                showDev();
                showRegs();
                settings.lastDevices = openDialog1.FileName;
                devChanged = false;
            }
        }

        private void btnSaveDev_Click(object sender, EventArgs e)
        {
            string AppPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (saveDialog1.InitialDirectory == "") saveDialog1.InitialDirectory = AppPath + Path.DirectorySeparatorChar + "devices";
            if (saveDialog1.ShowDialog() == DialogResult.OK)
            {
                saveDialog1.InitialDirectory = Path.GetDirectoryName(saveDialog1.FileName);

                global.SaveDevices(saveDialog1.FileName);

                settings.lastDevices = saveDialog1.FileName;
                devChanged = false;
            }
        }

        #endregion


        private void showDev()
        {
            lbDevices.Items.Clear();
            lvChart.Groups.Clear();
            for (int i = 0; i < global.devices.Count; i++)
            {
                lbDevices.Items.Add(global.devices[i].name);
            }
            for (int i = 0; i < global.groupList.Count; i++)
            {
                lvChart.Groups.Add("grp" + i.ToString(), global.groupList[i]);
            }
            showRegs();
            if (MB != null)
                MB.SetDevices(global.devices);
        }

        private void showRegs()
        {
            packetList = global.GetPacketList();
            regList = global.GetRegList();

            olvRegisters.SetObjects(regList);
            olvPacket.SetObjects(packetList);

            // ----- Chart -----
            lvChart.Items.Clear();
            int j = 0;
            for (int i = 0; i < regList.Count; i++)
            {
                if (regList[i].showChart)
                {
                    lvChart.Items.Add(regList[i].name);

                    int index = global.IsInGroupList(regList[i].group);
                    if (index >= 0)
                        lvChart.Items[j].Group = lvChart.Groups[index];
                    lvChart.Items[j].SubItems.Add("");
                    j++;
                }
            }
            CreateChart();

            // ----- Spectrum -----
            lvSpectrum.Items.Clear();
            j = 0;
            for (int i = 0; i < regList.Count; i++)
            {
                if (global.IsArrayType(regList[i]))
                {
                    lvSpectrum.Items.Add(regList[i].name);
                }
            }
            devChanged = true;
        }

        private void showValues()
        {
            packetList = global.GetPacketList();
            regList = global.GetRegList();

            olvRegisters.SetObjects(regList);
            olvPacket.SetObjects(packetList);


        }



        #endregion

        

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


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.SaveSettings();

            if (devChanged)
            {
                if (Dialogs.ShowQuest("Data was changed. Save?", "Change") == DialogResult.Yes)
                {
                    btnSaveDev_Click(null, null);
                }
            }
        }




        private void lbDevices_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbDevices.SelectedIndex >=0)
                mnuEdit_Click(sender, e);
        }


        private void button5_Click(object sender, EventArgs e)
        {
            /*int x = 0;
            int delay = 0;
            try
            {
                MB.OpenConnection(global.devices[global.registers[0].device].port, true, global.devices[global.registers[0].device].address);
                MB.SetConnection(global.devices[global.registers[0].device].baudrate, ToParity(global.devices[global.registers[0].device].parity), global.devices[global.registers[0].device].bits, ToStopBits(global.devices[global.registers[0].device].stopbits));
                MB.WriteInt(32, 500);
                x++;
                System.Threading.Thread.Sleep(delay);
                MB.WriteBool(6, false);
                x++;
                System.Threading.Thread.Sleep(delay);
                MB.WriteBool(7, true);
                x++;
                System.Threading.Thread.Sleep(delay);


                for (int I = 0; I <= 3; I++)
                {
                    MB.WriteInt(33, (short)I);
                    x++;
                    System.Threading.Thread.Sleep(delay);
                    MB.WriteLong(38, 3000);
                    x++;
                    System.Threading.Thread.Sleep(delay);

                    MB.WriteInt(34, 0); //LLD
                    x++;
                    System.Threading.Thread.Sleep(delay);
                    MB.WriteInt(35, 1023); //ULD
                    x++;
                    System.Threading.Thread.Sleep(delay);
                    MB.WriteInt(40, 1);
                    x++;
                    System.Threading.Thread.Sleep(delay);
                }

                MB.WriteBool(6, true);
                x++;
                System.Threading.Thread.Sleep(delay);

                MB.CloseConnection();
                MessageBox.Show("ok");
            }
            catch (Exception err)
            {
                MB.CloseConnection();
                MessageBox.Show(err.Message + " " + x.ToString());
            }*/

        }
        

        private void btnClear_Click(object sender, EventArgs e)
        {
            global.devices = new List<device_t>();
            showDev();
            showRegs();
        }

        #region spectrum

        private void btnSpecStart_Click(object sender, EventArgs e)
        {
            

            if (timer3.Enabled == false)
            {
                timer3_Tick(sender, e);

                MB.WriteCoil(1, true);              // clear spectrum
                MB.WriteCoil(0, true);              // Start spectrum

                btnSpecStart.Text = "Stop";
                timer3.Enabled = true;
            }
            else
            {
                btnSpecStart.Text = "Start";
                timer3.Enabled = false;
                while (sending) { System.Threading.Thread.Sleep(10); }
                MB.WriteCoil(0, false);              // Stop spectrum
            }
        }

        private void btnSpecClear_Click(object sender, EventArgs e)
        {
            MB.WriteCoil(1, true);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (!sending)
            {
                sending = true;
                try
                {
                    List<packet_t> selectPackets = new List<packet_t>();
                    int regI = 0;
                    for (int i = 0; i < lvSpectrum.Items.Count; i++)
                    {
                        
                        while ((regI < regList.Count) && !global.IsArrayType(regList[regI]))
                        {
                            regI++;
                        }
                        if (lvSpectrum.Items[i].Checked)
                        {

                            reg_t regItem = regList[regI];
                            tRegLocation loc = global.findReg(regItem.GUID);

                            bool isHere = false;
                            for (int j = 0; j < selectPackets.Count; j++)
                            {
                                if (selectPackets[j].GUID == global.devices[loc.devIdx].packet[loc.pacIdx].GUID)
                                {
                                    isHere = true;
                                    break;
                                }
                            }
                            if (!isHere) selectPackets.Add(global.devices[loc.devIdx].packet[loc.pacIdx]);
                        }
                        regI++;
                    }

                    bool procOK = true;
                    foreach (packet_t item in selectPackets)
                    {
                        procOK = MB.GetPacketValue(item);
                        if (!procOK) break;
                    }

                    showValues();

                    regI = 0;
                    for (int i = 0; i < lvSpectrum.Items.Count; i++)
                    {
                        while((regI < regList.Count) && !global.IsArrayType(regList[regI]))
                        {
                            regI++;
                        }
                        if (lvSpectrum.Items[i].Checked)
                        {
                            if (procOK)
                            {
                                reg_t regItem = regList[regI];

                                showArray(i, regItem.value);
                            }
                        }
                        regI++;
                    }

                }
                catch (Exception err)
                {
                    timer1.Enabled = false;
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sending = false;

            }

        }

        private void CreateChart2()
        {
            chart2.Series.Clear();
            int x = 0;
            for (int j = 0; j < 3; j++)
            {
                try
                {
                    chart2.Series.Add("Dev" + (j + 1).ToString() + "Stamp");
                    chart2.Series[x].ChartType = SeriesChartType.FastLine;
                    chart2.Series[x].BorderWidth = 2;
                    chart2.Series[x++].XValueType = ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";

                    chart2.Series.Add("Dev" + (j + 1).ToString() + "CPS1");
                    chart2.Series[x].ChartType = SeriesChartType.FastLine;
                    chart2.Series[x].BorderWidth = 2;
                    chart2.Series[x++].XValueType = ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";

                    chart2.Series.Add("Dev" + (j + 1).ToString() + "CPS2");
                    chart2.Series[x].ChartType = SeriesChartType.FastLine;
                    chart2.Series[x].BorderWidth = 2;
                    chart2.Series[x++].XValueType = ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";

                    chart2.Series.Add("Dev" + (j + 1).ToString() + "CPS3");
                    chart2.Series[x].ChartType = SeriesChartType.FastLine;
                    chart2.Series[x].BorderWidth = 2;
                    chart2.Series[x++].XValueType = ChartValueType.DateTime;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";
                }
                catch { }
            }

            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
        }



        private void addChart2(int index, string value)
        {
            try
            {
                double dvalue = Convert.ToDouble(value);
                chart2.Series[index].Points.AddXY(DateTime.Now, dvalue);
            }
            catch
            {

            }
        }


        #endregion
        
    }
}
