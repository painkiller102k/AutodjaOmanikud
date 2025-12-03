using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace AutodjaOmanikud
{
    public partial class Autoteenindus : Form
    {
        public Autoteenindus()
        {
            InitializeComponent();

            // Загружаем данные при старте
            LoadOwners();
            LoadCars();
            LoadServices();
            LoadServiceComboboxes();

            // Обработчики кликов по таблицам
            dgvOwners.CellClick += DgvOwners_CellClick;
            dgvCars.CellClick += DgvCars_CellClick;
            dgvServices.CellClick += DgvServices_CellClick;
            searchtextbox.TextChanged += (s, e) => LoadServices(searchtextbox.Text);

        }

        // =================== Owners ===================
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
                    Cars = string.Join(", ", o.Cars.Select(c => c.Brand))
                }).ToList();
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
            using var context = new AutoDbContext();
            context.Owners.Add(new Owner
            {
                FullName = txtOwnerFullName.Text,
                Phone = txtOwnerPhone.Text
            });
            context.SaveChanges();
            ClearOwnerFields();
            LoadOwners();
            LoadCars();
        }

        private void btnUpdateOwner_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow == null) return;
            int ownerId = Convert.ToInt32(dgvOwners.CurrentRow.Cells["Id"].Value);
            using var context = new AutoDbContext();
            var owner = context.Owners.Find(ownerId);
            if (owner != null)
            {
                owner.FullName = txtOwnerFullName.Text;
                owner.Phone = txtOwnerPhone.Text;
                context.SaveChanges();
            }
            ClearOwnerFields();
            LoadOwners();
            LoadCars();
        }

        private void btnDeleteOwner_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow == null) return;
            int ownerId = Convert.ToInt32(dgvOwners.CurrentRow.Cells["Id"].Value);
            using var context = new AutoDbContext();
            var owner = context.Owners.Include(o => o.Cars).FirstOrDefault(o => o.Id == ownerId);
            if (owner != null)
            {
                if (owner.Cars.Any())
                    context.Cars.RemoveRange(owner.Cars);
                context.Owners.Remove(owner);
                context.SaveChanges();
            }
            ClearOwnerFields();
            LoadOwners();
            LoadCars();
        }

        private void btnClearOwner_Click(object sender, EventArgs e)
        {
            ClearOwnerFields();
        }

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
            string ownerName = dgvCars.CurrentRow.Cells["Owner"].Value.ToString();
            cmbCarOwner.SelectedIndex = cmbCarOwner.FindStringExact(ownerName);
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            if (cmbCarOwner.SelectedValue == null) return;
            using var context = new AutoDbContext();
            context.Cars.Add(new Car
            {
                Brand = txtCarBrand.Text,
                Model = txtCarModel.Text,
                RegistrationNumber = txtCarRegNumber.Text,
                OwnerId = (int)cmbCarOwner.SelectedValue
            });
            context.SaveChanges();
            ClearCarFields();
            LoadCars();
            LoadOwners();
            LoadServiceComboboxes();

        }

        private void btnUpdateCar_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null || cmbCarOwner.SelectedValue == null) return;
            int carId = Convert.ToInt32(dgvCars.CurrentRow.Cells["Id"].Value);
            using var context = new AutoDbContext();
            var car = context.Cars.Find(carId);
            if (car != null)
            {
                car.Brand = txtCarBrand.Text;
                car.Model = txtCarModel.Text;
                car.RegistrationNumber = txtCarRegNumber.Text;
                car.OwnerId = (int)cmbCarOwner.SelectedValue;
                context.SaveChanges();
            }
            ClearCarFields();
            LoadCars();
            LoadOwners();
            LoadServiceComboboxes();
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;
            int carId = Convert.ToInt32(dgvCars.CurrentRow.Cells["Id"].Value);
            using var context = new AutoDbContext();
            var car = context.Cars.Find(carId);
            if (car != null)
            {
                context.Cars.Remove(car);
                context.SaveChanges();
            }
            ClearCarFields();
            LoadCars();
            LoadOwners();
            LoadServiceComboboxes();
        }

        private void btnClearCar_Click(object sender, EventArgs e)
        {
            ClearCarFields();
        }

        // =================== Services ===================
        private void LoadServiceComboboxes()
        {
            using var context = new AutoDbContext();
            cbauto.DataSource = context.Cars.ToList();
            cbauto.DisplayMember = "Brand"; // Можно добавить модель через $"{Brand} {Model}"
            cbauto.ValueMember = "Id";

            datetimepickertime.Format = DateTimePickerFormat.Custom;
            datetimepickertime.CustomFormat = "HH:mm dd.MM.yyyy";
            datetimepickertime.ShowUpDown = true;
        }

        private void LoadServices(string search = "")
        {
            using (var context = new AutoDbContext())
            {
                var query = context.Services
                    .Include(s => s.Car)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.ToLower();
                    query = query.Where(s =>
                        s.Car.Brand.ToLower().Contains(search) ||
                        s.Car.Model.ToLower().Contains(search) ||
                        s.Name.ToLower().Contains(search)
                    );
                }

                dgvServices.DataSource = query
                    .Select(s => new
                    {
                        s.Id,
                        s.Name,
                        s.Price,
                        Car = s.Car.Brand + " " + s.Car.Model,
                        FinishTime = s.Time.ToString("HH:mm dd.MM.yyyy")
                    })
                    .ToList();
            }
        }


        private void ClearServiceFields()
        {
            txtServiceName.Clear();
            txtServicePrice.Clear();
            cbauto.SelectedIndex = -1;
            datetimepickertime.Value = DateTime.Now;
        }

        private void DgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServices.CurrentRow == null) return;
            txtServiceName.Text = dgvServices.CurrentRow.Cells["Name"].Value.ToString();
            txtServicePrice.Text = dgvServices.CurrentRow.Cells["Price"].Value.ToString();

            string carName = dgvServices.CurrentRow.Cells["Car"].Value.ToString();
            cbauto.SelectedIndex = cbauto.FindStringExact(carName.Split(' ')[0]);

            if (DateTime.TryParse(dgvServices.CurrentRow.Cells["FinishTime"].Value.ToString(), out DateTime dt))
                datetimepickertime.Value = dt;
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (cbauto.SelectedValue == null) return;
            using var context = new AutoDbContext();
            context.Services.Add(new Service
            {
                Name = txtServiceName.Text,
                Price = decimal.Parse(txtServicePrice.Text),
                CarId = (int)cbauto.SelectedValue,
                Time = datetimepickertime.Value
            });
            context.SaveChanges();
            ClearServiceFields();
            LoadServices();
        }

        private void btnUpdateService_Click(object sender, EventArgs e)
        {
            if (dgvServices.CurrentRow == null || cbauto.SelectedValue == null) return;
            int serviceId = Convert.ToInt32(dgvServices.CurrentRow.Cells["Id"].Value);
            using var context = new AutoDbContext();
            var service = context.Services.Find(serviceId);
            if (service != null)
            {
                service.Name = txtServiceName.Text;
                service.Price = decimal.Parse(txtServicePrice.Text);
                service.CarId = (int)cbauto.SelectedValue;
                service.Time = datetimepickertime.Value;
                context.SaveChanges();
            }
            ClearServiceFields();
            LoadServices();
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (dgvServices.CurrentRow == null) return;
            int serviceId = Convert.ToInt32(dgvServices.CurrentRow.Cells["Id"].Value);
            using var context = new AutoDbContext();
            var service = context.Services.Find(serviceId);
            if (service != null)
            {
                context.Services.Remove(service);
                context.SaveChanges();
            }
            ClearServiceFields();
            LoadServices();
        }

        private void btnClearService_Click(object sender, EventArgs e)
        {
            ClearServiceFields();
        }

    }
}
