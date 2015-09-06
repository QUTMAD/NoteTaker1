using Cirrious.CrossCore.IoC;
using NoteTaker1.Data;
using NoteTaker1.Data.ViewModels;

namespace NoteTaker1
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
		public static string PageNamespace { get; private set; }

		public App()
		{
			PageNamespace = this.GetType().Namespace + ".Pages";
		}
		public override void Initialize()
		{
			// Mvx default registration here

			// Register all ContentPages
			this.CreatableTypes()
				.EndingWith("Page")
				.InNamespace(PageNamespace)
				.AsTypes()
				.RegisterAsDynamic();

			this.RegisterAppStart<NoteListViewModel>();
		}

    }
}