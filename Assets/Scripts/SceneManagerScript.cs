using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : NetworkBehaviour
{
    [SerializeField] GameObject playerPrefab;
    bool initialSpawnDone = false;

    public override void OnNetworkSpawn()
    {
        //Ao terminar de carregar a cena, executar um evento;
        if (IsServer)
        {
            NetworkManager.Singleton.SceneManager.OnLoadEventCompleted += SceneManager_OnLoadEventCompleted;
        }
    }

    private void SceneManager_OnLoadEventCompleted(string sceneName, LoadSceneMode loadSceneMode,
    List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
    {
        if (!initialSpawnDone)
        {
            initialSpawnDone = true;
            foreach (ulong id in NetworkManager.Singleton.ConnectedClientsIds)
            {
                //Instanciar o objeto player;
                GameObject playerTransform = Instantiate(playerPrefab);

                //Usar a funcao de "SpawnAsPlayerObject" dentro do NetworkObject para conectar o player;
                NetworkObject networkObject = playerTransform.GetComponent<NetworkObject>();

                networkObject.SpawnAsPlayerObject(id, true);


            }
        }
    }
}
