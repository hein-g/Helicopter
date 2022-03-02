using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heli : MonoBehaviour
{
    // Start is called before the first frame update
    private int sol;
    private int hosp;
    public Text solText;
    void Start()
    {
        sol = 0;
        hosp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement for the heli
        transform.Translate(0,Input.GetAxis("Vertical") * 10.0f * Time.deltaTime,0);
        transform.Translate(Input.GetAxis("Horizontal") * 10.0f * Time.deltaTime,0,0);
    }

    //Deals with picking up the soldiers
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("person") && sol < 3)
        {
            Destroy(other.gameObject);
            sol++;
            solText.text = sol.ToString();
            Debug.Log("you are carrying "+sol+" soldiers");
        }
        
        if (other.CompareTag("hospital"))
        {
            hosp = hosp + sol;
            sol = 0;
            solText.text = sol.ToString();
            Debug.Log(hosp+" soldiers in hospital");
            Debug.Log("you are carrying "+sol+" soldiers");
        }
        
        if (other.CompareTag("tree"))
        {
            Debug.Log("tree hit, game over");
        }
    }
}
