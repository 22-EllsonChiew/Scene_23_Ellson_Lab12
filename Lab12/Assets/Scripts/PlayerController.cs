using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    public float rotateSpeed;
    float iCount = 0.0f;
    public Text coinScore;
    Rigidbody PlayerRB;
    //public GameObject GameScore;

    int iTotalPowerUpLeft;




    // Start is called before the first frame update
    void Start()
    {
        PlayerRB.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        //float Inputvertical = Input.GetAxis("Vertical");
        //float Inputhorizontal = Input.GetAxis("Horizontal");


        //transform.Translate(Vector3.forward * Time.deltaTime * Inputvertical * speed);
        //transform.Translate(Vector3.right * Time.deltaTime * Inputhorizontal * speed);


        iTotalPowerUpLeft = GameObject.FindGameObjectsWithTag("Coins").Length;

        if (iTotalPowerUpLeft == 0)
        {
            Debug.Log("Going OVER to new SCENE NOW WHEN ALL POER UP COLLECTED!");
            SceneManager.LoadScene("WinScene");
        }



        if (transform.position.y < -5)
        {
            Debug.Log("You fall you lose");
            SceneManager.LoadScene("LoseScene");
        }



        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);


        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);


        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);


        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);


        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            iCount--;
            coinScore.GetComponent<Text>().text = "Coin Collected: " + iCount.ToString();
            if (iCount == 0)
            {
                Debug.Log("Going OVER to new SCENE NOW!");
                SceneManager.LoadScene("WinScene");
            }
        }

        



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            iCount++;
            coinScore.GetComponent<Text>().text = "Coin Collected: " + iCount.ToString();

            Destroy(other.gameObject);
        }

        

    }
}
