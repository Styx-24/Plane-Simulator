namespace TP2
{
    partial class GeneratorForm
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
            lstAirports = new ListBox();
            lstAircrafts = new ListBox();
            labNameAirport = new Label();
            btnAddAirport = new Button();
            txtNameAirport = new TextBox();
            labPosition = new Label();
            txtPosition = new TextBox();
            labMinPassenger = new Label();
            txtMinPassenger = new TextBox();
            txtMaxPassenger = new TextBox();
            labMaxPassenger = new Label();
            txtMaxCargo = new TextBox();
            labMaxCargo = new Label();
            txtMinCargo = new TextBox();
            labMinCargo = new Label();
            txtNameAircraft = new TextBox();
            labNameAircraft = new Label();
            labType = new Label();
            cmbType = new ComboBox();
            labSpeed = new Label();
            txtSpeed = new TextBox();
            txtBoarding = new TextBox();
            labBoarding = new Label();
            txtUnBoarding = new TextBox();
            labUnboarding = new Label();
            txtMaintenance = new TextBox();
            labMaintenance = new Label();
            label1 = new Label();
            btnAddAircraft = new Button();
            btnGenerate = new Button();
            labAirPortStatus = new Label();
            labAirCraftStatus = new Label();
            SuspendLayout();
            // 
            // lstAirports
            // 
            lstAirports.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lstAirports.FormattingEnabled = true;
            lstAirports.ItemHeight = 19;
            lstAirports.Location = new Point(12, 8);
            lstAirports.Margin = new Padding(3, 2, 3, 2);
            lstAirports.Name = "lstAirports";
            lstAirports.Size = new Size(983, 80);
            lstAirports.TabIndex = 0;
            lstAirports.SelectedIndexChanged += lstAirports_SelectedIndexChanged;
            // 
            // lstAircrafts
            // 
            lstAircrafts.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lstAircrafts.FormattingEnabled = true;
            lstAircrafts.ItemHeight = 19;
            lstAircrafts.Location = new Point(12, 254);
            lstAircrafts.Margin = new Padding(3, 2, 3, 2);
            lstAircrafts.Name = "lstAircrafts";
            lstAircrafts.Size = new Size(983, 99);
            lstAircrafts.TabIndex = 1;
            // 
            // labNameAirport
            // 
            labNameAirport.AutoSize = true;
            labNameAirport.Location = new Point(18, 156);
            labNameAirport.Name = "labNameAirport";
            labNameAirport.Size = new Size(42, 15);
            labNameAirport.TabIndex = 2;
            labNameAirport.Text = "Name:";
            // 
            // btnAddAirport
            // 
            btnAddAirport.Location = new Point(34, 190);
            btnAddAirport.Margin = new Padding(3, 2, 3, 2);
            btnAddAirport.Name = "btnAddAirport";
            btnAddAirport.Size = new Size(946, 22);
            btnAddAirport.TabIndex = 3;
            btnAddAirport.Text = "Add Airport";
            btnAddAirport.UseVisualStyleBackColor = true;
            btnAddAirport.Click += btnAddAirport_Click;
            // 
            // txtNameAirport
            // 
            txtNameAirport.Location = new Point(68, 154);
            txtNameAirport.Margin = new Padding(3, 2, 3, 2);
            txtNameAirport.Name = "txtNameAirport";
            txtNameAirport.Size = new Size(106, 23);
            txtNameAirport.TabIndex = 4;
            // 
            // labPosition
            // 
            labPosition.AutoSize = true;
            labPosition.Location = new Point(199, 156);
            labPosition.Name = "labPosition";
            labPosition.Size = new Size(76, 15);
            labPosition.TabIndex = 5;
            labPosition.Text = "Position(x,y):";
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(281, 154);
            txtPosition.Margin = new Padding(3, 2, 3, 2);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(82, 23);
            txtPosition.TabIndex = 6;
            // 
            // labMinPassenger
            // 
            labMinPassenger.AutoSize = true;
            labMinPassenger.Location = new Point(398, 156);
            labMinPassenger.Name = "labMinPassenger";
            labMinPassenger.Size = new Size(84, 15);
            labMinPassenger.TabIndex = 7;
            labMinPassenger.Text = "MinPassenger:";
            // 
            // txtMinPassenger
            // 
            txtMinPassenger.Location = new Point(493, 154);
            txtMinPassenger.Margin = new Padding(3, 2, 3, 2);
            txtMinPassenger.Name = "txtMinPassenger";
            txtMinPassenger.Size = new Size(37, 23);
            txtMinPassenger.TabIndex = 8;
            // 
            // txtMaxPassenger
            // 
            txtMaxPassenger.Location = new Point(641, 154);
            txtMaxPassenger.Margin = new Padding(3, 2, 3, 2);
            txtMaxPassenger.Name = "txtMaxPassenger";
            txtMaxPassenger.Size = new Size(37, 23);
            txtMaxPassenger.TabIndex = 10;
            // 
            // labMaxPassenger
            // 
            labMaxPassenger.AutoSize = true;
            labMaxPassenger.Location = new Point(544, 156);
            labMaxPassenger.Name = "labMaxPassenger";
            labMaxPassenger.Size = new Size(86, 15);
            labMaxPassenger.TabIndex = 9;
            labMaxPassenger.Text = "MaxPassenger:";
            // 
            // txtMaxCargo
            // 
            txtMaxCargo.Location = new Point(924, 154);
            txtMaxCargo.Margin = new Padding(3, 2, 3, 2);
            txtMaxCargo.Name = "txtMaxCargo";
            txtMaxCargo.Size = new Size(37, 23);
            txtMaxCargo.TabIndex = 14;
            // 
            // labMaxCargo
            // 
            labMaxCargo.AutoSize = true;
            labMaxCargo.Location = new Point(846, 156);
            labMaxCargo.Name = "labMaxCargo";
            labMaxCargo.Size = new Size(65, 15);
            labMaxCargo.TabIndex = 13;
            labMaxCargo.Text = "MaxCargo:";
            // 
            // txtMinCargo
            // 
            txtMinCargo.Location = new Point(791, 154);
            txtMinCargo.Margin = new Padding(3, 2, 3, 2);
            txtMinCargo.Name = "txtMinCargo";
            txtMinCargo.Size = new Size(37, 23);
            txtMinCargo.TabIndex = 12;
            // 
            // labMinCargo
            // 
            labMinCargo.AutoSize = true;
            labMinCargo.Location = new Point(718, 156);
            labMinCargo.Name = "labMinCargo";
            labMinCargo.Size = new Size(63, 15);
            labMinCargo.TabIndex = 11;
            labMinCargo.Text = "MinCargo:";
            // 
            // txtNameAircraft
            // 
            txtNameAircraft.Location = new Point(60, 416);
            txtNameAircraft.Margin = new Padding(3, 2, 3, 2);
            txtNameAircraft.Name = "txtNameAircraft";
            txtNameAircraft.Size = new Size(106, 23);
            txtNameAircraft.TabIndex = 16;
            // 
            // labNameAircraft
            // 
            labNameAircraft.AutoSize = true;
            labNameAircraft.Location = new Point(10, 418);
            labNameAircraft.Name = "labNameAircraft";
            labNameAircraft.Size = new Size(42, 15);
            labNameAircraft.TabIndex = 15;
            labNameAircraft.Text = "Name:";
            // 
            // labType
            // 
            labType.AutoSize = true;
            labType.Location = new Point(187, 418);
            labType.Name = "labType";
            labType.Size = new Size(34, 15);
            labType.TabIndex = 17;
            labType.Text = "Type:";
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(230, 416);
            cmbType.Margin = new Padding(3, 2, 3, 2);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(133, 23);
            cmbType.TabIndex = 18;
            // 
            // labSpeed
            // 
            labSpeed.AutoSize = true;
            labSpeed.Location = new Point(373, 419);
            labSpeed.Name = "labSpeed";
            labSpeed.Size = new Size(110, 15);
            labSpeed.TabIndex = 19;
            labSpeed.Text = "Speed(km/second):";
            // 
            // txtSpeed
            // 
            txtSpeed.Location = new Point(498, 416);
            txtSpeed.Margin = new Padding(3, 2, 3, 2);
            txtSpeed.Name = "txtSpeed";
            txtSpeed.Size = new Size(42, 23);
            txtSpeed.TabIndex = 20;
            txtSpeed.TextChanged += txtSpeed_TextChanged_1;
            // 
            // txtBoarding
            // 
            txtBoarding.Location = new Point(613, 416);
            txtBoarding.Margin = new Padding(3, 2, 3, 2);
            txtBoarding.Name = "txtBoarding";
            txtBoarding.Size = new Size(42, 23);
            txtBoarding.TabIndex = 22;
            // 
            // labBoarding
            // 
            labBoarding.AutoSize = true;
            labBoarding.Location = new Point(544, 418);
            labBoarding.Name = "labBoarding";
            labBoarding.Size = new Size(58, 15);
            labBoarding.TabIndex = 21;
            labBoarding.Text = "Boarding:";
            // 
            // txtUnBoarding
            // 
            txtUnBoarding.Location = new Point(760, 416);
            txtUnBoarding.Margin = new Padding(3, 2, 3, 2);
            txtUnBoarding.Name = "txtUnBoarding";
            txtUnBoarding.Size = new Size(42, 23);
            txtUnBoarding.TabIndex = 24;
            // 
            // labUnboarding
            // 
            labUnboarding.AutoSize = true;
            labUnboarding.Location = new Point(668, 418);
            labUnboarding.Name = "labUnboarding";
            labUnboarding.Size = new Size(73, 15);
            labUnboarding.TabIndex = 23;
            labUnboarding.Text = "Unboarding:";
            // 
            // txtMaintenance
            // 
            txtMaintenance.Location = new Point(961, 417);
            txtMaintenance.Margin = new Padding(3, 2, 3, 2);
            txtMaintenance.Name = "txtMaintenance";
            txtMaintenance.Size = new Size(47, 23);
            txtMaintenance.TabIndex = 26;
            // 
            // labMaintenance
            // 
            labMaintenance.AutoSize = true;
            labMaintenance.Location = new Point(812, 418);
            labMaintenance.Name = "labMaintenance";
            labMaintenance.Size = new Size(126, 15);
            labMaintenance.TabIndex = 25;
            labMaintenance.Text = "Maintenance(Second):";
            labMaintenance.Click += labMaintenance_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(635, 394);
            label1.Name = "label1";
            label1.Size = new Size(181, 15);
            label1.TabIndex = 27;
            label1.Text = "(Amount of people each second)";
            // 
            // btnAddAircraft
            // 
            btnAddAircraft.Location = new Point(34, 450);
            btnAddAircraft.Margin = new Padding(3, 2, 3, 2);
            btnAddAircraft.Name = "btnAddAircraft";
            btnAddAircraft.Size = new Size(946, 22);
            btnAddAircraft.TabIndex = 28;
            btnAddAircraft.Text = "Add Aircraft";
            btnAddAircraft.UseVisualStyleBackColor = true;
            btnAddAircraft.Click += btnAddAircraft_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(199, 484);
            btnGenerate.Margin = new Padding(3, 2, 3, 2);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(618, 26);
            btnGenerate.TabIndex = 29;
            btnGenerate.Text = "Generate Senario";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // labAirPortStatus
            // 
            labAirPortStatus.AutoSize = true;
            labAirPortStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labAirPortStatus.Location = new Point(448, 224);
            labAirPortStatus.Name = "labAirPortStatus";
            labAirPortStatus.Size = new Size(70, 21);
            labAirPortStatus.TabIndex = 30;
            labAirPortStatus.Text = "               ";
            // 
            // labAirCraftStatus
            // 
            labAirCraftStatus.AutoSize = true;
            labAirCraftStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labAirCraftStatus.Location = new Point(453, 513);
            labAirCraftStatus.Name = "labAirCraftStatus";
            labAirCraftStatus.Size = new Size(70, 21);
            labAirCraftStatus.TabIndex = 31;
            labAirCraftStatus.Text = "               ";
            // 
            // GeneratorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 542);
            Controls.Add(labAirCraftStatus);
            Controls.Add(labAirPortStatus);
            Controls.Add(btnGenerate);
            Controls.Add(btnAddAircraft);
            Controls.Add(label1);
            Controls.Add(txtMaintenance);
            Controls.Add(labMaintenance);
            Controls.Add(txtUnBoarding);
            Controls.Add(labUnboarding);
            Controls.Add(txtBoarding);
            Controls.Add(labBoarding);
            Controls.Add(txtSpeed);
            Controls.Add(labSpeed);
            Controls.Add(cmbType);
            Controls.Add(labType);
            Controls.Add(txtNameAircraft);
            Controls.Add(labNameAircraft);
            Controls.Add(txtMaxCargo);
            Controls.Add(labMaxCargo);
            Controls.Add(txtMinCargo);
            Controls.Add(labMinCargo);
            Controls.Add(txtMaxPassenger);
            Controls.Add(labMaxPassenger);
            Controls.Add(txtMinPassenger);
            Controls.Add(labMinPassenger);
            Controls.Add(txtPosition);
            Controls.Add(labPosition);
            Controls.Add(txtNameAirport);
            Controls.Add(btnAddAirport);
            Controls.Add(labNameAirport);
            Controls.Add(lstAircrafts);
            Controls.Add(lstAirports);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GeneratorForm";
            Text = "Generator";
            Load += GeneratorForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstAirports;
        private ListBox lstAircrafts;
        private Label labNameAirport;
        private Button btnAddAirport;
        private TextBox txtNameAirport;
        private Label labPosition;
        private TextBox txtPosition;
        private Label labMinPassenger;
        private TextBox txtMinPassenger;
        private TextBox txtMaxPassenger;
        private Label labMaxPassenger;
        private TextBox txtMaxCargo;
        private Label labMaxCargo;
        private TextBox txtMinCargo;
        private Label labMinCargo;
        private TextBox txtNameAircraft;
        private Label labNameAircraft;
        private Label labType;
        private ComboBox cmbType;
        private Label labSpeed;
        private TextBox txtSpeed;
        private TextBox txtBoarding;
        private Label labBoarding;
        private TextBox txtUnBoarding;
        private Label labUnboarding;
        private TextBox txtMaintenance;
        private Label labMaintenance;
        private Label label1;
        private Button btnAddAircraft;
        private Button btnGenerate;
        private Label labAirPortStatus;
        private Label labAirCraftStatus;
    }
}