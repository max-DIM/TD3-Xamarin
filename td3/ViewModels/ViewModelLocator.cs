using System;
using GalaSoft.MvvmLight.Ioc;

namespace td3.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            // OU
            //Xamarin.Forms.DependencyService.Register<MainViewModel>();
            SimpleIoc.Default.Register<UtilisateursViewModel>();
        }

        // OU
        //public MainViewModel Main => Xamarin.Forms.DependencyService.Get<MainViewModel>();

        public UtilisateursViewModel Main => SimpleIoc.Default.GetInstance<UtilisateursViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels  
        }
    }
}