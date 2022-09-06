using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _themeButton;

    private void Awake()
    {
        _playButton.onClick.RemoveAllListeners();
        _playButton.onClick.AddListener(OpenGameplay);
        _themeButton.onClick.RemoveAllListeners();
        _themeButton.onClick.AddListener(OpenTheme);
    }

    private void OpenGameplay()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    private void OpenTheme()
    {
        SceneManager.LoadScene("ThemeScene");
    }
}
