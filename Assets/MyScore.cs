using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyScore : MonoBehaviour
{
    public TMP_Text myText;  
    public string newText = "Keys: ";

    void Start()
    {
        //myText.text = "This is text";
        myText.text = newText;
    }

    void Update(){
        myText.text = "Keys: " + TreasureCollector.key + "/3";
    }
}
