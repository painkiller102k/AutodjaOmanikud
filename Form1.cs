using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.ComponentModel;

namespace AutodjaOmanikud
{
    public partial class Autoteenindus : Form
    {
        bool _keelLaetud = false;
        public Autoteenindus()
        {
            InitializeComponent();

            this.Load += Autoteenindus_Load;
            LoadOwners();
            LoadCars();
            LoadServiceTypes();
            LoadServiceOwners();
            LoadServices();

            dgvOwners.CellClick += DgvOwners_CellClick;
            dgvCars.CellClick += DgvCars_CellClick;
            dgvServiceTypes.CellClick += DgvServiceTypes_CellClick;
            dgvServices.CellClick += DgvServices_CellClick;

            cmbServiceOwner.SelectedIndexChanged += CmbServiceOwner_SelectedIndexChanged;
            searchtextbox.TextChanged += (s, e) => LoadServices(searchtextbox.Text);

            comboLanguage.SelectedIndexChanged += comboLanguage_SelectedIndexChanged;
        }

        private void LoadOwners()
        {
            using var context = new AutoDbContext();
            dgvOwners.DataSource = context.Owners
                .Include(o => o.Cars)
                .Select(o => new
                {
                    o.Id,
                    o.FullName,
                    o.Phone,
                    Cars = string.Join(", ", o.Cars.Select(c => $"{c.Brand} {c.Model}"))
                }).ToList();
        }


        private void Autoteenindus_Load(object sender, EventArgs e)
        {
            _keelLaetud = false;

            comboLanguage.Items.Clear();
            comboLanguage.Items.Add("Eesti");
            comboLanguage.Items.Add("English");

            string lang = Properties.Settings.Default.UserLanguage;
            if (lang == "en-US")
                comboLanguage.SelectedItem = "English";
            else
                comboLanguage.SelectedItem = "Eesti";

            _keelLaetud = true;
        }



        private void ApplyResourcesToControl(Control ctrl, ComponentResourceManager res)
        {
            res.ApplyResources(ctrl, ctrl.Name);

            foreach (Control child in ctrl.Controls)
            {
                ApplyResourcesToControl(child, res);
            }
        }

        private void ChangeLanguage(string lang)
        {
            // Сохраняем выбранный язык в Settings
            Properties.Settings.Default.UserLanguage = lang;
            Properties.Settings.Default.Save();

            // Меняем текущую культуру
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);

            // Применяем ресурсы к форме и всем контролам
            var res = new ComponentResourceManager(typeof(Autoteenindus));
            ApplyResourcesToControl(this, res);
            res.ApplyResources(this, "$this"); // заголовок формы
        }

