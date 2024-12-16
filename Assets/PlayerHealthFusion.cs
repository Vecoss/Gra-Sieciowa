using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerHealthFusion : NetworkBehaviour
{
    [Networked] public int Lives { get; set; } = 3; // Liczba ¿yæ synchronizowana sieciowo

    public void TakeDamage()
    {
        if (Object.HasStateAuthority)
        {
            Lives--;
            Debug.Log($"Gracz {Object.InputAuthority} straci³ ¿ycie. Pozosta³o: {Lives}");

            if (Lives <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        if (Object.HasStateAuthority)
        {
            Runner.Despawn(Object); // Usuniêcie obiektu gracza
        }
    }
}