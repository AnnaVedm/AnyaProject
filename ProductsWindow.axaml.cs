using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.ObjectModel;

namespace AnyaProject
{
    public partial class ProductsWindow : Window
    {
        private Border collapsiblePanel;
        private User queenUser;
        public ProductsWindow()
        {
            InitializeComponent();

            DataContext = this;
        }

        public ProductsWindow(User QueenUser)
        {
            InitializeComponent();
            DataContext = this;

            queenUser = QueenUser;

            this.Opened += ManagerUserWindow_WindowOpened;

            Button dobavitTovar = this.FindControl<Button>("DobavitTovar");
            Button deleteVibrannoe = this.FindControl<Button>("DeleteVibrannoe");

            if (queenUser.UserStatus == "Queen")
            {
                dobavitTovar.IsVisible = true;
                deleteVibrannoe.IsVisible = true;
            }
            else
            {
                dobavitTovar.IsVisible = false;
                deleteVibrannoe.IsVisible = false;
            }
        }

        private void ManagerUserWindow_WindowOpened(object? sender, EventArgs e)
        {
            // ��������� �������� �������� IsAdmin ��� ������� �������� � ProductsList
            foreach (var product in Products)
            {
                product.Otobrazhenie = queenUser.UserStatus == "Admin";
            }
        }

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>()
        {
            new Product()
            {
                Name = "����� ��� ������",
                Manufacturer = "EQUIMAN, �����",
                Description = "�������� ����� ��� ������. �������� ��� ����������� �������. �����: 370 ��. ������: 12 ��.",
                Price = 135,
                Stock = 321
            }
        };

        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>()
        {
            new User()
            {
                UserName = "Annushka",
                UserPassword = "1234",
                UserStatus = "Queen"
            },

            new User()
            {
                UserName = "Dzyuba",
                UserPassword = "1234",
                UserStatus = "Thief"
            }
        };

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            collapsiblePanel = this.FindControl<Border>("CollapsiblePanel");
        }

        private void TogglePanel_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // �������� ��������� ������
            collapsiblePanel.IsVisible = !collapsiblePanel.IsVisible;
        }

        private void Exit_ButtonClick(object sender, RoutedEventArgs e) //������ �������� ������� �� ���� �����������
        {
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
