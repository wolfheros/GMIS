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
    /// Interaction logic for ClassPage.xaml
    /// </summary>
    public partial class ClassPage : Page
    {   
        private StudentBean? studentBean;
        public ClassPage(StudentBean? bean)
        {
            InitializeComponent();
            studentBean = bean;
            InitTextValue();
        }

        public string? ImageResource
        {
            get
            {
                return studentBean?.PhotoURL;
            }
        }

        private void InitTextValue()
        {
            firstName.Text = "First Name: "+ studentBean?.FirstName;
            familyName.Text = "Family Name: " + studentBean?.FamilyName;
            studentID.Text = "Student ID: " + studentBean?.StudentId;
            groupID.Text = "Group ID: " +  studentBean?.GroupID;
            campus.Text = "Campus: " + studentBean?.Campus;
            phone.Text = "Phone: " + studentBean?.Phone;
            email.Text = "E-mail: " + studentBean?.Email;
            category.Text = "Category: " + studentBean?.Category;
        }

        private void showClassButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ClassShowPage(DatabaseContorller.FetchClassDataFromDatabase(studentBean.GroupID, GlobalsClassDatatype.ClassData)));
        }

        private void showAllClassButton_Click(object sender, RoutedEventArgs e)
        {   
            if(IsMasterDegree())
            {
                this.NavigationService.Navigate(new ClassShowPage(DatabaseContorller.FetchClassDataFromDatabase(studentBean.GroupID, GlobalsClassDatatype.AllClassData)));
            }
            else
            {
                MessageBox.Show("You have no authorization to do this operation.");
            }
            
        }

        /**
         *  check is master degree or not
         *  @return bool value
         */
        private bool IsMasterDegree()
        {
            var category = studentBean.Category;
            return (category != null) && (category == "Masters");
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchText = searchBox.Text;
            if(searchText.Length > 0)
            {
                this.NavigationService.Navigate(new ClassShowPage(DatabaseContorller.FetchClassDataFromDatabase(searchText, GlobalsClassDatatype.CustomerSearchData)));
            }
            else
            {
                MessageBox.Show("Invalid input, check you spell");
            }
            
        }
    }
}
