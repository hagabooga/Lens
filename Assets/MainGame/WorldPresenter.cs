using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;


public class WorldPresenter
{
    public Dialogue Dialogue { get; }
    public Characters Characters { get; }
    public MainGameSettings MainGameSettings { get; }

    public WorldPresenter(World world,
                          MainGameSettings mainGameSettings)
    {
        Dialogue = world.TheDialogue;
        Characters = world.TheCharacters;
        MainGameSettings = mainGameSettings;
    }
}
