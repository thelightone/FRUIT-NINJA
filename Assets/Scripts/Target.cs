using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    private AudioSource aus;
    public AudioClip death;
    private Rigidbody rb;
    public ParticleSystem explos;
    public GameObject finish;
    private GameObject gameMan;
   private GameManager gameManagerScript;
    private int score;
    
   
    // Start is called before the first frame update
    void Start()
    {
        aus = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * Random.Range(12,15), ForceMode.Impulse);
        rb.AddTorque(Random.Range(-10, 10), Random.Range(-10 ,10), Random.Range(-10, 10), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4, 4), -1, Random.Range(0, 3));
       
        gameMan = GameObject.Find("Game Manager");
        gameManagerScript = gameMan.GetComponent<GameManager>();
   
    }

    // Update is called once per frame
    void Update()
    {
      //  explos.transform.position = transform.position;
 
     
    }
   // private void OnMouseDown()
  //  {
      
       //// Instantiate(explos);
       //explos.Play();
       // aus.PlayOneShot(death);

       // if (gameObject.CompareTag("Finish"))
       // {
        
       //     Instantiate(finish);
       //       gameMan.SetActive(false);
           
       
       // }
       // else if (gameObject.CompareTag("Respawn"))
       // {
           
        
            
       //     gameManagerScript.Score(5);
       // }

       // // Expl();
       
       // Destroy(gameObject, 0.4f);
       // Instantiate(explos);

   // }
    private void OnTriggerEnter(Collider other)
    {
     
        Destroy(gameObject);
    }
    public void DestroyTarget()
    {
        Instantiate(explos);
        explos.Play();
        aus.PlayOneShot(death);

        if (gameObject.CompareTag("Finish"))
        {

            Instantiate(finish);
            gameMan.SetActive(false);


        }
        else if (gameObject.CompareTag("Respawn"))
        {



            gameManagerScript.Score(5);
        }

        // Expl();
        gameObject.layer = LayerMask.NameToLayer("Water");
        Destroy(gameObject, 0.4f);
        
    }
}
