using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Cinemachine;



public class GameManager : MonoBehaviour
{

    public Image pause;  
    public GameObject HazardPreefab;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighscoreText;
    private int points;
    private float timer;
    public CinemachineVirtualCamera Maincam;
    public CinemachineVirtualCamera Zoomcam;
    public bool gameover;
    public GameObject GameOverMenu;
    public GameObject player;
    private int HighScore;
    void Start()
    {
         StartCoroutine(SpawHazards());
       
    }
    private void OnEnable()
    {
        player.SetActive(true);
        Maincam.gameObject.SetActive(true);
        Zoomcam.gameObject.SetActive(false);
        gameover = false;
        points = 0;
        timer = 0;
        scoreText.text = "0";
        StartCoroutine(SpawHazards());
    }
    void Update()
    {

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pause.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pause.gameObject.SetActive(true);
            }
        }

        if (gameover)
            return;
        
            
        timer += Time.deltaTime;

        if (timer > 1f)
        {
            points++;
            scoreText.text =points.ToString();
            timer = 0f;
        }
    }

    private IEnumerator SpawHazards()
    { 
        int QTsBoxes = Random.Range(2, 5);

        for (int i = 0; i < QTsBoxes; i++)
        {
            Instantiate(HazardPreefab, new Vector3(Random.Range(-6f, 19.11f), 16f, -4.37f), Quaternion.identity);
            var variantegravidade = Random.Range(0, 1.5f);
            HazardPreefab.GetComponent<Rigidbody>().drag = variantegravidade;
        }
       yield return new WaitForSeconds(1f);

       yield return SpawHazards();
    }

    public void Game_Over()
    {
        gameover = true; 
        gameObject.SetActive(false);
        Maincam.gameObject.SetActive(false);
        Zoomcam.gameObject.SetActive(true);
        GameOverMenu.gameObject.SetActive(true);

        if(points > HighScore)
        {
            HighScore = points;
            HighscoreText.text = HighScore.ToString();
        }

    }

    public void ativar()
    {
         gameObject.SetActive(true);
    }
}
