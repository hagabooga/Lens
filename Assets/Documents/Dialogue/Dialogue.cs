using UnityEngine.UIElements;

public class Dialogue : ExplicitVisualTree
{
    public readonly VisualElement Arrow;
    public readonly Button Settings;
    public readonly Label SpeakerName, Text;

    public Dialogue(VisualElement root) : base(root)
    {

    }

}