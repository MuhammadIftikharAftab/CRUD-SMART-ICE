using CRUD_SMART_ICE.Data;
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

namespace CRUD_SMART_ICE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeDBContext context;
        Employee NewEmployee = new Employee();
        Employee selectedEmployee = new Employee();
        
        public MainWindow(EmployeeDBContext context)
        {
            this.context = context;
            InitializeComponent();
            GetEmployees();
            NewEmployeeGrid.DataContext = NewEmployee;
        }


        private void GetEmployees()
        {
            EmployeeDG.ItemsSource = context.Employees.ToList();
        }

        private void WriteAllEmployeesToFile(object s, RoutedEventArgs e)
        {
            System.IO.File.Delete(@"record.txt");

            foreach (var record in context.Employees.ToList())
            {
                System.IO.File.AppendAllText(@"record.txt", record.EmployeeAsCommaSepratedString() + Environment.NewLine);
                    
            }

            System.Diagnostics.Process.Start("notepad.exe", @"record.txt");

        }

        private void AddEmployee(object s, RoutedEventArgs e)
        {
            context.Employees.Add(NewEmployee);
            context.SaveChanges();
            GetEmployees();
            NewEmployee = new Employee();
            NewEmployeeGrid.DataContext = NewEmployee;
        }

        private void UpdateEmployee(object s, RoutedEventArgs e)
        {
            context.Update(selectedEmployee);
            context.SaveChanges();
            GetEmployees();
        }

        private void SelectEmployeeToEdit(object s, RoutedEventArgs e)
        {
            selectedEmployee = (s as FrameworkElement).DataContext as Employee;
            UpdateEmployeeGrid.DataContext = selectedEmployee;
        }

        private void DeleteEmployee(object s, RoutedEventArgs e)
        {
            var employeeToDelete = (s as FrameworkElement).DataContext as Employee;
            context.Employees.Remove(employeeToDelete);
            context.SaveChanges();
            GetEmployees();
        }
    }
}

