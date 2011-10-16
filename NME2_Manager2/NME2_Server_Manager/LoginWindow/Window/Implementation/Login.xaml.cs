using System.Windows;

namespace NME2_Server_Manager.LoginWindow.Window.Implementation
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : System.Windows.Window
    {
        private bool _isguest = false;
        private bool _cancelLogin = true;

        public Login()
        {
            InitializeComponent();
            txtUser.Focus();
        }

        private void BtnLoginClick(object sender, RoutedEventArgs e)
        {
            _cancelLogin = false;
            this.Close();
        }

        public string User
        {
            get { return txtUser.Text; }
        }

        public string Pwd
        {
            get { return txtPwd.Password; }
        }

        public bool IsGuest
        {
            get { return _isguest; }
        }

        public bool CancelLogin {
            get { return _cancelLogin; }
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            _isguest = true;
            _cancelLogin = false;
            this.Close();
        }
    }
}
