using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class MainEditor
{
    [MenuItem("Lens/Run Main")]
    static void OpenScene()
    {
        if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            return;
        }
        EditorSceneManager.OpenScene("Assets/Main/Main.unity");
        EditorApplication.isPlaying = true;
    }
}
