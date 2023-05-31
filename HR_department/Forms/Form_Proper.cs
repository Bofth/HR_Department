using System;
using System.Drawing;
using System.Windows.Forms;

namespace HR_department
{
    public partial class Form_Proper : Form
    {
        private Point lastPoint;

        public Form_Proper()
        {
            InitializeComponent();
        }

        private void ClouseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Form_Up_Inform _form_Up_Inform = new Form_Up_Inform();
            _form_Up_Inform.FormClosed += (eventSender, eventArgs) => Show();
            _form_Up_Inform.Show();
            Hide();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
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

        private void Dismissal_Click(object sender, EventArgs e)
        {
            Form_Dismissal _form_Dismissal = new Form_Dismissal();
            _form_Dismissal.FormClosed += (eventSender, eventArgs) => Show();
            _form_Dismissal.Show();
            Hide();
        }

        private void DismissalOld_Click(object sender, EventArgs e)
        {
            Form_Dismissal_ByAge _form_Dismissal_ByAge = new Form_Dismissal_ByAge();
            _form_Dismissal_ByAge.FormClosed += (eventSender, eventArgs) => Show();
            _form_Dismissal_ByAge.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
