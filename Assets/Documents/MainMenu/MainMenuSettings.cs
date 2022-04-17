using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Lens Settings/Main Menu")]
public class MainMenuSettings : ScriptableObject
{
    [SerializeField] Sprite flashBackground;

    public Sprite FlashBackground => flashBackground;


}
