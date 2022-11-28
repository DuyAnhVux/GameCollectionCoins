using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private int count;
    public GameObject winTextObject;
    void Start()
    {
        count = 0;
        setCountText();
        winTextObject.SetActive(false);
    }
    void setCountText()
    {
        scoreText.text = "Count: " + count.ToString();
        if(count >= 30)
        {
            winTextObject.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            count = count + 4;
            setCountText();
        }
        if (other.gameObject.tag == "Rock")
        {
            other.gameObject.SetActive(false);
            count = count - 6;
            setCountText();
        }
    }
}
