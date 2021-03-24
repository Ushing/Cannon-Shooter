using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HelthbarSCript : MonoBehaviour
{
 

    public int LoadnextLevel;
    public Image healthBar;
    public float health;
    public float startHealth;

    private void Start()
    {
        LoadnextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void OnTakeDamage(int damage)
    {
        health = health - damage;
        healthBar.fillAmount = health / startHealth;
        if (healthBar.fillAmount == 0)
        {
            SceneManager.LoadScene(LoadnextLevel);
            if(LoadnextLevel > PlayerPrefs.GetInt("CurrentLevel"))
            {
                PlayerPrefs.SetInt("CurrentLevel", LoadnextLevel);
            }
            
        }
    }
}
