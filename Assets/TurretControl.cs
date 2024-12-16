using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public Transform turret; // Wie�a
    public Transform gun;    // Dzia�o

    public float turretRotationSpeed = 50f; // Szybko�� obrotu wie�y
    public float gunRotationSpeed = 30f;   // Szybko�� obrotu dzia�a
    public float minGunAngle = -10f;       // Minimalny k�t dzia�a (w d�)
    public float maxGunAngle = 20f;        // Maksymalny k�t dzia�a (w g�r�)

    void Start()
    {
        // Ukryj kursor i ustaw go na �rodek
        Cursor.lockState = CursorLockMode.Locked; // Zablokowanie kursora na �rodku ekranu
        Cursor.visible = false;                  // Ukrycie kursora
    }

    void OnApplicationFocus(bool hasFocus)
    {
        // Zapewnia, �e kursor nadal b�dzie ukryty po utracie i odzyskaniu okna gry
        if (hasFocus)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {

        RotateTurret();
        AdjustGun();
    }

    void RotateTurret()
    {
        // Obr�t wie�y w lewo/prawo na podstawie ruchu myszki w osi X
        float mouseX = Input.GetAxis("Mouse X"); // Ruch myszy w osi X
        turret.Rotate(0, mouseX * turretRotationSpeed * Time.deltaTime, 0);
    }

    void AdjustGun()
    {
        // Pobierz ruch myszy w osi Y (g�ra/d�)
        float mouseY = Input.GetAxis("Mouse Y");

        // Pobierz aktualny k�t dzia�a w osi Z
        float currentGunAngle = gun.localEulerAngles.z;

        // Dostosuj k�t, aby by� w zakresie 0-360
        if (currentGunAngle > 180f) currentGunAngle -= 360f;

        // Oblicz nowy k�t dzia�a z ograniczeniem zakresu
        float newGunAngle = Mathf.Clamp(
            currentGunAngle - mouseY * gunRotationSpeed * Time.deltaTime,
            minGunAngle,
            maxGunAngle
        );

        // Zastosuj nowy k�t tylko w osi Z
        gun.localEulerAngles = new Vector3(gun.localEulerAngles.x, gun.localEulerAngles.y, newGunAngle);
    }
}