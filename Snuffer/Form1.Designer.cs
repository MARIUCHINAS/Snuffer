namespace Snuffer
{
    partial class Snuffer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Snuffer));
            btn_Refresh = new Button();
            cmbx_Process = new ComboBox();
            btn_Analyze = new Button();
            RchTxtBx_ProcessInfo = new RichTextBox();
            picbx_Snuffer = new PictureBox();
            btn_KillSelectedProcess = new Button();
            btn_SuspendSelectedProcess = new Button();
            btn_ResumeSelectedProcess = new Button();
            ((System.ComponentModel.ISupportInitialize)picbx_Snuffer).BeginInit();
            SuspendLayout();
            // 
            // btn_Refresh
            // 
            btn_Refresh.Font = new Font("Arial Nova Cond", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Refresh.Location = new Point(12, 12);
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Size = new Size(94, 29);
            btn_Refresh.TabIndex = 0;
            btn_Refresh.Text = "Refresh";
            btn_Refresh.UseVisualStyleBackColor = true;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // cmbx_Process
            // 
            cmbx_Process.Font = new Font("Arial Nova Cond", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            cmbx_Process.FormattingEnabled = true;
            cmbx_Process.Location = new Point(112, 12);
            cmbx_Process.Name = "cmbx_Process";
            cmbx_Process.Size = new Size(151, 29);
            cmbx_Process.TabIndex = 1;
            // 
            // btn_Analyze
            // 
            btn_Analyze.Font = new Font("Arial Nova Cond", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Analyze.Location = new Point(269, 12);
            btn_Analyze.Name = "btn_Analyze";
            btn_Analyze.Size = new Size(94, 29);
            btn_Analyze.TabIndex = 3;
            btn_Analyze.Text = "Analyze";
            btn_Analyze.UseVisualStyleBackColor = true;
            btn_Analyze.Click += btn_Analyze_Click;
            // 
            // RchTxtBx_ProcessInfo
            // 
            RchTxtBx_ProcessInfo.BackColor = Color.FromArgb(84, 134, 135);
            RchTxtBx_ProcessInfo.Location = new Point(12, 126);
            RchTxtBx_ProcessInfo.Name = "RchTxtBx_ProcessInfo";
            RchTxtBx_ProcessInfo.Size = new Size(666, 312);
            RchTxtBx_ProcessInfo.TabIndex = 4;
            RchTxtBx_ProcessInfo.Text = "";
            // 
            // picbx_Snuffer
            // 
            picbx_Snuffer.Image = Properties.Resources.Untitled__1___1___Custom_;
            picbx_Snuffer.Location = new Point(638, -25);
            picbx_Snuffer.Name = "picbx_Snuffer";
            picbx_Snuffer.Size = new Size(150, 150);
            picbx_Snuffer.TabIndex = 5;
            picbx_Snuffer.TabStop = false;
            // 
            // btn_KillSelectedProcess
            // 
            btn_KillSelectedProcess.Font = new Font("Arial Nova Cond", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btn_KillSelectedProcess.Location = new Point(12, 91);
            btn_KillSelectedProcess.Name = "btn_KillSelectedProcess";
            btn_KillSelectedProcess.Size = new Size(94, 29);
            btn_KillSelectedProcess.TabIndex = 6;
            btn_KillSelectedProcess.Text = "Kill";
            btn_KillSelectedProcess.UseVisualStyleBackColor = true;
            btn_KillSelectedProcess.Click += btn_KillSelectedProcess_Click;
            // 
            // btn_SuspendSelectedProcess
            // 
            btn_SuspendSelectedProcess.Font = new Font("Arial Nova Cond", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btn_SuspendSelectedProcess.Location = new Point(125, 91);
            btn_SuspendSelectedProcess.Name = "btn_SuspendSelectedProcess";
            btn_SuspendSelectedProcess.Size = new Size(94, 29);
            btn_SuspendSelectedProcess.TabIndex = 7;
            btn_SuspendSelectedProcess.Text = "Suspend";
            btn_SuspendSelectedProcess.UseVisualStyleBackColor = true;
            btn_SuspendSelectedProcess.Click += btn_SuspendSelectedProcess_Click;
            // 
            // btn_ResumeSelectedProcess
            // 
            btn_ResumeSelectedProcess.Font = new Font("Arial Nova", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btn_ResumeSelectedProcess.Location = new Point(225, 91);
            btn_ResumeSelectedProcess.Name = "btn_ResumeSelectedProcess";
            btn_ResumeSelectedProcess.Size = new Size(94, 29);
            btn_ResumeSelectedProcess.TabIndex = 8;
            btn_ResumeSelectedProcess.Text = "Resume";
            btn_ResumeSelectedProcess.UseVisualStyleBackColor = true;
            btn_ResumeSelectedProcess.Click += btn_ResumeSelectedProcess_Click;
            // 
            // Snuffer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(143, 188, 148);
            ClientSize = new Size(800, 450);
            Controls.Add(btn_ResumeSelectedProcess);
            Controls.Add(btn_SuspendSelectedProcess);
            Controls.Add(btn_KillSelectedProcess);
            Controls.Add(picbx_Snuffer);
            Controls.Add(RchTxtBx_ProcessInfo);
            Controls.Add(btn_Analyze);
            Controls.Add(cmbx_Process);
            Controls.Add(btn_Refresh);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Snuffer";
            Text = "Snuffer";
            ((System.ComponentModel.ISupportInitialize)picbx_Snuffer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Refresh;
        private ComboBox cmbx_Process;
        private Button btn_Analyze;
        private RichTextBox RchTxtBx_ProcessInfo;
        private PictureBox picbx_Snuffer;
        private Button btn_KillSelectedProcess;
        private Button btn_SuspendSelectedProcess;
        private Button btn_ResumeSelectedProcess;
    }
}