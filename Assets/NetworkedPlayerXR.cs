using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkedPlayerXR : NetworkBehaviour
{
    public Vector3 m_TargetServerOnly;
    
    // Update is called once per frame
    void Update()
    {
        if (IsOwner) {
            SendTargetToServerRPC(transform.position);
        }
        if (IsHost || IsServer || IsClient) {
            transform.position = m_TargetServerOnly;
        }
    }

    [ServerRpc]
    public void SendTargetToServerRPC(Vector3 target) {
        m_TargetServerOnly = target;
    }
}
