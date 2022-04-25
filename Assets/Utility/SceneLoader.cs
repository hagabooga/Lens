using System.Collections;
using UnityEngine.SceneManagement;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.Collections.Generic;

public class SceneLoader
{
    readonly Stack<string> loadedScenes = new Stack<string>();

    readonly LifetimeScope parent;
    readonly LoadingBar loadingBar;
    readonly MusicPlayer musicPlayer;


    public SceneLoader(LifetimeScope lifetimeScope,
                       LoadingBar loadingBar,
                       MusicPlayer musicPlayer)
    {
        parent = lifetimeScope;
        this.loadingBar = loadingBar;
        this.musicPlayer = musicPlayer;
    }

    public async UniTask LoadSceneAsync(string sceneName, bool unloadCurrentScene = true)
    {
        var loadSceneProgressBar = LoadSceneAsyncWithProgressBar(sceneName, unloadCurrentScene);
        await loadSceneProgressBar;
        loadingBar.Root.style.display = DisplayStyle.None;
    }

    async UniTask LoadSceneAsyncWithProgressBar(string sceneName, bool unloadCurrentScene)
    {
        using (LifetimeScope.EnqueueParent(parent))
        {
            musicPlayer.Stop();
            IProgress<float> progress;
            if (unloadCurrentScene)
            {
                string currentScene = loadedScenes.Peek();
                progress = Progress.Create<float>(x =>
                {
                    loadingBar.ProgressBar.value = x;
                    loadingBar.ProgressBar.title = $"Unloading {currentScene}... {(x * 100):N2}%";
                });
                await SceneManager.UnloadSceneAsync(currentScene).ToUniTask(
                    progress);
            }
            loadedScenes.Push(sceneName);
            loadingBar.Root.style.display = DisplayStyle.Flex;
            progress = Progress.Create<float>(x =>
            {
                loadingBar.ProgressBar.value = x;
                loadingBar.ProgressBar.title = $"Loading {sceneName}... {(x * 100):N2}%";
            });
            var task = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive)
                .ToUniTask(progress);
            await task;
        }
    }
}