using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAttackTrigger : MonoBehaviour
{
    private BoxCollider2D bc;
   public static int canAttack = 0; 

   private void Awake(){
       bc = GetComponent<BoxCollider2D>();
       bc.isTrigger = true; 
   }


   void OnTriggerEnter2D(Collider2D collision){
       
       if(collision.CompareTag("Player")){
           canAttack++;
           Destroy(gameObject);
       }
      
    }
}
