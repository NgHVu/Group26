using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowExplorerUI1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void C_Click(object sender, EventArgs e)
        {
            string cDrivePath = "C:\\";
            webBrowser.Url = new Uri(cDrivePath);
            Search.Text = cDrivePath;
            C.Hide();
            D.Hide();
            webBrowser.Show();
        }

        private void D_Click(object sender, EventArgs e)
        {
            string dDrivePath = "D:\\";
            webBrowser.Url = new Uri(dDrivePath);
            Search.Text = dDrivePath;
            C.Hide();
            D.Hide();
            webBrowser.Show();
        }

        private void Lui_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoBack)
                webBrowser.GoBack();
            else
            {
                webBrowser.Hide();
                C.Show();
                D.Show();
                Search.Text = " ";
            }

        }

        private void Tien_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoForward)
                webBrowser.GoForward();        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        bool isButtonHidden = false;
        private void X_Click(object sender, EventArgs e)
        {
            if (isButtonHidden)
            {
                C1.Show();
                D1.Show();
                isButtonHidden = false;
            }
            else
            {
                C1.Hide();
                D1.Hide();
                isButtonHidden = true;
            }
        }

        private void C1_Click(object sender, EventArgs e)
        {
            string cDrivePath = "C:\\";
            webBrowser.Url = new Uri(cDrivePath);
            Search.Text = cDrivePath;
            C.Hide();
            D.Hide();
            webBrowser.Show();
        }

        private void D1_Click(object sender, EventArgs e)
        {
            string dDrivePath = "D:\\";
            webBrowser.Url = new Uri(dDrivePath);
            Search.Text = dDrivePath;
            C.Hide();
            D.Hide();
            webBrowser.Show();
        }
    }
}
