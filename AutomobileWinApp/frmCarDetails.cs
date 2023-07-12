using AutomobileLibrary.BusinessObject;
using AutomobileLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomobileWinApp
{
    public partial class frmCarDetails : Form
    {
        public frmCarDetails()
        {
            InitializeComponent();
        }

        //--------
  public ICarRepository CarRepository { get; set; }
        public bool InsertOrUpdate { get; set; } // false : Insert , True : Update
        public Car CarInFo { get; set; }
        //-----
        
        private void frmCarDetails_Load(object sender, EventArgs e)
        {
            cboManufacturer.SelectedIndex = 0;
            txtCarID.Enabled = !InsertOrUpdate;
            if(InsertOrUpdate == true)
            {
                // show  car to perform updating 
                txtCarID.Text = CarInFo.CarID.ToString();
                txtCarName.Text = CarInFo.CarName;
                txtPrice.Text = CarInFo.Price.ToString();
                txtReleasedYear.Text = CarInFo.Manufacturer.Trim();

            }
        } //end frmCardetails_Load

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var car = new Car
                {
                    CarID = int.Parse(txtCarID.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = cboManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleaseYear = int.Parse(txtReleasedYear.Text),
                };
                if (InsertOrUpdate == false)
                {
                    CarRepository.InsertCar(car);
                }
                else
                {
                    CarRepository.UpdateCar(car);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,InsertOrUpdate == false?"Add a new car": "Update a car");
            }
        } //end btnsave_click

        private void btnCancel_Click(object sender, EventArgs e) => Close();
        
        

    } //end Form

}
