using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;
    public int score = 0;
    public Text scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        WeaponSwitch weaponSwitch = GetComponent<WeaponSwitch>();
    }

    
    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    
    private void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
    }
}