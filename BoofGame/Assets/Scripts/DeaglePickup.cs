using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeaglePickup : MonoBehaviour
{
    public GameObject gun;
    private bool touched;
    // Start is called before the first frame update
    void Start()
    {
        touched = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D (Collision2D col)
     {
         if (col.gameObject.tag == "Player" && !touched) // GameObject is a type, gameObject is the property
         {
            touched = true;
            GameObject currentGun = Instantiate(gun);
            playerMovement.gunsHeld.Add(currentGun);
            currentGun.transform.SetParent(GameObject.FindWithTag("Player").transform, false);
            currentGun.GetComponent<SpriteRenderer>().enabled = false;
            currentGun.GetComponent<shootGun>().bulletNumber = 20;
            currentGun.GetComponent<SpriteRenderer>().sortingOrder = 3;
            for(int i = 0; i < 3; i++){
                Debug.Log(GameObject.Find("Gun" + (i+1)).GetComponent<UnityEngine.UI.Image>().sprite);
                if(GameObject.Find("Gun" + (i+1)).GetComponent<UnityEngine.UI.Image>().sprite == null){
                    Debug.Log("foundEmptySlot");
                    GameObject.Find("Gun" + (i+1)).GetComponent<UnityEngine.UI.Image>().sprite = gun.GetComponent<SpriteRenderer>().sprite;
                    break;
                };
            }
            Destroy(gameObject);
         }
     }
}
