using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove8 : MonoBehaviour
{
    public float speed = 10.0f;
    public int dir = 0; 
    
    void MoveObject(){

        if(transform.position.x >= 55){
            dir = 1;
        }
        if(transform.position.x <= 40){
            dir = 0;
        }

        if (dir==0){
            transform.Translate((Vector2.right * Time.deltaTime) * speed);
        }
        if (dir==1){
            transform.Translate((Vector2.left * Time.deltaTime) * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            if (PlayerMove.didAttack == 1){
                MyMonsterScore.monster++;
                 Destroy(gameObject);
          }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }
}
