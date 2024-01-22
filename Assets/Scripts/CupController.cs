using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CupController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public AudioClip left;
    public AudioClip right;
    public AudioSource soundSource;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
       if(Time.timeScale == 1)
       {
        if(Input.GetKey(KeyCode.A))
        {
            soundSource.clip = left;
            soundSource.Play();
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            soundSource.clip = right;
            soundSource.Play();
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
       }
        
    }
   
}
