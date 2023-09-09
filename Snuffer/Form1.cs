using System;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Snuffer
{
    public partial class Snuffer : Form
    {
        public Snuffer()
        {
            InitializeComponent();
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
                MessageBox.Show("Please select a process to analyze.");
                return;
            }

            string selectedProcessName = cmbx_Process.SelectedItem.ToString();

            // Find the selected process by its name
            Process selectedProcess = Process.GetProcessesByName(selectedProcessName).FirstOrDefault();

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
                                    $"Session ID: {selectedProcess.SessionId}\n";



                // Display the information in a MessageBox (you can choose another way to display the info)
                RchTxtBx_ProcessInfo.Text = processInfo;
            }
            else
            {
                MessageBox.Show("Selected process not found.");
            }
        }
    }
}