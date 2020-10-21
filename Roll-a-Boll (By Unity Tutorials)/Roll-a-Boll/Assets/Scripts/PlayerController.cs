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


    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 8;
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
            count = count - 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count <= 0)
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


