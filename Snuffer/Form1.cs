using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;



// https://coolors.co/6da34d-56445d-548687-8fbc94-c5e99b

namespace Snuffer
{
    public partial class Snuffer : Form
    {
        public Snuffer()
        {
            InitializeComponent();
        }

        [Flags]
        public enum ThreadAccess : int
        {
            TERMINATE = (0x0001),
            SUSPEND_RESUME = (0x0002),
            GET_CONTEXT = (0x0008),
            SET_CONTEXT = (0x0010),
            SET_INFORMATION = (0x0020),
            QUERY_INFORMATION = (0x0040),
            SET_THREAD_TOKEN = (0x0080),
            IMPERSONATE = (0x0100),
            DIRECT_IMPERSONATION = (0x0200)
        }

        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000,
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll")]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll")]
        public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        [DllImport("kernel32.dll")]
        public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, AllocationType dwFreeType);

        public enum AllocationType
        {
            Commit = 0x00001000,
            Reserve = 0x00002000,
            Decommit = 0x00004000,
            Release = 0x00008000,
            Reset = 0x00080000,
            Physical = 0x00400000,
            TopDown = 0x00100000,
            WriteWatch = 0x00200000,
            LargePages = 0x20000000,
        }

        public enum MemoryProtection
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400,
        }


        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllPath);
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);

        public Process GetSelectedProcess()
        {
            try
            {
                if (cmbx_Process.SelectedItem != null)
                {
                    string selectedProcessName = cmbx_Process.SelectedItem.ToString();
                    if (string.IsNullOrEmpty(selectedProcessName))
                    {
                        MessageBox.Show("No Process Selected");
                        return null;
                    }
                    Process selectedProcess = Process.GetProcessesByName(selectedProcessName).FirstOrDefault();
                    if (selectedProcess != null)
                    {
                        return selectedProcess;
                    }
                    else
                    {
                        MessageBox.Show("No Process Selected");
                        return null;
                    }
                }
                else
                {
                    MessageBox.Show("Something Went Wrong");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went Wrong: {ex.GetType().Name}");
                return null;
            }




        }


        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            cmbx_Process.Items.Clear();
            foreach (var proc in processes)
            {
                if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                    cmbx_Process.Items.Add(proc.ProcessName);
            }
        }

        private void btn_Analyze_Click(object sender, EventArgs e)
        {
            // Check if a process is selected
            if (cmbx_Process.SelectedItem == null)
            {
                MessageBox.Show("Please select a process to Analyze.");
                return;
            }

            Process selectedProcess = GetSelectedProcess();

            if (selectedProcess != null)
            {
                string assemblyPath = selectedProcess.MainModule.FileName;
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assemblyPath);

                string compiler = fileVersionInfo.CompanyName; // Compiler name
                string version = fileVersionInfo.FileVersion;  // Assembly version

                // Gather information about the selected process
                string processInfo = $"Process Name: {selectedProcess.ProcessName}\n" +
                                    $"Process ID: {selectedProcess.Id}\n" +
                                    $"Main Window Title: {selectedProcess.MainWindowTitle}\n" +
                                    $"Start Time: {selectedProcess.StartTime}\n" +
                                    $"Total Processor Time: {selectedProcess.TotalProcessorTime}\n" +
                                    $"Working Set: {selectedProcess.WorkingSet64} bytes\n" +
                                    $"Base Priority: {selectedProcess.BasePriority}\n" +
                                    $"Session ID: {selectedProcess.SessionId}\n" +
                                    $"Type: {selectedProcess.GetType}\n" +
                                    $"Compiler (beta): {compiler}\n" +
                                    $"Assembly version: {version}\n";




                // Display the information in a MessageBox (you can choose another way to display the info)
                RchTxtBx_ProcessInfo.Text = processInfo;


            }
            else
            {
                MessageBox.Show("Selected process not found.");
            }
        }

        private void btn_KillSelectedProcess_Click(object sender, EventArgs e)
        {
            // Check if a process is selected
            if (cmbx_Process.SelectedItem == null)
            {
                MessageBox.Show("Please select a process to Kill.");
                return;
            }

            Process selectedProcess = GetSelectedProcess();
            var selectedProcessId = selectedProcess.Id;

            if (selectedProcess != null)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show(
                        $"Are you sure you want to terminate {selectedProcess.ProcessName}",
                        "Snuffer",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        selectedProcess.Kill();
                    }

                    if (selectedProcess.HasExited)
                    {
                        MessageBox.Show($"Process {selectedProcess.ProcessName} has been terminated");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong");
                }

            }
            else
            {
                MessageBox.Show("Selected process not found.");
            }
        }

        private void btn_SuspendSelectedProcess_Click(object sender, EventArgs e)
        {
            // Check if a process is selected
            if (cmbx_Process.SelectedItem == null)
            {
                MessageBox.Show("Please select a process to Suspend.");
                return;
            }

            Process selectedProcess = GetSelectedProcess();
            var selectedProcessId = selectedProcess.Id;

            if (selectedProcess != null)
            {
                try
                {
                    foreach (ProcessThread pT in selectedProcess.Threads)
                    {
                        IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                        if (pOpenThread == IntPtr.Zero)
                        {
                            continue;
                        }

                        SuspendThread(pOpenThread);

                        CloseHandle(pOpenThread);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong");
                }

            }
            else
            {
                MessageBox.Show("Selected process not found.");
            }
        }

        private void btn_ResumeSelectedProcess_Click(object sender, EventArgs e)
        {
            // Check if a process is selected
            if (cmbx_Process.SelectedItem == null)
            {
                MessageBox.Show("Please select a process to Resume.");
                return;
            }

            Process selectedProcess = GetSelectedProcess();
            var selectedProcessId = selectedProcess.Id;

            if (selectedProcess != null)
            {
                try
                {
                    foreach (ProcessThread pT in selectedProcess.Threads)
                    {
                        IntPtr pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pT.Id);

                        if (pOpenThread == IntPtr.Zero)
                        {
                            continue;
                        }

                        var suspendCount = 0;
                        do
                        {
                            suspendCount = ResumeThread(pOpenThread);
                        } while (suspendCount > 0);

                        CloseHandle(pOpenThread);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong");
                }

            }
            else
            {
                MessageBox.Show("Selected process not found.");
            }
        }

        private void chkbx_AutoUpdateAnalyze_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tmr_AutoUpdateAnalyze_Tick(object sender, EventArgs e)
        {
            if (chkbx_AutoUpdateAnalyze.Checked)
            {
                if (cmbx_Process.SelectedItem != null)
                {
                    btn_Analyze_Click(sender, EventArgs.Empty);
                }

            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        public void txtbx_SelectDLL_TextChanged(object sender, EventArgs e)
        {

        }

        private void Snuffer_Load(object sender, EventArgs e)
        {

        }

        private void RchTxtBx_ProcessInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_SelectDLL_Click(object sender, EventArgs e)
        {
            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set initial directory (optional)
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Filter for DLL files
            openFileDialog.Filter = "DLL Files (*.dll)|*.dll|All Files (*.*)|*.*";

            // Show the dialog to the user
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the selected file path to the txtbx_DLLPath TextBox
                txtbx_DLLPath.Text = openFileDialog.FileName;
            }
        }

        private void btn_InjectDLL_Click(object sender, EventArgs e)
        {
            // Define the path to your DLL
            string dllPath = txtbx_DLLPath.Text;

            // Get the selected process
            Process selectedProcess = GetSelectedProcess();

            if (selectedProcess != null)
            {
                IntPtr hProcess = OpenProcess(ProcessAccessFlags.All, false, selectedProcess.Id);

                if (hProcess != IntPtr.Zero)
                {
                    try
                    {
                        // Allocate memory in the target process
                        IntPtr remoteMemory = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)(dllPath.Length + 1), AllocationType.Commit, MemoryProtection.ReadWrite);

                        // Write the DLL path to the target process
                        byte[] dllPathBytes = Encoding.ASCII.GetBytes(dllPath);
                        int bytesWritten;
                        WriteProcessMemory(hProcess, remoteMemory, dllPathBytes, (uint)dllPathBytes.Length, out bytesWritten);

                        // Load the DLL into the target process
                        IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                        IntPtr threadHandle = CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibraryAddr, remoteMemory, 0, IntPtr.Zero);

                        // Wait for the injection to complete
                        WaitForSingleObject(threadHandle, uint.MaxValue);

                        // Clean up
                        CloseHandle(threadHandle);
                        VirtualFreeEx(hProcess, remoteMemory, UIntPtr.Zero, AllocationType.Release);
                        CloseHandle(hProcess);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An Error Has Occured: {ex.GetType().Name}");
                    }

                }
                else
                {
                    MessageBox.Show("The Process Has not Been Verified");
                }
            }
        }
    }
}