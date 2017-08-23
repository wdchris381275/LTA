using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierPath : MonoBehaviour
{
    //Public attributes
    [SerializeField] public int resolution = 16;
    [SerializeField] public List<BezierPoint> points = new List<BezierPoint>();

    //Private attributes
    [SerializeField] private List<Vector3> curvedPoints = new List<Vector3>();
    [SerializeField] private List<float> curvedPointDistances = new List<float>();

    //Renders the bezier path in the scene view
    void OnDrawGizmos()
    {
        //Set the bezier path color to blue
        Gizmos.color = Color.blue;

        //For each curved point
        for(int curvedPointIndex = 1; curvedPointIndex < curvedPoints.Count; ++curvedPointIndex)
        {
            //Draw line from the previous curved point to the current curved point
            Gizmos.DrawLine(curvedPoints[curvedPointIndex - 1], curvedPoints[curvedPointIndex]);
        }
    }

    //Adds a curved point to the bezier curved points list
    public void AddCurvedPoint(Vector3 curvedPoint)
    {
        //Add the curved point to the curved points list
        curvedPoints.Add(curvedPoint);
    }

    //Adds a curved point distance to the bezier curved point distances list
    public void AddCurvedPointDistance(float distance)
    {
        //Add a curved point distance to the bezier curved point distances list
        curvedPointDistances.Add(distance);
    }

    //Clears all of the bezier curved points
    public void ClearCurvedPoints()
    {
        //Clear all of the bezier curved points
        curvedPoints.Clear();
    }

    //Clears all of the bezier curved point distances
    public void ClearCurvedPointDistances()
    {
        //Clear all of the bezier curved point distances
        curvedPointDistances.Clear();
    }

    //Return the number of curved points in the bezier path
    public int GetCurvedPointsCount()
    {
        //Return the number of curved points in the bezier path
        return curvedPoints.Count;
    }

    //Return the number of curved point distances in the bezier path
    public int GetCurvedPointDistancesCount()
    {
        //Return the number of curved point distances in the bezier path
        return curvedPointDistances.Count;
    }

    //Returns the curved point at the specified index in the curved points list
    public Vector3 GetCurvedPointAt(int index)
    {
        //Return the curved point at the specified index in the curved points list
        return curvedPoints[index];
    }

    //Returns the curved point distance at the specified index in the curved point distances list
    public float GetCurvedPointDistanceAt(int index)
    {
        //Return the curved point distance at the specified index in the curved point distances list
        return curvedPointDistances[index];
    }

    //Returns the position an object should have when at the specified distance from the start of the bezier path
    public Vector3 GetPositionFromDistance(float distance)
    {
        //For each curved point distance in the bezier path
        for(int curvedPointDistanceIndex = 1; curvedPointDistanceIndex < curvedPointDistances.Count; ++curvedPointDistanceIndex)
        {
            //If the curved point distance is more or equal to the specified distance
            if(curvedPointDistances[curvedPointDistanceIndex] >= distance)
            {
                //Calculate the missing distance from the desired position on the path to the curved point
                float missingDistance = curvedPointDistances[curvedPointDistanceIndex] - distance;

                //Calculate the direction to the desired position from the curved point
                Vector3 desiredPositionDirection = Vector3.Normalize(curvedPoints[curvedPointDistanceIndex - 1] - curvedPoints[curvedPointDistanceIndex]);

                //Return the desired position on the bezier path
                return curvedPoints[curvedPointDistanceIndex] + desiredPositionDirection * missingDistance;
            }
        }
        
        //If there is one or more curved points in the bezier path
        if(curvedPoints.Count > 0)
        {
            //Return the position of the last curved point in the bezier path
            return curvedPoints[curvedPoints.Count - 1];
        }

        //Return default position
        return new Vector3(0.0f, 0.0f, 0.0f);
    }

    //Returns the rotation an object should have when at the specified distance from the start of the bezier path
    public Quaternion GetRotationFromDistance(float distance)
    {
        //For each curved point distance in the bezier path
        for(int curvedPointDistanceIndex = 1; curvedPointDistanceIndex < curvedPointDistances.Count; ++curvedPointDistanceIndex)
        {
            //If the curved point distance is more or equal to the specified distance
            if(curvedPointDistances[curvedPointDistanceIndex] >= distance)
            {
                //Calculate the direction to the curved point from the previous curved point
                Vector3 curvedPointDirection = Vector3.Normalize(curvedPoints[curvedPointDistanceIndex] - curvedPoints[curvedPointDistanceIndex - 1]);

                //Return a rotation that looks at the curved point from the previous curved point
                return Quaternion.LookRotation(curvedPointDirection);
            }
        }

        //If there is one or more points in the bezier path
        if(points.Count > 0)
        {
            //Return a rotation that looks at the last points tangent
            return Quaternion.LookRotation(points[points.Count - 1].tangent);
        }

        //Return default rotation
        return Quaternion.identity;
    }
}