using UnityEngine;
using UnityEngine.InputSystem;

public class AvatarAnimationController : MonoBehaviour {
    [SerializeField] private InputActionReference move;

    [SerializeField] private Animator animator;    

    public float mvmtThreshold;
    private Rigidbody rb;
    private Vector3 pastPosition, currentPosition;
    private void Start() {
        //rb = GetComponent<Rigidbody>();
        if (mvmtThreshold == 0.0f) mvmtThreshold = 0.02f;
    }

    private void AnimateLegs6DOFMotion() {
        this.animator.SetBool("isMoving", true  );
        this.animator.SetFloat("animSpeed", 2.0f);
    }

    private void StopAnimation6DOFMotion() {
        this.animator.SetBool("isMoving", false);
        this.animator.SetFloat("animSpeed", 0.0f);
    }

    private void Update() {
        currentPosition = gameObject.transform.position;
        float howFar = currentPosition.FlatDistanceTo(pastPosition);
        //Debug.Log($"Far {howFar}");

        diff = Vector3.Distance(currentPosition, pastPosition);// Mathf.Abs(currentPosition.z - pastPosition.z); //Vector3.Distance(currentPosition, pastPosition);
        if (diff > mvmtThreshold) {
            AnimateLegs6DOFMotion();
        } else {
            StopAnimation6DOFMotion();
        }
        //Debug.Log($"Diff {diff} for {gameObject.name}");
        pastPosition = gameObject.transform.position;
    }

    public void SavePastPosition() {
        pastPosition = gameObject.transform.position;
    }

    [SerializeField]
    public float diff;
    private void LateUpdate() {
        
        // check diff, 
        //float zVel = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z;
        //pastPosition = gameObject.transform.position;
    }
    private void OnEnable() {
        if (move == null) return;
        this.move.action.started += this.AnimateLegs;
        this.move.action.canceled += this.StopAnimation;
    }

    private void OnDisable() {
        if (move == null) return;
        this.move.action.started -= this.AnimateLegs;
        this.move.action.canceled -= this.StopAnimation;
    }

    private void AnimateLegs(InputAction.CallbackContext obj) {
        bool isWalkingFoward = this.move.action.ReadValue<Vector2>().y > 0;

        if (isWalkingFoward) {
            this.animator.SetBool("isMoving", true);
            this.animator.SetFloat("animSpeed", 1.0f);
        } else {
            this.animator.SetBool("isMoving", true);
            this.animator.SetFloat("animSpeed", -1.0f);
        }
    }
    private void StopAnimation(InputAction.CallbackContext obj) {
        this.animator.SetBool("isMoving", false);
        this.animator.SetFloat("animSpeed", 0.0f);
    }
}

public static class Extns {
    public static Vector2 xz(this Vector3 vv) {
        return new Vector2(vv.x, vv.z);
    }

    public static float FlatDistanceTo(this Vector3 from, Vector3 unto) {
        Vector2 a = from.xz();
        Vector2 b = unto.xz();
        return Vector2.Distance(a, b);
    }
}