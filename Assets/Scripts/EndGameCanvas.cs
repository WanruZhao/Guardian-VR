using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCanvas : MonoBehaviour {
    public GameObject resultText;
    public GameObject gameoverPannel;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayGameOverPannel(bool win) {
        string resultString;
        if (win) {
            resultString = "YOU WIN!";
        } else {
            resultString = "YOU LOSE!";
        }
        this.resultText.GetComponent<TMPro.TextMeshPro>().text = resultString;

    }
}
