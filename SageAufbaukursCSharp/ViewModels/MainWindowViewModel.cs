using SageAufbaukursCSharp.ServiceImplementations;
using SageAufbaukursCSharp.Services;

namespace SageAufbaukursCSharp.ViewModels
{
    

    public class MainWindowViewModel : ViewModelBase
    {

        #region services
        private readonly IPartnerUtil _partnerUtilService = new PartnerUtilImpl();
        #endregion services

        #region public properties
        private bool _isConnected;
        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                _isConnected = value;
                NotifyPropertyChanged(nameof(IsConnected));
            }
        }
        #endregion public properties

        #region commands
        public ActionCommand ToggleArgumentCommand { get; set; }
        public ActionCommand TestCommand { get; set; }
        #endregion commands

        #region constructors
        public MainWindowViewModel()
        {
            ToggleArgumentCommand = 
                new ActionCommand
                (
                    x => true, 
                    (x) => 
                    {
                        ;
                    });
            TestCommand =
                new ActionCommand
                (
                    x => true,
                    (x) =>
                    {
                        ;//Test
                    });
        }
        #endregion constructors
    }
}
