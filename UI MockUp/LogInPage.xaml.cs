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

namespace UI_MockUp
{
    /// <summary>
    /// Interaktionslogik für LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Window
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        private void OnClickLogInAsStudent(object sender, RoutedEventArgs e)
        {
            ViewerForStudents viewerForStudents = new ViewerForStudents();
            viewerForStudents.Show();
            this.Close();
            //später würde ich die LoginPage erst schließen, wenn die Anmeldung erfolgreich war. Das Mainwindow würde ich benutzen, um Seiten für die versch. Sichten zu realisieren. Im Moment werden dafür einzelne Windows benutzt.
        }

        private void OnClickLogInAsLecturer(object sender, RoutedEventArgs e)
        {
            if (UsernameBox.Text== "Test" && PasswordBox.Password == "Test")
            {
                Application.Current.MainWindow.Visibility = Visibility.Visible;
            }
        }
    }
}
