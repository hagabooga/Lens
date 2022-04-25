using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

public class ThoughtWorld : World
{
    public readonly VisualElement Mask, Content;

    public ThoughtWorld(VisualElement root) : base(root)
    {
    }

}
