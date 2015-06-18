using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using BaasBoxNet;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Unity;

namespace BBWPDemo
{
    public sealed partial class App : MvvmAppBase
    {
        private readonly BaasBox _baasBox = new BaasBox("10.211.55.8", "1234567890");
        private readonly IUnityContainer _container = new UnityContainer();

        public App()
        {
            InitializeComponent();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate(Experiences.Login.ToString(), null);
            return Task.FromResult<object>(null);
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            _container.RegisterInstance(_container);
            _container.RegisterInstance(NavigationService);
            _container.RegisterInstance(_baasBox);
            _container.RegisterInstance(_baasBox.UserManagement);
            return base.OnInitializeAsync(args);
        }

        protected override object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}