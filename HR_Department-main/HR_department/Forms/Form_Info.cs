using HR_department.Data;
using HR_department.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace HR_department
{
    public partial class Form_Info : Form
    {
        private Point lastPoint;
        private readonly List<Employee> employees;
        public Form_Info()
        {
            InitializeComponent();
            employees = Serialization.DeserializeObjects();
            ListOfEmployers.Items.Clear();
            foreach (Employee employee in employees)
            {
                _ = ListOfEmployers.Items.Add(employee.ToString());
            }
        }
        private void ClouseButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string selectedEmployeeFull = (string)ListOfEmployers.SelectedItem;
            Employee selectedEmployee = MainOfClass.GetEmployeeByNum(selectedEmployeeFull, employees);
            Form_Up_Inform _form_Up_Inform = new Form_Up_Inform(selectedEmployee);
            _form_Up_Inform.FormClosed += (eventSender, eventArgs) => Show();
            _form_Up_Inform.Show();
            Hide();
        }


        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
