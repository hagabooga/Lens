using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadingBar : ExplicitVisualTree
{
    public readonly ProgressBar ProgressBar;

    public LoadingBar(VisualElement root) : base(root)
    {
    }
}
