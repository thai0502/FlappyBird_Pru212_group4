using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    //public float moveRange;
    public float minY;
    public float maxY;

    public float oldPosition;
    private GameObject obj;
    void Start()
    {
        speed = 1.5f;
        //moveRange = 14.35f;
        //obj = gameObject;
        oldPosition = 0.7f;
        minY = 1.2f;
        maxY = 1.9f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Reset")) 
            {
            transform.position = new Vector3(oldPosition, Random.Range(minY, maxY + 1), 0);
        }       
    }
}
