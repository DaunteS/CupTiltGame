using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public Text win;
    public Text lose;
    public Text gameTimer;
    public Text tutorial;
    public float Timer = 10f;
    public AudioClip winS;
    public AudioClip loseS;
    public AudioClip music;
    public AudioClip tutorialS;
    public AudioSource musicSource;
    int playing;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = tutorialS;
        musicSource.Play();
        musicSource.loop = true;
        rigidbody2D = GetComponent<Rigidbody2D>();
        playing = 0;
        Time.timeScale = 0;
       tutorial.text = "Get the ball out of the cup! A to tilt left. D to lilt right. Press Space to start!";
    }
    void Update()
    {
        if(playing == 0)
        {
 if(Input.GetKey(KeyCode.Space))
        {
            musicSource.clip = music;
            musicSource.Play();
            Time.timeScale = 1;
             tutorial.text = "";
             playing = 1;
            
           
        }
        }
        
        Timer -= Time.deltaTime;
        gameTimer.text = Timer.ToString("N0");
    
    if(Input.GetKey(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
    }
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "hand")
        {
            musicSource.clip = winS;
            musicSource.loop = false;
            musicSource.Play();
            win.text = "You win!";
            Time.timeScale = 0;
        }
    }
     void FixedUpdate()
    {
        if(Timer < 0)
        {
            musicSource.clip = loseS;
            musicSource.loop = false;
            musicSource.Play();
            lose.text = "You lose... press R to restart";
            Time.timeScale = 0;
            
        }
    }
}
