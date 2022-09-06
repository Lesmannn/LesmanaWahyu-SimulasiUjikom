using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Theme : MonoBehaviour
{
    [SerializeField] private Button[] _themeButtons;
    [SerializeField] private GameObject[] _lockPanel;
    [SerializeField] private TextMeshProUGUI[] _costText;

    private void Awake()
    {
        for (int i = 0; i < _themeButtons.Length; i++)
        {
            int tempIndex = i;
            int cost = (tempIndex - 1) * 100;
            _themeButtons[i].onClick.AddListener(() => OnSelectTheme(tempIndex));
            _costText[i].text = cost.ToString() + "G";
        }
    }

    private void Update()
    {
        for (int i = 0; i < _themeButtons.Length; i++)
        {
            /*if (SaveData.saveInstance.boughtTheme[i])
            {
                _lockPanel[i].SetActive(false);
            }*/
        }
    }

    private void OnSelectTheme(int index)
    {
        //SaveData.saveInstance.ChangeCurrentTheme(index);
    }
}
