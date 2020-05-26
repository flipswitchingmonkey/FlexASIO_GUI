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

namespace FlexASIOGUI
{
    public partial class Form1 : Form
    {

        private bool InitDone = false;
        private string TOMLPath;
        private FlexGUIConfig flexGUIConfig;

        public Form1()
        {
            InitializeComponent();

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            CultureInfo.DefaultThreadCurrentCulture = customCulture;
            CultureInfo.DefaultThreadCurrentUICulture = customCulture;

            TOMLPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\FlexASIO.toml";

            flexGUIConfig = new FlexGUIConfig();
            if (File.Exists(TOMLPath))
            {
                flexGUIConfig = Toml.ReadFile<FlexGUIConfig>(TOMLPath);
            }

            numericBufferSize.Maximum = 8192;
            numericBufferSize.Value = 256;
            numericBufferSize.Increment = 16;

            numericLatencyInput.Increment = 0.1m;
            numericLatencyOutput.Increment = 0.1m;

            PortAudioInterop.Pa_Initialize();

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


            numericBufferSize.Value = (Int64)flexGUIConfig.bufferSizeSamples;
            
            treeDevicesInput.SelectedNode = treeDevicesInput.Nodes.Cast<TreeNode>().FirstOrDefault(x => x.Text == (flexGUIConfig.input.device == "" ? "(None)" : flexGUIConfig.input.device));
            treeDevicesOutput.SelectedNode = treeDevicesOutput.Nodes.Cast<TreeNode>().FirstOrDefault(x => x.Text == (flexGUIConfig.output.device == "" ? "(None)" : flexGUIConfig.output.device));
            
            numericLatencyInput.Value = (decimal)(double)flexGUIConfig.input.suggestedLatencySeconds;
            numericLatencyOutput.Value = (decimal)(double)flexGUIConfig.output.suggestedLatencySeconds;

            numericChannelsInput.Value = (decimal)(flexGUIConfig.input.channels ?? 0);
            numericChannelsOutput.Value = (decimal)(flexGUIConfig.output.channels ?? 0);

            wasapiExclusiveInput.Checked = flexGUIConfig.input.wasapiExclusiveMode;
            wasapiExclusiveOutput.Checked = flexGUIConfig.output.wasapiExclusiveMode;

            wasapiAutoConvertInput.Checked = flexGUIConfig.input.wasapiAutoConvert;
            wasapiAutoConvertOutput.Checked = flexGUIConfig.output.wasapiAutoConvert;

            InitDone = true;
            SetStatusMessage($"FlexASIO GUI for FlexASIO 0.15 started ({Configuration.VersionString})");
            GenerateOutput();
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
                        treeNodes.Add(new TreeNode(deviceInfo.name));
                    }
                }
                else
                {
                    if (deviceInfo.maxOutputChannels > 0)
                    {
                        treeNodes.Add(new TreeNode(deviceInfo.name));
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
                if (selectedBackend != null)
                {
                    treeDevicesInput.Nodes.Clear();
                    treeDevicesInput.Nodes.AddRange(GetDevicesForBackend(selectedBackend, true));

                    treeDevicesOutput.Nodes.Clear();
                    treeDevicesOutput.Nodes.AddRange(GetDevicesForBackend(selectedBackend, false));
                }
                flexGUIConfig.backend = selectedBackend;
                GenerateOutput();
            }
        }

        private void GenerateOutput()
        {
            if (!InitDone) return;

            // Old manual way of writing the config file...

            //StringBuilder config = new StringBuilder();
            //var backend = comboBackend.SelectedItem.ToString();
            //var input = treeDevicesInput?.SelectedNode?.Text;
            //var output = treeDevicesOutput?.SelectedNode?.Text;
            //var inputLatency = numericLatencyInput.Value.ToString();
            //var outputLatency = numericLatencyOutput.Value.ToString();

            //config.AppendLine($"# Host API backend");
            //config.AppendLine($"backend = \"{comboBackend.SelectedItem?.ToString()}\"");
            //config.AppendLine($"bufferSizeSamples = {numericBufferSize?.Value.ToString()}");
            //config.AppendLine("");
            //config.AppendLine($"[input]");
            //if (input == "(None)")
            //    config.AppendLine($"device = \"\"");
            //else
            //    config.AppendLine($"device = \"{treeDevicesInput?.SelectedNode?.Text}\"");
            //if (numericChannelsInput.Value > 0)
            //{
            //    config.AppendLine($"channels = {numericChannelsInput?.Value.ToString()}");
            //}
            //config.AppendLine($"suggestedLatencySeconds = {numericLatencyInput?.Value.ToString("0.0", new CultureInfo("en-US"))}");
            //config.AppendLine($"wasapiExclusiveMode = {wasapiExclusiveInput?.Checked.ToString().ToLower()}");
            //config.AppendLine($"wasapiAutoConvert = {wasapiAutoConvertInput?.Checked.ToString().ToLower()}");
            //config.AppendLine("");
            //config.AppendLine($"[output]");
            //if (output == "(None)")
            //    config.AppendLine($"device = \"\"");
            //else
            //    config.AppendLine($"device = \"{treeDevicesOutput?.SelectedNode?.Text}\"");
            //if (numericChannelsOutput.Value > 0)
            //{
            //    config.AppendLine($"channels = {numericChannelsOutput?.Value.ToString()}");
            //}
            //config.AppendLine($"suggestedLatencySeconds = {numericLatencyOutput?.Value.ToString("0.0", new CultureInfo("en-US"))}");
            //config.AppendLine($"wasapiExclusiveMode = {wasapiExclusiveOutput?.Checked.ToString().ToLower()}");
            //config.AppendLine($"wasapiAutoConvert = {wasapiAutoConvertOutput?.Checked.ToString().ToLower()}");
            //configOutput.Text = config.ToString();

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
            saveFileDialog.FileName = "FlexASIO.toml";
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
                flexGUIConfig.input.device = o.SelectedNode.Text;
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
                flexGUIConfig.output.device = o.SelectedNode.Text;
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
            flexGUIConfig.output.suggestedLatencySeconds = (o.Value > 0 ? (double)o.Value : 0);
            GenerateOutput();
        }

        private void numericLatencyInput_ValueChanged(object sender, EventArgs e)
        {
            var o = sender as NumericUpDown;
            if (o == null) return;
            flexGUIConfig.input.suggestedLatencySeconds = (o.Value > 0 ? (double)o.Value : 0);
            GenerateOutput();
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
    }
}
