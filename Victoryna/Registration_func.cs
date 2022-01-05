using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victoryna
{
    class Registration_func
    {
        public static string Check_too_password(string pas1, string pas2)           //Проверка совпадают ли пароли при регистрации
        {
            if (pas2 == "")
            {
                Functions.error = text_data.strings[(int)DATA_SET.Confirm_password];
                return Functions.error;
            }
            else if (pas1 != pas2)
            {
                Functions.error = text_data.strings[(int)DATA_SET.Error_confirm_password];
                return Functions.error;
            }
            else
            {
                return null;
            }
        }

        public static string Check_Validation_Login(string str)
        {
            bool done;
            if (str.All(a => Char.IsLetterOrDigit(a)))
            {
                if (str.Length >= 6) done = true;
                else done = false;

            }
            else done = false;

            if (done == false)
            {
                Functions.error = text_data.strings[(int)DATA_SET.incorrect_login];

                return Functions.error;
            }
            else return null;
        }

        public static string Check_Validation_Password(string str)
        {
            bool done;
            if (str.All(a => Char.IsLetterOrDigit(a)))
            {
                if (str.Length >= 6) done = true;
                else done = false;

            }
            else done = false;

            if (done == false)
            {
                Functions.error = text_data.strings[(int)DATA_SET.incorrect_password];

                return Functions.error;
            }
            else return null;
        }

        public static string Check_Happy_Birthday()
        {
            System.Windows.Forms.Form Reg = System.Windows.Forms.Application.OpenForms["Registration"];  //Для открытия текущей формы
            DateTime thisTime = DateTime.Today;
            if ((((Registration)Reg).monthCalendar1.SelectionRange.Start.ToString() == Convert.ToString(thisTime)))
            {
                Functions.error = text_data.strings[(int)DATA_SET.Error_Happy_Birthday];
                return Functions.error;
            }
            else if (Convert.ToDateTime(((Registration)Reg).monthCalendar1.SelectionRange.Start) > Convert.ToDateTime(thisTime))
            {
                Functions.error = text_data.strings[(int)DATA_SET.incorrect_Happy_Birthday];
                return Functions.error;
            }
            else
            {
                return null;
            }
        }

        public static bool Check_too_login(string last_login)
        {
            for (int i = 0; i < User_data.count; i++)
            {
                if (last_login == User_data.User_list[i].login)
                {
                    return false;
                }
            }
            return true;
        }

        public static void Default_data_after_closing()
        {
            DateTime thisTime = DateTime.Now;     //Чтоб календарь по умолчанию поставить на сегодняшний день
            Forms.registrationForm.textBox1.Text = "";
            Forms.registrationForm.textBox2.Text = "";
            Forms.registrationForm.textBox3.Text = "";
            Forms.registrationForm.label3.Text = "";
            Forms.registrationForm.monthCalendar1.SelectionRange.Start = thisTime;
            Forms.registrationForm.Hide();
        }
    }
}
