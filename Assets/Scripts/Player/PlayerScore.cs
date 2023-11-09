using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;
    public int score = 0;
    public Text scoreText; // Asigna el objeto de texto desde el inspector

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

    // Incrementa la puntuación y actualiza la UI de puntuación
    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    // Actualiza el elemento de UI con la puntuación actual
    private void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
    }
}