
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepaireArea : MonoBehaviour {
    private Door parentDoor;
    static Color normalColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
    static Color activeColor = new Color(0.5f, 1.0f, 0.5f, 1.0f);


    // Use this for initialization
    void Start () {
        this.parentDoor = this.GetComponentInParent<Door>();

        Renderer rend = this.GetComponent<Renderer>();
        rend.material.SetColor("_Color", RepaireArea.normalColor);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void repaireDoor(int health) {
        this.parentDoor.AddHealth(health);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "player") {
            Renderer rend = this.GetComponent<Renderer>();
            rend.material.SetColor("_Color", RepaireArea.activeColor);
        }
    }

    private void OnTriggerExit(Collider other) {
        Renderer rend = this.GetComponent<Renderer>();
        rend.material.SetColor("_Color", RepaireArea.normalColor);
    }
}
