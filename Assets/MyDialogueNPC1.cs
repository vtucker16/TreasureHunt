using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MyDialogueNPC1 : MonoBehaviour
{
    public TMP_Text myText;
    public string newText = " ";
    public int score = MyMonsterScore.monster - 5; 

    // Start is called before the first frame update
    void Start()
    {
        myText.text = newText;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMove.didCollide == 1){
            
            if(MyMonsterScore.monster < 5){
                if(Input.GetKey(KeyCode.Z)){
                myText.text = "Are you here to save me?    [press x]";
            }
            if(Input.GetKey(KeyCode.X)){
                myText.text = "I appreciate it.         There's some monsters left.       [press c]";
            }
            if(Input.GetKey(KeyCode.C)){
                myText.text = "I need you to kill them.  Good Luck.";
            }
            }
            else if(MyMonsterScore.monster == 5){
                myText.text = "You killed them!  Thank you, traveler.   [press z]";
                if(Input.GetKey(KeyCode.Z)){
                    SceneManager.LoadScene("TheEnd");
                }
            }
                   
        }
        else if (PlayerMove.didCollide == 0){
            myText.text = " ";
        }
    }
}
