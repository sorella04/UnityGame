using UnityEngine;
using System.Collections;

public class UFO_controller : MonoBehaviour {

    private Rigidbody2D rb2d;
    public int speed;
    public float rotationSpeed;
    public float frictionFactor;

    public GameObject bullet;
    public float bulletSpeed;

    public GameObject Player;


    void Fire()
    {
        Vector3 positionShift = new Vector3(-Mathf.Sin(rb2d.rotation * Mathf.Deg2Rad), Mathf.Cos(rb2d.rotation * Mathf.Deg2Rad), 0);
        positionShift = positionShift * 3;
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

    float getAngleFromVersor(Vector2 versor)
    {
        return 0.0f;
    }

    // oblicza dystans miedzy punktami
    float getDistance(Vector2 point1, Vector2 point2)
    {
        float dx = point1.x - point2.x;
        float dy = point1.y - point2.y;

        float dx2 = dx * dx;
        float dy2 = dy * dy;

        return Mathf.Sqrt(dx2 + dy2);
    }

    Vector2 getDelta(Vector2 a, Vector2 b)
    {
        return new Vector2(
            a.x - b.x,
            a.y - b.y
            );
    }

    //oblicza wersor miedzy punktami
    Vector2 getVersor(Vector2 point1, Vector2 point2)
    {
        Vector2 delta = getDelta(point1, point2);
        
        return new Vector2(
            delta.x / Mathf.Abs(delta.x),
            delta.y / Mathf.Abs(delta.y)
            );
    }

    Vector2 invertVector(Vector2 vector)
    {
        return new Vector2(
            vector.x * -1.0f,
            vector.y * -1.0f
            );
    }

    /*
        obraca o skalar. skalar powiniene być w przedziale <-1;1>, gdzie 1 to w <lewo/prawo> a -1 <prawo/lewo>
    */
    void doRotate(float scalar)
    {

    }

    /*
        dodaje sile na rb obiektu, 1 to do produ, -1 do tylu. skalar w przedziale <-1;1>
    */
    void doMove(float scalar)
    {

    }

    void fixRotatation()
    {
        float angle = 0.0f; //to be changed
        if (rb2d.rotation - angle > angle - rb2d.rotation + 360f) //powinnien obracać się w prawo?
        {
            // obroc w prawo
        }
        else
        {
            //obroc w lewo
        }
    }

    bool check_rotation(float angle)
    {
        return Mathf.Abs(rb2d.rotation - angle) > 5; //dalej kąt różni się co najmniej o 5 stopni
    }

    Vector2 getPosition(GameObject obj)
    {
        return obj.transform.position;
    }

    static Vector2[] blackHoles = {
        new Vector2(-22, -22),
        new Vector2(-22, 22),
        new Vector2(22, 22),
        new Vector2(22, -22)
    };

    Vector2 getNearestBlackHolePosition(Vector2 position)
    {
        float bestDistance = 100;
        int bestIndex = 0;

        for(int i=0; i<blackHoles.Length; ++i)
        {
            float currentDistance = getDistance(position, blackHoles[i]);

            if (currentDistance < bestDistance)
            {
                bestDistance = currentDistance;
                bestIndex = i;
            }
        }

        return blackHoles[bestIndex];
    }

    Vector2 getTargetPossition(Vector2 playerPosition, Vector2 nearestBlackHoldePosition)
    {
        Vector2 versor = getVersor(nearestBlackHoldePosition, playerPosition);
        versor = invertVector(versor);

        return new Vector2(
            playerPosition.x + versor.x,
            playerPosition.y + versor.y
            );
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Pobierz pozycje gracza
        Vector2 playerPosition = getPosition(Player);

        //Pobierz pozycję najbliższej względem gracza czarnej dziury
        Vector2 nearestBlackHoldePosition = getNearestBlackHolePosition(playerPosition);

        //Ustal pozycję na którą musisz się przemieścić
        Vector2 targetPosition = getTargetPossition(playerPosition, nearestBlackHoldePosition);

        float moveHorizontal = Input.GetAxis("Horizontal");// lewo -1 prawo 1 nic 0
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movment = new Vector2(-Mathf.Sin(rb2d.rotation * Mathf.Deg2Rad), Mathf.Cos(rb2d.rotation * Mathf.Deg2Rad));
        rb2d.AddForce(movment * speed * moveVertical);
        float newangle = rb2d.rotation - rotationSpeed * moveHorizontal;
        //Debug.logger.Log(rb2d.rotation);
        //rb2d.MoveRotation(90f);
        rb2d.rotation = newangle;
        //Debug.logger.Log(rb2d.position);

        ApplyFriction();
    }
} 