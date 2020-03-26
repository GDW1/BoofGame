using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootGun : MonoBehaviour
{
    private Transform transform;
    public AudioClip impact;
    private Animator anim;
    private AudioSource sound;
    public int bulletNumber;
    public Object bullet;
    public bool beingHeld;
    public bool instantiated;
    public int maxBullets;
    // Start is called before the first frame update
    void Start()
    {
        instantiated = false;
        maxBullets = bulletNumber;
        anim = gameObject.GetComponent<Animator>();
        sound = gameObject.GetComponent<AudioSource>();
        transform = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && bulletNumber > 0 && beingHeld){
            anim.SetTrigger("IsFiring");
            if(impact != null) sound.PlayOneShot(impact);
            bulletNumber -= 1;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
