using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (SphereCollider))]
[RequireComponent (typeof (Rigidbody))]
public class LightNode : MonoBehaviour {
    private SphereCollider col;
    public SphereCollider Col { get { return col; } private set { col = value; } }

    private Transform reflectionZone;
    public Transform ReflectionZone { get { return reflectionZone; } private set { reflectionZone = value; } }

    private Rigidbody rb;
    public Rigidbody Rb { get { return rb; } private set { rb = value; } }

    private Transform optionalOutput;
    public Transform OptionalOutput { get { return optionalOutput; } private set { optionalOutput = value; } }

    public enum NodeType {
        target, // the goal
        mirror, // reflects across the normal axis
        focus, // directs in a given direction
        torch // moves directly upward
    }

    public NodeType nodeType;

    [HideInInspector] public Vector3 reflectionNormal;

    void Start () {
        GetInitialObjects ();
    }

    void GetInitialObjects () {
        rb = GetComponent<Rigidbody> ();
        col = GetComponent<SphereCollider> ();
        col.isTrigger = true;
        rb.isKinematic = true;

        reflectionZone = transform.Find ("ReflectionZone");
        optionalOutput = transform.Find ("OptionalOutput");
    }

    // override this in particular types of nodes if need be
    public virtual Vector3 ReflectionoOutputVector (float beamDistance, Vector3 inputVector) {
        Vector3 targetPos = Vector3.zero;
        switch (nodeType) {
            case NodeType.target:
                targetPos = Vector3.zero;
                break;
            case NodeType.mirror:
                targetPos = Vector3.zero;
                break;
            case NodeType.focus:
                targetPos = optionalOutput.position + optionalOutput.rotation * (Vector3.forward * beamDistance);
                break;
            case NodeType.torch:
                targetPos = optionalOutput.position + Vector3.up * beamDistance;
                break;
            default:
                targetPos = Vector3.zero;
                break;
        }
        return targetPos;
    }

    #region Gizmo Functions
    void DrawForwardVector () {
        Gizmos.color = Color.red;
        Vector3 targetPos = transform.position + transform.rotation * (Vector3.forward * 3f);
        Gizmos.DrawLine (col.transform.position, targetPos);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere (targetPos, 0.25f);
    }

    public virtual void DrawOutputPath () {
        Vector3 optionalPos = optionalOutput.position;
        Vector3 calculatedTarget = ReflectionoOutputVector (3f, Vector3.zero);
        Vector3 targetPos;
        switch (nodeType) {
            case NodeType.focus:
                Gizmos.color = Color.cyan;
                Gizmos.DrawWireSphere (optionalPos, 0.5f);

                //targetPos = optionalPos + optionalOutput.rotation * (Vector3.forward * 3f);
                targetPos = calculatedTarget;

                Gizmos.color = Color.white;
                Gizmos.DrawLine (optionalPos, targetPos);
                Gizmos.color = Color.cyan;
                Gizmos.DrawWireSphere (targetPos, 0.15f);

                break;
            case NodeType.torch:
                //targetPos = optionalPos + Vector3.up * 3f;
                targetPos = calculatedTarget;

                Gizmos.color = Color.white;
                Gizmos.DrawLine (optionalPos, targetPos);
                Gizmos.color = Color.cyan;
                Gizmos.DrawWireSphere (targetPos, 0.15f);
                break;
            case NodeType.target:
                Gizmos.color = new Color (0.25f, 1, 0.5f, 1);
                Gizmos.DrawWireSphere (transform.position, 1.5f);
                break;
            default:
                break;
        }
        #endregion

        void OnDrawGizmos () {
            GetInitialObjects ();
            DrawForwardVector ();
            DrawOutputPath ();
        }
    }
}