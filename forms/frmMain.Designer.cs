namespace ModBus
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("item1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "fghfhgfhgf",
            "ffff"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("item1");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "fghfhgfhgf",
            "ffff"}, -1);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.olvPacket = new BrightIdeasSoftware.ObjectListView();
            this.olvColPacket = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColPRange = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColPType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDevice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.mnuPacketItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuPacAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPacEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPacDel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPacDuplicate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPacRead = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPacket = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.olvRegisters = new BrightIdeasSoftware.ObjectListView();
            this.olvColName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAddress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColRW = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.mnuRegItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRegAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRegRead = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegWrite = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSaveDev = new System.Windows.Forms.Button();
            this.lbDevices = new System.Windows.Forms.ListBox();
            this.mnuDevItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDevRead = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRead = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.lvChart = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lvSpectrum = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSpecClear = new System.Windows.Forms.Button();
            this.btnSpecStart = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.openDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.txtLog = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvPacket)).BeginInit();
            this.mnuPacketItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvRegisters)).BeginInit();
            this.mnuRegItem.SuspendLayout();
            this.mnuDevItem.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(221, 6);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(768, 547);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(352, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(352, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(160, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(467, 103);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(160, 76);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "blbec";
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(296, 103);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "blbec";
            this.textBox2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(254, 326);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1003, 614);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.olvPacket);
            this.tabPage1.Controls.Add(this.lblPacket);
            this.tabPage1.Controls.Add(this.btnClear);
            this.tabPage1.Controls.Add(this.olvRegisters);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnLoad);
            this.tabPage1.Controls.Add(this.btnSaveDev);
            this.tabPage1.Controls.Add(this.lbDevices);
            this.tabPage1.Controls.Add(this.btnRead);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(995, 588);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Table";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // olvPacket
            // 
            this.olvPacket.AllColumns.Add(this.olvColPacket);
            this.olvPacket.AllColumns.Add(this.olvColPRange);
            this.olvPacket.AllColumns.Add(this.olvColPType);
            this.olvPacket.AllColumns.Add(this.olvColDevice);
            this.olvPacket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.olvPacket.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColPacket,
            this.olvColPRange,
            this.olvColPType});
            this.olvPacket.ContextMenuStrip = this.mnuPacketItem;
            this.olvPacket.Location = new System.Drawing.Point(139, 33);
            this.olvPacket.MultiSelect = false;
            this.olvPacket.Name = "olvPacket";
            this.olvPacket.Size = new System.Drawing.Size(288, 517);
            this.olvPacket.SortGroupItemsByPrimaryColumn = false;
            this.olvPacket.TabIndex = 12;
            this.olvPacket.UseCompatibleStateImageBehavior = false;
            this.olvPacket.View = System.Windows.Forms.View.Details;
            // 
            // olvColPacket
            // 
            this.olvColPacket.Text = "Name";
            this.olvColPacket.Width = 146;
            // 
            // olvColPRange
            // 
            this.olvColPRange.Text = "Range";
            this.olvColPRange.Width = 59;
            // 
            // olvColPType
            // 
            this.olvColPType.Text = "Type";
            this.olvColPType.Width = 59;
            // 
            // olvColDevice
            // 
            this.olvColDevice.DisplayIndex = 5;
            this.olvColDevice.IsVisible = false;
            this.olvColDevice.Text = "Device";
            // 
            // mnuPacketItem
            // 
            this.mnuPacketItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPacAdd,
            this.mnuPacEdit,
            this.mnuPacDel,
            this.mnuPacDuplicate,
            this.toolStripSeparator1,
            this.mnuPacRead});
            this.mnuPacketItem.Name = "mnuItem";
            this.mnuPacketItem.Size = new System.Drawing.Size(137, 120);
            this.mnuPacketItem.Opening += new System.ComponentModel.CancelEventHandler(this.mnuPacketItem_Opening);
            // 
            // mnuPacAdd
            // 
            this.mnuPacAdd.Name = "mnuPacAdd";
            this.mnuPacAdd.Size = new System.Drawing.Size(136, 22);
            this.mnuPacAdd.Text = "Add";
            this.mnuPacAdd.Click += new System.EventHandler(this.mnuPacAdd_Click);
            // 
            // mnuPacEdit
            // 
            this.mnuPacEdit.Name = "mnuPacEdit";
            this.mnuPacEdit.Size = new System.Drawing.Size(136, 22);
            this.mnuPacEdit.Text = "Edit";
            this.mnuPacEdit.Click += new System.EventHandler(this.mnuPacEdit_Click);
            // 
            // mnuPacDel
            // 
            this.mnuPacDel.Name = "mnuPacDel";
            this.mnuPacDel.Size = new System.Drawing.Size(136, 22);
            this.mnuPacDel.Text = "Delete";
            this.mnuPacDel.Click += new System.EventHandler(this.mnuPacDel_Click);
            // 
            // mnuPacDuplicate
            // 
            this.mnuPacDuplicate.Name = "mnuPacDuplicate";
            this.mnuPacDuplicate.Size = new System.Drawing.Size(136, 22);
            this.mnuPacDuplicate.Text = "Duplicate";
            this.mnuPacDuplicate.Click += new System.EventHandler(this.mnuPacDuplicate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuPacRead
            // 
            this.mnuPacRead.Name = "mnuPacRead";
            this.mnuPacRead.Size = new System.Drawing.Size(136, 22);
            this.mnuPacRead.Text = "Read Values";
            this.mnuPacRead.Click += new System.EventHandler(this.mnuPacRead_Click);
            // 
            // lblPacket
            // 
            this.lblPacket.AutoSize = true;
            this.lblPacket.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPacket.Location = new System.Drawing.Point(135, 6);
            this.lblPacket.Name = "lblPacket";
            this.lblPacket.Size = new System.Drawing.Size(59, 19);
            this.lblPacket.TabIndex = 11;
            this.lblPacket.Text = "Packet:";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(130, 558);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // olvRegisters
            // 
            this.olvRegisters.AllColumns.Add(this.olvColName);
            this.olvRegisters.AllColumns.Add(this.olvColValue);
            this.olvRegisters.AllColumns.Add(this.olvColAddress);
            this.olvRegisters.AllColumns.Add(this.olvColRW);
            this.olvRegisters.AllColumns.Add(this.olvColType);
            this.olvRegisters.AllColumns.Add(this.olvColDevice);
            this.olvRegisters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvRegisters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColName,
            this.olvColValue,
            this.olvColAddress,
            this.olvColRW,
            this.olvColType});
            this.olvRegisters.ContextMenuStrip = this.mnuRegItem;
            this.olvRegisters.Location = new System.Drawing.Point(433, 33);
            this.olvRegisters.MultiSelect = false;
            this.olvRegisters.Name = "olvRegisters";
            this.olvRegisters.Size = new System.Drawing.Size(556, 517);
            this.olvRegisters.SortGroupItemsByPrimaryColumn = false;
            this.olvRegisters.TabIndex = 9;
            this.olvRegisters.UseCompatibleStateImageBehavior = false;
            this.olvRegisters.View = System.Windows.Forms.View.Details;
            // 
            // olvColName
            // 
            this.olvColName.Text = "Name";
            this.olvColName.Width = 146;
            // 
            // olvColValue
            // 
            this.olvColValue.Text = "Value";
            this.olvColValue.Width = 223;
            // 
            // olvColAddress
            // 
            this.olvColAddress.Text = "Address";
            this.olvColAddress.Width = 53;
            // 
            // olvColRW
            // 
            this.olvColRW.Text = "R/W";
            this.olvColRW.Width = 42;
            // 
            // olvColType
            // 
            this.olvColType.Text = "Type";
            this.olvColType.Width = 200;
            // 
            // mnuRegItem
            // 
            this.mnuRegItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRegAdd,
            this.mnuRegEdit,
            this.mnuRegDelete,
            this.mnuRegCopy,
            this.toolStripMenuItem1,
            this.mnuRegRead,
            this.mnuRegWrite});
            this.mnuRegItem.Name = "mnuItem";
            this.mnuRegItem.Size = new System.Drawing.Size(134, 142);
            this.mnuRegItem.Opening += new System.ComponentModel.CancelEventHandler(this.mnuRegItem_Opening);
            // 
            // mnuRegAdd
            // 
            this.mnuRegAdd.Name = "mnuRegAdd";
            this.mnuRegAdd.Size = new System.Drawing.Size(133, 22);
            this.mnuRegAdd.Text = "Add";
            this.mnuRegAdd.Click += new System.EventHandler(this.mnuRegAdd_Click);
            // 
            // mnuRegEdit
            // 
            this.mnuRegEdit.Name = "mnuRegEdit";
            this.mnuRegEdit.Size = new System.Drawing.Size(133, 22);
            this.mnuRegEdit.Text = "Edit";
            this.mnuRegEdit.Click += new System.EventHandler(this.mnuRegEdit_Click);
            // 
            // mnuRegDelete
            // 
            this.mnuRegDelete.Name = "mnuRegDelete";
            this.mnuRegDelete.Size = new System.Drawing.Size(133, 22);
            this.mnuRegDelete.Text = "Delete";
            this.mnuRegDelete.Click += new System.EventHandler(this.mnuRegDelete_Click);
            // 
            // mnuRegCopy
            // 
            this.mnuRegCopy.Name = "mnuRegCopy";
            this.mnuRegCopy.Size = new System.Drawing.Size(133, 22);
            this.mnuRegCopy.Text = "Duplicate";
            this.mnuRegCopy.Click += new System.EventHandler(this.mnuRegCopy_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(130, 6);
            // 
            // mnuRegRead
            // 
            this.mnuRegRead.Name = "mnuRegRead";
            this.mnuRegRead.Size = new System.Drawing.Size(133, 22);
            this.mnuRegRead.Text = "Read Value";
            this.mnuRegRead.Click += new System.EventHandler(this.mnuRegRead_Click);
            // 
            // mnuRegWrite
            // 
            this.mnuRegWrite.Name = "mnuRegWrite";
            this.mnuRegWrite.Size = new System.Drawing.Size(133, 22);
            this.mnuRegWrite.Text = "Write Value";
            this.mnuRegWrite.Click += new System.EventHandler(this.mnuRegWrite_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(429, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Registers:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(6, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Devices:";
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoad.Location = new System.Drawing.Point(6, 558);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(56, 23);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSaveDev
            // 
            this.btnSaveDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveDev.Location = new System.Drawing.Point(68, 558);
            this.btnSaveDev.Name = "btnSaveDev";
            this.btnSaveDev.Size = new System.Drawing.Size(56, 23);
            this.btnSaveDev.TabIndex = 5;
            this.btnSaveDev.Text = "Save";
            this.btnSaveDev.UseVisualStyleBackColor = true;
            this.btnSaveDev.Click += new System.EventHandler(this.btnSaveDev_Click);
            // 
            // lbDevices
            // 
            this.lbDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDevices.ContextMenuStrip = this.mnuDevItem;
            this.lbDevices.FormattingEnabled = true;
            this.lbDevices.Location = new System.Drawing.Point(6, 33);
            this.lbDevices.Name = "lbDevices";
            this.lbDevices.Size = new System.Drawing.Size(127, 511);
            this.lbDevices.TabIndex = 4;
            this.lbDevices.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbDevices_MouseDoubleClick);
            // 
            // mnuDevItem
            // 
            this.mnuDevItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuEdit,
            this.mnuDelete,
            this.toolStripMenuItem2,
            this.mnuImport,
            this.mnuExport,
            this.toolStripMenuItem3,
            this.mnuDevRead});
            this.mnuDevItem.Name = "mnuItem";
            this.mnuDevItem.Size = new System.Drawing.Size(137, 148);
            this.mnuDevItem.Opening += new System.ComponentModel.CancelEventHandler(this.mnuDevItem_Opening);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(136, 22);
            this.mnuAdd.Text = "Add";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(136, 22);
            this.mnuEdit.Text = "Edit";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(136, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuImport
            // 
            this.mnuImport.Name = "mnuImport";
            this.mnuImport.Size = new System.Drawing.Size(136, 22);
            this.mnuImport.Text = "Import";
            this.mnuImport.Click += new System.EventHandler(this.mnuImport_Click);
            // 
            // mnuExport
            // 
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Size = new System.Drawing.Size(136, 22);
            this.mnuExport.Text = "Export";
            this.mnuExport.Click += new System.EventHandler(this.mnuExport_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuDevRead
            // 
            this.mnuDevRead.Name = "mnuDevRead";
            this.mnuDevRead.Size = new System.Drawing.Size(136, 22);
            this.mnuDevRead.Text = "Read Values";
            this.mnuDevRead.Click += new System.EventHandler(this.mnuDevRead_Click);
            // 
            // btnRead
            // 
            this.btnRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRead.Location = new System.Drawing.Point(433, 556);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 3;
            this.btnRead.Text = "Read All";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.lblDelay);
            this.tabPage2.Controls.Add(this.btnSet);
            this.tabPage2.Controls.Add(this.txtPeriod);
            this.tabPage2.Controls.Add(this.btnRun);
            this.tabPage2.Controls.Add(this.lvChart);
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(995, 588);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Graph";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(169, 562);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Interval [ms]:";
            // 
            // lblDelay
            // 
            this.lblDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(449, 559);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(35, 13);
            this.lblDelay.TabIndex = 10;
            this.lblDelay.Text = "label6";
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSet.Location = new System.Drawing.Point(350, 556);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 9;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // txtPeriod
            // 
            this.txtPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPeriod.Location = new System.Drawing.Point(244, 559);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(100, 20);
            this.txtPeriod.TabIndex = 8;
            this.txtPeriod.Text = "1000";
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRun.Location = new System.Drawing.Point(6, 559);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(56, 23);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lvChart
            // 
            this.lvChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvChart.CheckBoxes = true;
            this.lvChart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvChart.ContextMenuStrip = this.mnuRegItem;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            this.lvChart.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lvChart.Location = new System.Drawing.Point(6, 6);
            this.lvChart.MultiSelect = false;
            this.lvChart.Name = "lvChart";
            this.lvChart.Size = new System.Drawing.Size(198, 547);
            this.lvChart.TabIndex = 2;
            this.lvChart.UseCompatibleStateImageBehavior = false;
            this.lvChart.View = System.Windows.Forms.View.Details;
            this.lvChart.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvChart_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 87;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lvSpectrum);
            this.tabPage4.Controls.Add(this.btnSpecClear);
            this.tabPage4.Controls.Add(this.btnSpecStart);
            this.tabPage4.Controls.Add(this.chart2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(995, 588);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Spectrum";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lvSpectrum
            // 
            this.lvSpectrum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvSpectrum.CheckBoxes = true;
            this.lvSpectrum.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.lvSpectrum.ContextMenuStrip = this.mnuRegItem;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            this.lvSpectrum.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.lvSpectrum.Location = new System.Drawing.Point(6, 6);
            this.lvSpectrum.MultiSelect = false;
            this.lvSpectrum.Name = "lvSpectrum";
            this.lvSpectrum.ShowGroups = false;
            this.lvSpectrum.Size = new System.Drawing.Size(111, 205);
            this.lvSpectrum.TabIndex = 6;
            this.lvSpectrum.UseCompatibleStateImageBehavior = false;
            this.lvSpectrum.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 80;
            // 
            // btnSpecClear
            // 
            this.btnSpecClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSpecClear.Location = new System.Drawing.Point(77, 559);
            this.btnSpecClear.Name = "btnSpecClear";
            this.btnSpecClear.Size = new System.Drawing.Size(65, 23);
            this.btnSpecClear.TabIndex = 5;
            this.btnSpecClear.Text = "Clear";
            this.btnSpecClear.UseVisualStyleBackColor = true;
            this.btnSpecClear.Click += new System.EventHandler(this.btnSpecClear_Click);
            // 
            // btnSpecStart
            // 
            this.btnSpecStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSpecStart.Location = new System.Drawing.Point(6, 559);
            this.btnSpecStart.Name = "btnSpecStart";
            this.btnSpecStart.Size = new System.Drawing.Size(65, 23);
            this.btnSpecStart.TabIndex = 3;
            this.btnSpecStart.Text = "Start";
            this.btnSpecStart.UseVisualStyleBackColor = true;
            this.btnSpecStart.Click += new System.EventHandler(this.btnSpecStart_Click);
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(84, 4);
            this.chart2.Name = "chart2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Legend = "Legend1";
            series4.Name = "Series2";
            this.chart2.Series.Add(series3);
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(908, 581);
            this.chart2.TabIndex = 2;
            this.chart2.Text = "chart2";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(995, 588);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Test";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(38, 24);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // openDialog1
            // 
            this.openDialog1.DefaultExt = "xml";
            this.openDialog1.Filter = "XML Device settings|*.xml|Device settings (*.ini)|*.ini|All files (*.*)|*.*";
            // 
            // saveDialog1
            // 
            this.saveDialog1.DefaultExt = "xml";
            this.saveDialog1.Filter = "XML Device settings|*.xml|Device settings (*.ini)|*.ini|All files (*.*)|*.*";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImage = global::ModBus.Properties.Resources.modbus_logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(912, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 27);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Location = new System.Drawing.Point(0, 632);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1027, 65);
            this.txtLog.TabIndex = 12;
            this.txtLog.Text = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 697);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MODBUS tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvPacket)).EndInit();
            this.mnuPacketItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvRegisters)).EndInit();
            this.mnuRegItem.ResumeLayout(false);
            this.mnuDevItem.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lbDevices;
        private System.Windows.Forms.Button btnSaveDev;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openDialog1;
        private System.Windows.Forms.SaveFileDialog saveDialog1;
        private System.Windows.Forms.ContextMenuStrip mnuDevItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ContextMenuStrip mnuRegItem;
        private System.Windows.Forms.ToolStripMenuItem mnuRegEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuRegDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuRegAdd;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuRegWrite;
        private System.Windows.Forms.ToolStripMenuItem mnuRegRead;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuDevRead;
        private System.Windows.Forms.ListView lvChart;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnSpecStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button btnSpecClear;
        private BrightIdeasSoftware.ObjectListView olvRegisters;
        private BrightIdeasSoftware.OLVColumn olvColName;
        private BrightIdeasSoftware.OLVColumn olvColValue;
        private BrightIdeasSoftware.OLVColumn olvColAddress;
        private BrightIdeasSoftware.OLVColumn olvColRW;
        private BrightIdeasSoftware.OLVColumn olvColType;
        private BrightIdeasSoftware.OLVColumn olvColDevice;
        private System.Windows.Forms.ToolStripMenuItem mnuRegCopy;
        private System.Windows.Forms.Button btnClear;
        private BrightIdeasSoftware.ObjectListView olvPacket;
        private BrightIdeasSoftware.OLVColumn olvColPacket;
        private BrightIdeasSoftware.OLVColumn olvColPRange;
        private BrightIdeasSoftware.OLVColumn olvColPType;
        private System.Windows.Forms.Label lblPacket;
        private System.Windows.Forms.ContextMenuStrip mnuPacketItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPacAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuPacEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuPacDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuPacRead;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem mnuPacDuplicate;
        private System.Windows.Forms.ToolStripMenuItem mnuImport;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.ListView lvSpectrum;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

