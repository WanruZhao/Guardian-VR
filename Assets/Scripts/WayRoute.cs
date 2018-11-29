using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayRoute : MonoBehaviour {

    public GameObject spawnpoint;
    public GameObject[] waypoints;
    public GameObject endpoint;

    public int routetag;

    LineRenderer linerenderer;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 1.0f);

        Transform currentTransform, nextTransform;
        currentTransform = spawnpoint.transform;
        
        if(waypoints.Length == 0)
        {
            nextTransform = endpoint.transform;
            Gizmos.DrawLine(currentTransform.position, nextTransform.position);

        } else
        {
            nextTransform = waypoints[0].transform;
            Gizmos.DrawLine(currentTransform.position, nextTransform.position);
            for (int i = 0; i < waypoints.Length - 1; i++)
            {
                currentTransform = waypoints[i].transform;
                nextTransform = waypoints[i + 1].transform;
                Gizmos.DrawLine(currentTransform.position, nextTransform.position);
            }

            Gizmos.DrawLine(waypoints[waypoints.Length - 1].transform.position, endpoint.transform.position);
        }
        
    }

}
