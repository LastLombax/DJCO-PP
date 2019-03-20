using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject creditsBackground;
    public GameObject background;
    public GameObject playButton;
    public GameObject creditsButton;

    public GameObject exitButton;
    public GameObject backButton;

    public void GoToCredits()
    {
        background.SetActive(false);
        playButton.SetActive(false);
        creditsButton.SetActive(false);
        exitButton.SetActive(false);
        creditsBackground.SetActive(true);
        backButton.SetActive(true);
    }

    public void CloseCredits()
    {
        background.SetActive(true);
        playButton.SetActive(true);
        creditsButton.SetActive(true);
        exitButton.SetActive(true);
        creditsBackground.SetActive(false);
        backButton.SetActive(false);
    }
}
