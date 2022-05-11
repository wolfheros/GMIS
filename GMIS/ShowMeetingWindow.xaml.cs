//YUCHAO WU Meeting Page 2

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

namespace GMIS
{
    /// <summary>
    /// Interaction logic for ShowMeetingWindow.xaml
    /// </summary>
    public partial class ShowMeetingWindow : Window
    {
        public ShowMeetingWindow(List<MeetingBean> MeetingBeans)
        {
            InitializeComponent();
            meetingView.ItemsSource = MeetingBeans;
        }
    }
}
