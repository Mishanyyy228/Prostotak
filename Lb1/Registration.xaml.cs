using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Lb1
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private InputValidator validator;
        public Registration()
        {
            InitializeComponent();
            Name_user.Text = "Введите имя пользователя";
            Pass_user.Text = "Введите пароль";
            Email_user.Text = "Введите почту";
            Pass_user1.Text = "Повторите пароль";
            validator = new InputValidator();
        }

        private void Name_user_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (Name_user.Text == "Введите имя пользователя")
            {
                Name_user.Text = string.Empty;
                Name_user.Foreground = Brushes.Black;
            }
        }

        private void Email_user_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Email_user.Text == "Введите почту")
            {
                Email_user.Text = string.Empty;
                Email_user.Foreground = Brushes.Black;
            }
        }

        private void Pass_user_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Pass_user.Text == "Введите пароль")
            {
                Pass_user.Text = string.Empty;
                Pass_user.Foreground = Brushes.Black;
            }
        }

        private void Pass_user1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Pass_user1.Text == "Повторите пароль")
            {
                Pass_user1.Text = string.Empty;
                Pass_user1.Foreground = Brushes.Black;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window w2 = new LogIn();
            Hide();
            w2.Show();
        }
        public class InputValidator
        {
            public bool ValidateEmail(string email)
            {
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, emailPattern);
            }

            public bool ValidatePassword(string password)
            {
                return password.Length >= 6;
            }

            public bool ValidateName(string name)
            {
                return name.Length >= 3;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string email = Email_user.Text;
            string password = Pass_user.Text;
            string name = Name_user.Text;
            string password1 = Pass_user1.Text;

            bool isEmailValid = validator.ValidateEmail(email);
            bool isPasswordValid = validator.ValidatePassword(password);
            bool isNameValid = validator.ValidateName(name);
            bool isPasswordValid1 = validator.ValidatePassword(password1);

            if (!isEmailValid | !isPasswordValid | !isNameValid)
            {
                if (!isEmailValid)
                {
                    MessageBox.Show("Некорректный формат почты.");
                }
                else if (!isPasswordValid)
                {
                    MessageBox.Show("Пароль должен быть не менее 6 символов.");
                }
                else if (!isPasswordValid1)
                {
                    MessageBox.Show("Пароль должен быть не менее 6 символов.");
                }
                else if (!isNameValid)
                {
                    MessageBox.Show("Имя должно содержать не менее 3 символов.");
                }
                else if(Pass_user.Text != Pass_user1.Text)
                {
                    MessageBox.Show("Пароли должны совпадать");
                }
            }
            else if (Pass_user.Text == Pass_user1.Text)
            {
                

                Window w2 = new Main();
                Hide();
                w2.Show();
            }
            else
            {
                MessageBox.Show("Пароли должны совпадать");
            }
        }
    }
}
