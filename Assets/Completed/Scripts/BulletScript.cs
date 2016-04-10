using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    public GameObject explosion;
    private Rigidbody2D rb2d;
    // Use this for initialization

    void OnCollisionEnter2D(Collision2D col)
    {
        //GameObject expl = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        //Destroy(gameObject); // destroy the grenade
        //Destroy(expl, 3); // delete the explosion after 3 seconds
        Debug.Log(col);
        if (col.gameObject.name == "UFO2")
        { 
            Destroy(gameObject, 0.1f);
        }

        if (col.gameObject.name == "Background")
        {
            Destroy(gameObject, 0.1f);            
        }
            
    }


    void OnCollisionEnter()
    {
        GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject); // destroy the grenade
        Destroy(expl, 3); // delete the explosion after 3 seconds
    }

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
        //Debug.Log("aaa");
    }

   
}
