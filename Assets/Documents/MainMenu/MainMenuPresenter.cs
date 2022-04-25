using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using System.Threading.Tasks;
using VContainer;

public class MainMenuPresenter : IStartable, IAsyncStartable
{
    private const float flashInterval = 0.1f;
    readonly MusicPlayer musicPlayer;
    readonly MainMenu mainMenu;
    readonly MainMenuSettings mainMenuSettings;
    readonly SceneLoader sceneLoader;

    public MainMenuPresenter(MusicPlayer musicPlayer,
                             MainMenu mainMenu,
                             MainMenuSettings mainMenuSettings,
                             SceneLoader sceneLoader)
    {
        this.musicPlayer = musicPlayer;
        this.mainMenu = mainMenu;
        this.mainMenuSettings = mainMenuSettings;
        this.sceneLoader = sceneLoader;
    }

    public void Start()
    {
        mainMenu.Start.clicked += () =>
        {
            sceneLoader.LoadSceneAsync("MainGame");
        };
        mainMenu.Help.clicked += () =>
        {
            Debug.Log("Help pressed");
        };
        mainMenu.Credits.clicked += () =>
        {
            Debug.Log("Credits pressed");
        };
        musicPlayer.Play(4);
    }

    public async UniTask StartAsync(CancellationToken cancellation)
    {
        await FlashBackground(cancellation);
    }


    async UniTask FlashBackground(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(5));
            for (int i = 0; i < 5; i++)
            {
                await Flash();
            }
        }
    }

    private async Task Flash()
    {
        ToFlashBackground();
        await UniTask.Delay(TimeSpan.FromSeconds(flashInterval));
        ToOringalBackground();
        await UniTask.Delay(TimeSpan.FromSeconds(flashInterval));
    }

    private void ToFlashBackground()
    {
        mainMenu.Background.style.backgroundImage = new StyleBackground(mainMenuSettings.FlashBackground);
    }

    private void ToOringalBackground()
    {
        mainMenu.Background.style.backgroundImage = new StyleBackground(mainMenuSettings.OriginalBackground);
    }
}
