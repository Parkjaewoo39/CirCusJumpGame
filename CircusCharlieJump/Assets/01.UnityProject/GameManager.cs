using UnityEngine;
using UnityEngine.UI;


public class GamieManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text TimeText;
    public Text HiscordText;
    public Text ScoreText;
    float playerScore;

    private float bonusTime;
    private bool isGameover;
    // Start is called before the first frame update
    void Start()
    {
        bonusTime = 5000;
        isGameover= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            bonusTime += Time.deltaTime * 10;
            TimeText.text = "5000" + (-1) * (int)bonusTime;
        }
        else 
        {
           
        }
    }
    public void EndGame() 
    {
        isGameover = true;
        gameoverText.SetActive(true);
        ScoreText.text += TimeText.text; 
        
        float bestTime = PlayerPrefs.GetFloat("HIScore");

       // if(playerScore > bestTime)
    }
}
