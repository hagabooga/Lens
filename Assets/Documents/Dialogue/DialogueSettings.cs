using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Lens Settings/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [SerializeField] Backgrounds backgrounds;
    [SerializeField] CharacterInfo mc, cam, yun;

    public Backgrounds Backgrounds => backgrounds;
    public CharacterInfo Mc => mc;
    public CharacterInfo Cam => cam;
    public CharacterInfo Yun => yun;
}