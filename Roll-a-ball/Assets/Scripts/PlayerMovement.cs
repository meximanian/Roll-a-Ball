using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;
    public static float count;
    private bool jumping;
    private bool loser;
    private bool winner;
    private float total;
    private float timeLeft;
    private float totalTime = 30f;
    private float delay = 5f;


    public float speed;
    public float jump;
    public Text countText;
    public Text winText;
    public Text loseText;
    public Text time;
    public Slider timeStatus;
    public Slider countStatus;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        loseText.text = "";
        jumping = true;
        total = 24;
        loser = true;
        winner = true;
        timeLeft = totalTime;
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey(KeyCode.Space))
        {
            if (jumping)
            {
                Vector3 movement2 = new Vector3(0, jump, 0);
                rb.AddForce(movement2);
                jumping = false;
            }
        }
    }

    void Update()
    {
        countStatus.value = AddPoint();
        timeStatus.value = Timer();
        SetCountText();
        SetTimeText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            jumping = true;
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 24 && winner)
        {
            winText.text = "You Win!!!";
            loser = false;
        }
    }

    float AddPoint()
    {
        return count / total;
    }

    void SetTimeText()
    {
        timeLeft -= Time.deltaTime;
        time.text = timeLeft.ToString();

        if (timeLeft <= 0)
        {
            time.text = "Times Up!!!";

            if (loser)
            {
                loseText.text = "You Lose!!!";
                winner = false;
                StartCoroutine(LoadLevelAfterDelay(delay));
            }
        }
    }

    float Timer()
    {
        return timeLeft / totalTime; ;
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Roll-a-Ball");
    }

}
