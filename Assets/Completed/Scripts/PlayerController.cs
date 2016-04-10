using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public int speed;
    public float rotationSpeed;
    public float frictionFactor;
    
    public GameObject bullet;
    public float bulletSpeed;

    void Fire()
    {
        Vector3 positionShift = new Vector3(-Mathf.Sin(rb2d.rotation * Mathf.Deg2Rad), Mathf.Cos(rb2d.rotation * Mathf.Deg2Rad), 0);
        positionShift = positionShift * 2;
        GameObject bulletClone = (GameObject)Instantiate(bullet, transform.position + positionShift, transform.rotation);
        //bulletClone.velocity = transform.forward * speed;

        // You can also acccess other components / scripts of the clone
        bulletClone.GetComponent<BulletScript>().addForce(rb2d.rotation, bulletSpeed);
    }

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Calls the fire method when holding down ctrl or mouse
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }


    bool isTheSameSign(float a, float b)
    {
        return (a < 0.0f && b < 0.0f) || (a >= 0.0f && b >= 0.0f); 
    }

    Vector2 getFrictionVector()
    {
        Vector2 currentVelocity = rb2d.velocity;
        Vector2 currentVelocityScalar = rb2d.velocity;
        currentVelocityScalar.Normalize();

        float xFriction = currentVelocityScalar.x * frictionFactor;
        float yFriction = currentVelocityScalar.y * frictionFactor;

        xFriction = isTheSameSign(currentVelocity.x, currentVelocity.x - xFriction) ? xFriction : currentVelocity.x;
        yFriction = isTheSameSign(currentVelocity.y, currentVelocity.y - yFriction) ? yFriction : currentVelocity.y;

        return new Vector2(-xFriction, -yFriction);
    }

    void ApplyFriction()
    {
        if (rb2d.velocity.sqrMagnitude > 0.0f)
        {
            Vector2 frictionFactor = getFrictionVector();

            rb2d.AddForce(frictionFactor);
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");// lewo -1 prawo 1 nic 0
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movment = new Vector2 (-Mathf.Sin(rb2d.rotation * Mathf.Deg2Rad), Mathf.Cos(rb2d.rotation * Mathf.Deg2Rad));
        rb2d.AddForce(movment * speed * moveVertical);
        float newangle = rb2d.rotation - rotationSpeed * moveHorizontal;
        rb2d.MoveRotation(newangle);

        ApplyFriction();
    }
}
