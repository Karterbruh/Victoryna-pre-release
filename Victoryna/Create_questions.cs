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
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vict_func.Add_questions();
        }

        private void Create_questions_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(button2, "Загрузить вопросы с Excel");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vict_func.Add_questions_with_excel();
        }
    }
}
