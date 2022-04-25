using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class World : ExplicitVisualTree
{
    public readonly VisualElement Characters, Dialogue;

    public Characters TheCharacters { get; }
    public Dialogue TheDialogue { get; }

    public World(VisualElement root) : base(root)
    {
        TheCharacters = new Characters(Characters);
        TheDialogue = new Dialogue(Dialogue);
    }
}
