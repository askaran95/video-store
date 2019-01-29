using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Video_Store
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Login  Obj_Login= new Login();

        public Window1()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = Convert.ToString(Rg_user.Text);
            string password = Convert.ToString(Rg_pass.Text);
            Obj_Login.Regis_method(username,password);
          
                MessageBox.Show("Succesfull");
                LoginPage w = new LoginPage();
                w.ShowDialog();
                this.Close();
            

        }
    }
}
