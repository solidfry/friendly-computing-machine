using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class ResetGameData : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] LevelList levels;

    private void Start()
    {
        if (levels.CheckAllComplete())
        {
            button.gameObject.SetActive(true);
        }
        else
        {
            button.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        button.onClick.AddListener(() => levels.ResetData());
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }
}

