using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayButton : MonoBehaviour
{
    [SerializeField] Button _backButton;

    private void Awake()
    {
        _backButton.onClick.RemoveAllListeners();
        _backButton.onClick.AddListener(OpenHome);
    }

    private void OpenHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
