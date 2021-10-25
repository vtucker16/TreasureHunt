using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureCollector : MonoBehaviour
{
   private CircleCollider2D cc;
   public static int key; 

   private void Awake(){
       cc = GetComponent<CircleCollider2D>();
       cc.isTrigger = true; 
   }

   //private void OnCollisionEnter2D(Collision2D collision){}

   void OnTriggerEnter2D(Collider2D collision){
       //Debug.Log("A collision has happened.", gameObject);
       if(collision.CompareTag("Player")){
           key++;
           Destroy(gameObject);
       }
       else{
           //collision.gameObject.SetActive(false); //true to create object(?)
       }
   }
}
