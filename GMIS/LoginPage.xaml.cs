/**
 * @auther Shengya Ji
 * @date 08/05/2022
 */
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GMIS
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private int Type
        {
            get; set; 
        }
        public LoginPage(int type)
        {
            InitializeComponent();
            Type = type;
        }

        private void loginbutton_Click(object sender, RoutedEventArgs e)
        {
            var FirstName = firstName.Text;
            var FamilyName = familyName.Text;
            var StudentID = studentID.Text;

            if(Type == GlobalsType.ClassManagementType)
            {
                User user = new User(FirstName, FamilyName, StudentID);
                if (DatabaseContorller.AuthUser(user))
                {
                    this.NavigationService.Navigate(new ClassPage(DatabaseContorller.GetStudent()));
                }
                else
                {
                    MessageBox.Show(FirstName + " , " + FamilyName + "," + StudentID + " is NOT exit");
                }

            }
        }
    }
}
