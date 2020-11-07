using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaktionslogik für ViewerForStudents.xaml
    /// </summary>
    public partial class ViewerForStudents : Window
    {
        public ViewerForStudents()
        {
            InitializeComponent();
        }

        private void OnClickRefreshModuleList(object sender, RoutedEventArgs e)
        {
            DataTable dataTable = SQLHandler.ReturnModule();
            ModuleList.Items.Clear();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ModuleList.Items.Add(dataTable.Rows[i][0]);
            }
        }

        private void OnClickClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
