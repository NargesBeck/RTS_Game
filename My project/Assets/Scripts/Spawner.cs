using Mirror;
using UnityEngine;

public class Spawner : NetworkBehaviour
{
    [Command]
    public virtual void SpawnThis(GameObject prefab, Transform spawnPoint)
    {
        GameObject instantiated = Instantiate(prefab, spawnPoint);
    }
}
