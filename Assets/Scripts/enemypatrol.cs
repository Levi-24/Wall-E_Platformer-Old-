    using Unity.VisualScripting;
    using UnityEngine;

    public class Mace : MonoBehaviour
    {
        public float speed = 0.8f;
        public float range = 3;
        SpriteRenderer spriteRenderer;
        float startingx;
        private float sclex;
        int dir = 1;
        // Start is called before the first frame update
        void Start()
        {
            startingx = transform.position.x;
            sclex = transform.localScale.x;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime * dir);
            if (transform.position.x < startingx || transform.position.x > startingx + range)
                {
                    transform.localScale = new Vector3((1)sclex,transform.localScale.y, transform.localScale.z);
                    dir *= -1;
                
                
                }
            if (transform.position.x < startingx || transform.position.x > startingx + range)
            {
                transform.localScale = new Vector3((-1) * sclex, transform.localScale.y, transform.localScale.z);
                dir *= 1;
                
        }
        
    

        }
   
    }