using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour {
    private static int maxHealth = 100;
    private static int attackDamage = 10;

    private int health = Door.maxHealth;
    private GameObject healthText;
    private GameObject repaireArea;
    private GameObject smokeEffect;
    private GameObject flameEffect;

    public GameObject smokeEffectPrefab;
    public GameObject explosionEffectPrefab;
    public GameObject flameEffectPrefab;


    // Use this for initialization
    void Start () {
        this.healthText = this.transform.GetChild(0).gameObject;
        this.DisplayHealth();
	}
	
	// Update is called once per frame
	void Update () {
        this.DisplayHealth();
        Debug.Log("health" + this.health);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Enemy") {
            this.ReceiveAttack();
        }
        
    }

    void ReceiveAttack() {
        if (this.health == Door.maxHealth) {
            this.flameEffect = Instantiate(this.flameEffectPrefab, this.transform.position, this.transform.rotation);
            this.smokeEffect = Instantiate(this.smokeEffectPrefab, this.transform.position, this.transform.rotation);
        }
        this.health -= Door.attackDamage;
        this.DisplayHealth();
        if (this.health <= 0) {
            this.DestroyDoor();
        }
        
    }

    public void AddHealth(int health) {
        this.health += health;
        this.DisplayHealth();
        if (this.health >= Door.maxHealth)
        {
            Destroy(this.smokeEffect);
            Destroy(this.flameEffect);
        }
    }

    void DestroyDoor() {
        GameObject explosionEffect = Instantiate(this.explosionEffectPrefab, this.transform.position, this.transform.rotation);
        Destroy(this.flameEffect);
        Destroy(this.smokeEffect);
        Destroy(this.gameObject);

    }

    void DisplayHealth() {
        this.healthText.GetComponent<TMPro.TextMeshPro>().text = "Health: " + this.health;

        if (this.health < Door.maxHealth * 0.3) {
            this.healthText.GetComponent<TMPro.TextMeshPro>().color = new Color32(255, 0, 0, 255);
        } else {
            this.healthText.GetComponent<TMPro.TextMeshPro>().color = new Color32(255, 255, 255, 255);
        }

    }
}
