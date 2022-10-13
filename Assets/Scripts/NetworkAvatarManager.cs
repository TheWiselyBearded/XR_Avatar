using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkAvatarManager : NetworkBehaviour
{

    public override void OnNetworkSpawn() {
        if (!IsOwner) Destroy(gameObject.GetComponent<AvatarController>());
    }
}
