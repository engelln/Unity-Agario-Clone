using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 30;
    public Camera cam;

    private Rigidbody2D rb;
    private bool isCameraChanging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MovePlayer();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            ConsumeBall();
            ScoreManager.IncrementPlayerScore();
            Destroy(collision.gameObject);
        }


    }

    void ConsumeBall()
    {
        
        transform.localScale = new Vector3(transform.localScale.x + .1f, transform.localScale.y + .1f, 1);
        rb.mass += .01f;
        
        if((ScoreManager.GetScore() + 1) % 100  == 0)
        {
            if (!isCameraChanging)
            {
                StartCoroutine(ChangeCameraSize(cam.orthographicSize + 5f));
                isCameraChanging = true;
            }
        }
        else
        {
            //cam.orthographicSize += .1f;
        }

    }

    IEnumerator ChangeCameraSize(float targetSize)
    {
        

        while(cam.orthographicSize < targetSize)
        {
            cam.orthographicSize += Time.deltaTime;
            yield return null;
        }
      
        isCameraChanging = false;
        yield return null;
        
    }

    void MovePlayer()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
       

        Vector3 pos = Input.mousePosition;
        Vector3 convertedPos = cam.ScreenToWorldPoint(pos);

        Vector3 vel = convertedPos - transform.position;
        
        

        /*
        if(convertedPos.x > transform.position.x)
        {
            moveHorizontal = 1;
        }
        else
        {
            moveHorizontal = -1;
        }

        if(convertedPos.y > transform.position.y)
        {
            moveVertical = 1;
        }
        else
        {
            moveVertical = -1;
        }*/

        float moveHorizontal = vel.x;
        float moveVertical = vel.y;
        


        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);
        
    }
}
