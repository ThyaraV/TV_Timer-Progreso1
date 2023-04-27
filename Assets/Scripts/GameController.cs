using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private string tag;

    [SerializeField]
    private GameObject playerPrefab;
  

    private GameObject player;

    [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField]
    private GameObject selectedSpawnPoints;

    [SerializeField]
    private GameObject menuCamera;

    [SerializeField]
    private GameObject menuUI;

    [SerializeField]
    private GameObject gameUI;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject text2;

    private Timer timer;



    // Start is called before the first frame update
    void Start()
    {
        timer=gameObject.GetComponent<Timer>();
        menuCamera.SetActive(true);
        menuUI.SetActive(true);
        gameUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            endGame();
        }
    }

    public void starGame()
    {
        timer.startTimer();
        menuCamera.SetActive(false);
        gameOver.SetActive(false);
        menuUI.SetActive(false);
        gameUI.SetActive(true);
       

        placePlayerRandomly();
    }

    public void endGame()
    {
        timer.stopTimer();

        menuCamera.SetActive(true);
        menuUI.SetActive(true);
        gameOver.SetActive(true);
        text.SetActive(false);
        text2.SetActive(true);
        gameUI.SetActive(false);
        
        Destroy(player);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }



    private void placePlayerRandomly()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag(tag);
        int rand = Random.Range(0, spawnPoints.Length);
        selectedSpawnPoints = spawnPoints[rand];

        player = Instantiate(playerPrefab, selectedSpawnPoints.transform.position, selectedSpawnPoints.transform.localRotation);

    }
}
