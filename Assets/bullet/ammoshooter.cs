using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    GameObject prefab;
	void Start () {
        prefab = Resources.Load("ammo") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetMouseButtonDown(0))
        {
            GameObject ammo = Instantiate(prefab) as GameObject;
            ammo.transform.position = transform.position;
            Rigidbody2D rb = ammo.GetComponent<Rigidbody2D>();
            //rb.velocity = 
        }
	}
}
