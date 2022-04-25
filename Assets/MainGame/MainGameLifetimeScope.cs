using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;


public class MainGameLifetimeScope : LifetimeScope
{
    [SerializeField] UIDocument realWorld, thoughtWorld;
    [SerializeField] MainGameSettings mainGameSettings;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(mainGameSettings);
        var real = new World(realWorld.rootVisualElement);
        var thought = new ThoughtWorld(thoughtWorld.rootVisualElement);
        var realPresenter = new WorldPresenter(real, mainGameSettings);
        var thoughtPresenter = new WorldPresenter(thought, mainGameSettings);

        builder.RegisterEntryPoint<BothWorldsPresenter>()
            .WithParameter(new List<WorldPresenter>() { realPresenter, thoughtPresenter })
            .WithParameter(thought);
    }
}
