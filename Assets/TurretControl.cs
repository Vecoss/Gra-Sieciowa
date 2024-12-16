using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public Transform turret; // Wie¿a
    public Transform gun;    // Dzia³o

    public float turretRotationSpeed = 50f; // Szybkoœæ obrotu wie¿y
    public float gunRotationSpeed = 30f;   // Szybkoœæ obrotu dzia³a
    public float minGunAngle = -10f;       // Minimalny k¹t dzia³a (w dó³)
    public float maxGunAngle = 20f;        // Maksymalny k¹t dzia³a (w górê)

    void Start()
    {
        // Ukryj kursor i ustaw go na œrodek
        Cursor.lockState = CursorLockMode.Locked; // Zablokowanie kursora na œrodku ekranu
        Cursor.visible = false;                  // Ukrycie kursora
    }

    void OnApplicationFocus(bool hasFocus)
    {
        // Zapewnia, ¿e kursor nadal bêdzie ukryty po utracie i odzyskaniu okna gry
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
        // Obrót wie¿y w lewo/prawo na podstawie ruchu myszki w osi X
        float mouseX = Input.GetAxis("Mouse X"); // Ruch myszy w osi X
        turret.Rotate(0, mouseX * turretRotationSpeed * Time.deltaTime, 0);
    }

    void AdjustGun()
    {
        // Pobierz ruch myszy w osi Y (góra/dó³)
        float mouseY = Input.GetAxis("Mouse Y");

        // Pobierz aktualny k¹t dzia³a w osi Z
        float currentGunAngle = gun.localEulerAngles.z;

        // Dostosuj k¹t, aby by³ w zakresie 0-360
        if (currentGunAngle > 180f) currentGunAngle -= 360f;

        // Oblicz nowy k¹t dzia³a z ograniczeniem zakresu
        float newGunAngle = Mathf.Clamp(
            currentGunAngle - mouseY * gunRotationSpeed * Time.deltaTime,
            minGunAngle,
            maxGunAngle
        );

        // Zastosuj nowy k¹t tylko w osi Z
        gun.localEulerAngles = new Vector3(gun.localEulerAngles.x, gun.localEulerAngles.y, newGunAngle);
    }
}