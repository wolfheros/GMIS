//YUCHAO WU Meeting Page 1



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
    public partial class MeetingPage : Page
    {   
        private StudentBean? studentBean;
        public MeetingPage(StudentBean? bean)
        {
            InitializeComponent();
            studentBean = bean;
        }

        private void MeetingView_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MeetingPage2(DatabaseContorller.FetchMeetingDataFromDatabase(studentBean.GroupID, GlobalsMeetingDatatype.ShowMeetingData)));
        }

        private void MeetingShow_Click(object sender, RoutedEventArgs e)
        {   
            if(IsMasterDegree())
            {
                this.NavigationService.Navigate(new MeetingPage2(DatabaseContorller.FetchMeetingDataFromDatabase(studentBean.GroupID, GlobalsMeetingDatatype.ShowAllMeetingData)));
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

        private void MeetingSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchText = MeetingSerachText.Text;
            if(searchText.Length > 0)
            {
                this.NavigationService.Navigate(new MeetingPage2(DatabaseContorller.FetchMeetingDataFromDatabase(searchText, GlobalsMeetingDatatype.ShowCustomerSearchData)));
            }
            else
            {
                MessageBox.Show("Invalid input, check you spell");
            }
            
        }
    }
}
