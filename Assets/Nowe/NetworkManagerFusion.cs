using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Fusion;
using UnityEngine.SceneManagement;

public class NetworkManagerFusion : MonoBehaviour
{
    public NetworkPrefabRef playerPrefab;

    private NetworkRunner runner;

    async void Start()
    {
        runner = gameObject.AddComponent<NetworkRunner>();
        runner.ProvideInput = true;

        var result = await runner.StartGame(new StartGameArgs
        {
            GameMode = GameMode.AutoHostOrClient,
            SessionName = "Room1",
            //Scene = SceneManager.GetActiveScene().buildIndex,
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
        });

        if (!result.Ok)
        {
            Debug.LogError($"B³¹d uruchamiania gry: {result.ShutdownReason}");
        }
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if (runner.IsServer)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-5, 5), 1, Random.Range(-5, 5));
            runner.Spawn(playerPrefab, spawnPosition, Quaternion.identity, player);
        }
    }
}