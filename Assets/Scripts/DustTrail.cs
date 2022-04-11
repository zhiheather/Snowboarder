using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    CapsuleCollider2D snowboarder;
    [SerializeField] ParticleSystem dustTrailEffect;

    // Start is called before the first frame update
    void Start()
    {
        snowboarder = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Collider2D otherCollider = other.gameObject.GetComponent<Collider2D>();
        if (other.gameObject.tag == "Ground" && snowboarder.IsTouching(otherCollider))
        {
            dustTrailEffect.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        Collider2D otherCollider = other.gameObject.GetComponent<Collider2D>();
        if (other.gameObject.tag == "Ground" && !snowboarder.IsTouching(otherCollider))
        {
            dustTrailEffect.Stop();
        }
    }
}
