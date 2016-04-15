
using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    public GameObject explosion;
    private Rigidbody2D rb2d;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "UFO2")
        {
            GameObject expl = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
            expl.GetComponent<UnityStandardAssets.Effects.ParticleSystemMultiplier>().Restart();
            expl.GetComponent<UnityStandardAssets.Effects.ExplosionPhysicsForce>().Restart();
            Destroy(gameObject, 0.1f);
            Destroy(expl, 3.0f);
        }

        if (col.gameObject.name == "Background")
        {
            Destroy(gameObject, 0.1f);            
        }            
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
    }
}
