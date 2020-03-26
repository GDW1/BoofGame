using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootGun : MonoBehaviour
{
    private Transform transform;
    public AudioClip impact;
    private Animator anim;
    private AudioSource sound;
    private int bulletNumber;
    private UnityEngine.UI.Text bul;
    public Object bullet;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        sound = gameObject.GetComponent<AudioSource>();
        bulletNumber = 20;
        bul = GameObject.Find("BullC").GetComponent<UnityEngine.UI.Text>();
        bul.text= "Bullet Count: " + bulletNumber  + "/20";
        transform = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && bulletNumber > 0){
            anim.SetTrigger("IsFiring");
            sound.PlayOneShot(impact);
            bulletNumber -= 1;
            bul.text= "Bullet Count: " + bulletNumber  + "/20";
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
