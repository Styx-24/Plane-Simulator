namespace Simulator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLoad = new Button();
            btnPause = new Button();
            lstAircrafts = new ListBox();
            lstClients = new ListBox();
            lstAirports = new ListBox();
            btnFast = new Button();
            btnSlow = new Button();
            labTimeMultExplain = new Label();
            labTimeMult = new Label();
            labAirports = new Label();
            labClients = new Label();
            lab = new Label();
            panMap = new Panel();
            labTimeExplain = new Label();
            labTime = new Label();
            checkShowAll = new CheckBox();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(17, 32);
            btnLoad.Margin = new Padding(3, 2, 3, 2);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(458, 22);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load a senario";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click_1;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(624, 32);
            btnPause.Margin = new Padding(3, 2, 3, 2);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(150, 22);
            btnPause.TabIndex = 1;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click_1;
            // 
            // lstAircrafts
            // 
            lstAircrafts.FormattingEnabled = true;
            lstAircrafts.ItemHeight = 15;
            lstAircrafts.Location = new Point(570, 139);
            lstAircrafts.Margin = new Padding(3, 2, 3, 2);
            lstAircrafts.Name = "lstAircrafts";
            lstAircrafts.Size = new Size(334, 94);
            lstAircrafts.TabIndex = 2;
            // 
            // lstClients
            // 
            lstClients.FormattingEnabled = true;
            lstClients.ItemHeight = 15;
            lstClients.Location = new Point(255, 139);
            lstClients.Margin = new Padding(3, 2, 3, 2);
            lstClients.Name = "lstClients";
            lstClients.Size = new Size(264, 94);
            lstClients.TabIndex = 3;
            // 
            // lstAirports
            // 
            lstAirports.FormattingEnabled = true;
            lstAirports.ItemHeight = 15;
            lstAirports.Location = new Point(37, 139);
            lstAirports.Margin = new Padding(3, 2, 3, 2);
            lstAirports.Name = "lstAirports";
            lstAirports.Size = new Size(148, 94);
            lstAirports.TabIndex = 4;
            lstAirports.SelectedIndexChanged += lstAirports_SelectedIndexChanged_1;
            // 
            // btnFast
            // 
            btnFast.Location = new Point(793, 32);
            btnFast.Margin = new Padding(3, 2, 3, 2);
            btnFast.Name = "btnFast";
            btnFast.Size = new Size(46, 22);
            btnFast.TabIndex = 5;
            btnFast.Text = ">";
            btnFast.UseVisualStyleBackColor = true;
            btnFast.Click += btnFast_Click_1;
            // 
            // btnSlow
            // 
            btnSlow.Location = new Point(553, 32);
            btnSlow.Margin = new Padding(3, 2, 3, 2);
            btnSlow.Name = "btnSlow";
            btnSlow.Size = new Size(56, 22);
            btnSlow.TabIndex = 6;
            btnSlow.Text = "<";
            btnSlow.UseVisualStyleBackColor = true;
            btnSlow.Click += btnSlow_Click_1;
            // 
            // labTimeMultExplain
            // 
            labTimeMultExplain.AutoSize = true;
            labTimeMultExplain.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            labTimeMultExplain.Location = new Point(507, 76);
            labTimeMultExplain.Name = "labTimeMultExplain";
            labTimeMultExplain.Size = new Size(126, 20);
            labTimeMultExplain.TabIndex = 7;
            labTimeMultExplain.Text = "Time multiplier: X";
            // 
            // labTimeMult
            // 
            labTimeMult.AutoSize = true;
            labTimeMult.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            labTimeMult.Location = new Point(631, 76);
            labTimeMult.Name = "labTimeMult";
            labTimeMult.Size = new Size(17, 20);
            labTimeMult.TabIndex = 8;
            labTimeMult.Text = "0";
            // 
            // labAirports
            // 
            labAirports.AutoSize = true;
            labAirports.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            labAirports.Location = new Point(37, 110);
            labAirports.Name = "labAirports";
            labAirports.Size = new Size(62, 20);
            labAirports.TabIndex = 9;
            labAirports.Text = "Airports";
            // 
            // labClients
            // 
            labClients.AutoSize = true;
            labClients.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            labClients.Location = new Point(255, 110);
            labClients.Name = "labClients";
            labClients.Size = new Size(53, 20);
            labClients.TabIndex = 10;
            labClients.Text = "Clients";
            // 
            // lab
            // 
            lab.AutoSize = true;
            lab.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lab.Location = new Point(570, 110);
            lab.Name = "lab";
            lab.Size = new Size(64, 20);
            lab.TabIndex = 11;
            lab.Text = "Aircrafts";
            // 
            // panMap
            // 
            panMap.BackgroundImage = Properties.Resources.reverseMap1;
            panMap.Location = new Point(80, 272);
            panMap.Margin = new Padding(3, 2, 3, 2);
            panMap.Name = "panMap";
            panMap.Size = new Size(842, 502);
            panMap.TabIndex = 12;
            panMap.Paint += panMap_Paint_1;
            // 
            // labTimeExplain
            // 
            labTimeExplain.AutoSize = true;
            labTimeExplain.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            labTimeExplain.Location = new Point(663, 76);
            labTimeExplain.Name = "labTimeExplain";
            labTimeExplain.Size = new Size(200, 20);
            labTimeExplain.TabIndex = 13;
            labTimeExplain.Text = "Time(passed since the start): ";
            // 
            // labTime
            // 
            labTime.AutoSize = true;
            labTime.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            labTime.Location = new Point(864, 76);
            labTime.Name = "labTime";
            labTime.Size = new Size(39, 20);
            labTime.TabIndex = 14;
            labTime.Text = "0:0:0";
            // 
            // checkShowAll
            // 
            checkShowAll.AutoSize = true;
            checkShowAll.Location = new Point(65, 236);
            checkShowAll.Margin = new Padding(3, 2, 3, 2);
            checkShowAll.Name = "checkShowAll";
            checkShowAll.Size = new Size(72, 19);
            checkShowAll.TabIndex = 15;
            checkShowAll.Text = "Show All";
            checkShowAll.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1004, 800);
            Controls.Add(checkShowAll);
            Controls.Add(labTime);
            Controls.Add(labTimeExplain);
            Controls.Add(panMap);
            Controls.Add(lab);
            Controls.Add(labClients);
            Controls.Add(labAirports);
            Controls.Add(labTimeMult);
            Controls.Add(labTimeMultExplain);
            Controls.Add(btnSlow);
            Controls.Add(btnFast);
            Controls.Add(lstAirports);
            Controls.Add(lstClients);
            Controls.Add(lstAircrafts);
            Controls.Add(btnPause);
            Controls.Add(btnLoad);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoad;
        private Button btnPause;
        private ListBox lstAircrafts;
        private ListBox lstClients;
        private ListBox lstAirports;
        private Button btnFast;
        private Button btnSlow;
        private Label labTimeMultExplain;
        private Label labTimeMult;
        private Label labAirports;
        private Label labClients;
        private Label lab;
        private Panel panMap;
        private Label labTimeExplain;
        private Label labTime;
        private CheckBox checkShowAll;
    }
}