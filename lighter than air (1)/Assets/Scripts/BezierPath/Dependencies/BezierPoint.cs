using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierPoint : MonoBehaviour
{
    //Public attributes
    [SerializeField] public Vector3 tangent = new Vector3(0.0f, 0.0f, 0.0f);
    [SerializeField] public Vector3 bitangent = new Vector3(0.0f, 0.0f, 0.0f);

    //Renders the bezier point in the scene view
    void OnDrawGizmos()
    {
        //Draw the bezier point position gizmo
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.1f);

        //Draw the bezier point tangent gizmo
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(tangent, 0.1f);

        //Draw the bezier point bitangent gizmo
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(bitangent, 0.1f);

        //Draw the lines from the bezier point to the tangent and bitangent
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, tangent);
        Gizmos.DrawLine(transform.position, bitangent);
    }
}