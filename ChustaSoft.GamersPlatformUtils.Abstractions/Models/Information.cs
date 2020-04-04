using System;
using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public class Information
    {
        public string MachineName { get; set; }
        public OperatingSystem OperartiveSystem { get; set; }
        public IEnumerable<IPlatform> Platforms { get; set; }

        public string MachineSystem => OperartiveSystem.ToString();

    }
}
