using UnityEngine;
using System.Collections;

public class Black_Hole_script : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
    }

        // Use this for initialization
        void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
