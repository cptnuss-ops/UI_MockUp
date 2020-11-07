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
        private DataTable dataTable = new DataTable();       
        public ViewerForStudents()
        {
            InitializeComponent();
        }

        private void OnClickRefreshModuleList(object sender, RoutedEventArgs e)
        {
            dataTable = SQLHandler.ReturnModule();
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

        private void SetDataGrid(DataTable dataTable)
        {            
            dataGridAllgemein.ItemsSource = dataTable.DefaultView;
        }

        private void OnSelectionChange(object sender, SelectionChangedEventArgs e)
        {           
            var SelectedItemInList = ModuleList.SelectedItem.ToString();
            DataRow[] selectedModul = dataTable.Select("Modulbezeichnung LIKE '" + SelectedItemInList + "%'");
            var finaltest = selectedModul[0].ItemArray[1];
            int Modulnummer = Convert.ToInt32(finaltest);
            SQLHandler.GetModulInfo(Modulnummer);
            SetDataGrid(SQLHandler.dataTable1);
        }
    }
}
