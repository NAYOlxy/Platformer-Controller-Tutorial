using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel playerDefeatedEventChannel;
    [SerializeField] AudioClip[] voice;

    [SerializeField] Button retryButton;
    [SerializeField] Button quitButton;

    void OnEnable()
    {
        playerDefeatedEventChannel.AddListener(ShowUI);

        retryButton.onClick.AddListener(SceneLoader.ReloadScene);
        quitButton.onClick.AddListener(SceneLoader.QuitGame);
    }

    void OnDisable()
    {
        playerDefeatedEventChannel.RemoveListener(ShowUI);

        retryButton.onClick.RemoveListener(SceneLoader.ReloadScene);
        quitButton.onClick.RemoveListener(SceneLoader.QuitGame);
    }

    private void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;

        AudioClip retryvoice = voice[Random.Range(0,voice.Length)];
        SoundEffectsPlayer.audioSource.PlayOneShot(retryvoice);

        Cursor.lockState = CursorLockMode.None;
    }
}
