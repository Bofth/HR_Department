using HR_department.Data;
using HR_department.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HR_department
{
    public partial class Form_Dismissal : Form
    {
        private Point lastPoint;
        private List<Employee> Employers = Serialization.DeserializeObjects();
        public Form_Dismissal()
        {
            InitializeComponent();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void ClouseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Employee> listForDismissal;
            listForDismissal = MainOfClass.SearchEmploye(textBox1.Text, Employers);
            ListOfEmployers.Items.Clear();
            foreach (Employee employee in listForDismissal)
            {
                _ = ListOfEmployers.Items.Add(employee.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
            }
            else
            {
                return;
            }
            if (ListOfEmployers.SelectedItem != null)
            {
                string selectedEmployee = ListOfEmployers.SelectedItem.ToString();

                Employee employeeToRemove = Employers.FirstOrDefault(emp => emp.ToString() == selectedEmployee);
                if (employeeToRemove != null)
                {
                    _ = Employers.Remove(employeeToRemove);
                    Serialization.SerializeObjects(Employers);

                    ListOfEmployers.Items.Remove(selectedEmployee);

                    _ = MessageBox.Show("Працівник успішно звільнений.");

                    // Оновлення списку Employers після видалення працівника
                    Employers = Serialization.DeserializeObjects();
                }
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }
    }
}
