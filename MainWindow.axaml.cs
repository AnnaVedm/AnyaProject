using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnyaProject
{
    public partial class MainWindow : Window
    {
        User user = new User();
        ProductsWindow w = new ProductsWindow();
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void VoitiVAkkaynt(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Name.Text)) //Если строка непустая, то проверяем наш список на наличие этих полей
            {
                User proverka = w.Users.FirstOrDefault(u => u.UserName == Name.Text && u.UserPassword == Password.Text);

                if (proverka != null)
                {
                    // Вход выполнен успешно
                    Oshibka.Text = null;
                    ProductsWindow wp = new ProductsWindow(proverka);
                    wp.Show();
                }
                else
                {
                    // Ошибка входа
                    Oshibka.Text = "Неверно введены данные";
                    Password.Clear();
                }
            }
        }
    }
}