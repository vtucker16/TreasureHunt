using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb; 
    
    public float speed = 9.0f;
    public Sprite SUp;
    public Sprite SDown;
    public Sprite SLeft;
    public Sprite SRight;

    public Sprite SAUp;
    public Sprite SADown;
    public Sprite SALeft;
    public Sprite SARight;

    public Vector3 raycastOffset = Vector3.zero;
    public float raycastDistance = 1.0f;
    
    public enum Direction {None, Right, Left, Up, Down}
    public Direction currentDir = Direction.None;

    bool moveLeft, moveRight, moveUp, moveDown;
    public static int didCollide = 0; 

    public static int didAttack = 0;

    public AudioSource myAudioSource;
    public AudioSource myAudioSource1;
    public AudioSource myAudioSource2;


    // Start is called before the first frame update
        
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        //audio = GetComponent<AudioSource>();
        
    }

    void KeyBoardInput(){
        moveLeft = Input.GetKey(KeyCode.LeftArrow);
        moveRight = Input.GetKey(KeyCode.RightArrow);
        moveUp = Input.GetKey(KeyCode.UpArrow);
        moveDown = Input.GetKey(KeyCode.DownArrow);
    }

    public void Move() {
            Vector3 tempVect = new Vector3(0, 0);

            if (moveLeft)
                tempVect.x = -1.0f;
            if (moveRight)
                tempVect.x = 1.0f;
            if (moveUp)
                tempVect.y = 1.0f;
            if (moveDown)
                tempVect.y = -1.0f;

            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(rb.transform.position + tempVect);
    }

    void MoveObject(){
       if(Input.GetKey(KeyCode.LeftArrow)){
           currentDir = Direction.Left;
           transform.Translate((Vector2.left * Time.deltaTime) * speed);
       }
       if(Input.GetKey(KeyCode.RightArrow)){
           currentDir = Direction.Right;
           transform.Translate((Vector2.right * Time.deltaTime) * speed);
       }
       if(Input.GetKey(KeyCode.UpArrow)){
           currentDir = Direction.Up;
           transform.Translate((Vector2.up * Time.deltaTime) * speed);
       }
       if(Input.GetKey(KeyCode.DownArrow)){
           currentDir = Direction.Down;
           transform.Translate((Vector2.down * Time.deltaTime) * speed);
       }
       /*RaycastHit2D rayCheck = Physics2D.Raycast(transform.position + raycastOffset, GetDirectionVector(currentDir), raycastDistance);
       //Debug.DrawRay(transform.position, GetDirectionVector(currentDir), Color.red);


        if(Input.GetKey(KeyCode.LeftArrow)){
            //currentDir = Direction.Left;
            if(rayCheck.collider != null){

            } else {
                //transform.Translate((Vector2.left * Time.deltaTime) * speed);
            }
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            //currentDir = Direction.Right; 
            if(rayCheck.collider != null){

            } else {
                //transform.Translate((Vector2.right * Time.deltaTime) * speed);
            }
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            //currentDir = Direction.Up;
            if(rayCheck.collider != null){

            } else {
                //transform.Translate((Vector2.up * Time.deltaTime) * speed);
            }
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            //currentDir = Direction.Down;
            if(rayCheck.collider != null){

            } else {
                //transform.Translate((Vector2.down * Time.deltaTime) * speed);
            }
        }*/
    }

    Vector2 GetDirectionVector(Direction dir){
        Vector3 d = new Vector3();
        switch(dir){
            case Direction.Left:
            d = Vector3.left;
            break;

            case Direction.Right:
            d = Vector3.right;
            break;

            case Direction.Up:
            d = Vector3.up;
            break;

            case Direction.Down:
            d = Vector3.down;
            break;
        }
        return d;
    }

    /*private void OnCollisionEnter2D(Collision2D collision){
        speed = -9.0f;
        Debug.Log(collision.gameObject.name, collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision){
        speed = 9.0f;
    }*/

    bool IsSomethingThere(Direction dir){
        return false;
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("NPC2")){
            didCollide = 1; 
        }
        if(collision.CompareTag("NPC1")){
            didCollide = 1;
        }
        if(collision.CompareTag("Enemy")){
            if(didAttack == 0){
                MyAttackTrigger.canAttack = 0;
                TreasureCollector.key = 0;
                MyMonsterScore.monster = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if(didAttack == 1){
                myAudioSource1.Play();
            }
        }
        if(collision.CompareTag("Key")){
            myAudioSource2.Play();
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("NPC2")){
            didCollide = 0; 
        }
        if(collision.CompareTag("NPC1")){
            didCollide = 0;
        }
    }



    /*private void OnDrawGizmos(){
        switch(currentDir){
            case Direction.Right:
            Debug.DrawRay(transform.position + raycastOffset, Vector2.right * raycastDistance, Color.red);
            break;

            case Direction.Left:
            Debug.DrawRay(transform.position + raycastOffset, Vector2.left * raycastDistance, Color.red);
            break;

            case Direction.Up:
            Debug.DrawRay(transform.position + raycastOffset, Vector2.up * raycastDistance, Color.red);
            break;

            case Direction.Down:
            Debug.DrawRay(transform.position + raycastOffset, Vector2.down * raycastDistance, Color.red);
            break;
        }
    }*/

    void FixedUpdate(){
        Move();
    }

    void Update()
    {
        //MoveObject();
        KeyBoardInput();
        if(Input.GetKey(KeyCode.LeftArrow)){
            GetComponent<SpriteRenderer>().sprite = SLeft;
            didAttack = 0;
            myAudioSource.Stop();
            if(MyAttackTrigger.canAttack == 1){
                if(Input.GetKey(KeyCode.Space)){
                    didAttack = 1;
                    GetComponent<SpriteRenderer>().sprite = SALeft;
                    myAudioSource.Play();
                }
                else{
                    myAudioSource.Stop();
                }
            }
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            GetComponent<SpriteRenderer>().sprite = SRight;
            didAttack = 0;
            myAudioSource.Stop();
            if(MyAttackTrigger.canAttack == 1){
                if(Input.GetKey(KeyCode.Space)){
                    didAttack = 1;
                    GetComponent<SpriteRenderer>().sprite = SARight;
                    myAudioSource.Play();
                }
                else{
                    myAudioSource.Stop();
                }
            }
        }
        if(Input.GetKey(KeyCode.DownArrow)){
             GetComponent<SpriteRenderer>().sprite = SDown;
             didAttack = 0;
             myAudioSource.Stop();
             if(MyAttackTrigger.canAttack == 1){
                if(Input.GetKey(KeyCode.Space)){
                    didAttack = 1;
                    GetComponent<SpriteRenderer>().sprite = SADown;
                    myAudioSource.Play();
                }
                else{
                    myAudioSource.Stop();
                }
            }
            } 
        if (Input.GetKey(KeyCode.UpArrow)){
                GetComponent<SpriteRenderer>().sprite = SUp;
                didAttack = 0;
                myAudioSource.Stop();
                if(MyAttackTrigger.canAttack == 1){
                if(Input.GetKey(KeyCode.Space)){
                    didAttack = 1;
                    GetComponent<SpriteRenderer>().sprite = SAUp;
                    myAudioSource.Play();
                }
                else{
                    myAudioSource.Stop();
                }
            }

        }
    }

}
