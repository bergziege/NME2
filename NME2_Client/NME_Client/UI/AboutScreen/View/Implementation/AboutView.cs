using System;
using System.Windows.Forms;

namespace NME2.UI.AboutScreen.View.Implementation
{
    public partial class AboutView : Form, IAboutView
    {
        public AboutView()
        {
            InitializeComponent();
            
        }

        private void LblLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (RequestOpenLink != null)
            {
                RequestOpenLink(this, EventArgs.Empty);
            }
        }

        public Form GetAsForm()
        {
            return this;
        }

        public void SetAboutLink(int length, string link)
        {
            lblLink.Links.Add(0, length, link);
        }

        public event EventHandler RequestOpenLink;
    }
}
