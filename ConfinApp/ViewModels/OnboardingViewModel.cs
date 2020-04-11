using System.Threading.Tasks;
using System.Windows.Input;
using ConfinApp.Helpers;
using ConfinApp.Services.Routing;
using Splat;
using Xamarin.Forms;

namespace ConfinApp.ViewModels
{
    class OnboardingViewModel : BaseViewModel
    {
        private IRoutingService _navigationService;
        private Color InitColor = Color.FromHex("#C8C8C8");
        private Color SelectColor = Color.FromHex("#CAC6D4");
        
        public OnboardingViewModel(IRoutingService navigationService = null)
        {
            _navigationService = navigationService ?? Locator.Current.GetService<IRoutingService>();
            ExecuteOmetre = new Command(() => Ometre());
            ExecuteContinuar = new Command(() => Continuar());
            ExecuteIndepKO = new Command(() => IndepKO());
            ExecuteIndepOK = new Command(() => IndepOK());
            ExecuteEsportKO = new Command(() => EsportKO());
            ExecuteEsportOK = new Command(() => EsportOK());

            BtnIndepKOColor = InitColor;
            BtnIndepOKColor = InitColor;
            BtnEsportKOColor = InitColor;
            BtnEsportOKColor = InitColor;

        }
        public ICommand ExecuteOmetre { get; set; }
        public ICommand ExecuteContinuar { get; set; }
        public ICommand ExecuteIndepKO { get; set; }
        public ICommand ExecuteIndepOK { get; set; }
        public ICommand ExecuteEsportKO { get; set; }
        public ICommand ExecuteEsportOK { get; set; }

        private Color _btnIndepKOColor;
        public Color BtnIndepKOColor
        {
            get => _btnIndepKOColor;
            set
            {
                _btnIndepKOColor = value;
                OnPropertyChanged();
            }
        }

        private Color _btnIndepOKColor;
        public Color BtnIndepOKColor
        {
            get => _btnIndepOKColor;
            set
            {
                _btnIndepOKColor = value;
                OnPropertyChanged();
            }
        }

        private Color _btnEsportKOColor;
        public Color BtnEsportKOColor
        {
            get => _btnEsportKOColor;
            set
            {
                _btnEsportKOColor = value;
                OnPropertyChanged();
            }
        }

        private Color _btnEsportOKColor;
        public Color BtnEsportOKColor
        {
            get => _btnEsportOKColor;
            set
            {
                _btnEsportOKColor = value;
                OnPropertyChanged();
            }
        }

        private async void Ometre()
        {
            Notify.ShowLoading();
            await Task.Delay(2000);

            await Shell.Current.GoToAsync("///main/avui");
            //_navigationService.NavigateTo("///main/avui");


            Notify.HideLoading();
        }

        private async void Continuar()
        {
            Notify.ShowLoading();
            await Task.Delay(2000);

            await Shell.Current.GoToAsync("///main/avui");
            //_navigationService.NavigateTo("///main/avui");

            Notify.HideLoading();
        }

        private void IndepKO()
        {
            BtnIndepKOColor = SelectColor;
            BtnIndepOKColor = InitColor;
        }

        private void IndepOK()
        {
            BtnIndepOKColor = SelectColor;
            BtnIndepKOColor = InitColor;
        }

        private void EsportKO()
        {
            BtnEsportKOColor = SelectColor;
            BtnEsportOKColor = InitColor;
        }

        private void EsportOK()
        {
            BtnEsportOKColor = SelectColor;
            BtnEsportKOColor = InitColor;
        }
    }
}
