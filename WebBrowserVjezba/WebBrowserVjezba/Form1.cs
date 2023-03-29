using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowserVjezba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolTrazi_Click(object sender, EventArgs e)
        {
            Navigacija(toolStripTextBox2.Text);
        }

        private void Navigacija(String adresa)
        {
            if (String.IsNullOrEmpty(adresa)) return;
            if (adresa.Equals("about:blank")) return;
            if (!adresa.StartsWith("http://") && !adresa.StartsWith("https://"))
            {
                adresa = "http://" + adresa;
            }
            if (!adresa.EndsWith(".com") && !adresa.EndsWith(".org") && !adresa.EndsWith(".net") && !adresa.EndsWith(".co") && !adresa.EndsWith(".us"))
            {
                adresa = adresa + ".com";
            }
            try
            {
                webBrowser1.Navigate(new Uri(adresa));
            }
            catch (System.UriFormatException)
            {
                return;
            }
            toolStripTextBox2.Text = adresa;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void toolBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
            toolStripTextBox2.Text = webBrowser1.Url.ToString();
        }

        private void toolForward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
            toolStripTextBox2.Text = webBrowser1.Url.ToString();
        }

        private void toolHome_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void toolBtnBookMark_Click(object sender, EventArgs e)
        {
            toolBookmarkList.Items.Add(webBrowser1.Url);
        }
    }
}
