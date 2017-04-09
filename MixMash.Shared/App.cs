using AutoMapper;
using MixMash.Shared.BL;
using MixMash.Shared.BL.Contracts;
using MixMash.Shared.BL.ViewModels;
using MixMash.Shared.DAL.Clients;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace MixMash.Shared
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            Bootstrapper.InitializeAutoMapper();
            RegisterAppStart<SeedSelectorViewModel>();
        }
    }
}
