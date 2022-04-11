using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{   
    [SerializeField] float crashDelay = .5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    CircleCollider2D playerHead;

    private void Start() 
    {
        playerHead = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        Collider2D otherCollider = other.gameObject.GetComponent<Collider2D>();
        if (other.gameObject.tag == "Ground" && playerHead.IsTouching(otherCollider) && FindObjectOfType<PlayerController>().GetCanMove())
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", crashDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);        
    }
}
