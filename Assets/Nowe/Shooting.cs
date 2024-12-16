using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Shooting : NetworkBehaviour
{
    public NetworkPrefabRef bulletPrefab; // Prefab pocisku
    public Transform firePoint;           // Punkt wystrza�u
    public float reloadTime = 2f;         // Czas prze�adowania
    private float nextFireTime = 0f;      // Czas na nast�pny strza�
    public float bulletSpeed = 20f;       // Pr�dko�� pocisku


    void Update()
    {
        if (HasInputAuthority && Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + reloadTime;
            Shoot();
        }
    }

    private void Shoot()
    {
        // Tworzenie pocisku w miejscu firePoint
        Runner.Spawn(bulletPrefab, firePoint.position, firePoint.rotation, Object.InputAuthority,
            (runner, obj) =>
            {
                // Ustawienie pr�dko�ci pocisku
                obj.GetComponent<Bullet_Fusion>().Initialize(firePoint.forward, bulletSpeed);
            });
    }
}
