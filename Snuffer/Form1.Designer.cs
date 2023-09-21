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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Snuffer));
            btn_Refresh = new Button();
            cmbx_Process = new ComboBox();
            btn_Analyze = new Button();
            RchTxtBx_ProcessInfo = new RichTextBox();
            picbx_Snuffer = new PictureBox();
            btn_KillSelectedProcess = new Button();
            btn_SuspendSelectedProcess = new Button();
            btn_ResumeSelectedProcess = new Button();
            chkbx_AutoUpdateAnalyze = new CheckBox();
            tmr_AutoUpdateAnalyze = new System.Windows.Forms.Timer(components);
            opnfldlg_SelectDll = new OpenFileDialog();
            txtbx_DLLPath = new TextBox();
            btn_SelectDLL = new Button();
            btn_InjectDLL = new Button();
            lbl_InjectDLL = new Label();
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
            cmbx_Process.Size = new Size(232, 29);
            cmbx_Process.TabIndex = 1;
            // 
            // btn_Analyze
            // 
            btn_Analyze.Font = new Font("Arial Nova Cond", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Analyze.Location = new Point(350, 12);
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
            RchTxtBx_ProcessInfo.Location = new Point(12, 113);
            RchTxtBx_ProcessInfo.Name = "RchTxtBx_ProcessInfo";
            RchTxtBx_ProcessInfo.Size = new Size(620, 312);
            RchTxtBx_ProcessInfo.TabIndex = 4;
            RchTxtBx_ProcessInfo.Text = "";
            RchTxtBx_ProcessInfo.TextChanged += RchTxtBx_ProcessInfo_TextChanged;
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
            btn_KillSelectedProcess.Location = new Point(12, 78);
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
            btn_SuspendSelectedProcess.Location = new Point(125, 78);
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
            btn_ResumeSelectedProcess.Location = new Point(225, 78);
            btn_ResumeSelectedProcess.Name = "btn_ResumeSelectedProcess";
            btn_ResumeSelectedProcess.Size = new Size(94, 29);
            btn_ResumeSelectedProcess.TabIndex = 8;
            btn_ResumeSelectedProcess.Text = "Resume";
            btn_ResumeSelectedProcess.UseVisualStyleBackColor = true;
            btn_ResumeSelectedProcess.Click += btn_ResumeSelectedProcess_Click;
            // 
            // chkbx_AutoUpdateAnalyze
            // 
            chkbx_AutoUpdateAnalyze.AutoSize = true;
            chkbx_AutoUpdateAnalyze.Font = new Font("Arial Nova Cond", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            chkbx_AutoUpdateAnalyze.Location = new Point(450, 15);
            chkbx_AutoUpdateAnalyze.Name = "chkbx_AutoUpdateAnalyze";
            chkbx_AutoUpdateAnalyze.Size = new Size(176, 25);
            chkbx_AutoUpdateAnalyze.TabIndex = 9;
            chkbx_AutoUpdateAnalyze.Text = "Auto Update Analyze";
            chkbx_AutoUpdateAnalyze.UseVisualStyleBackColor = true;
            chkbx_AutoUpdateAnalyze.CheckedChanged += chkbx_AutoUpdateAnalyze_CheckedChanged;
            // 
            // tmr_AutoUpdateAnalyze
            // 
            tmr_AutoUpdateAnalyze.Enabled = true;
            tmr_AutoUpdateAnalyze.Interval = 50;
            tmr_AutoUpdateAnalyze.Tick += tmr_AutoUpdateAnalyze_Tick;
            // 
            // txtbx_DLLPath
            // 
            txtbx_DLLPath.Location = new Point(340, 78);
            txtbx_DLLPath.Name = "txtbx_DLLPath";
            txtbx_DLLPath.Size = new Size(161, 27);
            txtbx_DLLPath.TabIndex = 10;
            // 
            // btn_SelectDLL
            // 
            btn_SelectDLL.Font = new Font("Arial Nova Cond", 7.20000029F, FontStyle.Bold, GraphicsUnit.Point);
            btn_SelectDLL.Location = new Point(507, 78);
            btn_SelectDLL.Name = "btn_SelectDLL";
            btn_SelectDLL.Size = new Size(27, 27);
            btn_SelectDLL.TabIndex = 11;
            btn_SelectDLL.Text = "...";
            btn_SelectDLL.UseVisualStyleBackColor = true;
            btn_SelectDLL.Click += btn_SelectDLL_Click;
            // 
            // btn_InjectDLL
            // 
            btn_InjectDLL.Font = new Font("Arial Nova Cond", 7.20000029F, FontStyle.Bold, GraphicsUnit.Point);
            btn_InjectDLL.Location = new Point(540, 78);
            btn_InjectDLL.Name = "btn_InjectDLL";
            btn_InjectDLL.Size = new Size(92, 27);
            btn_InjectDLL.TabIndex = 12;
            btn_InjectDLL.Text = "Inject DLL";
            btn_InjectDLL.UseVisualStyleBackColor = true;
            btn_InjectDLL.Click += btn_InjectDLL_Click;
            // 
            // lbl_InjectDLL
            // 
            lbl_InjectDLL.AutoSize = true;
            lbl_InjectDLL.Font = new Font("Arial Nova Cond", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_InjectDLL.Location = new Point(350, 54);
            lbl_InjectDLL.Name = "lbl_InjectDLL";
            lbl_InjectDLL.Size = new Size(151, 21);
            lbl_InjectDLL.TabIndex = 13;
            lbl_InjectDLL.Text = "DLL Injection (beta)";
            // 
            // Snuffer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(143, 188, 148);
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_InjectDLL);
            Controls.Add(btn_InjectDLL);
            Controls.Add(btn_SelectDLL);
            Controls.Add(txtbx_DLLPath);
            Controls.Add(chkbx_AutoUpdateAnalyze);
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
            Load += Snuffer_Load;
            ((System.ComponentModel.ISupportInitialize)picbx_Snuffer).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private CheckBox chkbx_AutoUpdateAnalyze;
        private System.Windows.Forms.Timer tmr_AutoUpdateAnalyze;
        private OpenFileDialog opnfldlg_SelectDll;
        private TextBox txtbx_DLLPath;
        private Button btn_SelectDLL;
        private Button btn_InjectDLL;
        private Label lbl_InjectDLL;
    }
}