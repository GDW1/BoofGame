using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform transform;
    public int bulletSpeed;
    public Rigidbody2D rgbd;
    public int damage;
    void Start()
    {
        // transform.transform.position.Set(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        if(playerMovement.directionRight){
            rgbd.AddForce(new Vector2(bulletSpeed, 0));
        }else{
            rgbd.AddForce(new Vector2(-bulletSpeed, 0));
        }
    }
    private void OnCollisionEnter2D (Collision2D col)
     {
        if (col.gameObject.tag != "Player") {
            Destroy(gameObject);
        }// GameObject is a type, gameObject is the property
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
