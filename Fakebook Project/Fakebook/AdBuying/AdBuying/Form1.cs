using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdBuying
{
    public partial class Form1 : Form
    {
        private static int plan;
        private static string imageLocation;
        private static string path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Application.ExecutablePath))) + @"\";

        public Form1()
        {
            InitializeComponent();
            plan = 0;
            imageLocation = "";
            DataService.Path = path + @"AdService.mdf";
        }

        private void btnLow_Click(object sender, EventArgs e)
        {
            plan = 1;
            GoToBuy();
        }

        private void GoToBuy()
        {
            panelBuy.Visible = true;
            txtAdvertiser.Text = "";
            txtURL.Text = "";
            imageAd.Image = null;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            plan = 2;
            GoToBuy();
        }

        private void btnHigh_Click(object sender, EventArgs e)
        {
            plan = 3;
            GoToBuy();
        }

        private void btnBackPlans_Click(object sender, EventArgs e)
        {
            panelBuy.Visible = false;
        }

        private void btnChooseAd_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "JPG(*.JPG)|*.jpg|PNG files(*.png)|*.png";
                dialog.FilterIndex = 1;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    imageAd.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (txtURL.Text != "" && txtAdvertiser.Text != "" && imageAd.ImageLocation != "")
            {
                try
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(imageLocation);
                    string ext = fi.Extension;
                    int items = System.IO.Directory.GetFiles(path + "Advertisements", "*", System.IO.SearchOption.TopDirectoryOnly).Length;
                    string fileName = items + ext;
                    Ads ad = new Ads(1, txtURL.Text, txtAdvertiser.Text, path + @"Advertisements\" + fileName, plan);
                    ad.Insert();
                    System.IO.File.Copy(imageLocation, path + @"Advertisements\" + fileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