        private void comboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_keelLaetud)
                return;

            if (comboLanguage.SelectedItem.ToString() == "English")
                ChangeLanguage("en-US");
            else
                ChangeLanguage("et-EE");
        }



        private void ClearOwnerFields()
        {
            txtOwnerFullName.Clear();
            txtOwnerPhone.Clear();
        }

        private void DgvOwners_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOwners.CurrentRow == null) return;
            txtOwnerFullName.Text = dgvOwners.CurrentRow.Cells["FullName"].Value.ToString();
            txtOwnerPhone.Text = dgvOwners.CurrentRow.Cells["Phone"].Value.ToString();
        }

        private void btnAddOwner_Click(object sender, EventArgs e)
        {
            string fullName = txtOwnerFullName.Text.Trim();
            if (string.IsNullOrEmpty(fullName)) return;

            using var context = new AutoDbContext();
            context.Owners.Add(new Owner { FullName = fullName, Phone = txtOwnerPhone.Text.Trim() });
            context.SaveChanges();

            ClearOwnerFields();
            LoadOwners(); LoadCars(); LoadServiceOwners();
        }

        private void btnUpdateOwner_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow == null) return;

            using var context = new AutoDbContext();
            int id = (int)dgvOwners.CurrentRow.Cells["Id"].Value;
            var o = context.Owners.Find(id);
            if (o != null)
            {
                o.FullName = txtOwnerFullName.Text.Trim();
                o.Phone = txtOwnerPhone.Text.Trim();
                context.SaveChanges();
            }

            ClearOwnerFields();
            LoadOwners(); LoadCars(); LoadServiceOwners();
        }

        private void btnDeleteOwner_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow == null) return;

            using var context = new AutoDbContext();
            int id = (int)dgvOwners.CurrentRow.Cells["Id"].Value;
            var o = context.Owners.Include(a => a.Cars).First(x => x.Id == id);

            context.Cars.RemoveRange(o.Cars);
            context.Owners.Remove(o);
            context.SaveChanges();

            ClearOwnerFields();
            LoadOwners(); LoadCars(); LoadServiceOwners();
        }

        private void btnClearOwner_Click(object sender, EventArgs e) => ClearOwnerFields();

        // =================== Cars ===================
        private void LoadCars()
        {
            using var context = new AutoDbContext();
            dgvCars.DataSource = context.Cars.Include(c => c.Owner)
                .Select(c => new
                {
                    c.Id,
                    c.Brand,
                    c.Model,
                    c.RegistrationNumber,
                    Owner = c.Owner.FullName
                }).ToList();

            cmbCarOwner.DataSource = context.Owners.ToList();
            cmbCarOwner.DisplayMember = "FullName";
            cmbCarOwner.ValueMember = "Id";
            cmbCarOwner.SelectedIndex = -1;
        }

        private void ClearCarFields()
        {
            txtCarBrand.Clear();
            txtCarModel.Clear();
            txtCarRegNumber.Clear();
            cmbCarOwner.SelectedIndex = -1;
        }

        private void DgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;

            txtCarBrand.Text = dgvCars.CurrentRow.Cells["Brand"].Value.ToString();
            txtCarModel.Text = dgvCars.CurrentRow.Cells["Model"].Value.ToString();
            txtCarRegNumber.Text = dgvCars.CurrentRow.Cells["RegistrationNumber"].Value.ToString();
            cmbCarOwner.SelectedIndex = cmbCarOwner.FindStringExact(dgvCars.CurrentRow.Cells["Owner"].Value.ToString());
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            if (cmbCarOwner.SelectedValue == null) return;

            using var context = new AutoDbContext();
            context.Cars.Add(new Car
            {
                Brand = txtCarBrand.Text.Trim(),
                Model = txtCarModel.Text.Trim(),
                RegistrationNumber = txtCarRegNumber.Text.Trim(),
                OwnerId = (int)cmbCarOwner.SelectedValue
            });
            context.SaveChanges();

            ClearCarFields();
            LoadCars(); LoadOwners(); LoadServiceOwners();
        }

        private void btnUpdateCar_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;

            using var context = new AutoDbContext();
            int id = (int)dgvCars.CurrentRow.Cells["Id"].Value;
            var c = context.Cars.Find(id);
            if (c != null)
            {
                c.Brand = txtCarBrand.Text.Trim();
                c.Model = txtCarModel.Text.Trim();
                c.RegistrationNumber = txtCarRegNumber.Text.Trim();
                c.OwnerId = (int)cmbCarOwner.SelectedValue;
                context.SaveChanges();
            }

            ClearCarFields();
            LoadCars(); LoadOwners(); LoadServiceOwners();
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;

            using var context = new AutoDbContext();
            var c = context.Cars.Find((int)dgvCars.CurrentRow.Cells["Id"].Value);
            if (c != null)
            {
                context.Cars.Remove(c);
                context.SaveChanges();
            }

            ClearCarFields();
            LoadCars(); LoadOwners(); LoadServiceOwners();
        }

        private void btnClearCar_Click(object sender, EventArgs e) => ClearCarFields();

        // =================== Service Types ===================
        private void LoadServiceTypes()
        {
            using var context = new AutoDbContext();
            var types = context.ServiceTypes.ToList();
            dgvServiceTypes.DataSource = types;

            cbteenus.DataSource = types;
            cbteenus.DisplayMember = "Name";
            cbteenus.ValueMember = "Id";
            cbteenus.SelectedIndex = -1;
        }

        private void ClearSTypeFields()
        {
            txtSTypeName.Clear();
            txtSTypePrice.Clear();
        }

        private void DgvServiceTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServiceTypes.CurrentRow == null) return;

            txtSTypeName.Text = dgvServiceTypes.CurrentRow.Cells["Name"].Value.ToString();
            txtSTypePrice.Text = dgvServiceTypes.CurrentRow.Cells["Price"].Value.ToString();
        }

        private void btnAddSType_Click(object sender, EventArgs e)
        {
            using var context = new AutoDbContext();
            context.ServiceTypes.Add(new ServiceType
            {
                Name = txtSTypeName.Text.Trim(),
                Price = decimal.Parse(txtSTypePrice.Text)
            });
            context.SaveChanges();

            ClearSTypeFields();
            LoadServiceTypes();
        }

        private void btnUpdateSType_Click(object sender, EventArgs e)
        {
            if (dgvServiceTypes.CurrentRow == null) return;

            using var context = new AutoDbContext();
            int id = (int)dgvServiceTypes.CurrentRow.Cells["Id"].Value;
            var t = context.ServiceTypes.Find(id);
            if (t != null)
            {
                t.Name = txtSTypeName.Text.Trim();
                t.Price = decimal.Parse(txtSTypePrice.Text);
                context.SaveChanges();
            }

            ClearSTypeFields();
            LoadServiceTypes();
        }

        private void btnDeleteSType_Click(object sender, EventArgs e)
        {
            if (dgvServiceTypes.CurrentRow == null) return;

            using var context = new AutoDbContext();
            var t = context.ServiceTypes.Find((int)dgvServiceTypes.CurrentRow.Cells["Id"].Value);
            if (t != null)
            {
                context.ServiceTypes.Remove(t);
                context.SaveChanges();
            }

            ClearSTypeFields();
            LoadServiceTypes();
        }

        private void btnClearSType_Click(object sender, EventArgs e) => ClearSTypeFields();

        // =================== Services ===================
        private void LoadServiceOwners()
        {
            using var context = new AutoDbContext();
            cmbServiceOwner.DataSource = context.Owners.ToList();
            cmbServiceOwner.DisplayMember = "FullName";
            cmbServiceOwner.ValueMember = "Id";
            cmbServiceOwner.SelectedIndex = -1;
        }

        private void CmbServiceOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServiceOwner.SelectedValue == null) return;

            using var context = new AutoDbContext();
            int ownerId = (int)cmbServiceOwner.SelectedValue;

            cbauto.DataSource = context.Cars
                .Where(c => c.OwnerId == ownerId)
                .Select(c => new { c.Id, DisplayName = $"{c.Brand} {c.Model} ({c.RegistrationNumber})" })
                .ToList();

            cbauto.DisplayMember = "DisplayName";
            cbauto.ValueMember = "Id";
            cbauto.SelectedIndex = -1;
        }

        private void LoadServices(string search = "")
        {
            using var context = new AutoDbContext();
            var q = context.Services.Include(s => s.Car).ThenInclude(c => c.Owner)
                                    .Include(s => s.ServiceType)
                                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                q = q.Where(s => s.ServiceType.Name.Contains(search) ||
                                 s.Car.Brand.Contains(search) ||
                                 s.Car.Model.Contains(search) ||
                                 s.Car.Owner.FullName.Contains(search));

            dgvServices.DataSource = q
                .Select(s => new
                {
                    s.Id,
                    Owner = s.Car.Owner.FullName,
                    Car = $"{s.Car.Brand} {s.Car.Model} ({s.Car.RegistrationNumber})",
                    Service = s.ServiceType.Name,
                    Price = s.ServiceType.Price,
                    Finish = s.Time.ToString("HH:mm dd.MM.yyyy"),
                    s.CarId,
                    s.ServiceTypeId
                }).ToList();
        }

        private void ClearServiceFields()
        {
            cmbServiceOwner.SelectedIndex = -1;
            cbauto.SelectedIndex = -1;
            cbteenus.SelectedIndex = -1;
            datetimepickertime.Value = DateTime.Now;
        }

        private void DgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServices.CurrentRow == null) return;

            using var context = new AutoDbContext();
            int carId = (int)dgvServices.CurrentRow.Cells["CarId"].Value;
            int typeId = (int)dgvServices.CurrentRow.Cells["ServiceTypeId"].Value;

            var car = context.Cars.Include(c => c.Owner).First(x => x.Id == carId);

            cmbServiceOwner.SelectedValue = car.OwnerId;
            cbauto.SelectedValue = carId;
            cbteenus.SelectedValue = typeId;

            DateTime.TryParse(dgvServices.CurrentRow.Cells["Finish"].Value.ToString(), out DateTime dt);
            datetimepickertime.Value = dt;
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (cbauto.SelectedValue == null || cbteenus.SelectedValue == null) return;

            using var context = new AutoDbContext();
            context.Services.Add(new Service
            {
                CarId = (int)cbauto.SelectedValue,
                ServiceTypeId = (int)cbteenus.SelectedValue,
                Time = datetimepickertime.Value
            });
            context.SaveChanges();

            ClearServiceFields();
            LoadServices();
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (dgvServices.CurrentRow == null) return;

            using var context = new AutoDbContext();
            var s = context.Services.Find((int)dgvServices.CurrentRow.Cells["Id"].Value);
            if (s != null)
            {
                context.Services.Remove(s);
                context.SaveChanges();
            }

            ClearServiceFields();
            LoadServices();
        }

        private void btnClearService_Click(object sender, EventArgs e) => ClearServiceFields();

    }
}
