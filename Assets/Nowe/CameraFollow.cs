using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;


public class CameraFollow : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 5, -10); // Offset kamery wzglêdem gracza
    private Transform playerTransform;             // Transform gracza, za którym kamera pod¹¿a

    void Start()
    {
        // Znajdowanie lokalnego gracza
        FindLocalPlayer();
    }

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Ustawianie pozycji kamery wzglêdem gracza
            transform.position = playerTransform.position + offset;
            transform.LookAt(playerTransform); // Kamera patrzy na gracza
        }
    }

    private void FindLocalPlayer()
    {
        // Znajdowanie gracza z InputAuthority (tylko lokalny gracz)
        foreach (var player in FindObjectsOfType<NetworkObject>())
        {
            if (player.HasInputAuthority)
            {
                playerTransform = player.transform;
                break;
            }
        }
    }
}
