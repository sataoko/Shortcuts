using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Shortcuts
{
    public enum Platform
    {
        X86,
        X64,
        Unknown
    }

    public class ProcessorInfo
    {
        public Platform Platform;
        public uint CPUCount;
    }

    class SystemInfo
    {


        internal const ushort PROCESSOR_ARCHITECTURE_INTEL = 0;
        internal const ushort PROCESSOR_ARCHITECTURE_IA64 = 6;
        internal const ushort PROCESSOR_ARCHITECTURE_AMD64 = 9;
        internal const ushort PROCESSOR_ARCHITECTURE_UNKNOWN = 0xFFFF;

        [StructLayout(LayoutKind.Sequential)]
        internal struct SYSTEM_INFO
        {
            public ushort wProcessorArchitecture;
            public ushort wReserved;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public UIntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort wProcessorLevel;
            public ushort wProcessorRevision;
        };

        [DllImport("kernel32.dll")]
        internal static extern void GetNativeSystemInfo(ref SYSTEM_INFO lpSystemInfo);

        [DllImport("kernel32.dll")]
        internal static extern void GetSystemInfo(ref SYSTEM_INFO lpSystemInfo);

        public static ProcessorInfo GetPlatform()
        {
            ProcessorInfo pi = new ProcessorInfo();
            SYSTEM_INFO sysInfo = new SYSTEM_INFO();

            if (System.Environment.OSVersion.Version.Major > 5 ||
          (System.Environment.OSVersion.Version.Major == 5 && System.Environment.OSVersion.Version.Minor >= 1))
            {
                GetNativeSystemInfo(ref sysInfo);
            }
            else
            {
                GetSystemInfo(ref sysInfo);
            }

            pi.CPUCount = sysInfo.dwNumberOfProcessors;
            switch (sysInfo.wProcessorArchitecture)
            {
                case PROCESSOR_ARCHITECTURE_IA64: break;
                case PROCESSOR_ARCHITECTURE_AMD64: pi.Platform = Platform.X64; break;
                case PROCESSOR_ARCHITECTURE_INTEL: pi.Platform = Platform.X86; break;
                default: pi.Platform = Platform.Unknown; break;
            }


            return pi;
        }


        public static string LicenseCDKey
        {
            get
            {
                try
                {
                    byte[] rpk = (byte[])Microsoft.Win32.Registry.LocalMachine
                       .OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion")
                       .GetValue("DigitalProductId");
                    string serial = "";
                    const string possible = "BCDFGHJKMPQRTVWXY2346789";
                    for (int i = 0; i < 25; i++)
                    {
                        int accu = 0;
                        for (int a = 0; a < 15; a++)
                        {
                            accu <<= 8;
                            accu += rpk[66 - a];
                            rpk[66 - a] = (byte)(accu / 24 & 0xff);
                            accu %= 24;
                        }
                        serial = possible[accu] + serial;
                        if (i % 5 == 4 && i < 24)
                        {
                            serial = "-" + serial;
                        }
                    }
                    return serial;
                }
                catch
                {
                    return "Error";
                }
            }
        }

        public static string GetCurrentScreenSize()
        {
            //System.Windows.Forms.Screen scrn = System.Windows.Forms.Screen.FromControl(this);
            //if (scrn == null)
            //{
            //    scrn = System.Windows.Forms.Screen.PrimaryScreen;
            //}
            System.Windows.Forms.Screen scrn = System.Windows.Forms.Screen.PrimaryScreen;
            int deskHeight = scrn.Bounds.Height;
            int deskWidth = scrn.Bounds.Width;
            return deskWidth.ToString() + "x" + deskHeight.ToString();
        }

    }
}
