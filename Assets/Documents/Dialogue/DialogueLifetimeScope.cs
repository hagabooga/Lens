using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;


public class DialogueLifetimeScope : LifetimeScope
{
    [SerializeField] UIDocument dialogue;
    [SerializeField] DialogueSettings dialogueSettings;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(dialogueSettings);

        builder.Register<Dialogue>(Lifetime.Singleton);


    }
}
