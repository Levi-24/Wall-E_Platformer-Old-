using UnityEngine;

public class Mace : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3;

    float startingx;
    int dir = 1;
    // Start is called before the first frame update
    void Start()
    {
        startingx = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * dir);
        if (transform.position.x < startingx || transform.position.x > startingx + range)
            dir *= -1;
    }
}