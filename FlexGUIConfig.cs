using System;
using System.Collections.Generic;
using System.Text;

namespace FlexASIOGUI
{
    public class FlexGUIConfig
    {
        public string backend { get; set; } = "Windows WASAPI";
        public int? bufferSizeSamples { get; set; } = null;
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
        public double? suggestedLatencySeconds { get; set; } = null;
        public bool? wasapiExclusiveMode { get; set; } = null;
        public bool? wasapiAutoConvert { get; set; } = null;
        public int? channels { get; set; }
    }
}
