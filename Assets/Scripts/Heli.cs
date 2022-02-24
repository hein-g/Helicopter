using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli : MonoBehaviour
{
    // Start is called before the first frame update
    public int sol;
    void Start()
    {
        sol = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //Movement for the heli
        transform.Translate(0,Input.GetAxis("Vertical") * 10.0f * Time.deltaTime,0);
        transform.Translate(Input.GetAxis("Horizontal") * 10.0f * Time.deltaTime,0,0);
    }

    //Deals with picking up the soldiers
    private void OnTriggerEnter(Collider other)
    {
        if (true)
        {
            Destroy(other.gameObject);
            sol++;
            Debug.Log("you are carrying "+sol+" soldiers");
        }
    }
}
