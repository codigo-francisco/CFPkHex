using CFPkHex.Backend.Repository;
using CFPkHex.MAUI.Pages.GenOne;
using CFPkHex.MAUI.ViewModels;
using CommunityToolkit.Maui.Storage;

namespace CFPkHex.MAUI
{
    public partial class MainPage : ContentPage
    {
        private IRepository? _repository;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        private async void AddMaxCandiesBtn_Clicked(object sender, EventArgs e)
        {
            _repository?.AddMaxCandies();

            await DisplayAlert("Alerta", "Caramelos raros agregados", "Ok");
        }

        private async void LoadFileBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GenOnePage());

            /*var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select a Save File"
            });

            if (result != null)
            {
                var viewModel = BindingContext as MainPageViewModel;
                var builderRepository = viewModel?.BuilderRepository;

                using var stream = await result.OpenReadAsync();
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);

                _repository = builderRepository?.GetRepository(ms.ToArray(), result.FileName);

                await DisplayAlert("Alerta", "Archivo cargado correctamente", "Ok");

                
            }
            else
            {
                await DisplayAlert("Alerta", "No seleccionó ningún archivo", "Ok");
            }*/
        }

        private async void SaveFileBtn_Clicked(object sender, EventArgs e)
        {
            if (_repository != null)
            {
                var fileName = _repository.FileName;
                var ms = new MemoryStream(_repository.SaveFile.Data);
                var result = await FileSaver.Default.SaveAsync(fileName, ms);

                if (result.IsSuccessful)
                {
                    await DisplayAlert("Alerta", "Exportado", "Ok");
                }
                else
                {
                    await DisplayAlert("Alerta", "No Exportado", "Ok");
                }
            }

        }
    }
}
