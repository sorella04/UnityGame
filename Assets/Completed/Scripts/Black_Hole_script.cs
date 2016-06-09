using UnityEngine;
using System.Collections;

public class Black_Hole_script : MonoBehaviour {

    bool gameover_bool = false;
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);

        if (col.gameObject.name == "Player")
        {
            gameover_bool = true;
        }
    }

        // Use this for initialization
        void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
