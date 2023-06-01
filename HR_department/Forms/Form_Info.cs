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
        private List<Employee> employees;
        public Form_Info()
        {
            InitializeComponent();
            employees = Serialization.DeserializeObjects();
            dataGridView1.DataSource = employees;
            Font font = new Font("Arial", 12, FontStyle.Bold);

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.Font = font;
            }
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle(dataGridView1.DefaultCellStyle);
            cellStyle.Font = new Font("Microsoft Sans Serif", 10, GraphicsUnit.Pixel);

            // Застосовуємо новий стиль до dataGridView1
            dataGridView1.DefaultCellStyle = cellStyle;
        }
        private void ClouseButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                Employee selectedEmployee = (Employee)selectedRow.DataBoundItem;
                Form_Up_Inform _form_Up_Inform = new Form_Up_Inform(selectedEmployee);
                _form_Up_Inform.FormClosed += (eventSender, eventArgs) => Show();
                _form_Up_Inform.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Виберіть користувача для редагування.");
            }
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

        private void ListOfEmployers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Employee> listForDismissal;
            listForDismissal = MainOfClass.SearchEmploye(textBox1.Text, employees);
            dataGridView1.DataSource = listForDismissal;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
