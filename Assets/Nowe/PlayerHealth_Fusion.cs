using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;


public class PlayerHealth_Fusion : NetworkBehaviour
{
    [Networked] public int Lives { get; set; } = 3; // Liczba �y� synchronizowana w sieci
    private bool isGameOver = false;

    public void TakeDamage()
    {
        if (HasStateAuthority && !isGameOver)
        {
            Lives--;

            Debug.Log($"Gracz {Object.InputAuthority} straci� �ycie. Pozosta�e �ycia: {Lives}");

            if (Lives <= 0)
            {
                HandleGameOver();
            }
        }
    }

    private void HandleGameOver()
    {
        isGameOver = true;

        if (HasStateAuthority)
        {
            // Wywo�anie zako�czenia gry
            GameManager.Instance.EndGame(Object.InputAuthority == Runner.LocalPlayer ? "Przegrana" : "Wygrana");
        }

        // Despawnowanie obiektu gracza
        Runner.Despawn(Object);
    }
}

