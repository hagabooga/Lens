using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Backgrounds", menuName = "Cameron's World/Backgrounds", order = 1)]
public class Backgrounds : ScriptableObject
{
    [Serializable]
    class RealThoughtBackgroundHolder
    {
        [SerializeField] Sprite realWorld, thoughtWorld;

        public RealThoughtBackgroundHolder(Sprite realWorld, Sprite thoughtWorld)
        {
            this.realWorld = realWorld;
            this.thoughtWorld = thoughtWorld;
        }

        public Sprite RealWorld { get => realWorld; }
        public Sprite ThoughtWorld { get => thoughtWorld; }
    }

    [Serializable]
    class RealThoughtBackgrounds : SerializableDictionary<string, RealThoughtBackgroundHolder> { }

    const string BackgroundsPath = "Assets/UI/Backgrounds";

    const string RealWorld = "RealWorld";
    const string ThoughtWorld = "ThoughtWorld";

    [SerializeField] RealThoughtBackgrounds backgrounds;

    RealThoughtBackgroundHolder AlarmClock => backgrounds["AlarmClock"];
    RealThoughtBackgroundHolder AlarmClockFinalScene => backgrounds["AlarmClockFinalScene"];
    RealThoughtBackgroundHolder Bedroom => backgrounds["Bedroom"];
    RealThoughtBackgroundHolder Cafe => backgrounds["Cafe"];
    RealThoughtBackgroundHolder LivingRoom => backgrounds["LivingRoom"];
    RealThoughtBackgroundHolder Outside => backgrounds["Outside"];


    void OnValidate()
    {
        Helper.GetFiles(out string folderPath, out IEnumerable<FileInfo> files, RealWorld, ".png", BackgroundsPath);
        foreach (var file in files)
        {
            var nameWithoutExtension = Path.GetFileNameWithoutExtension(file.Name);
            if (backgrounds.ContainsKey(nameWithoutExtension))
            {
                continue;
            }
            backgrounds.Add(nameWithoutExtension, new RealThoughtBackgroundHolder(
                AssetDatabase.LoadAssetAtPath<Sprite>(Path.Combine(folderPath, file.Name)),
                AssetDatabase.LoadAssetAtPath<Sprite>(Path.Combine(Path.Combine(BackgroundsPath, ThoughtWorld), file.Name))

            ));
        }
    }


}