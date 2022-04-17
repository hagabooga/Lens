using System.Collections;
using UnityEngine.SceneManagement;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class SceneLoader
{
    readonly LifetimeScope parent;
    readonly LoadingBar loadingBar;

    public SceneLoader(LifetimeScope lifetimeScope, LoadingBar loadingBar)
    {
        parent = lifetimeScope;
        this.loadingBar = loadingBar;
    }

    public async UniTask LoadSceneAsync(string sceneName)
    {
        var loadSceneProgressBar = LoadSceneAsyncWithProgressBar(sceneName);
        await loadSceneProgressBar;
        loadingBar.Root.style.display = DisplayStyle.None;
    }

    async UniTask LoadSceneAsyncWithProgressBar(string sceneName)
    {
        using (LifetimeScope.EnqueueParent(parent))
        {
            loadingBar.Root.style.display = DisplayStyle.Flex;
            var progress = Progress.Create<float>(x =>
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