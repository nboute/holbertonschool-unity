using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;
using System.Threading.Tasks;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;
    public int health = 5;
    private bool canTeleport = true;
 
    public Text scoreText;

    public Text healthText;

    public Image winLoseUI;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            Destroy(other.gameObject);
            SetScoreText();
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            SetWin();
            StartCoroutine(LoadScene(3));
        }
        else if (other.gameObject.CompareTag("Teleporter") && canTeleport)
        {
            var teleporter = GameObject.FindGameObjectsWithTag("Teleporter").First(obj => obj != other.gameObject);
            transform.position = teleporter.transform.position;
            canTeleport = false;
            Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith(t => canTeleport = true);
        }
    }

    void Update()
    {
        if (health == 0)
        {
            SetLose();
            StartCoroutine(LoadScene(3));
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }

    void SetWin()
    {
        winLoseUI.gameObject.SetActive(true);
        winLoseUI.color = Color.green;
        winLoseUI.GetComponentInChildren<Text>().text = "You Win!";
        winLoseUI.GetComponentInChildren<Text>().color = Color.black;
    }

    void SetLose()
    {
        winLoseUI.gameObject.SetActive(true);
        winLoseUI.color = Color.red;
        winLoseUI.GetComponentInChildren<Text>().text = "Game Over!";
        winLoseUI.GetComponentInChildren<Text>().color = Color.white;
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
