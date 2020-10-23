using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float timeStart = 0;

    public Text timerText;
    public Text countText;
    public Text winText;

    bool timerRunning = false;

    public AudioClip Pickup;


    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        
    }

    void FixedUpdate()
    {

        Timer();

        if (winText.text != "Well Done!")
        {
            float moveHor = Input.GetAxis("Horizontal");
            float moveVer = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHor, 0f, moveVer);

            rb.AddForce(movement * speed);

            TimerTrigger();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            GetComponent<AudioSource>().PlayOneShot(Pickup);
        }
    }

    void SetCountText()
    {
        countText.text = "Pick up: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "Well Done!";
            timerRunning = false;
        }
    }

    void Timer()
    {
        if (winText.text != "Well Done!")
        {
            timeStart += Time.deltaTime;
            timerText.text = timeStart.ToString("F2");
        }
    }

    void TimerTrigger()
    {
        timerRunning = !timerRunning;
    }
}


