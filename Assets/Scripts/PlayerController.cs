using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static event Action<RaycastHit> EventChangedGravity;

    public float speed;

    public AudioClip jumpSound;
    public AudioClip contactSound;
    public AudioClip jumpPad;
    public AudioClip go;

    public Canvas PauseMenu;

    private float volLowRange = 0.25f;
    private float volHighRange = 0.8f;
    

   
    public float jumpHeight;
    public float virtualAxisSpeedUp;
    public Vector3 movement;

    public Rigidbody rb;

    
    private bool isFalling = false;

    private float virtualVelocityAxis = 1f;

    public static AudioSource playerSound;

    Camera mainCam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;

        playerSound = GetComponent<AudioSource>();
        playerSound.PlayOneShot(go);

        Physics.gravity = new Vector3(0.0f, -9.81f, 0.0f);
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") != 0f)
        {
            virtualVelocityAxis += Time.deltaTime;
        }
        else
        {
            virtualVelocityAxis = 1f;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = mainCam.transform.forward * moveVertical * virtualVelocityAxis + mainCam.transform.right * moveHorizontal;

        rb.AddForce(movement * speed);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isFalling == false)
        {
            rb.AddForce(-Physics.gravity.normalized * jumpHeight );

            float vol = UnityEngine.Random.Range(volLowRange, volHighRange);
            playerSound.PlayOneShot(jumpSound, vol);
            

            isFalling = true;
        }
        
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("JumpPad"))
        {
            float vol = UnityEngine.Random.Range(volLowRange, volHighRange);
            playerSound.PlayOneShot(jumpPad, vol);

            // makes the player jump by contact

            rb.AddForce(-Physics.gravity.normalized * 1200);
            isFalling = true;

            
        }
       
    }


    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("PlayArea"))
        {
            
            TimeCounter.time = 0f;
            SceneManager.LoadScene("Game Over");

        }
    }

   

    void OnCollisionEnter(Collision EventCol)
    {
        float vol = UnityEngine.Random.Range(volLowRange, volHighRange);
        playerSound.PlayOneShot(contactSound, vol);

        if (EventCol.gameObject.tag == "GravityChange")
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (EventCol.contacts[0].point - transform.position),out hit))
            {
                Physics.gravity = hit.normal * -9.81f;

                Quaternion TargetRot = Quaternion.AngleAxis(-Vector3.Angle(hit.normal, transform.up), Vector3.Cross(hit.normal, transform.up).normalized) * transform.rotation;
                transform.rotation = TargetRot;

                if (EventChangedGravity != null)
                {
                    EventChangedGravity(hit);
                }
            }
        }

        isFalling = false;
    }
}