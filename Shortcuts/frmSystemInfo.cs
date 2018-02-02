using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Shortcuts
{
    public partial class frmSystemInfo : Form
    {
        [DllImport("msi.dll", CharSet = CharSet.Unicode)]
        static extern Int32 MsiGetProductInfo(string product, string property,
            [Out] StringBuilder valueBuf, ref Int32 len);

        [DllImport("msi.dll", SetLastError = true)]
        static extern int MsiEnumProducts(int iProductIndex,
            StringBuilder lpProductBuf);


        public void WriteLine(string s)
        {
            txtConsole.Text += s + "\r\n";
        }

        private void WriteKey(RegistryKey hk, string relPath)
        {
            if (relPath != "")
                relPath += "/";

            foreach (var keyname in hk.GetSubKeyNames())
            {
                var key = hk.OpenSubKey(keyname, false);

                var keySP = key.GetValue("SP");
                var keyVersion = key.GetValue("Version");

                if (keyVersion != null)
                    WriteLine(relPath + keyname +
                      ": Version " + keyVersion.ToString() +
                      ((keySP != null) ? " SP " + keySP.ToString() : "") +
                      (1.Equals(key.GetValue("Install")) ? " installed" : ""));

                WriteKey(key, relPath + keyname);

                key.Close();
            }
        }

        public void getProcessorInfo()
        {
            RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.
            if (processor_name != null)
            {
                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    WriteLine(processor_name.GetValue("ProcessorNameString").ToString());   //Display processor ingo.
                }
            }
        }

        struct MEMORYSTATUS
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public uint dwTotalPhys;
            public uint dwAvailPhys;
            public uint dwTotalPageFile;
            public uint dwAvailPageFile;
            public uint dwTotalVirtual;
            public uint dwAvailVirtual;
        }

        [DllImport("kernel32.dll")]
        static extern void GlobalMemoryStatus
            (ref MEMORYSTATUS lpBuffer);

        public void GetMemoryStatus()
        {
            MEMORYSTATUS Status = new MEMORYSTATUS();
            GlobalMemoryStatus(ref Status);
            WriteLine("Percentage memory loaded:" + Status.dwMemoryLoad + " %");
            WriteLine("Amount of physical memory: " + Status.dwTotalPhys / (1024 * 1024) + " mb");
            WriteLine("Amount of physical memory currently available:" +
            (int)((Status.dwTotalPhys - ((decimal)Status.dwTotalPhys * ((decimal)Status.dwMemoryLoad / 100))) / (1024 * 1024)) + " mb");
        }

        public frmSystemInfo()
        {
            InitializeComponent();
        }

        private void btnShowSystemInfo_Click(object sender, EventArgs e)
        {
            WriteLine("OPERATING SYSTEM DETAILS");
            WriteLine("===================================================");
            OperatingSystem os = Environment.OSVersion;
            WriteLine("OS Version: " + os.Version.ToString());
            WriteLine("OS Platoform: " + os.Platform.ToString());
            WriteLine("OS SP: " + os.ServicePack.ToString());
            WriteLine("OS Version String: " + os.VersionString.ToString());
            // Get Version details
            Version ver = os.Version;
            WriteLine("Major version: " + ver.Major);
            WriteLine("Major Revision: " + ver.MajorRevision);
            WriteLine("Minor version: " + ver.Minor);
            WriteLine("Minor Revision: " + ver.MinorRevision);
            WriteLine("Build: " + ver.Build);
            WriteLine("WINDOWS KEY:" + SystemInfo.LicenseCDKey);

            WriteLine("");
            WriteLine(".NET FRAMEWORK VERSIONS");
            WriteLine("===================================================");
            var hkNDP = Registry.LocalMachine.OpenSubKey(
              @"SOFTWARE\Microsoft\NET Framework Setup\NDP", false);
            WriteKey(hkNDP, "");
            hkNDP.Close();

            WriteLine("");
            WriteLine("PROCESSOR INFO");
            WriteLine("===================================================");
            getProcessorInfo();

            ProcessorInfo pi = SystemInfo.GetPlatform();
            WriteLine("CPU Count:" + pi.CPUCount.ToString());
            WriteLine(pi.Platform.ToString());



            WriteLine("");
            WriteLine("MEMORY STATUS");
            WriteLine("===================================================");
            GetMemoryStatus();

            WriteLine("");
            WriteLine("DISPLAY INFO");
            WriteLine("===================================================");

            //WriteLine("Primary Monitor Size:"+SystemInformation.PrimaryMonitorSize.Width + "x" + SystemInformation.PrimaryMonitorSize.Height);
            //WriteLine("Virtual Screen Size:"+SystemInformation.VirtualScreen.Width + "x" + SystemInformation.VirtualScreen.Height);


            // WriteLine("Screen Size:"+SystemInfo.GetCurrentScreenSize());

            Screen[] monitors = Screen.AllScreens;

            foreach (Screen monitor in monitors)
            {
                WriteLine("Bits Per Pixel: " + monitor.BitsPerPixel);
                WriteLine("Bounds: " + monitor.Bounds);
                WriteLine("Device Name: " + monitor.DeviceName);
                WriteLine("Is Primary: " + monitor.Primary);
                WriteLine("Working Area: " + monitor.WorkingArea);
            }



            WriteLine("");
            WriteLine("HARDDISK INFO");
            WriteLine("===================================================");

            foreach (System.IO.DriveInfo label in System.IO.DriveInfo.GetDrives())
            {
                if (label.IsReady)
                {
                    WriteLine(label.Name + " " + "TotalSize" + " " + (label.TotalSize / 1073741824).ToString("##.#") + "GB");
                    WriteLine(label.Name + " " + "FreeSpace" + " " + (label.TotalFreeSpace / 1073741824).ToString("##.#") + "GB");
                }
            }

            WriteLine("");
            WriteLine("INSTALLED SOFTWARES");
            WriteLine("===================================================");

            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        // we have many attributes other than these which are useful.
                        WriteLine(sk.GetValue("DisplayName") + "  " + sk.GetValue("DisplayVersion"));
                    }

                }
            }


            StringBuilder sbProductCode = new StringBuilder(39);
            int iIdx = 0;
            while (
                0 == MsiEnumProducts(iIdx++, sbProductCode))
            {
                Int32 productNameLen = 512;
                StringBuilder sbProductName = new StringBuilder(productNameLen);

                MsiGetProductInfo(sbProductCode.ToString(),
                    "ProductName", sbProductName, ref productNameLen);

                if (sbProductName.ToString().Contains("Visual Studio"))
                {
                    Int32 installDirLen = 1024;
                    StringBuilder sbInstallDir = new StringBuilder(installDirLen);
                    MsiGetProductInfo(sbProductCode.ToString(), "InstallLocation", sbInstallDir, ref installDirLen);
                    WriteLine("ProductName:" + sbProductName + ", DIR:" + sbInstallDir);
                }
            }
        }

        private void btnSaveSystemInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(txtConsole.Text))
                if(saveFileDialog1.ShowDialog()==DialogResult.OK)
                System.IO.File.WriteAllText(saveFileDialog1.FileName, txtConsole.Text);

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            
        }
    }
}
