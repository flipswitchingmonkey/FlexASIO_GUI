using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commons.Media.PortAudio;
using System.Diagnostics;
using System.IO;
using System.Globalization;
using Nett;
using System.Runtime.InteropServices;

namespace FlexASIOGUI
{
    public partial class Form1 : Form
    {

        private bool InitDone = false;
        private string TOMLPath;
        private FlexGUIConfig flexGUIConfig;
        private Encoding legacyEncoding;
        private string flexasioGuiVersion = "0.33";
        private string flexasioVersion = "1.8";
        private string tomlName = "FlexASIO.toml";
        private string docUrl = "https://github.com/dechamps/FlexASIO/blob/master/CONFIGURATION.md";

        [DllImport(@"C:\Program Files\FlexASIO\x64\FlexASIO.dll")]
        public static extern int Initialize(string PathName, bool TestMode);
        [DllImport(@"kernel32.dll")]
        public static extern uint GetACP();

        public Form1()
        {
            InitializeComponent();
            
            this.Text = $"FlexASIO GUI v{flexasioGuiVersion}";

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // get the value of the "Language for non-Unicode programs" setting (1252 for English)
            // note: in Win11 this could be UTF-8 already, since it's natively supported
            legacyEncoding = Encoding.GetEncoding((int)GetACP());

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            CultureInfo.DefaultThreadCurrentCulture = customCulture;
            CultureInfo.DefaultThreadCurrentUICulture = customCulture;

            TOMLPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\{tomlName}";

            flexGUIConfig = new FlexGUIConfig();
            if (File.Exists(TOMLPath))
            {
                flexGUIConfig = Toml.ReadFile<FlexGUIConfig>(TOMLPath);
            }

            numericBufferSize.Maximum = 8192;
            numericBufferSize.Increment = 16;

            numericLatencyInput.Increment = 0.1m;
            numericLatencyOutput.Increment = 0.1m;

            for (var i=0; i<Configuration.HostApiCount; i++)
            {
                comboBackend.Items.Add(Configuration.GetHostApiInfo(i).name);
            }

            if (comboBackend.Items.Contains(flexGUIConfig.backend))
            {
                comboBackend.SelectedIndex = comboBackend.Items.IndexOf(flexGUIConfig.backend);
            }
            else
            {
                comboBackend.SelectedIndex = 0;
            }

            if (flexGUIConfig.bufferSizeSamples != null)
                numericBufferSize.Value = (Int64)flexGUIConfig.bufferSizeSamples;
            checkBoxSetBufferSize.Checked = numericBufferSize.Enabled = flexGUIConfig.bufferSizeSamples != null;
            
            treeDevicesInput.SelectedNode = treeDevicesInput.Nodes.Cast<TreeNode>().FirstOrDefault(x => x.Text == (flexGUIConfig.input.device == "" ? "(None)" : flexGUIConfig.input.device));
            treeDevicesOutput.SelectedNode = treeDevicesOutput.Nodes.Cast<TreeNode>().FirstOrDefault(x => x.Text == (flexGUIConfig.output.device == "" ? "(None)" : flexGUIConfig.output.device));

            checkBoxSetInputLatency.Checked = numericLatencyInput.Enabled = flexGUIConfig.input.suggestedLatencySeconds != null;
            checkBoxSetOutputLatency.Checked = numericLatencyOutput.Enabled = flexGUIConfig.output.suggestedLatencySeconds != null;

            if (flexGUIConfig.input.suggestedLatencySeconds != null)
                numericLatencyInput.Value = (decimal)(double)flexGUIConfig.input.suggestedLatencySeconds;
            if (flexGUIConfig.output.suggestedLatencySeconds != null)
                numericLatencyOutput.Value = (decimal)(double)flexGUIConfig.output.suggestedLatencySeconds;

            numericChannelsInput.Value = (decimal)(flexGUIConfig.input.channels ?? 0);
            numericChannelsOutput.Value = (decimal)(flexGUIConfig.output.channels ?? 0);

            checkBoxWasapiInputSet.Checked = flexGUIConfig.input.wasapiExclusiveMode != null || flexGUIConfig.input.wasapiAutoConvert != null;
            checkBoxWasapiOutputSet.Checked = flexGUIConfig.output.wasapiExclusiveMode != null || flexGUIConfig.output.wasapiAutoConvert != null;

            wasapiExclusiveInput.Enabled = flexGUIConfig.input.wasapiExclusiveMode != null;
            wasapiExclusiveInput.Checked = flexGUIConfig.input.wasapiExclusiveMode ?? false;
            wasapiExclusiveOutput.Enabled = flexGUIConfig.output.wasapiExclusiveMode != null;
            wasapiExclusiveOutput.Checked = flexGUIConfig.output.wasapiExclusiveMode ?? false;

            wasapiAutoConvertInput.Enabled = flexGUIConfig.input.wasapiAutoConvert != null;
            wasapiAutoConvertInput.Checked = flexGUIConfig.input.wasapiAutoConvert ?? false;
            wasapiAutoConvertOutput.Enabled = flexGUIConfig.output.wasapiAutoConvert != null;
            wasapiAutoConvertOutput.Checked = flexGUIConfig.output.wasapiAutoConvert ?? false;

            InitDone = true;
            SetStatusMessage($"FlexASIO GUI for FlexASIO {flexasioVersion} started ({Configuration.VersionString})");
            GenerateOutput();
        }

