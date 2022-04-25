using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;


public class BothWorldsPresenter : ITickable
{
    ThoughtWorld ThoughtWorld { get; }
    List<WorldPresenter> WorldPresenters { get; }

    public BothWorldsPresenter(List<WorldPresenter> worldPresenters,
                               ThoughtWorld thoughtWorld)
    {
        WorldPresenters = worldPresenters;
        ThoughtWorld = thoughtWorld;
    }

    public void Tick()
    {
        bool holdingShift = Input.GetKey(KeyCode.LeftShift);
        Cursor.visible = !holdingShift;
        if (holdingShift)
        {
            var position = Input.mousePosition;
            position.x -= ((int)ThoughtWorld.Mask.resolvedStyle.width) / 2;
            position.y = Screen.height - position.y;
            position.y -= ((int)ThoughtWorld.Mask.resolvedStyle.height) / 2;
            ThoughtWorld.Mask.transform.position = position;
            ThoughtWorld.Content.transform.position = -position;
        }
    }
}