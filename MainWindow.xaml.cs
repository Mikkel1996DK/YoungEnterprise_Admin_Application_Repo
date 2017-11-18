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

namespace YoungEnterprise_Admin_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //TODO: Have a look at this in order to check how to generate unique passwords for users!
        // https://stackoverflow.com/questions/54991/generating-random-passwords
        // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        // All of the xaml "main"-grids RowDefinitions should:
        // - All should add up to 9
        // - Top two rows should be of the auto-size of 1.5* except if the usercontrol contains a DataGrid
        //   Such as the CreateScheduleControl's layout
        //   and also the ViewUsersControl's layout

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
