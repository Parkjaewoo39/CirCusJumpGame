using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject gameoverText;
    public TMP_Text TimeText;       //남은시간
    public TMP_Text HiscordText;    //최고점수
    public TMP_Text ScoreText;      //현재점수



    private bool isCoCheck = false;
    private bool isGameover;
    private int Highscore;
   // private float bonusTime;
    private float playerScore;

    private void Awake()
    {
        
        playerScore = PlayerPrefs.GetFloat("HiScore");
        

    }
    // Start is called before the first frame update
    void Start()
    {


        isGameover = false;

        Highscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCoCheck == false && GData.bonusTime != 0)
        {
            isCoCheck = true;
            StartCoroutine(BonusZeroCheck());

        }
        TimeText.text = $"{GData.bonusTime}";
        HiscordText.text = $"HI-{Highscore:D6}";
        ScoreText.text = $"{GData.gameScore:D6}";
    }
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);


        float bestTime = PlayerPrefs.GetFloat("HiScore");

        if (bestTime < playerScore)
        {
            bestTime = playerScore;
            PlayerPrefs.SetFloat("HiScore", bestTime);
        }


    }
    public void ClearGame()
    {
        isGameover = false;
    }

    IEnumerator BonusZeroCheck()
    {
        yield return new WaitForSeconds(0.2f);
        GData.bonusTime -= 10;
        
        isCoCheck = false;
    }
}
