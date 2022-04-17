using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

public class MainLifetimeScope : LifetimeScope
{
    [SerializeField] MusicPlayer musicPlayer;
    [SerializeField] UIDocument loadingBar;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(musicPlayer);



        builder.Register<LoadingBar>(Lifetime.Singleton).WithParameter(loadingBar.rootVisualElement);
        builder.Register<SceneLoader>(Lifetime.Singleton);


        builder.RegisterEntryPoint<Main>();
    }
}