        private string DescrambleUTF8(string s)
        {
            // portaudio incorrectly returns UTF-8 strings as if they were ANSI (CP1252 for most Latin systems, CP1251 for Cyrillic, etc...)
            // this line fixes the issue by reading the input as CP* and parsing it as UTF-8
            var bytes = legacyEncoding.GetBytes(s);
            return Encoding.UTF8.GetString(bytes);
        }

        private TreeNode[] GetDevicesForBackend(string Backend, bool Input)
        {
            List<TreeNode> treeNodes = new List<TreeNode>();
            treeNodes.Add(new TreeNode("(None)"));
            for (var i = 0; i < Configuration.DeviceCount; i++)
            {
                var deviceInfo = Configuration.GetDeviceInfo(i);

                var apiInfo = Configuration.GetHostApiInfo(deviceInfo.hostApi);
                
                if (apiInfo.name != Backend) 
                    continue;

                if (Input == true)
                {
                    if (deviceInfo.maxInputChannels > 0)
                    {
                        treeNodes.Add(new TreeNode(DescrambleUTF8(deviceInfo.name)));
                    }
                }
                else
                {
                    if (deviceInfo.maxOutputChannels > 0)
                    {
                        treeNodes.Add(new TreeNode(DescrambleUTF8(deviceInfo.name)));
                    }
                }
            }
            return treeNodes.ToArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBackend_SelectedIndexChanged(object sender, EventArgs e)
        {
            var o = sender as ComboBox;
            if (o != null)
            {
                var selectedBackend = o.SelectedItem as string;
                RefreshDevices(selectedBackend);
                if (selectedBackend == "(None)") selectedBackend = "";
                flexGUIConfig.backend = selectedBackend;
                GenerateOutput();
            }
        }

        private void RefreshDevices(string selectedBackend)
        {
            var tmpInput = treeDevicesInput.SelectedNode;
            var tmpOutput = treeDevicesOutput.SelectedNode;
            if (selectedBackend != null)
            {
                treeDevicesInput.Nodes.Clear();
                treeDevicesInput.Nodes.AddRange(GetDevicesForBackend(selectedBackend, true));
                for (int i = 0; i < treeDevicesInput.Nodes.Count; i++)
                {
                    if (treeDevicesInput?.Nodes[i].Text == tmpInput?.Text)
                    {
                        treeDevicesInput.SelectedNode = treeDevicesInput.Nodes[i];
                        break;
                    }
                }

                treeDevicesOutput.Nodes.Clear();
                treeDevicesOutput.Nodes.AddRange(GetDevicesForBackend(selectedBackend, false));
                for (int i = 0; i < treeDevicesOutput.Nodes.Count; i++)
                {
                    if (treeDevicesOutput?.Nodes[i].Text == tmpOutput?.Text)
                    {
                        treeDevicesOutput.SelectedNode = treeDevicesOutput.Nodes[i];
                        break;
                    }
                }
            }
        }

        private void GenerateOutput()
        {
            if (!InitDone) return;

            if (!checkBoxSetBufferSize.Checked) flexGUIConfig.bufferSizeSamples = null;
            if (!checkBoxSetInputLatency.Checked) flexGUIConfig.input.suggestedLatencySeconds = null;
            if (!checkBoxSetOutputLatency.Checked) flexGUIConfig.output.suggestedLatencySeconds = null;
            if (!checkBoxWasapiInputSet.Checked)
            {
                flexGUIConfig.input.wasapiAutoConvert = null;
                flexGUIConfig.input.wasapiExclusiveMode = null;
            }
            if (!checkBoxWasapiOutputSet.Checked)
            {
                flexGUIConfig.output.wasapiAutoConvert = null;
                flexGUIConfig.output.wasapiExclusiveMode = null;
            }

            configOutput.Clear();
            configOutput.Text = Toml.WriteString(flexGUIConfig);
        }



        private void SetStatusMessage(string msg)
        {
            toolStripStatusLabel1.Text = $"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()}: {msg}";
        }

        private void btClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(configOutput.Text);
            SetStatusMessage("Configuration copied to Clipboard");
        }

