using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Heli : MonoBehaviour
{
    // Start is called before the first frame update
    private int sol;
    private int totalSolCount;
    private int hosp;
    private bool destroyed;
    public Text solText;
    public Text hospCount;
    public AudioSource pickupSound;
    public Canvas winScreen;
    public Canvas loseScreen;
    public SpriteRenderer flame;
    void Start()
    {
        flame.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(false);
        destroyed = false;
        sol = 0;
        hosp = 0;
        totalSolCount = GameObject.FindGameObjectsWithTag("person").Length;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement for the heli
        if (!destroyed)
        {
            transform.Translate(0, Input.GetAxis("Vertical") * 10.0f * Time.deltaTime, 0);
            transform.Translate(Input.GetAxis("Horizontal") * 10.0f * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (hosp == totalSolCount)
        {
            foreach (var o in GameObject.FindGameObjectsWithTag("tree"))
            {
                Destroy(o);
            }
            winScreen.gameObject.SetActive(true);
        }
    }

    //Deals with picking up the soldiers
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("person") && sol < 3)
        {
            Destroy(other.gameObject);
            pickupSound.Play();
            sol++;
            solText.text = sol.ToString();
        }
        
        if (other.CompareTag("hospital"))
        {
            hosp = hosp + sol;
            hospCount.text = hosp.ToString();
            sol = 0;
            solText.text = sol.ToString();
        }
        
        if (other.CompareTag("tree"))
        {
            foreach (var o in GameObject.FindGameObjectsWithTag("tree"))
            {
                Destroy(o);
            }
            foreach (var o in GameObject.FindGameObjectsWithTag("person"))
            {
                Destroy(o);
            }
            gameObject.GetComponentInChildren<Canvas>().gameObject.SetActive(false);
            flame.gameObject.SetActive(true);
            destroyed = true;
            loseScreen.gameObject.SetActive(true);
        }
    }
}
