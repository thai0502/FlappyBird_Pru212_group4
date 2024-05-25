using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEndGame;
    bool isStartFirstTime = true;
    int gamePoint = 0;
    public TextMeshProUGUI txtPoint;
    public GameObject pnlEndGame;
    public Text txtEndPoint;
    public Button btnRestart;

    public Sprite btnIdle;
    public Sprite btnOver;
    public Sprite btnClick;

    void Start()
    {
        Time.timeScale = 0;
        pnlEndGame.SetActive(false);
        isStartFirstTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetMouseButtonDown(0) && isStartFirstTime)
            {
                //Time.timeScale = 1;
                //isEndGame = false;
                //SceneManager.LoadScene(0);
                StartGame();
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
        }
    }
    public void GetPoint()
    {
        gamePoint++;
        if (txtPoint != null)
        {
            txtPoint.text = "Point: " + gamePoint.ToString();
        }
    }
    void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ReStart()
    {
        StartGame();
    }
    public void EndGame()
    {
        isStartFirstTime = false;
        if (isEndGame = true)
        Time.timeScale = 0;
        pnlEndGame.SetActive(true);
        txtEndPoint.text = "Your Point: " + gamePoint.ToString();
    }
}