        private void btSaveToProfile_Click(object sender, EventArgs e)
        {
            File.WriteAllText(TOMLPath, configOutput.Text);
            SetStatusMessage($"Configuration written to {TOMLPath}");
        }

        private void btSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            saveFileDialog.FileName = tomlName;
            var ret = saveFileDialog.ShowDialog();
            if (ret == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, configOutput.Text);
            }
            SetStatusMessage($"Configuration written to {saveFileDialog.FileName}");
        }

        private void treeDevicesInput_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            var o = sender as TreeView;
            if (o.SelectedNode != null)
            {
                o.SelectedNode.Checked = false;
            }
        }

        private void treeDevicesOutput_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            var o = sender as TreeView;
            if (o.SelectedNode != null)
            {
                o.SelectedNode.Checked = false;
            }
        }

        private void treeDevicesInput_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.IsSelected == false)
            {
                e.Cancel = true;
            }
        }

        private void treeDevicesOutput_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.IsSelected == false)
            {
                e.Cancel = true;
            }
        }

        private void treeDevicesInput_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var o = sender as TreeView;
            if (o == null) return;
            if (o.SelectedNode != null)
            {
                o.SelectedNode.Checked = true;
                flexGUIConfig.input.device = o.SelectedNode.Text == "(None)" ? "" : o.SelectedNode.Text;
                GenerateOutput();
            }
        }

        private void treeDevicesOutput_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var o = sender as TreeView;
            if (o == null) return;
            if (o.SelectedNode != null)
            {
                o.SelectedNode.Checked = true;
                flexGUIConfig.output.device = o.SelectedNode.Text == "(None)" ? "" : o.SelectedNode.Text;
                GenerateOutput();
            }
        }


        private void numericChannelsOutput_ValueChanged(object sender, EventArgs e)
        {
            var o = sender as NumericUpDown;
            if (o == null) return;
            flexGUIConfig.output.channels = (o.Value > 0 ? (int?)o.Value : null);
            GenerateOutput();
        }

        private void numericChannelsInput_ValueChanged(object sender, EventArgs e)
        {
            var o = sender as NumericUpDown;
            if (o == null) return;
            flexGUIConfig.input.channels = (o.Value > 0 ? (int?)o.Value : null);
            GenerateOutput();
        }

        private void numericLatencyOutput_ValueChanged(object sender, EventArgs e)
        {
            var o = sender as NumericUpDown;
            if (o == null) return;
            if (checkBoxSetOutputLatency.Enabled)
            {
                flexGUIConfig.output.suggestedLatencySeconds = (o.Value > 0 ? (double)o.Value : 0);
                GenerateOutput();
            }
        }

        private void numericLatencyInput_ValueChanged(object sender, EventArgs e)
        {
            var o = sender as NumericUpDown;
            if (o == null) return;
            if (checkBoxSetInputLatency.Enabled)
            {
                flexGUIConfig.input.suggestedLatencySeconds = (o.Value > 0 ? (double)o.Value : 0);
                GenerateOutput();
            }
        }

        private void wasapiAutoConvertOutput_CheckedChanged(object sender, EventArgs e)
        {
            var o = sender as CheckBox;
            if (o == null) return;
            flexGUIConfig.output.wasapiAutoConvert = o.Checked;
            GenerateOutput();
        }

        private void wasapiExclusiveOutput_CheckedChanged(object sender, EventArgs e)
        {
            var o = sender as CheckBox;
            if (o == null) return;
            flexGUIConfig.output.wasapiExclusiveMode = o.Checked;
            GenerateOutput();
        }

        private void wasapiAutoConvertInput_CheckedChanged(object sender, EventArgs e)
        {
            var o = sender as CheckBox;
            if (o == null) return;
            flexGUIConfig.input.wasapiAutoConvert = o.Checked;
            GenerateOutput();
        }

        private void wasapiExclusiveInput_CheckedChanged(object sender, EventArgs e)
        {
            var o = sender as CheckBox;
            if (o == null) return;
            flexGUIConfig.input.wasapiExclusiveMode = o.Checked;
            GenerateOutput();
        }

        private void numericBufferSize_ValueChanged(object sender, EventArgs e)
        {
            var o = sender as NumericUpDown;
            if (o == null) return;
            flexGUIConfig.bufferSizeSamples = (o.Value > 0 ? (int)o.Value : 0);
            GenerateOutput();
        }

        private void treeDevicesOutput_AfterCheck(object sender, TreeViewEventArgs e)
        {
        }

        private void treeDevicesInput_AfterCheck(object sender, TreeViewEventArgs e)
        {

        }

        private void checkBoxSetInputLatency_CheckedChanged(object sender, EventArgs e)
        {
            var o = sender as CheckBox;
            if (o == null) return;
            numericLatencyInput.Enabled = o.Checked;
            if (o.Checked == false)
            {
                flexGUIConfig.input.suggestedLatencySeconds = null;
            }
            else
            {
                numericLatencyInput_ValueChanged(numericLatencyInput, null);
            }
            GenerateOutput();
        }

        private void checkBoxSetOutputLatency_CheckedChanged(object sender, EventArgs e)
        {
            var o = sender as CheckBox;
            if (o == null) return;
            numericLatencyOutput.Enabled = o.Checked;
            if (o.Checked == false) {
                flexGUIConfig.output.suggestedLatencySeconds = null;
            }
            else
            {
                numericLatencyOutput_ValueChanged(numericLatencyOutput, null);
            }
            GenerateOutput();
        }
       

        private void checkBoxSetBufferSize_CheckedChanged(object sender, EventArgs e)
        {
            var o = sender as CheckBox;
            if (o == null) return;
            numericBufferSize.Enabled = o.Checked;
            if (o.Checked == false) { 
                flexGUIConfig.bufferSizeSamples = null; 
            }
            else
            {
                numericBufferSize_ValueChanged(numericBufferSize, null);
            }
            GenerateOutput();
        }

        private void checkBoxWasapiInputSet_CheckedChanged(object sender, EventArgs e)
        {
            var o = sender as CheckBox;
            if (o == null) return;
            wasapiAutoConvertInput.Enabled = o.Checked;
            wasapiExclusiveInput.Enabled = o.Checked;

            if (o.Checked == false)
            {
                flexGUIConfig.input.wasapiAutoConvert = null;
                flexGUIConfig.input.wasapiExclusiveMode = null;
            }
            else
            {
                flexGUIConfig.input.wasapiAutoConvert = wasapiAutoConvertInput.Checked;
                flexGUIConfig.input.wasapiExclusiveMode = wasapiExclusiveInput.Checked;
            }
            GenerateOutput();
        }

        private void checkBoxWasapOutputSet_CheckedChanged(object sender, EventArgs e)
        {
            var o = sender as CheckBox;
            if (o == null) return;
            wasapiAutoConvertOutput.Enabled = o.Checked;
            wasapiExclusiveOutput.Enabled = o.Checked;

            if (o.Checked == false)
            {
                flexGUIConfig.output.wasapiAutoConvert = null;
                flexGUIConfig.output.wasapiExclusiveMode = null;
            }
            else
            {
                flexGUIConfig.output.wasapiAutoConvert = wasapiAutoConvertOutput.Checked;
                flexGUIConfig.output.wasapiExclusiveMode = wasapiExclusiveOutput.Checked;
            }
            GenerateOutput();
        }

        private void btRefreshDevices_Click(object sender, EventArgs e)
        {
            var selectedBackend = comboBackend.SelectedItem as string;
            RefreshDevices(selectedBackend);
        }

        private void linkLabelDocs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo(docUrl) { UseShellExecute = true });
        }
    }
}
