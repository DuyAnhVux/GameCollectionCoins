using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text score;
    private int countCoins;
    private int sumScore;
    void Start()
    {
        countCoins = 0;
        sumScore = 0;
        setCountText();
        FindObjectOfType<GameManager>().showGamePanel(false);
    }
    void setCountText()
    {
        scoreText.text = "Coins: " + countCoins.ToString();   
    }
    void setScore()
    {
        score.text = "Score: " + sumScore.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            countCoins = countCoins +1;
            sumScore = sumScore + 5;
            setCountText();
            setScore();
        }     
    }
}
