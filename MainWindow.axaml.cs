using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.ObjectModel;

namespace AnyaProject
{
    public partial class MainWindow : Window
    {
        private Border collapsiblePanel;
        //public bool IsPanelVisible { get; set; } = false;

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
                UserPassword = "Don't fucking touch my crucifixes!",
                UserStatus = "Thief"
            }
        };

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            ProductsWindow w = new ProductsWindow();
        }

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
    }
}