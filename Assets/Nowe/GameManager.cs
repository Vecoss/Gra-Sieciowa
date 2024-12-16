using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton, aby u�atwi� dost�p do instancji GameManagera
    public Text gameOverText;            // Tekst wy�wietlaj�cy wynik (wygrana/przegrana)
    public GameObject gameOverPanel;     // Panel, kt�ry pojawia si� na ko�cu gry

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
        // Ukrycie panelu Game Over na pocz�tku gry
        gameOverPanel.SetActive(false);
    }

    public void EndGame(string result)
    {
        // Wy�wietlenie wyniku gry
        gameOverPanel.SetActive(true);
        gameOverText.text = result; // Przyk�adowo: "Wygrana" lub "Przegrana"
    }
}
