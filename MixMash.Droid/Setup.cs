using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MixMash.Shared;
using MvvmCross.Platform;
using MixMash.Shared.DL.Clients;
using MixMash.Droid.Data;

namespace MixMash.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            Mvx.RegisterSingleton<ISqlLiteConnectionFactory>(new SqlLiteConnectionFactory());
            base.InitializeFirstChance();
        }
    }
}
