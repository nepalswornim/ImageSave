using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using Utilities;


namespace ImageImplementation_Operation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BLLPhoto blph = new BLLPhoto();
        Find fnd = new Find();
        
     

        string noimagepath = Application.StartupPath + "\\image.jpg";
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All jpg imager 6(*.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBrowse.Text = openFileDialog1.FileName;
                imgHead.ImageLocation = txtBrowse.Text;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imgHead.ImageLocation = noimagepath;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            byte[] picture = Utilities.Helpeer.ReadFile(txtBrowse.Text);

          int i=  blph.InsertPicture(txtFullName.Text, picture);
          if (i>0)
          {
              MessageBox.Show("Inserted Successfully");
              Loadgrid();
          }

        }

        private void Loadgrid()
        {
            imgHead.ImageLocation = noimagepath;
            txtFullName.Text = "";
            txtBrowse.Text = "";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.Hide();
            fnd.Show();
        }
    }
}