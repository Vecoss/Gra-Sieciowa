using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerHealthFusion : NetworkBehaviour
{
    [Networked] public int Lives { get; set; } = 3; // Liczba �y� synchronizowana sieciowo

    public void TakeDamage()
    {
        if (Object.HasStateAuthority)
        {
            Lives--;
            Debug.Log($"Gracz {Object.InputAuthority} straci� �ycie. Pozosta�o: {Lives}");

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
            Runner.Despawn(Object); // Usuni�cie obiektu gracza
        }
    }
}