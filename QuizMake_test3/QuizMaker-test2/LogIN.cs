using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizMaker_test2
{
    public partial class LogIN : Form
    {
        Quizmaker_Test3_CreateQuizEntities1 db = new Quizmaker_Test3_CreateQuizEntities1();
        User activeUser = new User();
        public LogIN()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string email = tbxEmail.Text;
            string pass = tbxPass.Text;

            if (IsEmailExist(email))
            {
                if (CheckPassWord(pass))
                {
                    db.Logs.Add(new Log()
                    {
                        User_Id = activeUser.UserId,
                        Log_IN = DateTime.Now,
                        LogStatus = true

                    });
                    db.SaveChanges();
                    if (CheckUserType())
                    {

                        Admin adminForm = new Admin();
                        adminForm.Show();
                    }
                    else
                    {
                        User2 userForm = new User2();
                        userForm.Show();
                    }


                }
            }
        }

        private bool CheckUserType()
        {
            if (activeUser.UserType_Id==1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool CheckPassWord(string pass)
        {
            if (activeUser.UserPassword== pass)
            {

               // MessageBox.Show(activeUser.UserPassword.ToString());
                return true;
            }
            else
            {
                MessageBox.Show("not match pass");
                return false;
            }
        }

        private bool IsEmailExist(string email)
        {
            if (db.Users.Any(user => user.UserEmail == email)){
                activeUser = db.Users.Where(user => user.UserEmail == email).First();
               // MessageBox.Show(activeUser.UserFullName.ToString());
                return true;
                
            }
            else
            {
                //  activeUser = null;
                MessageBox.Show("not match email");
                return false;
            }
        }

        
    }
}
