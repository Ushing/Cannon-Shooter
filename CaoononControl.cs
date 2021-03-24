using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaoononControl : MonoBehaviour
{

    //Cannon Rotation
    public Transform xTower;
    public Transform yCannon;
    public float xTowerSpeed;
    public float yCannonSpeed;
    float xTowerAngle;
    float yCannonAngle;

    //Cannon Ball
    public GameObject cannonBall;
    Rigidbody cannonballRb;
    public Transform shotPos;
    public GameObject explosion;
    public float firepower;

    //audio
     AudioSource audioSouce;
    public AudioClip audioClip;

    //Cannon Control
    public GameObject cannon;
    public GameObject shot;

    //touch Control
    private Touch touch;

    // Ammo
    public int Ammo =15;
    public Text ammoDisplay;

    public GameObject restart;
    public GameObject Panel;


    void Start()
    { 
        audioSouce = this.GetComponent<AudioSource>();
    }

    public void Update()
    {
        ammoDisplay.text = Ammo.ToString();
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                xRotatedTower();
                yRotatedCannon();
            }
        }

        if (shot == GameObject.FindWithTag("Shotting"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                FireCannon();
                audioSouce.PlayOneShot(audioClip, 1f);
            }
        }
    }
    void xRotatedTower()
    {
        xTowerAngle += touch.deltaPosition.x * xTowerSpeed * Time.fixedDeltaTime;
        xTowerAngle = Mathf.Clamp(xTowerAngle, -40, 40);
        xTower.localRotation = Quaternion.AngleAxis(xTowerAngle, Vector3.up);
    }
    void yRotatedCannon()
    {
        yCannonAngle -= touch.deltaPosition.y * yCannonSpeed * Time.fixedDeltaTime;
        yCannonAngle = Mathf.Clamp(yCannonAngle, -30, 30);
        yCannon.localRotation = Quaternion.AngleAxis(yCannonAngle, Vector3.right);
    }
    public void FireCannon()
    {
        audioSouce.PlayOneShot(audioClip, 1f);
        GameObject cannonBallCopy = Instantiate(cannonBall, shotPos.position, transform.rotation) as GameObject;
        cannonballRb = cannonBallCopy.GetComponent<Rigidbody>();
        cannonballRb.AddForce(transform.forward * firepower);
        Instantiate(explosion, shotPos.position, shotPos.rotation);
        Ammo--;

        if(Ammo == 0)
        {
            restart.SetActive(true);
            Panel.SetActive(true);
        }
    }
}
