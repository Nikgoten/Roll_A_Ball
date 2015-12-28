using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    public static event Action<RaycastHit> EventChangedGravity;


    public float speed;
    public Text countText;
    public Text winText;
    public float jumpHeight;

    public Rigidbody rb;

    private int count;
    private bool isFalling = false;

    Camera mainCam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";

        mainCam = Camera.main;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = mainCam.transform.forward * moveVertical + mainCam.transform.right * moveHorizontal;

        rb.AddForce(movement * speed);
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isFalling == false)
        {
            rb.AddForce(-Physics.gravity.normalized * jumpHeight );
            isFalling = true;
        }
    }
  

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            winText.text = "You Win!";
        }
    }

    void OnCollisionEnter(Collision EventCol)
    {
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