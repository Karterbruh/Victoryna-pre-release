using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victoryna
{
    public partial class Vict : Form
    {
        public Vict()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)      //Ответить
        {
            Vict_func.Tests(User_data.t);
        }

        private void button2_Click(object sender, EventArgs e)      //Начать
        {
            Vict_func.Start();
            Vict_func.Draw_table();
        }

        private void button3_Click(object sender, EventArgs e)      //Следующий вопрос
        {
            Vict_func.Next_questions();
        }

        public void выйтиИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["JoinForm"];  //Для открытия текущей формы
            ((JoinForm)f).textBox1.Text = null;        //Чтобы когда мы вышли из аккаунта поля были пустыми
            ((JoinForm)f).textBox2.Text = null;
            Forms.vict.Hide();
            f.Show();
        }

        private void Vict_Activated(object sender, EventArgs e)
        {
            label6.Text = $"Добро пожаловать {User_data.join_login}";
        }

        private void добавитьВопросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create_questions create_Questions = new Create_questions();
            create_Questions.Show();
        }

        private void Vict_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            if(User_data.join_login == "maximka")
            {
                ((Vict)VictF).menuStrip1.Items[1].Enabled = true;
            }
        }
    }
}
