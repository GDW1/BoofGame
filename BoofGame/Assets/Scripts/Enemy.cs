using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private Animator anim;
    public bool isDead;
    private BoxCollider2D collide;
    private Rigidbody2D rigbod;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        anim = gameObject.GetComponent<Animator>();
        isDead = false;
        collide = gameObject.GetComponent<BoxCollider2D>();
        rigbod = gameObject.GetComponent<Rigidbody2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead){

        }else{
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Alex_death"))
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D (Collision2D col)
    {
        Debug.Log("Enemy hit");
        if (col.gameObject.tag == "Bullet") {
            health -= col.gameObject.GetComponent<Bullet>().damage;
            if(health <= 0){
                Debug.Log("DeadEnemy");
                isDead = true;
                anim.SetBool("IsDead", isDead);
                renderer.sortingOrder = 1;
                Destroy(collide);
                rigbod.gravityScale = 0;
                rigbod.velocity = new Vector2(0,0);
            }
        }
    }
}
