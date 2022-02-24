using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,Input.GetAxis("Vertical") * 10.0f * Time.deltaTime,0);
        transform.Translate(Input.GetAxis("Horizontal") * 10.0f * Time.deltaTime,0,0);
    }
}
