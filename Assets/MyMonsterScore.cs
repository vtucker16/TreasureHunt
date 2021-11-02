using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyMonsterScore : MonoBehaviour
{
    public static int monster;
    public TMP_Text myText;  
    public string newText = "Monsters: ";

    void Start()
    {
        //myText.text = "This is text";
        myText.text = newText;
    }

    void Update(){
        myText.text = "Monster: " + monster + "/5";
    }
}
