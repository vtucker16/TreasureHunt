using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove5 : MonoBehaviour
{
    public float speed = 10.0f;
    public int dir = 0; 
    
    void MoveObject(){

        if(transform.position.x >= 50){
            dir = 1;
        }
        if(transform.position.x <= 15){
            dir = 0;
        }

        if (dir==0){
            transform.Translate((Vector2.right * Time.deltaTime) * speed);
        }
        if (dir==1){
            transform.Translate((Vector2.left * Time.deltaTime) * speed);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }
}
