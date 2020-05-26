using System;
using System.Collections.Generic;
using System.Text;

namespace FlexASIOGUI
{
    public class FlexGUIConfig
    {
        public string backend { get; set; } = "Windows WASAPI";
        public int bufferSizeSamples { get; set; } = 256;
        public FlexGUIConfigDeviceSection input { get; set; }
        public FlexGUIConfigDeviceSection output { get; set; }

        public FlexGUIConfig()
        {
            input = new FlexGUIConfigDeviceSection();
            output = new FlexGUIConfigDeviceSection();
        }

    }
    public class FlexGUIConfigDeviceSection
    {
        public string device { get; set; }
        public double suggestedLatencySeconds { get; set; }
        public bool wasapiExclusiveMode { get; set; } = false;
        public bool wasapiAutoConvert { get; set; } = true;
        public int? channels { get; set; }
    }
}
