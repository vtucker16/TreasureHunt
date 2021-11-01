using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyDialogueNPC2 : MonoBehaviour
{
    public TMP_Text myText;
    public string newText = " ";

    // Start is called before the first frame update
    void Start()
    {
        //myText.text = "This is text";
        myText.text = newText;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMove.didCollide == 1){
            //myText.text = "[press z]";
            if(Input.GetKey(KeyCode.Z)){
                myText.text = "Good, you're here. [press x]";
            }
            if(Input.GetKey(KeyCode.X)){
                myText.text = "We're under attack. The archmage is beyond that door.    [press c]";
            }
            if(Input.GetKey(KeyCode.C)){
                myText.text = "Find the three keys to open the door and save them!";
            }
                   
        }
        else if (PlayerMove.didCollide == 0){
            myText.text = " ";
        }
    }
}
