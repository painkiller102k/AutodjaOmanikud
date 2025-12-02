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
            LoadServices();

            dgvOwners.CellClick += DgvOwners_CellClick;
            dgvCars.CellClick += DgvCars_CellClick;
            dgvServices.CellClick += DgvServices_CellClick;
        }

        private void LoadOwners()
        {
            using (var context = new AutoDbContext())
            {
                dgvOwners.DataSource = context.Owners
                    .Include(o => o.Cars)
                    .Select(o => new
                    {
                        o.Id,
                        o.FullName,
                        o.Phone,
                        Cars = string.Join(", ", o.Cars.Select(c => c.Brand))
                    })
                    .ToList();
            }
        }

        private void ClearOwnerFields()
        {
            txtOwnerFullName.Clear();
            txtOwnerPhone.Clear();
        }

        private void DgvOwners_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOwners.CurrentRow != null)
            {
                txtOwnerFullName.Text = dgvOwners.CurrentRow.Cells["FullName"].Value.ToString();
                txtOwnerPhone.Text = dgvOwners.CurrentRow.Cells["Phone"].Value.ToString();
            }
        }

        private void btnAddOwner_Click(object sender, EventArgs e)
        {
            using (var context = new AutoDbContext())
            {
                context.Owners.Add(new Owner
                {
                    FullName = txtOwnerFullName.Text,
                    Phone = txtOwnerPhone.Text
                });
                context.SaveChanges();
            }
            ClearOwnerFields();
            LoadOwners();
            LoadCars();
        }

        private void btnUpdateOwner_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow != null)
            {
                int ownerId = Convert.ToInt32(dgvOwners.CurrentRow.Cells["Id"].Value);
                using (var context = new AutoDbContext())
                {
                    var owner = context.Owners.Find(ownerId);
                    if (owner != null)
                    {
                        owner.FullName = txtOwnerFullName.Text;
                        owner.Phone = txtOwnerPhone.Text;
                        context.SaveChanges();
                    }
                }
                ClearOwnerFields();
                LoadOwners();
                LoadCars();
            }
        }

        private void btnDeleteOwner_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow != null)
            {
                int ownerId = Convert.ToInt32(dgvOwners.CurrentRow.Cells["Id"].Value);
                using (var context = new AutoDbContext())
                {
                    var owner = context.Owners.Include(o => o.Cars).FirstOrDefault(o => o.Id == ownerId);
                    if (owner != null)
                    {
                        if (owner.Cars.Any())
                            context.Cars.RemoveRange(owner.Cars);
                        context.Owners.Remove(owner);
                        context.SaveChanges();
                    }
                }
                ClearOwnerFields();
                LoadOwners();
                LoadCars();
            }
        }

        private void btnClearOwner_Click(object sender, EventArgs e)
        {
            ClearOwnerFields();
        }

        private void LoadCars()
        {
            using (var context = new AutoDbContext())
            {
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
            if (dgvCars.CurrentRow != null)
            {
                txtCarBrand.Text = dgvCars.CurrentRow.Cells["Brand"].Value.ToString();
                txtCarModel.Text = dgvCars.CurrentRow.Cells["Model"].Value.ToString();
                txtCarRegNumber.Text = dgvCars.CurrentRow.Cells["RegistrationNumber"].Value.ToString();
                string ownerName = dgvCars.CurrentRow.Cells["Owner"].Value.ToString();
                cmbCarOwner.SelectedIndex = cmbCarOwner.FindStringExact(ownerName);
            }
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            if (cmbCarOwner.SelectedValue == null) return;

            using (var context = new AutoDbContext())
            {
                context.Cars.Add(new Car
                {
                    Brand = txtCarBrand.Text,
                    Model = txtCarModel.Text,
                    RegistrationNumber = txtCarRegNumber.Text,
                    OwnerId = (int)cmbCarOwner.SelectedValue
                });
                context.SaveChanges();
            }
            ClearCarFields();
            LoadCars();
            LoadOwners();
        }

        private void btnUpdateCar_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow != null && cmbCarOwner.SelectedValue != null)
            {
                int carId = Convert.ToInt32(dgvCars.CurrentRow.Cells["Id"].Value);
                using (var context = new AutoDbContext())
                {
                    var car = context.Cars.Find(carId);
                    if (car != null)
                    {
                        car.Brand = txtCarBrand.Text;
                        car.Model = txtCarModel.Text;
                        car.RegistrationNumber = txtCarRegNumber.Text;
                        car.OwnerId = (int)cmbCarOwner.SelectedValue;
                        context.SaveChanges();
                    }
                }
                ClearCarFields();
                LoadCars();
                LoadOwners();
            }
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow != null)
            {
                int carId = Convert.ToInt32(dgvCars.CurrentRow.Cells["Id"].Value);
                using (var context = new AutoDbContext())
                {
                    var car = context.Cars.Find(carId);
                    if (car != null)
                    {
                        context.Cars.Remove(car);
                        context.SaveChanges();
                    }
                }
                ClearCarFields();
                LoadCars();
                LoadOwners();
            }
        }

        private void btnClearCar_Click(object sender, EventArgs e)
        {
            ClearCarFields();
        }

        private void LoadServices()
        {
            using (var context = new AutoDbContext())
            {
                dgvServices.DataSource = context.Services
                    .Select(s => new
                    {
                        s.Id,
                        s.Name,
                        s.Price
                    }).ToList();
            }
        }

        private void ClearServiceFields()
        {
            txtServiceName.Clear();
            txtServicePrice.Clear();
        }

        private void DgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServices.CurrentRow != null)
            {
                txtServiceName.Text = dgvServices.CurrentRow.Cells["Name"].Value.ToString();
                txtServicePrice.Text = dgvServices.CurrentRow.Cells["Price"].Value.ToString();
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            using (var context = new AutoDbContext())
            {
                context.Services.Add(new Service
                {
                    Name = txtServiceName.Text,
                    Price = decimal.Parse(txtServicePrice.Text)
                });
                context.SaveChanges();
            }
            ClearServiceFields();
            LoadServices();
        }

        private void btnUpdateService_Click(object sender, EventArgs e)
        {
            if (dgvServices.CurrentRow != null)
            {
                int serviceId = Convert.ToInt32(dgvServices.CurrentRow.Cells["Id"].Value);
                using (var context = new AutoDbContext())
                {
                    var service = context.Services.Find(serviceId);
                    if (service != null)
                    {
                        service.Name = txtServiceName.Text;
                        service.Price = decimal.Parse(txtServicePrice.Text);
                        context.SaveChanges();
                    }
                }
                ClearServiceFields();
                LoadServices();
            }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (dgvServices.CurrentRow != null)
            {
                int serviceId = Convert.ToInt32(dgvServices.CurrentRow.Cells["Id"].Value);
                using (var context = new AutoDbContext())
                {
                    var service = context.Services.Find(serviceId);
                    if (service != null)
                    {
                        context.Services.Remove(service);
                        context.SaveChanges();
                    }
                }
                ClearServiceFields();
                LoadServices();
            }
        }

        private void btnClearService_Click(object sender, EventArgs e)
        {
            ClearServiceFields();
        }
    }
}
