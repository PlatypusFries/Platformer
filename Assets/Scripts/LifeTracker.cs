using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeTracker : MonoBehaviour
{

    static public LifeTracker instance;

    Text lifeText;
    public int startingLives;
    int playerLives;

    void Awake()
    {
        instance = this;

        playerLives = startingLives;

        lifeText = GetComponent<Text>();
        lifeText.text = "Lives: " + playerLives.ToString();
    }

    public void AddLife()
    {
        playerLives += 1;
        lifeText.text = "Lives: " + playerLives.ToString();
    }

    public void SubtractLife()
    {
        playerLives -= 1;
        lifeText.text = "Lives: " + playerLives.ToString();
        if ( playerLives < 0 )
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}