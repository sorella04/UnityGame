using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    private Rigidbody2D rb2d;
    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addForce(float rotation, float force)
    {
        rb2d = GetComponent<Rigidbody2D>();
        Vector2 movment = new Vector2(-Mathf.Sin(rb2d.rotation * Mathf.Deg2Rad), Mathf.Cos(rb2d.rotation * Mathf.Deg2Rad));
        rb2d.AddForce(movment * force);
        Debug.Log("aaa");
    }
}
