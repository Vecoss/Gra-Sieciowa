using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;


public class Bullet_Fusion : NetworkBehaviour
{
    private Vector3 direction; // Kierunek lotu pocisku
    private float speed;       // Prêdkoœæ pocisku

    public void Initialize(Vector3 direction, float speed)
    {
        this.direction = direction;
        this.speed = speed;
    }

    void Update()
    {
        // Ruch pocisku w zadanym kierunku
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerHealth_Fusion health))
        {
            health.TakeDamage();
        }

        // Usuniêcie pocisku po trafieniu
        Runner.Despawn(Object);
    }
}