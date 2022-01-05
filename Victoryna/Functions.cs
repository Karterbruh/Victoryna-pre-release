using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Victoryna
{
    [Serializable]
    class Functions
    {
        public static string error;     //переменная для вывода ошибок

        //Функция для перемещения данных переменных в файл (запихнуть в файл)
        public static void Serializible_func()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
            using (StreamWriter file = new StreamWriter("ThisSystem.xml", false))
            {
                xmlSerializer.Serialize(file, User_data.User_list);
            }
        }

        //Достать данные из файла xml
        public static void Deserializible_func()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
            using (StreamReader file = new StreamReader("ThisSystem.xml", false))
            {
                User_data.User_list = (List<User>)xmlSerializer.Deserialize(file);
            }
        }

        public static void Serializible_questions()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(text_data.question[]));
            using (StreamWriter file = new StreamWriter("questions_lol.xml", false))
            {
                //xmlSerializer.Serialize(file, text_data.somearr);
            }
        }

        public static void Deserializible_questions()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(text_data.question[]));
            using (StreamReader file = new StreamReader("questions_lol.xml", false))
            {
                //text_data.somearr = (text_data.question[])xmlSerializer.Deserialize(file);
            }
        }
        public static string Hash(string password)         //Хеш пароля
        {
            byte[] data = Encoding.Default.GetBytes(password);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(data);
            password = Convert.ToBase64String(result);
            return password;
        }
        public static string Dehash(string Dehash)
        {
            byte[] b = Convert.FromBase64String(Dehash);
            string decryptedPassword = System.Text.ASCIIEncoding.ASCII.GetString(b);
            return decryptedPassword;
        }

        public static void Hide_item_main_menu()      //Скрыть элементы интерфейса
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            ((Vict)VictF).comboBox1.Visible = false;
            ((Vict)VictF).button2.Visible = false;
            ((Vict)VictF).label1.Visible = false;
            ((Vict)VictF).label3.Visible = false;
            ((Vict)VictF).label5.Visible = false;
            ((Vict)VictF).dataGridView1.Visible = false;

            ((Vict)VictF).button1.Visible = true;
            ((Vict)VictF).label4.Visible = true;
            ((Vict)VictF).label2.Visible = true;
            ((Vict)VictF).checkBox1.Visible = true;
            ((Vict)VictF).checkBox2.Visible = true;
            ((Vict)VictF).checkBox3.Visible = true;
            ((Vict)VictF).checkBox4.Visible = true;
        }

        //public static bool Did_you_answer_correctly_one_question(CheckBox checkBox_right, CheckBox checkBox_choose_user)  //Вроде старый способ проверки одно ответа
        //{
        //    System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
        //    if (checkBox_right == checkBox_choose_user)
        //    {
        //        User_data.question++;
        //        ((Vict)VictF).label4.Text = "Верно";       
        //        ((Vict)VictF).label4.ForeColor = Color.Green;
        //        User_data.points++;
        //        return true;
        //    }
        //    else
        //    {
        //        ((Vict)VictF).label4.Text = "Неверно";
        //        ((Vict)VictF).label4.ForeColor = Color.Red;
        //        User_data.question++;
        //        return false;
        //    }
        //}       //Верно ли ответил пользователь? (вопрос с одним вариантом ответа


    }
}
