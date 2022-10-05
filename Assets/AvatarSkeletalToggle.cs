using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSkeletalToggle : MonoBehaviour
{
    public GameObject[] skeletalBodyParts;
    [SerializeField] public SkinnedMeshRenderer[] skinnedMeshRenderers;

    public void Start() {
        skinnedMeshRenderers = new SkinnedMeshRenderer[skeletalBodyParts.Length];
        for (int i=0; i<skeletalBodyParts.Length;i++) {
            skinnedMeshRenderers[i] = skeletalBodyParts[i].GetComponent<SkinnedMeshRenderer>();
        }
    }

    public void ToggleBodyParts(bool state) {
        foreach (SkinnedMeshRenderer smr in skinnedMeshRenderers)
            smr.enabled = state;
    }
}
