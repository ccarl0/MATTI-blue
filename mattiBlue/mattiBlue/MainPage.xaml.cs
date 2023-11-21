using mattiBlue.Helpers;
using mattiBlue.ViewModel;

namespace mattiBlue;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

