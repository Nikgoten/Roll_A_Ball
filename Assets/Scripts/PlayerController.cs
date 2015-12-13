using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public float jumpHeight;

    public Rigidbody rb;
   
    private int count;
    private bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
       
        Vector3 movement = new Vector3(moveHorizontal, Time.deltaTime, moveVertical);

        rb.AddForce(movement * speed);

       if (Input.GetKeyDown(KeyCode.Space) && isFalling == false)    
        {    
        rb.velocity = new Vector3(moveHorizontal,jumpHeight, moveVertical);        
        }

    isFalling = true; 

}

    void OnCollisionStay()
{
    isFalling = false;

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
}