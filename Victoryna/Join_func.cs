using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victoryna
{
    class Join_func
    {
        public static string Correct_log_and_pass(string login, string password)
        {
            if (User_data.User_list.Count > 0)
            {
                for (int i = 0; i < User_data.User_list.Count; i++)
                {
                    if (login == User_data.User_list[i].login)        //поиск логина
                    {
                        if (User_data.User_list[i].password[User_data.User_list[i].password.Length - 1] == '=')   //Если последним символом являтся '=' значит это hash код и его
                        {
                            password = Functions.Hash(password);
                        }
                        if (password == User_data.User_list[i].password)  //поиск пароля
                        {
                            return null;
                        }
                    }
                }
            }
            else
            {
                Functions.error = text_data.strings[(int)DATA_SET.There_are_no_users];
                return Functions.error;
            }
            Functions.error = text_data.strings[(int)DATA_SET.incorrect_login_or_password];
            return Functions.error;
        }

    }
}
