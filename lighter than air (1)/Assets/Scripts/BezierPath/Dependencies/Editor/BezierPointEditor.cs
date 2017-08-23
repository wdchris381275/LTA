using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BezierPoint))]
public class BezierPointEditor : Editor
{
    //Renders the bezier point tangent in the scene view
    void OnSceneGUI()
    {
        //Create reference to the bezier point
        BezierPoint point = target as BezierPoint;

        //Render and update the bezier point tangent handle
        Handles.PositionHandle(point.tangent, Quaternion.identity);
        point.tangent = Handles.DoPositionHandle(point.tangent, Quaternion.identity);

        //Render and update the bezier point bitangent handle
        Handles.PositionHandle(point.bitangent, Quaternion.identity);
        point.bitangent = Handles.DoPositionHandle(point.bitangent, Quaternion.identity);
    }
}