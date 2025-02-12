using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using UI.Contents;

namespace UI.Views;

/// <summary>
/// Interaction logic for Home.xaml
/// </summary>
public partial class Home : Window
{
    private TextBlock[] SideMenuButtonTexts { get; set; }
    public Home()
    {
        InitializeComponent();
        SideMenuButtonTexts = [HomeButtonText, InvoicesButtonText, ProductsButtonText, CustomersButtonText];
    }

    private void Home_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
            DragMove();
    }

    private void CustomersButton_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var customersContent = new HomeCustomersContent();
        HomeBodyContent.Child = customersContent;

        ChangeSideMenuButtonsColors(CustomersButtonText, "PurpleBrush");

    }

    private void ProductsButton_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var productsContent = new HomeProductsContent();
        HomeBodyContent.Child = productsContent;

        ChangeSideMenuButtonsColors(ProductsButtonText, "PurpleBrush");
    }

    private void InvoicesButton_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var invoicesContent = new HomeInvoicesContent();
        HomeBodyContent.Child = invoicesContent;

        ChangeSideMenuButtonsColors(InvoicesButtonText, "PurpleBrush");
    }

    private void ChangeSideMenuButtonsColors(TextBlock item, string colorName)
    {
        var brush = (Brush)FindResource(colorName);
        item.Foreground = brush;

        foreach (var sideMenuButtonText in SideMenuButtonTexts)
        {
            if (sideMenuButtonText == item)
                continue;
                
            sideMenuButtonText.Foreground = Brushes.White;
        }
    }
}