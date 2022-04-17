using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : ExplicitVisualTree
{
    public readonly VisualElement Background;
    public readonly Button Start, Credits, Help;

    public MainMenu(VisualElement root) : base(root)
    {
    }
}
