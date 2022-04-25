using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Characters : ExplicitVisualTree
{
    public readonly VisualElement Background, CharacterLeft, CharacterRight;

    public Characters(VisualElement root) : base(root)
    {
    }
}
