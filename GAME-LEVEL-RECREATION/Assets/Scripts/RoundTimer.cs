using TMPro;
using UnityEngine;

public class RoundTimer : MonoBehaviour
{
    public GameManager gameManager;
    public float currentTime = 0f;
    public float startingTime;

    public TextMeshProUGUI roundTimeText;

    private bool isEnd;

    private void Start()
    {
        isEnd = false;
        startingTime = 30f;
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        roundTimeText.text = currentTime.ToString("0");

        if(currentTime <= 10 &&  currentTime > 5)
        {
            roundTimeText.color = Color.yellow;
        }

        else if(currentTime <= 5)
        {
            roundTimeText.color = Color.red;
        }

        if(currentTime <= 0 )
        {
            currentTime = 0;
            if(!isEnd)
            {
                gameManager.DispalyDraw();
            }
            isEnd = true;
        }
    }
}
