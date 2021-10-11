using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    GameObject obj;
    GameObject gameController;
    public AudioClip fly;
    public AudioClip gameOver;
    public AudioClip getPoints;
    public AudioClip hit;
    private AudioSource audioSource;
    private AudioSource effectSource;
    private float flyPower;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        flyPower = 200;
        audioSource = obj.AddComponent<AudioSource>();
        effectSource = obj.AddComponent<AudioSource>();
        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameController.GetComponent<GameController>().isEndGame)
        {
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
            audioSource.clip = fly;
            audioSource.Play();
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        effectSource.clip = hit;
        effectSource.Play();
        EndGame();
    }
    void OnCollisionStay2D()
    {

    }
    void OnCollisionExit2D()
    {

    }
    void OnTriggerEnter2D()
    {
        gameController.GetComponent<GameController>().GetPoint();
        effectSource.clip = getPoints;
        effectSource.Play();
    }
    void OnTriggerStay2D()
    {

    }
    void OnTriggerExit2D()
    {

    }
    void EndGame()
    {
        gameController.GetComponent<GameController>().EndGame();
        audioSource.clip = gameOver;
        audioSource.Play();
    }
}
