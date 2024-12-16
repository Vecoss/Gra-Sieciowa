using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton, aby u³atwiæ dostêp do instancji GameManagera
    public Text gameOverText;            // Tekst wyœwietlaj¹cy wynik (wygrana/przegrana)
    public GameObject gameOverPanel;     // Panel, który pojawia siê na koñcu gry

    private void Awake()
    {
        // Tworzenie instancji Singletona
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Ukrycie panelu Game Over na pocz¹tku gry
        gameOverPanel.SetActive(false);
    }

    public void EndGame(string result)
    {
        // Wyœwietlenie wyniku gry
        gameOverPanel.SetActive(true);
        gameOverText.text = result; // Przyk³adowo: "Wygrana" lub "Przegrana"
    }
}
