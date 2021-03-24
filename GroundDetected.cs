using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundDetected : MonoBehaviour
{
    public HelthbarSCript healthBar;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grounded")
        {
            if(healthBar)
            {
                healthBar.OnTakeDamage(10);
            }
            
        }
    }
}
