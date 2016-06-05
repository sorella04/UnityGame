using UnityEngine;
using System.Collections;

public class CameraPlayer : MonoBehaviour {

    public GameObject Player;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if(Player != null)
            transform.position = Player.transform.position + offset;
	}
}
