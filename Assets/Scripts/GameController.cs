using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private GameObject obj;
    public bool isEndGame = false;
    private bool isStartFirstTime = true;
    private AudioSource audioSource;
    public AudioClip gamePlay;
    private int gamePoint = 0;
    public Text txtPoint;
    public GameObject panelEndGame;
    public GameObject panelMenu;
    public Text txtEndPoint;
    public Button btnRestart;
    public Button btnStart;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        gamePoint = 0;
        Time.timeScale = 0;
        audioSource = obj.AddComponent<AudioSource>();
        panelEndGame.SetActive(false);
        panelMenu.SetActive(false);
        if (!isStartFirstTime)
        {

        }
        audioSource.clip = gamePlay;
        audioSource.loop = true;
        audioSource.Play();
        audioSource.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (isStartFirstTime)
            {
                Time.timeScale = 1;
            }
        }
        txtPoint.text = "Point: " + gamePoint.ToString();
    }
    public void EndGame()
    {
        Time.timeScale = 0;
        isEndGame = true;
        audioSource.playOnAwake = false;
        audioSource.Stop();
        panelEndGame.SetActive(true);
        txtEndPoint.text = "Your point\n" + gamePoint.ToString();
        isStartFirstTime = false;
    }
    public void GetPoint()
    {
        gamePoint++;
    }
    public void StartGame()
    {
        panelMenu.SetActive(false);
    }
    public void RestartGame()
    {
        StartGame();
    }
}
