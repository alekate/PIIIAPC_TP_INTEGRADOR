using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPatrulla : MonoBehaviour {

    public Transform[] WayPoints;

    private NavMesh navMesh;

    private int nextWayPoint;

    void Awake()
    {
        navMesh = GetComponent<NavMesh>();
    }

    void Update() {
       if (navMesh.HaLlegado())
       {
         nextWayPoint = (nextWayPoint + 1) % WayPoints.Length;
         ActualizarWaypointDestino();
       }
    }

     
    void OnEnable()
    {
        ActualizarWaypointDestino();
    }

    void ActualizarWaypointDestino()
    {
       navMesh.ActualizarWaypointNavMeshAgent(WayPoints[nextWayPoint].position);
    }

}
