using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;        // Obiekt gracza, za kt�rym kamera pod��a
    public Vector3 offset = new Vector3(0, 3, -5); // Offset kamery wzgl�dem gracza
    public Vector3 customAngle = new Vector3(20, 0, 0); // K�t kamery (Pitch, Yaw, Roll)

    void LateUpdate()
    {
        // Ustawienie pozycji kamery wzgl�dem gracza
        transform.position = player.position + player.rotation * offset;

        // Ustawienie k�ta kamery wed�ug customAngle
        Quaternion customRotation = Quaternion.Euler(customAngle);
        transform.rotation = player.rotation * customRotation;
    }
}
