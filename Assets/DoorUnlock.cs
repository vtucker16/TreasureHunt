using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
   private BoxCollider2D bc;

   private void Awake(){
       bc = GetComponent<BoxCollider2D>();
       bc.isTrigger = true; 
   }
   
    void OnTriggerEnter2D(Collider2D collision){
        if(TreasureCollector.key == 3){
          if(collision.CompareTag("Player")){
            //if(Input.GetKey(KeyCode.E)){
               Destroy(gameObject);
            //}
          }  
       }
        
    }

}
