using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BezierPath))]
public class BezierPathEditor : Editor
{
    //Renders and updates the bezier path inspector
    public override void OnInspectorGUI()
    {
        //Create reference to the bezier path
        BezierPath path = target as BezierPath;

        //Update the resolution attribute
        UpdateResolution(ref path);

        //If the user presses the update path button
        if (GUILayout.Button("Update Path"))
        {
            //Update bezier path
            UpdateBezierPath(ref path);
        }

        //If the user presses the add point button
        if (GUILayout.Button("Add Point"))
        {
            //Add a bezier point to the bezier path
            AddBezierPoint(ref path);
        }

        //If the user presses the remove all button
        if(GUILayout.Button("Remove All Points"))
        {
            //Remove all the bezier points in the bezier path
            RemoveAllBezierPoints(ref path);
        }
    }

    //Updates the resolution attribute
    private void UpdateResolution(ref BezierPath path)
    {
        //Update the resolution attribute
        path.resolution = EditorGUILayout.IntSlider("Resolution", path.resolution, 1, 64);
    }

    //Updates the bezier path
    private void UpdateBezierPath(ref BezierPath path)
    {
        //Remove all curved points
        path.ClearCurvedPoints();

        //Remove all curved point distances
        path.ClearCurvedPointDistances();

        //For each bezier point in the bezier path
        for (int bezierPointIndex = 1; bezierPointIndex < path.points.Count; ++bezierPointIndex)
        {
            //Create curved points
            Vector3[] curvedPoints = Handles.MakeBezierPoints(path.points[bezierPointIndex - 1].transform.position,
                                                              path.points[bezierPointIndex].transform.position,
                                                              path.points[bezierPointIndex - 1].tangent,
                                                              path.points[bezierPointIndex].bitangent,
                                                              path.resolution);

            //For each curved point
            for (int curvedPointIndex = 0; curvedPointIndex < curvedPoints.Length; ++curvedPointIndex)
            {
                //Add curved point to the bezier path
                path.AddCurvedPoint(curvedPoints[curvedPointIndex]);
            }
        }

        //For each curved point in the bezier path
        for(int curvedPointIndex = 0; curvedPointIndex < path.GetCurvedPointsCount(); ++curvedPointIndex)
        {
            //If the curved point is the first curved point in the bezier path
            if (curvedPointIndex == 0)
            {
                //Add a curved point distance of zero
                path.AddCurvedPointDistance(0.0f);
            }
            //Otherwise
            else
            {
                //Add a curved point distance of the previous curved point distance and the distance between the previous and current curved point
                path.AddCurvedPointDistance(path.GetCurvedPointDistanceAt(curvedPointIndex - 1) + Vector3.Distance(path.GetCurvedPointAt(curvedPointIndex - 1), path.GetCurvedPointAt(curvedPointIndex)));
            }
        }

        //Render the scene view
        SceneView.RepaintAll();
    }

    //Adds a new bezier point to the bezier path
    private void AddBezierPoint(ref BezierPath path)
    {
        //Create bezier point GameObject
        GameObject bezierPoint = new GameObject("Point " + (path.points.Count + 1).ToString());

        //Configure bezier point GameObject
        bezierPoint.transform.parent = path.transform;

        //Create and add new bezier point to the bezier path
        path.points.Add(bezierPoint.AddComponent<BezierPoint>());
    }

    //Removes all the bezier points in the bezier path
    private void RemoveAllBezierPoints(ref BezierPath path)
    {
        //Remove all curved points
        path.ClearCurvedPoints();

        //Remove all curved point distances
        path.ClearCurvedPointDistances();

        //While there are bezier points in the bezier path
        while (path.points.Count > 0)
        {
            //Destroy the first bezier point in the bezier path
            DestroyImmediate(path.points[0].gameObject);

            //Remove the first bezier point in the bezier path
            path.points.RemoveAt(0);
        }
    }
}