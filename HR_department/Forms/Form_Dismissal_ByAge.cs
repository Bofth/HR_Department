using HR_department.Data;
using HR_department.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HR_department
{
    public partial class Form_Dismissal_ByAge : Form
    {
        private Point lastPoint;
        private readonly List<Employee> employees;
        public Form_Dismissal_ByAge()
        {
            InitializeComponent();
            employees = Serialization.DeserializeObjects();
        }

        private void ClouseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int maxAge)) // Отримуємо максимальний вік з текстового поля
            {
                Updatethis(maxAge);
            }
            else
            {
                _ = MessageBox.Show("Введіть коректне значення для максимального віку!");
            }
        }
        private void Updatethis(int maxAge)
        {
            checkedListBox1.Items.Clear(); // Очищаємо список перед пошуком

            foreach (Employee employee in employees)
            {
                if (employee.Age >= maxAge)
                {
                    _ = checkedListBox1.Items.Add(employee.ToString()); // Додаємо працівника до списку
                }
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            List<Employee> employeesToFire = new List<Employee>();

            DialogResult result = MessageBox.Show("Ви впевнені?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
            }
            else
            {
                return;
            }

            foreach (string selectedEmployee in checkedListBox1.CheckedItems)
            {
                Employee employee = employees.FirstOrDefault(emp => emp.ToString() == selectedEmployee);
                if (employee != null)
                {
                    employeesToFire.Add(employee);
                }
            }

            if (employeesToFire.Count > 0)
            {
                foreach (Employee employee in employeesToFire)
                {
                    _ = employees.Remove(employee);
                }

                Serialization.SerializeObjects(employees);
                _ = MessageBox.Show("Вибрані працівники були звільнені!");
                Updatethis(int.Parse(textBox1.Text));
            }
            else
            {
                _ = MessageBox.Show("Виберіть працівників для звільнення!");
            }
        }
    }
}
