using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victoryna
{
    public partial class Create_questions : Form
    {
        public Create_questions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vict_func.Add_questions();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vict_func.Input_questions();
        }

        private void Create_questions_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Для загрузки вопроса из файла нужно выбрать тему вопроса и нажать на кнопку в верхнем левом углу\nДля ручной загрузки необходимо заполнить все поля и тему вопросов");
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (label1.Text == "Загруженные вопросы")
            {
                label1.Text = "Вопросы";
                textBox1.Text = "";
            }
        }
    }
}
