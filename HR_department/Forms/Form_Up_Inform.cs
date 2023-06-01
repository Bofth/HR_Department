using HR_department.Data;
using HR_department.Enums;
using HR_department.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HR_department
{
    public partial class Form_Up_Inform : Form
    {
        private Point lastPoint;
        private readonly Employee ChengetEmployee;
        public Form_Up_Inform()
        {
            InitializeComponent();
            ChengetEmployee = new Employee();
        }

        public Form_Up_Inform(Employee employeeInfo)
        {
            InitializeComponent();
            ChengetEmployee = employeeInfo;
            textBox1.Text = employeeInfo.Name.ToString();
            textBox2.Text = employeeInfo.Surname.ToString();
            textBox3.Text = employeeInfo.PassNum.ToString();
            comboBox1.Text = employeeInfo.Education.ToString();
            textBox4.Text = employeeInfo.Specialization.ToString();
            textBox5.Text = employeeInfo.Age.ToString();
            textBox6.Text = employeeInfo.Position.ToString();
            textBox7.Text = employeeInfo.Salary.ToString();
            textBox8.Text = employeeInfo.EntryIntoCompany.ToString();
            textBox9.Text = employeeInfo.LastAppointment.ToString();
        }
        private void ClouseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Education enumValue;
            if (Enum.TryParse(comboBox1.Text, out enumValue))
            {
                DialogResult result = MessageBox.Show("Ви впевнені?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                        string.IsNullOrWhiteSpace(textBox2.Text) ||
                        string.IsNullOrWhiteSpace(textBox3.Text) ||
                        string.IsNullOrWhiteSpace(textBox5.Text) ||
                        string.IsNullOrWhiteSpace(textBox4.Text) ||
                        string.IsNullOrWhiteSpace(textBox6.Text) ||
                        string.IsNullOrWhiteSpace(textBox7.Text) ||
                        string.IsNullOrWhiteSpace(textBox8.Text) ||
                        string.IsNullOrWhiteSpace(textBox9.Text))
                    {
                        MessageBox.Show("Не усі поля заповнені", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        ChengetEmployee.Name = textBox1.Text;
                        ChengetEmployee.Surname = textBox2.Text;
                        ChengetEmployee.PassNum = int.Parse(textBox3.Text);
                        ChengetEmployee.Education = enumValue;
                        ChengetEmployee.Age = int.Parse(textBox5.Text);
                        ChengetEmployee.Specialization = textBox4.Text;
                        ChengetEmployee.Position = textBox6.Text;
                        ChengetEmployee.Salary = int.Parse(textBox7.Text);
                        ChengetEmployee.EntryIntoCompany = DateTime.Parse(textBox8.Text);
                        ChengetEmployee.LastAppointment = DateTime.Parse(textBox9.Text);

                        Serialization.SerializeObject(ChengetEmployee);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Введено недопустиме значення у поле. Перевірте будь ласка коректність введення ваших даних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Недопустиме значення в полі освіта.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
