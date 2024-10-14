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
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private InputValidator validator;
        public LogIn()
        {
            InitializeComponent();
            Pochta_user11.Text = "mananev13@gmal.com";
            Password_user11.Text = "Введите пароль";
            validator = new InputValidator();
        }

        private void Pochta_user11_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Pochta_user11.Text == "mananev13@gmal.com")
            {
                Pochta_user11.Text = string.Empty;
                Pochta_user11.Foreground = Brushes.Black;
            }
        }

        private void Password_user11_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Password_user11.Text == "Введите пароль")
            {
                Password_user11.Text = string.Empty;
                Password_user11.Foreground = Brushes.Black;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window w2 = new Registration();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string email = Pochta_user11.Text;
            string password = Password_user11.Text;

            bool isEmailValid = validator.ValidateEmail(email);
            bool isPasswordValid = validator.ValidatePassword(password);

            if (!isEmailValid | !isPasswordValid)
            {
                if (!isEmailValid)
                {
                    MessageBox.Show("Некорректный формат почты.");
                }
                else if (!isPasswordValid)
                {
                    MessageBox.Show("Пароль должен быть не менее 6 символов.");
                }
                else
                {
                    MessageBox.Show("Все поля валидны!");
                }
            }
            else
            {
                Window w2 = new Main();
                Hide();
                w2.Show();
            }
        }
    }
    }

