namespace AutodjaOmanikud
{
    partial class Autoteenindus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Autoteenindus));
            tabPage3 = new TabPage();
            label13 = new Label();
            cbtime = new DateTimePicker();
            label11 = new Label();
            cbauto = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            btnClearService = new Button();
            btnDeleteService = new Button();
            btnUpdateService = new Button();
            btnAddService = new Button();
            txtServicePrice = new TextBox();
            txtServiceName = new TextBox();
            dgvServices = new DataGridView();
            tabPage2 = new TabPage();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnClearCar = new Button();
            btnDeleteCar = new Button();
            btnUpdateCar = new Button();
            btnAddCar = new Button();
            cmbCarOwner = new ComboBox();
            txtCarRegNumber = new TextBox();
            txtCarModel = new TextBox();
            txtCarBrand = new TextBox();
            dgvCars = new DataGridView();
            tabPage1 = new TabPage();
            Telefoninumber = new Label();
            label1 = new Label();
            txtOwnerPhone = new TextBox();
            txtOwnerFullName = new TextBox();
            dgvOwners = new DataGridView();
            btnClearOwner = new Button();
            btnDeleteOwner = new Button();
            btnUpdateOwner = new Button();
            btnAddOwner = new Button();
            tabControl1 = new TabControl();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOwners).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.LavenderBlush;
            tabPage3.Controls.Add(label13);
            tabPage3.Controls.Add(cbtime);
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(cbauto);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(btnClearService);
            tabPage3.Controls.Add(btnDeleteService);
            tabPage3.Controls.Add(btnUpdateService);
            tabPage3.Controls.Add(btnAddService);
            tabPage3.Controls.Add(txtServicePrice);
            tabPage3.Controls.Add(txtServiceName);
            tabPage3.Controls.Add(dgvServices);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(705, 398);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Service";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(307, 138);
            label13.Name = "label13";
            label13.Size = new Size(107, 15);
            label13.TabIndex = 13;
            label13.Text = "Töö lõppemise aeg";
            // 
            // cbtime
            // 
            cbtime.Location = new Point(418, 132);
            cbtime.Name = "cbtime";
            cbtime.Size = new Size(121, 23);
            cbtime.TabIndex = 11;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(379, 106);
            label11.Name = "label11";
            label11.Size = new Size(33, 15);
            label11.TabIndex = 10;
            label11.Text = "Auto";
            // 
            // cbauto
            // 
            cbauto.BackColor = Color.WhiteSmoke;
            cbauto.FormattingEnabled = true;
            cbauto.Location = new Point(418, 103);
            cbauto.Name = "cbauto";
            cbauto.Size = new Size(121, 23);
            cbauto.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(362, 80);
            label7.Name = "label7";
            label7.Size = new Size(71, 15);
            label7.TabIndex = 8;
            label7.Text = "Service hind";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(348, 53);
            label6.Name = "label6";
            label6.Size = new Size(85, 15);
            label6.TabIndex = 7;
            label6.Text = "Service pealkiri";
            // 
            // btnClearService
            // 
            btnClearService.Location = new Point(6, 138);
            btnClearService.Name = "btnClearService";
            btnClearService.Size = new Size(105, 30);
            btnClearService.TabIndex = 6;
            btnClearService.Text = "Clear service";
            btnClearService.UseVisualStyleBackColor = true;
            btnClearService.Click += btnClearService_Click;
            // 
            // btnDeleteService
            // 
            btnDeleteService.Location = new Point(3, 109);
            btnDeleteService.Name = "btnDeleteService";
            btnDeleteService.Size = new Size(105, 23);
            btnDeleteService.TabIndex = 5;
            btnDeleteService.Text = "Kustuta service";
            btnDeleteService.UseVisualStyleBackColor = true;
            btnDeleteService.Click += btnDeleteService_Click;
            // 
            // btnUpdateService
            // 
            btnUpdateService.Location = new Point(6, 80);
            btnUpdateService.Name = "btnUpdateService";
            btnUpdateService.Size = new Size(105, 23);
            btnUpdateService.TabIndex = 4;
            btnUpdateService.Text = "Uuenda service";
            btnUpdateService.UseVisualStyleBackColor = true;
            btnUpdateService.Click += btnUpdateService_Click;
            // 
            // btnAddService
            // 
            btnAddService.Location = new Point(6, 51);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new Size(105, 23);
            btnAddService.TabIndex = 3;
            btnAddService.Text = "Lisa service";
            btnAddService.UseVisualStyleBackColor = true;
            btnAddService.Click += btnAddService_Click;
            // 
            // txtServicePrice
            // 
            txtServicePrice.BackColor = Color.WhiteSmoke;
            txtServicePrice.Location = new Point(439, 74);
            txtServicePrice.Name = "txtServicePrice";
            txtServicePrice.Size = new Size(100, 23);
            txtServicePrice.TabIndex = 2;
            // 
            // txtServiceName
            // 
            txtServiceName.BackColor = Color.WhiteSmoke;
            txtServiceName.Location = new Point(439, 45);
            txtServiceName.Name = "txtServiceName";
            txtServiceName.Size = new Size(100, 23);
            txtServiceName.TabIndex = 1;
            // 
            // dgvServices
            // 
            dgvServices.BackgroundColor = Color.Snow;
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.Location = new Point(6, 174);
            dgvServices.Name = "dgvServices";
            dgvServices.Size = new Size(589, 218);
            dgvServices.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.LavenderBlush;
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(btnClearCar);
            tabPage2.Controls.Add(btnDeleteCar);
            tabPage2.Controls.Add(btnUpdateCar);
            tabPage2.Controls.Add(btnAddCar);
            tabPage2.Controls.Add(cmbCarOwner);
            tabPage2.Controls.Add(txtCarRegNumber);
            tabPage2.Controls.Add(txtCarModel);
            tabPage2.Controls.Add(txtCarBrand);
            tabPage2.Controls.Add(dgvCars);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(705, 398);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Auto";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(336, 122);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 12;
            label5.Text = "Auto omanik";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(310, 96);
            label4.Name = "label4";
            label4.Size = new Size(123, 15);
            label4.TabIndex = 11;
            label4.Text = "Registreerimisnumber";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(356, 68);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 10;
            label3.Text = "Auto mudel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(356, 39);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 9;
            label2.Text = "Auto mark";
            // 
            // btnClearCar
            // 
            btnClearCar.Location = new Point(6, 117);
            btnClearCar.Name = "btnClearCar";
            btnClearCar.Size = new Size(93, 24);
            btnClearCar.TabIndex = 8;
            btnClearCar.Text = "Clear auto";
            btnClearCar.UseVisualStyleBackColor = true;
            btnClearCar.Click += btnClearCar_Click;
            // 
            // btnDeleteCar
            // 
            btnDeleteCar.Location = new Point(6, 88);
            btnDeleteCar.Name = "btnDeleteCar";
            btnDeleteCar.Size = new Size(93, 23);
            btnDeleteCar.TabIndex = 7;
            btnDeleteCar.Text = "Kustuta auto";
            btnDeleteCar.UseVisualStyleBackColor = true;
            btnDeleteCar.Click += btnDeleteCar_Click;
            // 
            // btnUpdateCar
            // 
            btnUpdateCar.Location = new Point(6, 59);
            btnUpdateCar.Name = "btnUpdateCar";
            btnUpdateCar.Size = new Size(93, 24);
            btnUpdateCar.TabIndex = 6;
            btnUpdateCar.Text = "Uuenda auto";
            btnUpdateCar.UseVisualStyleBackColor = true;
            btnUpdateCar.Click += btnUpdateCar_Click;
            // 
            // btnAddCar
            // 
            btnAddCar.Location = new Point(6, 30);
            btnAddCar.Name = "btnAddCar";
            btnAddCar.Size = new Size(93, 24);
            btnAddCar.TabIndex = 5;
            btnAddCar.Text = "Lisa auto";
            btnAddCar.UseVisualStyleBackColor = true;
            btnAddCar.Click += btnAddCar_Click;
            // 
            // cmbCarOwner
            // 
            cmbCarOwner.BackColor = Color.WhiteSmoke;
            cmbCarOwner.FormattingEnabled = true;
            cmbCarOwner.Location = new Point(418, 118);
            cmbCarOwner.Name = "cmbCarOwner";
            cmbCarOwner.Size = new Size(121, 23);
            cmbCarOwner.TabIndex = 4;
            // 
            // txtCarRegNumber
            // 
            txtCarRegNumber.BackColor = Color.WhiteSmoke;
            txtCarRegNumber.Location = new Point(439, 89);
            txtCarRegNumber.Name = "txtCarRegNumber";
            txtCarRegNumber.Size = new Size(100, 23);
            txtCarRegNumber.TabIndex = 3;
            // 
            // txtCarModel
            // 
            txtCarModel.BackColor = Color.WhiteSmoke;
            txtCarModel.Location = new Point(439, 60);
            txtCarModel.Name = "txtCarModel";
            txtCarModel.Size = new Size(100, 23);
            txtCarModel.TabIndex = 2;
            // 
            // txtCarBrand
            // 
            txtCarBrand.BackColor = Color.WhiteSmoke;
            txtCarBrand.Location = new Point(439, 31);
            txtCarBrand.Name = "txtCarBrand";
            txtCarBrand.Size = new Size(100, 23);
            txtCarBrand.TabIndex = 1;
            // 
            // dgvCars
            // 
            dgvCars.BackgroundColor = Color.Snow;
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Location = new Point(6, 158);
            dgvCars.Name = "dgvCars";
            dgvCars.Size = new Size(548, 234);
            dgvCars.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.LavenderBlush;
            tabPage1.Controls.Add(Telefoninumber);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(txtOwnerPhone);
            tabPage1.Controls.Add(txtOwnerFullName);
            tabPage1.Controls.Add(dgvOwners);
            tabPage1.Controls.Add(btnClearOwner);
            tabPage1.Controls.Add(btnDeleteOwner);
            tabPage1.Controls.Add(btnUpdateOwner);
            tabPage1.Controls.Add(btnAddOwner);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(705, 398);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Omanik";
            // 
            // Telefoninumber
            // 
            Telefoninumber.AutoSize = true;
            Telefoninumber.Location = new Point(342, 83);
            Telefoninumber.Name = "Telefoninumber";
            Telefoninumber.Size = new Size(91, 15);
            Telefoninumber.TabIndex = 8;
            Telefoninumber.Text = "Telefoninumber";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(388, 55);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 7;
            label1.Text = "Nimi";
            // 
            // txtOwnerPhone
            // 
            txtOwnerPhone.BackColor = Color.WhiteSmoke;
            txtOwnerPhone.Location = new Point(439, 75);
            txtOwnerPhone.Name = "txtOwnerPhone";
            txtOwnerPhone.Size = new Size(100, 23);
            txtOwnerPhone.TabIndex = 6;
            // 
            // txtOwnerFullName
            // 
            txtOwnerFullName.BackColor = Color.WhiteSmoke;
            txtOwnerFullName.Location = new Point(439, 47);
            txtOwnerFullName.Name = "txtOwnerFullName";
            txtOwnerFullName.Size = new Size(100, 23);
            txtOwnerFullName.TabIndex = 5;
            // 
            // dgvOwners
            // 
            dgvOwners.BackgroundColor = Color.Snow;
            dgvOwners.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOwners.Location = new Point(6, 162);
            dgvOwners.Name = "dgvOwners";
            dgvOwners.Size = new Size(561, 230);
            dgvOwners.TabIndex = 4;
            // 
            // btnClearOwner
            // 
            btnClearOwner.Location = new Point(6, 133);
            btnClearOwner.Name = "btnClearOwner";
            btnClearOwner.Size = new Size(101, 23);
            btnClearOwner.TabIndex = 3;
            btnClearOwner.Text = "Clear omanik";
            btnClearOwner.UseVisualStyleBackColor = true;
            btnClearOwner.Click += btnClearOwner_Click;
            // 
            // btnDeleteOwner
            // 
            btnDeleteOwner.Location = new Point(6, 104);
            btnDeleteOwner.Name = "btnDeleteOwner";
            btnDeleteOwner.Size = new Size(101, 23);
            btnDeleteOwner.TabIndex = 2;
            btnDeleteOwner.Text = "Kustuta omanik";
            btnDeleteOwner.UseVisualStyleBackColor = true;
            btnDeleteOwner.Click += btnDeleteOwner_Click;
            // 
            // btnUpdateOwner
            // 
            btnUpdateOwner.Location = new Point(6, 75);
            btnUpdateOwner.Name = "btnUpdateOwner";
            btnUpdateOwner.Size = new Size(101, 23);
            btnUpdateOwner.TabIndex = 1;
            btnUpdateOwner.Text = "Uuenda omanik";
            btnUpdateOwner.UseVisualStyleBackColor = true;
            btnUpdateOwner.Click += btnUpdateOwner_Click;
            // 
            // btnAddOwner
            // 
            btnAddOwner.Location = new Point(6, 46);
            btnAddOwner.Name = "btnAddOwner";
            btnAddOwner.Size = new Size(101, 23);
            btnAddOwner.TabIndex = 0;
            btnAddOwner.Text = "Lisa omanik";
            btnAddOwner.UseVisualStyleBackColor = true;
            btnAddOwner.Click += btnAddOwner_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(713, 426);
            tabControl1.TabIndex = 0;
            // 
            // Autoteenindus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Autoteenindus";
            Text = "Autoteenindus";
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCars).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOwners).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabPage tabPage3;
        private Label label11;
        private ComboBox cbauto;
        private Label label7;
        private Label label6;
        private Button btnClearService;
        private Button btnDeleteService;
        private Button btnUpdateService;
        private Button btnAddService;
        private TextBox txtServicePrice;
        private TextBox txtServiceName;
        private DataGridView dgvServices;
        private TabPage tabPage2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnClearCar;
        private Button btnDeleteCar;
        private Button btnUpdateCar;
        private Button btnAddCar;
        private ComboBox cmbCarOwner;
        private TextBox txtCarRegNumber;
        private TextBox txtCarModel;
        private TextBox txtCarBrand;
        private DataGridView dgvCars;
        private TabPage tabPage1;
        private Label Telefoninumber;
        private Label label1;
        private TextBox txtOwnerPhone;
        private TextBox txtOwnerFullName;
        private DataGridView dgvOwners;
        private Button btnClearOwner;
        private Button btnDeleteOwner;
        private Button btnUpdateOwner;
        private Button btnAddOwner;
        private TabControl tabControl1;
        private Label label13;
        private DateTimePicker cbtime;
    }
}
