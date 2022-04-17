using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

public class MainMenuLifetimeScope : LifetimeScope
{
    [SerializeField] UIDocument mainMenu;
    [SerializeField] MainMenuSettings mainMenuSettings;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(mainMenuSettings);

        builder.Register<MainMenu>(Lifetime.Singleton).WithParameter(mainMenu.rootVisualElement);


        builder.RegisterEntryPoint<MainMenuPresenter>();
    }
}
