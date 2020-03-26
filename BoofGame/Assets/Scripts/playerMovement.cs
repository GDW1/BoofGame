﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Transform transform;
    public float speed;
    public float jumpHeight;
    private GameObject obj;
    private Rigidbody2D rigbod;
    private bool isJumping;
    static public bool directionRight;
    public int maxSpeed;
    private Animator anim;
    private BoxCollider2D collider2D;
    private bool holdingGun;
    static public List<GameObject> gunsHeld;
    private int GunNum;
    private GameObject currentGun;
    private UnityEngine.UI.Text bul;

    // Start is called before the first frame update
    void Start()
    {
        holdingGun = false;
        obj = gameObject;
        rigbod = obj.GetComponent<Rigidbody2D>();
        directionRight = true;
        anim = gameObject.GetComponent<Animator>();
        transform = gameObject.GetComponent<Transform>();
        collider2D = gameObject.GetComponent<BoxCollider2D>();
        gunsHeld = new List<GameObject>();
        bul = GameObject.Find("BullC").GetComponent<UnityEngine.UI.Text>();

    }

    // Update is called once per frame
    void Update()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis ("Vertical");

        if(moveVertical > 0 && !isJumping){
            rigbod.AddForce(new Vector2(0, 40 *jumpHeight));
            isJumping = true;
        }
        // add a force to the object
        if(Mathf.Abs(rigbod.velocity.x) > maxSpeed){
            rigbod.velocity = new Vector2(maxSpeed * Mathf.Sign(rigbod.velocity.x), rigbod.velocity.y);
        }else{
            rigbod.AddForce(new Vector2(moveHorizontal * speed, rigbod.velocity.y));
        }
        if(moveHorizontal < 0 && directionRight){
            gameObject.GetComponent<Transform>().Rotate(0, 180, 0);
            directionRight = !directionRight;
        }else if(moveHorizontal > 0 && !directionRight){
            gameObject.GetComponent<Transform>().Rotate(0, 180, 0);
            directionRight = !directionRight;
        }
        if(moveHorizontal != 0){
            anim.SetBool("IsMoving", true);
        }else{
            anim.SetBool("IsMoving", false);
        }
        if(directionRight){
            transform.eulerAngles = new Vector3(transform.rotation.x, 0, 0);
            
        }else{
            transform.eulerAngles = new Vector3(transform.rotation.x, 180, 0);
        }
        if(moveVertical < 0 && !isJumping){
            anim.SetBool("IsCrouching", true);
            collider2D.offset = new Vector2(0.0229615f, -0.01492025f);
            collider2D.size = new Vector2(0.7759895f, 0.787169f);
            rigbod.velocity = new Vector2(0, rigbod.velocity.y);
        }else if(isJumping && rigbod.velocity.y >  -8 && rigbod.velocity.y < 3){
            collider2D.offset = new Vector2(-0.03369844f, 0.4987781f);
            collider2D.size = new Vector2(0.8245552f, 1.065273f);
        }else{
            collider2D.offset = new Vector2(0.0229615f, 0.01312095f);
            collider2D.size = new Vector2(0.7759895f, 1.291913f);
            anim.SetBool("IsCrouching", false);
        }
        anim.SetBool("IsJumping", isJumping);
        if(gunsHeld.Count != 0){
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                GunNum = 0;
                            Debug.Log(GunNum);

            }else if(Input.GetKeyDown(KeyCode.Alpha2)){
                GunNum = 1;
            Debug.Log(GunNum);

            }else if(Input.GetKeyDown(KeyCode.Alpha3)){
                GunNum = 2;
            Debug.Log(GunNum);

            }else if(Input.GetKeyDown(KeyCode.Alpha4)){
                GunNum = 3;
            Debug.Log(GunNum);

            }
        }
        if(Input.GetButtonDown("Equip1") && !holdingGun && gunsHeld.Count != 0){
            Debug.Log(GunNum);
            currentGun = gunsHeld[GunNum];
            currentGun.GetComponent<SpriteRenderer>().enabled = true;
            currentGun.GetComponent<shootGun>().beingHeld = true;
            holdingGun = true;
        }else if(Input.GetButtonDown("Equip1") && holdingGun && gunsHeld.Count != 0){
            currentGun.GetComponent<SpriteRenderer>().enabled = false;
            currentGun.GetComponent<shootGun>().beingHeld = false;
            holdingGun = false;
        }
        if(currentGun != null) bul.text= "Bullet Count: " + currentGun.GetComponent<shootGun>().bulletNumber  + "/" + currentGun.GetComponent<shootGun>().maxBullets;

    }

    private void assignGunNum()
    {
        if(gunsHeld.Count != 0){
            if(Input.GetKeyDown("1")){
                GunNum = 0;
            }else if(Input.GetKeyDown("2")){
                GunNum = 1;

            }else if(Input.GetKeyDown("2")){
                GunNum = 2;

            }else if(Input.GetKeyDown("2")){
                GunNum = 3;

            }else{
                GunNum = 0;

            }
        }
    }

    private void OnCollisionEnter2D (Collision2D col)
     {
         if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Obstical") // GameObject is a type, gameObject is the property
         {
             isJumping = false;
         }
     }
}
