using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

public class Main : IAsyncStartable
{
    readonly LoadingBar loadingBar;
    readonly SceneLoader sceneLoader;

    public Main(SceneLoader sceneLoader, LoadingBar loadingBar)
    {
        this.sceneLoader = sceneLoader;
        this.loadingBar = loadingBar;
    }

    public async UniTask StartAsync(CancellationToken cancellation)
    {
        UniTask uniTask = sceneLoader.LoadSceneAsync("MainMenu");
        await uniTask;
    }
}
