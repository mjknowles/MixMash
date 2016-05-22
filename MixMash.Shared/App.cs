using AutoMapper;
using MixMash.Shared.BL;
using MixMash.Shared.BL.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace MixMash.Shared
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterSingleton<IMapper>(Bootstrapper.AutoMapper());
            CreatableTypes()
                .EndingWith("Client")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //RegisterAppStart<ViewModels.FirstViewModel>();
            RegisterAppStart<AuthenticationViewModel>();
        }
    }
}
