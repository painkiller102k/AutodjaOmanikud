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

            LoadOwners();
            LoadCars();
            LoadServiceOwners();
            LoadServices();

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
                    Cars = string.Join(", ", o.Cars.Select(c => c.Brand + " " + c.Model))
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
            string fullName = txtOwnerFullName.Text.Trim();
            string phone = txtOwnerPhone.Text.Trim();
            if (string.IsNullOrEmpty(fullName)) return;

            using var context = new AutoDbContext();

            // Проверяем, есть ли уже владелец с таким именем
            var existingOwner = context.Owners.FirstOrDefault(o => o.FullName == fullName);

            if (existingOwner == null)
            {
                context.Owners.Add(new Owner
                {
                    FullName = fullName,
                    Phone = phone
                });
            }
            else
            {
                existingOwner.Phone = phone; // Обновляем телефон
            }

            context.SaveChanges();
            ClearOwnerFields();
            LoadOwners();
            LoadCars();
            LoadServiceOwners();
        }

        private void btnUpdateOwner_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow == null) return;
            int ownerId = Convert.ToInt32(dgvOwners.CurrentRow.Cells["Id"].Value);
            using var context = new AutoDbContext();
            var owner = context.Owners.Find(ownerId);
            if (owner != null)
            {
                owner.FullName = txtOwnerFullName.Text.Trim();
                owner.Phone = txtOwnerPhone.Text.Trim();
                context.SaveChanges();
            }
            ClearOwnerFields();
            LoadOwners();
            LoadCars();
            LoadServiceOwners();
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
            LoadServiceOwners();
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
                Brand = txtCarBrand.Text.Trim(),
                Model = txtCarModel.Text.Trim(),
                RegistrationNumber = txtCarRegNumber.Text.Trim(),
                OwnerId = (int)cmbCarOwner.SelectedValue
            });
            context.SaveChanges();
            ClearCarFields();
            LoadCars();
            LoadOwners();
            LoadServiceOwners();
        }

        private void btnUpdateCar_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null || cmbCarOwner.SelectedValue == null) return;
            int carId = Convert.ToInt32(dgvCars.CurrentRow.Cells["Id"].Value);
            using var context = new AutoDbContext();
            var car = context.Cars.Find(carId);
            if (car != null)
            {
                car.Brand = txtCarBrand.Text.Trim();
                car.Model = txtCarModel.Text.Trim();
                car.RegistrationNumber = txtCarRegNumber.Text.Trim();
                car.OwnerId = (int)cmbCarOwner.SelectedValue;
                context.SaveChanges();
            }
            ClearCarFields();
            LoadCars();
            LoadOwners();
            LoadServiceOwners();
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
            LoadServiceOwners();
        }

        private void btnClearCar_Click(object sender, EventArgs e)
        {
            ClearCarFields();
        }

        // =================== Services ===================
        private void LoadServiceOwners()
        {
            using var context = new AutoDbContext();
            var owners = context.Owners.ToList();

            cmbServiceOwner.SelectedIndexChanged -= CmbServiceOwner_SelectedIndexChanged;
            cmbServiceOwner.DataSource = owners;
            cmbServiceOwner.DisplayMember = "FullName";
            cmbServiceOwner.ValueMember = "Id";
            cmbServiceOwner.SelectedIndex = -1;
            cmbServiceOwner.SelectedIndexChanged += CmbServiceOwner_SelectedIndexChanged;

            cbauto.DataSource = null; // пока нет выбранного владельца
        }

        private void CmbServiceOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServiceOwner.SelectedValue == null) return;

            int ownerId = (int)cmbServiceOwner.SelectedValue;
            using var context = new AutoDbContext();
            var cars = context.Cars
                .Where(c => c.OwnerId == ownerId)
                .Select(c => new { c.Id, DisplayName = $"{c.Brand} {c.Model} ({c.RegistrationNumber})" })
                .ToList();

            cbauto.DataSource = cars;
            cbauto.DisplayMember = "DisplayName";
            cbauto.ValueMember = "Id";
            cbauto.SelectedIndex = -1;
        }

        private void LoadServices(string search = "")
        {
            using var context = new AutoDbContext();
            var query = context.Services.Include(s => s.Car).ThenInclude(c => c.Owner).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(s =>
                    s.Car.Brand.ToLower().Contains(search) ||
                    s.Car.Model.ToLower().Contains(search) ||
                    s.Car.RegistrationNumber.ToLower().Contains(search) ||
                    s.Name.ToLower().Contains(search) ||
                    s.Car.Owner.FullName.ToLower().Contains(search)
                );
            }

            dgvServices.DataSource = query
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Price,
                    Car = s.Car.Brand + " " + s.Car.Model + " (" + s.Car.RegistrationNumber + ")",
                    Owner = s.Car.Owner.FullName,
                    s.CarId,
                    FinishTime = s.Time.ToString("HH:mm dd.MM.yyyy")
                })
                .ToList();
        }

        private void ClearServiceFields()
        {
            txtServiceName.Clear();
            txtServicePrice.Clear();
            cbauto.SelectedIndex = -1;
            cmbServiceOwner.SelectedIndex = -1;
            datetimepickertime.Value = DateTime.Now;
        }

        private void DgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServices.CurrentRow == null) return;

            txtServiceName.Text = dgvServices.CurrentRow.Cells["Name"].Value.ToString();
            txtServicePrice.Text = dgvServices.CurrentRow.Cells["Price"].Value.ToString();

            int carId = (int)dgvServices.CurrentRow.Cells["CarId"].Value;

            using var context = new AutoDbContext();
            var car = context.Cars.Include(c => c.Owner).First(c => c.Id == carId);
            cmbServiceOwner.SelectedValue = car.OwnerId;
            cbauto.SelectedValue = carId;

            if (DateTime.TryParse(dgvServices.CurrentRow.Cells["FinishTime"].Value.ToString(), out DateTime dt))
                datetimepickertime.Value = dt;
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (cbauto.SelectedValue == null) return;

            using var context = new AutoDbContext();
            context.Services.Add(new Service
            {
                Name = txtServiceName.Text.Trim(),
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
                service.Name = txtServiceName.Text.Trim();
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
