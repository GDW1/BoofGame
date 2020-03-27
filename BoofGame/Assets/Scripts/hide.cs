using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide : MonoBehaviour
{
    public bool isHiding;
    private SpriteRenderer invisible;

    // Start is called before the first frame update
    void Start()
    {
        isHiding = false;
        invisible = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("h")){
            invisible.color = new Color(1f,1f,1f,0.5f);
            isHiding = true;
        }
        if(Input.GetKeyUp("h")){
            invisible.color = new Color(1f,1f,1f,1f);
            isHiding = false;
        }
    }
}
