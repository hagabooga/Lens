using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] List<AudioClip> clips;
    [SerializeField] AudioSource audioSource;

    public void Stop()
    {
        audioSource.Stop();
    }


    public void Play(int i, bool loop = true)
    {
        audioSource.clip = clips[i];
        audioSource.Play();
        audioSource.loop = loop;
    }

    void OnValidate()
    {
        clips = Directory.GetFiles("Assets/Music")
            .Where(x => x.EndsWith(".mp3") || x.EndsWith(".wav"))
            .Select(x => AssetDatabase.LoadAssetAtPath<AudioClip>(x))
            .OrderBy(x => x.name)
            .ToList();
    }
}
