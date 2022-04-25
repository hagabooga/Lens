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
    readonly SceneLoader sceneLoader;

    public Main(SceneLoader sceneLoader)
    {
        this.sceneLoader = sceneLoader;
    }

    public async UniTask StartAsync(CancellationToken cancellation)
    {
        UniTask uniTask = sceneLoader.LoadSceneAsync("MainMenu", false);
        await uniTask;
    }


}
