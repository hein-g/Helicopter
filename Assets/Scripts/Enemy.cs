using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float speed;
    void Start()
    {
        transform.position = transform.position = new Vector3(transform.position.x, Random.Range(-4.0f, 4.0f), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed / 100);
    }
}
