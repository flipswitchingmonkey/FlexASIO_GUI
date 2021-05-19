namespace FlexASIOGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeDevicesInput = new System.Windows.Forms.TreeView();
            this.treeDevicesOutput = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btSaveAs = new System.Windows.Forms.Button();
            this.btClipboard = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btSaveToProfile = new System.Windows.Forms.Button();
            this.comboBackend = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxSetOutputLatency = new System.Windows.Forms.CheckBox();
            this.numericLatencyOutput = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxWasapiInputSet = new System.Windows.Forms.CheckBox();
            this.wasapiExclusiveInput = new System.Windows.Forms.CheckBox();
            this.wasapiAutoConvertInput = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxWasapiOutputSet = new System.Windows.Forms.CheckBox();
            this.wasapiExclusiveOutput = new System.Windows.Forms.CheckBox();
            this.wasapiAutoConvertOutput = new System.Windows.Forms.CheckBox();
            this.configOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxSetInputLatency = new System.Windows.Forms.CheckBox();
            this.numericLatencyInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericChannelsInput = new System.Windows.Forms.NumericUpDown();
            this.numericChannelsOutput = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxSetBufferSize = new System.Windows.Forms.CheckBox();
            this.numericBufferSize = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLatencyOutput)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLatencyInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericChannelsInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericChannelsOutput)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBufferSize)).BeginInit();
            this.SuspendLayout();
            // 
            // treeDevicesInput
            // 
            this.treeDevicesInput.CheckBoxes = true;
            this.treeDevicesInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDevicesInput.HideSelection = false;
            this.treeDevicesInput.Location = new System.Drawing.Point(93, 53);
            this.treeDevicesInput.Name = "treeDevicesInput";
            this.treeDevicesInput.Size = new System.Drawing.Size(236, 358);
            this.treeDevicesInput.TabIndex = 1;
            this.treeDevicesInput.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeDevicesInput_BeforeCheck);
            this.treeDevicesInput.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeDevicesInput_AfterCheck);
            this.treeDevicesInput.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeDevicesInput_BeforeSelect);
            this.treeDevicesInput.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDevicesInput_AfterSelect);
            // 
            // treeDevicesOutput
            // 
            this.treeDevicesOutput.CheckBoxes = true;
            this.treeDevicesOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDevicesOutput.HideSelection = false;
            this.treeDevicesOutput.Location = new System.Drawing.Point(335, 53);
            this.treeDevicesOutput.Name = "treeDevicesOutput";
            this.treeDevicesOutput.Size = new System.Drawing.Size(236, 358);
            this.treeDevicesOutput.TabIndex = 1;
            this.treeDevicesOutput.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeDevicesOutput_BeforeCheck);
            this.treeDevicesOutput.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeDevicesOutput_AfterCheck);
            this.treeDevicesOutput.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeDevicesOutput_BeforeSelect);
            this.treeDevicesOutput.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDevicesOutput_AfterSelect);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 301F));
            this.tableLayoutPanel1.Controls.Add(this.btSaveAs, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.btClipboard, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeDevicesOutput, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btSaveToProfile, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.treeDevicesInput, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBackend, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.configOutput, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.numericChannelsInput, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.numericChannelsOutput, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(875, 534);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btSaveAs
            // 
            this.btSaveAs.Dock = System.Windows.Forms.DockStyle.Right;
            this.btSaveAs.Location = new System.Drawing.Point(797, 477);
            this.btSaveAs.Name = "btSaveAs";
            this.btSaveAs.Size = new System.Drawing.Size(75, 24);
            this.btSaveAs.TabIndex = 11;
            this.btSaveAs.Text = "Save as";
            this.btSaveAs.UseVisualStyleBackColor = true;
            this.btSaveAs.Click += new System.EventHandler(this.btSaveAs_Click);
            // 
            // btClipboard
            // 
            this.btClipboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btClipboard.Location = new System.Drawing.Point(577, 417);
            this.btClipboard.Name = "btClipboard";
            this.btClipboard.Size = new System.Drawing.Size(295, 24);
            this.btClipboard.TabIndex = 0;
            this.btClipboard.Text = "Copy to Clipboard";
            this.btClipboard.UseVisualStyleBackColor = true;
            this.btClipboard.Click += new System.EventHandler(this.btClipboard_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Backend";
            // 
            // btSaveToProfile
            // 
            this.btSaveToProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSaveToProfile.Location = new System.Drawing.Point(577, 447);
            this.btSaveToProfile.Name = "btSaveToProfile";
            this.btSaveToProfile.Size = new System.Drawing.Size(295, 24);
            this.btSaveToProfile.TabIndex = 1;
            this.btSaveToProfile.Text = "Save to Default FlexASIO.toml";
            this.btSaveToProfile.UseVisualStyleBackColor = true;
            this.btSaveToProfile.Click += new System.EventHandler(this.btSaveToProfile_Click);
            // 
            // comboBackend
            // 
            this.comboBackend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBackend.FormattingEnabled = true;
            this.comboBackend.Location = new System.Drawing.Point(93, 3);
            this.comboBackend.MinimumSize = new System.Drawing.Size(200, 0);
            this.comboBackend.Name = "comboBackend";
            this.comboBackend.Size = new System.Drawing.Size(236, 23);
            this.comboBackend.TabIndex = 1;
            this.comboBackend.SelectedIndexChanged += new System.EventHandler(this.comboBackend_SelectedIndexChanged);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.checkBoxSetOutputLatency);
            this.flowLayoutPanel4.Controls.Add(this.numericLatencyOutput);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(335, 417);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(236, 24);
            this.flowLayoutPanel4.TabIndex = 11;
            // 
            // checkBoxSetOutputLatency
            // 
            this.checkBoxSetOutputLatency.AutoSize = true;
            this.checkBoxSetOutputLatency.Location = new System.Drawing.Point(3, 3);
            this.checkBoxSetOutputLatency.Name = "checkBoxSetOutputLatency";
            this.checkBoxSetOutputLatency.Size = new System.Drawing.Size(127, 19);
            this.checkBoxSetOutputLatency.TabIndex = 19;
            this.checkBoxSetOutputLatency.Text = "Set Output Latency";
            this.checkBoxSetOutputLatency.UseVisualStyleBackColor = true;
            this.checkBoxSetOutputLatency.CheckedChanged += new System.EventHandler(this.checkBoxSetOutputLatency_CheckedChanged);
            // 
            // numericLatencyOutput
            // 
            this.numericLatencyOutput.DecimalPlaces = 1;
            this.numericLatencyOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericLatencyOutput.Location = new System.Drawing.Point(136, 3);
            this.numericLatencyOutput.Name = "numericLatencyOutput";
            this.numericLatencyOutput.Size = new System.Drawing.Size(90, 23);
            this.numericLatencyOutput.TabIndex = 3;
            this.numericLatencyOutput.ValueChanged += new System.EventHandler(this.numericLatencyOutput_ValueChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "WASAPI";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.checkBoxWasapiInputSet);
            this.flowLayoutPanel2.Controls.Add(this.wasapiExclusiveInput);
            this.flowLayoutPanel2.Controls.Add(this.wasapiAutoConvertInput);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(93, 447);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(236, 24);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // checkBoxWasapiInputSet
            // 
            this.checkBoxWasapiInputSet.AutoSize = true;
            this.checkBoxWasapiInputSet.Location = new System.Drawing.Point(3, 3);
            this.checkBoxWasapiInputSet.Name = "checkBoxWasapiInputSet";
            this.checkBoxWasapiInputSet.Size = new System.Drawing.Size(45, 19);
            this.checkBoxWasapiInputSet.TabIndex = 9;
            this.checkBoxWasapiInputSet.Text = "Set:";
            this.checkBoxWasapiInputSet.UseVisualStyleBackColor = true;
            this.checkBoxWasapiInputSet.CheckedChanged += new System.EventHandler(this.checkBoxWasapiInputSet_CheckedChanged);
            // 
            // wasapiExclusiveInput
            // 
            this.wasapiExclusiveInput.AutoSize = true;
            this.wasapiExclusiveInput.Location = new System.Drawing.Point(54, 3);
            this.wasapiExclusiveInput.Name = "wasapiExclusiveInput";
            this.wasapiExclusiveInput.Size = new System.Drawing.Size(74, 19);
            this.wasapiExclusiveInput.TabIndex = 7;
            this.wasapiExclusiveInput.Text = "Exclusive";
            this.wasapiExclusiveInput.UseVisualStyleBackColor = true;
            this.wasapiExclusiveInput.CheckedChanged += new System.EventHandler(this.wasapiExclusiveInput_CheckedChanged);
            // 
            // wasapiAutoConvertInput
            // 
            this.wasapiAutoConvertInput.AutoSize = true;
            this.wasapiAutoConvertInput.Checked = true;
            this.wasapiAutoConvertInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wasapiAutoConvertInput.Location = new System.Drawing.Point(134, 3);
            this.wasapiAutoConvertInput.Name = "wasapiAutoConvertInput";
            this.wasapiAutoConvertInput.Size = new System.Drawing.Size(94, 19);
            this.wasapiAutoConvertInput.TabIndex = 8;
            this.wasapiAutoConvertInput.Text = "AutoConvert";
            this.wasapiAutoConvertInput.UseVisualStyleBackColor = true;
            this.wasapiAutoConvertInput.CheckedChanged += new System.EventHandler(this.wasapiAutoConvertInput_CheckedChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.checkBoxWasapiOutputSet);
            this.flowLayoutPanel3.Controls.Add(this.wasapiExclusiveOutput);
            this.flowLayoutPanel3.Controls.Add(this.wasapiAutoConvertOutput);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(335, 447);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(236, 24);
            this.flowLayoutPanel3.TabIndex = 12;
            // 
            // checkBoxWasapiOutputSet
            // 
            this.checkBoxWasapiOutputSet.AutoSize = true;
            this.checkBoxWasapiOutputSet.Location = new System.Drawing.Point(3, 3);
            this.checkBoxWasapiOutputSet.Name = "checkBoxWasapiOutputSet";
            this.checkBoxWasapiOutputSet.Size = new System.Drawing.Size(45, 19);
            this.checkBoxWasapiOutputSet.TabIndex = 10;
            this.checkBoxWasapiOutputSet.Text = "Set:";
            this.checkBoxWasapiOutputSet.UseVisualStyleBackColor = true;
            this.checkBoxWasapiOutputSet.CheckedChanged += new System.EventHandler(this.checkBoxWasapOutputSet_CheckedChanged);
            // 
            // wasapiExclusiveOutput
            // 
            this.wasapiExclusiveOutput.AutoSize = true;
            this.wasapiExclusiveOutput.Location = new System.Drawing.Point(54, 3);
            this.wasapiExclusiveOutput.Name = "wasapiExclusiveOutput";
            this.wasapiExclusiveOutput.Size = new System.Drawing.Size(74, 19);
            this.wasapiExclusiveOutput.TabIndex = 8;
            this.wasapiExclusiveOutput.Text = "Exclusive";
            this.wasapiExclusiveOutput.UseVisualStyleBackColor = true;
            this.wasapiExclusiveOutput.CheckedChanged += new System.EventHandler(this.wasapiExclusiveOutput_CheckedChanged);
            // 
            // wasapiAutoConvertOutput
            // 
            this.wasapiAutoConvertOutput.AutoSize = true;
            this.wasapiAutoConvertOutput.Checked = true;
            this.wasapiAutoConvertOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wasapiAutoConvertOutput.Location = new System.Drawing.Point(134, 3);
            this.wasapiAutoConvertOutput.Name = "wasapiAutoConvertOutput";
            this.wasapiAutoConvertOutput.Size = new System.Drawing.Size(94, 19);
            this.wasapiAutoConvertOutput.TabIndex = 9;
            this.wasapiAutoConvertOutput.Text = "AutoConvert";
            this.wasapiAutoConvertOutput.UseVisualStyleBackColor = true;
            this.wasapiAutoConvertOutput.CheckedChanged += new System.EventHandler(this.wasapiAutoConvertOutput_CheckedChanged);
            // 
            // configOutput
            // 
            this.configOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configOutput.Location = new System.Drawing.Point(577, 53);
            this.configOutput.Multiline = true;
            this.configOutput.Name = "configOutput";
            this.configOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.configOutput.Size = new System.Drawing.Size(295, 358);
            this.configOutput.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Device";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Output Device";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.checkBoxSetInputLatency);
            this.flowLayoutPanel5.Controls.Add(this.numericLatencyInput);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(93, 417);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(236, 24);
            this.flowLayoutPanel5.TabIndex = 11;
            // 
            // checkBoxSetInputLatency
            // 
            this.checkBoxSetInputLatency.AutoSize = true;
            this.checkBoxSetInputLatency.Location = new System.Drawing.Point(3, 3);
            this.checkBoxSetInputLatency.Name = "checkBoxSetInputLatency";
            this.checkBoxSetInputLatency.Size = new System.Drawing.Size(117, 19);
            this.checkBoxSetInputLatency.TabIndex = 20;
            this.checkBoxSetInputLatency.Text = "Set Input Latency";
            this.checkBoxSetInputLatency.UseVisualStyleBackColor = true;
            this.checkBoxSetInputLatency.CheckedChanged += new System.EventHandler(this.checkBoxSetInputLatency_CheckedChanged);
            // 
            // numericLatencyInput
            // 
            this.numericLatencyInput.DecimalPlaces = 1;
            this.numericLatencyInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericLatencyInput.Location = new System.Drawing.Point(126, 3);
            this.numericLatencyInput.Name = "numericLatencyInput";
            this.numericLatencyInput.Size = new System.Drawing.Size(90, 23);
            this.numericLatencyInput.TabIndex = 3;
            this.numericLatencyInput.ValueChanged += new System.EventHandler(this.numericLatencyInput_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Latency";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(827, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "Output";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 481);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Channels";
            // 
            // numericChannelsInput
            // 
            this.numericChannelsInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericChannelsInput.Location = new System.Drawing.Point(93, 477);
            this.numericChannelsInput.Name = "numericChannelsInput";
            this.numericChannelsInput.Size = new System.Drawing.Size(236, 23);
            this.numericChannelsInput.TabIndex = 15;
            this.numericChannelsInput.ValueChanged += new System.EventHandler(this.numericChannelsInput_ValueChanged);
            // 
            // numericChannelsOutput
            // 
            this.numericChannelsOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericChannelsOutput.Location = new System.Drawing.Point(335, 477);
            this.numericChannelsOutput.Name = "numericChannelsOutput";
            this.numericChannelsOutput.Size = new System.Drawing.Size(236, 23);
            this.numericChannelsOutput.TabIndex = 16;
            this.numericChannelsOutput.ValueChanged += new System.EventHandler(this.numericChannelsOutput_ValueChanged);
            // 
            // statusStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 4);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 512);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(875, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxSetBufferSize);
            this.flowLayoutPanel1.Controls.Add(this.numericBufferSize);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(335, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(236, 24);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 15);
            this.label6.TabIndex = 6;
            // 
            // checkBoxSetBufferSize
            // 
            this.checkBoxSetBufferSize.AutoSize = true;
            this.checkBoxSetBufferSize.Location = new System.Drawing.Point(9, 3);
            this.checkBoxSetBufferSize.Name = "checkBoxSetBufferSize";
            this.checkBoxSetBufferSize.Size = new System.Drawing.Size(100, 19);
            this.checkBoxSetBufferSize.TabIndex = 7;
            this.checkBoxSetBufferSize.Text = "Set Buffer Size";
            this.checkBoxSetBufferSize.UseVisualStyleBackColor = true;
            this.checkBoxSetBufferSize.CheckedChanged += new System.EventHandler(this.checkBoxSetBufferSize_CheckedChanged);
            // 
            // numericBufferSize
            // 
            this.numericBufferSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericBufferSize.Location = new System.Drawing.Point(115, 0);
            this.numericBufferSize.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.numericBufferSize.Name = "numericBufferSize";
            this.numericBufferSize.Size = new System.Drawing.Size(90, 23);
            this.numericBufferSize.TabIndex = 5;
            this.numericBufferSize.ValueChanged += new System.EventHandler(this.numericBufferSize_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 534);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "FlexASIO GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLatencyOutput)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLatencyInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericChannelsInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericChannelsOutput)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBufferSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treeDevicesInput;
        private System.Windows.Forms.TreeView treeDevicesOutput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBackend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericLatencyInput;
        private System.Windows.Forms.NumericUpDown numericLatencyOutput;
        private System.Windows.Forms.NumericUpDown numericBufferSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox wasapiExclusiveInput;
        private System.Windows.Forms.CheckBox wasapiExclusiveOutput;
        private System.Windows.Forms.TextBox configOutput;
        private System.Windows.Forms.Button btClipboard;
        private System.Windows.Forms.Button btSaveToProfile;
        private System.Windows.Forms.Button btSaveAs;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.CheckBox wasapiAutoConvertInput;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.CheckBox wasapiAutoConvertOutput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericChannelsInput;
        private System.Windows.Forms.NumericUpDown numericChannelsOutput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxSetOutputLatency;
        private System.Windows.Forms.CheckBox checkBoxSetInputLatency;
        private System.Windows.Forms.CheckBox checkBoxSetBufferSize;
        private System.Windows.Forms.CheckBox checkBoxWasapiInputSet;
        private System.Windows.Forms.CheckBox checkBoxWasapiOutputSet;
    }
}

