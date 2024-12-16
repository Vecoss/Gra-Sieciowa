using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Shooting : NetworkBehaviour
{
    public NetworkPrefabRef bulletPrefab; // Prefab pocisku
    public Transform firePoint;           // Punkt wystrza³u
    public float reloadTime = 2f;         // Czas prze³adowania
    private float nextFireTime = 0f;      // Czas na nastêpny strza³
    public float bulletSpeed = 20f;       // Prêdkoœæ pocisku


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
                // Ustawienie prêdkoœci pocisku
                obj.GetComponent<Bullet_Fusion>().Initialize(firePoint.forward, bulletSpeed);
            });
    }
}
