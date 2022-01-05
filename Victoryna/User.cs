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

namespace Victoryna
{
    [Serializable]
    enum Test
    {
        Geography,
        History,
        Biology,
        Random_questions
    }

    public struct User
    {
        public string login;
        public string password;
        public string Date_of_Birthday;
        public int points_History;
        public int points_Biology;
        public int points_Geography;
        public int points_Random;
    }

    public static class User_data
    {
        public static int count { get { return User_list.Count; } }

        public static List<User> User_list = new List<User>();
        public static string join_login;
        public static int ID = 0;
        public static int counter = 0;
        public static int t;    //Выбранная тема
        public static int[] Random_number = new int[21];
        public static int question = 1;
        public static int all_points = 0;
        public static int points_History = 0;
        public static int points_Biology = 0;
        public static int points_Geography = 0;
        public static int points_Random = 0;
        public static int points = 0;
    }

    public static class Forms
    {
        public static Registration registrationForm = new Registration();
        public static Vict vict = new Vict();
    }

    public static class Functions_with_user   //Класс для взаимодействия с пользователем
    {
        public static string Join()
        {
            System.Windows.Forms.Form JoinF = System.Windows.Forms.Application.OpenForms["JoinForm"];
            Functions.Deserializible_func();
            if ((((JoinForm)JoinF).textBox1.Text == "") && (((JoinForm)JoinF).textBox2.Text == ""))
            {
                Functions.error = text_data.strings[(int)DATA_SET.Empty_log_or_password];
                return Functions.error;
            }
            else if (Join_func.Correct_log_and_pass(((JoinForm)JoinF).textBox1.Text, ((JoinForm)JoinF).textBox2.Text) == null)      //Верно ли введен логин и пароль
            {
                User_data.join_login = ((JoinForm)JoinF).textBox1.Text;
                ((JoinForm)JoinF).Hide();
                Forms.vict.Show();
                return null;
            }
            else
            {
                Functions.error = text_data.strings[(int)DATA_SET.incorrect_login_or_password];
                return Functions.error;
            }
        }
        public static string Registrated()
        {
            Functions.Deserializible_func();  //Десерилизировать
            DateTime thisTime = DateTime.Today;
            string login = Forms.registrationForm.textBox1.Text;
            string password = Forms.registrationForm.textBox2.Text;
            string password_two = Forms.registrationForm.textBox3.Text;
            if (!Registration_func.Check_too_login(login))        //Проверка на такой же логин
            {
                //rror = text_data.strings[(int)DATA_SET.login_error_text];

                return Properties.Resources.login_error_text;

                //return error;
            }
            else
            {
                if ((Registration_func.Check_Validation_Login(login) == null) && (Registration_func.Check_Validation_Password(password) == null) && (Registration_func.Check_too_password(password, password_two) == null) && (Registration_func.Check_Happy_Birthday() == null))     //Если все норм зарегались, т.е. логин и пароль подходят по дресс-коду
                {
                    string wake_up = Forms.registrationForm.monthCalendar1.SelectionRange.Start.ToShortDateString();
                    thisTime = DateTime.Now;
                    string text_for_import_in_the_file = $"Логин: {Forms.registrationForm.textBox1.Text}  Пароль: {Forms.registrationForm.textBox2.Text}  Дата рождения: {wake_up}  Время регистрации: {thisTime}";
                    password = Functions.Hash(Forms.registrationForm.textBox2.Text);
                    User_data.User_list.Add(new User { login = Forms.registrationForm.textBox1.Text, password = password, Date_of_Birthday = wake_up });

                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    path = Path.Combine(path, "thissystem.txt");

                    Functions.Serializible_func();    //Сериализировать
                    Forms.registrationForm.Hide();
                    return null;
                }
                else
                {
                    return Functions.error;
                }
            }
        }
    }
}
