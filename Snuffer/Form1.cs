using System;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Windows;
using System.Runtime.InteropServices;

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
            string selectedProcessName = cmbx_Process.SelectedItem.ToString();
            Process selectedProcess = Process.GetProcessesByName(selectedProcessName).FirstOrDefault();

            return selectedProcess;
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
                // Gather information about the selected process
                string processInfo = $"Process Name: {selectedProcess.ProcessName}\n" +
                                    $"Process ID: {selectedProcess.Id}\n" +
                                    $"Main Window Title: {selectedProcess.MainWindowTitle}\n" +
                                    $"Start Time: {selectedProcess.StartTime}\n" +
                                    $"Total Processor Time: {selectedProcess.TotalProcessorTime}\n" +
                                    $"Working Set: {selectedProcess.WorkingSet64} bytes\n" +
                                    $"Base Priority: {selectedProcess.BasePriority}\n" +
                                    $"Session ID: {selectedProcess.SessionId}\n" +
                                    $"Type: {selectedProcess.GetType}\n";




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
                    selectedProcess.Kill();
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
    }
}