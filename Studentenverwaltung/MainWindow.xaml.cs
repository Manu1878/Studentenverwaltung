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

namespace Studentenverwaltung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Student> Students = new List<Student>();
        List<string> ProgList = new List<string>();
        //private int changePos = -1; // stores the pos of the changed element.
        public MainWindow()
        {
            InitializeComponent();
            //cboProg.ItemsSource = new List<string>() { "BWI", "Phd", "Elektrotechnik", "BWL" };
            //cboProg.SelectedIndex = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Students.Add(new Student()
            {
                Age = int.Parse(tboAge.Text),
                Firstname = tboFName.Text,
                Lastname = tboLName.Text,
                HasPaid = chkPaid.IsChecked.GetValueOrDefault(),
                Program = cboProg.SelectedItem.ToString()
            });
            UpdateStudentDataGrid();
        }

        private void UpdateStudentDataGrid()
        {
            dtgStudentData.ItemsSource = null;
            dtgStudentData.ItemsSource = Students;
        }

        private void EditBtnClicked(object sender, RoutedEventArgs e)
        {
            var selected = dtgStudentData.SelectedItem as Student;
            if(selected != null)
            {
                tboAge.Text = selected.Age + "";
                tboFName.Text = selected.Firstname;
                tboLName.Text = selected.Lastname;
                chkPaid.IsChecked = selected.HasPaid;
                cboProg.SelectedItem = selected.Program;
                //Test
                //deletes the entry from the List
                Students.RemoveAt(dtgStudentData.SelectedIndex);
                UpdateStudentDataGrid();
            }
        }

        private void DeleteBtnClicked(object sender, RoutedEventArgs e)
        {
            Students.RemoveAt(dtgStudentData.SelectedIndex);
            UpdateStudentDataGrid();
        }

        private void MasterDataSaveBtnClicked(object sender, RoutedEventArgs e)
        {
            ProgList.Add(tboNewProg.Text);
            UpdateProgList();
        }

        private void UpdateProgList()
        {
            lboProgs.ItemsSource = null;
            lboProgs.ItemsSource = ProgList;
            cboProg.ItemsSource = null;
            cboProg.ItemsSource = ProgList;
        }
    }
}
