using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;        // Obiekt gracza, za którym kamera pod¹¿a
    public Vector3 offset = new Vector3(0, 3, -5); // Offset kamery wzglêdem gracza
    public Vector3 customAngle = new Vector3(20, 0, 0); // K¹t kamery (Pitch, Yaw, Roll)

    void LateUpdate()
    {
        // Ustawienie pozycji kamery wzglêdem gracza
        transform.position = player.position + player.rotation * offset;

        // Ustawienie k¹ta kamery wed³ug customAngle
        Quaternion customRotation = Quaternion.Euler(customAngle);
        transform.rotation = player.rotation * customRotation;
    }
}
