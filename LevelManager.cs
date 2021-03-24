using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
 
    public Button[] levelButton;
    

    private void Start()
    {
        int CurrentLevel = PlayerPrefs.GetInt("CurrentLevel", 2);

        for (int i = 0; i < levelButton.Length; i++)
        {
            if (i + 2 > CurrentLevel)
            {
                levelButton[i].interactable = false;
            }
        }

    }


    //for button open level
    public void ChangeLevel(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);

    }
}
