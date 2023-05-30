using System;
using System.Drawing;
using System.Windows.Forms;

namespace HR_department
{
    public partial class Start_Form : Form
    {
        public Start_Form()
        {
            InitializeComponent();
        }
        private void infoButton_Click(object sender, EventArgs e)
        {
            Form_Info _form_Info = new Form_Info();
            _form_Info.FormClosed += (eventSender, eventArgs) => Show();
            _form_Info.Show();
            Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form_Proper _form_Proper = new Form_Proper();
            _form_Proper.FormClosed += (eventSender, eventArgs) => Show();
            _form_Proper.Show();
            Hide();
        }

        private Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

    }
}
