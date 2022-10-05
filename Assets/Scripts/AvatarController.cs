using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapTransform
{
    public Transform vrTarget;
    public Transform IKTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void MapVRAvatar()
    {
        IKTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        IKTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}
public class AvatarController : MonoBehaviour
{
    public List<MapTransform> avatarJoints;
    [SerializeField] private MapTransform head;
    [SerializeField] private MapTransform leftHand;
    [SerializeField] private MapTransform rightHand;
    [SerializeField] private MapTransform leftFingerIndex;
    [SerializeField] private MapTransform leftFingerMiddle;
    [SerializeField] private MapTransform leftFingerRing;
    [SerializeField] private MapTransform leftFingerPinky;
    [SerializeField] private MapTransform leftFingerThumb;
    [SerializeField] private MapTransform rightFingerIndex;
    [SerializeField] private MapTransform rightFingerMiddle;
    [SerializeField] private MapTransform rightFingerRing;
    [SerializeField] private MapTransform rightFingerPinky;
    [SerializeField] private MapTransform rightFingerThumb;

    [SerializeField] private float turnSmoothness;

    [SerializeField] private Transform IKHead;

    [SerializeField] private Vector3 headBodyOffset;

    private void Awake() {
        if (avatarJoints.Count == 0) {
            avatarJoints = new List<MapTransform>();
            avatarJoints.Add(head);
            avatarJoints.Add(leftHand);
            avatarJoints.Add(rightHand);
            avatarJoints.Add(leftFingerIndex);
            avatarJoints.Add(leftFingerMiddle);
            avatarJoints.Add(leftFingerRing);
            avatarJoints.Add(leftFingerPinky);
            avatarJoints.Add(leftFingerThumb);
            avatarJoints.Add(rightFingerIndex);
            avatarJoints.Add(rightFingerMiddle);
            avatarJoints.Add(rightFingerRing);
            avatarJoints.Add(rightFingerPinky);
            avatarJoints.Add(rightFingerThumb);
        }

    }

    public void AssignMappings(List<GameObject> sourceIKMapping) {
        Debug.Assert(sourceIKMapping.Count == avatarJoints.Count);
        for (int i=0; i<avatarJoints.Count; i++) {
            avatarJoints[i].vrTarget = sourceIKMapping[i].transform;
        }
    }
        

    void LateUpdate()
    {
        transform.position = IKHead.position + headBodyOffset;
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(IKHead.forward, Vector3.up).normalized, Time.deltaTime * turnSmoothness); ;
        head.MapVRAvatar();
        leftHand.MapVRAvatar();
        rightHand.MapVRAvatar();
        leftFingerIndex.MapVRAvatar();
        leftFingerMiddle.MapVRAvatar();
        leftFingerRing.MapVRAvatar();
        leftFingerPinky.MapVRAvatar();
        leftFingerThumb.MapVRAvatar();

        rightFingerIndex.MapVRAvatar();
        rightFingerMiddle.MapVRAvatar();
        rightFingerRing.MapVRAvatar();
        rightFingerPinky.MapVRAvatar();
        rightFingerThumb.MapVRAvatar();
    }
}
