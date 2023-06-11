using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMesh : MonoBehaviour
{
 [HideInInspector]  //ocultar variable
 public Transform perseguirObjetivo;

 private UnityEngine.AI.NavMeshAgent navMeshAgent;


  void Awake ()
  {
    navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
  }
 //metodo que actualiza el waypoint del agente
 //punto concreto donde debe ir el agente
 public void ActualizarWaypointNavMeshAgent(UnityEngine.Vector3 wayPoint)
  {
    navMeshAgent.destination = wayPoint; //punto de destino
    navMeshAgent.isStopped = false;
  }

  // metodo que se utiliza para la persecucion del enemigo hacia el jugador
 public void ActualizarWaypointNavMeshAgent()
 {
   ActualizarWaypointNavMeshAgent(perseguirObjetivo.position); 
 }

  // para que el enemigo se detenga su estado de patrulla, ya sea para los waypoints o para el jugador
 public void StopNavMeshAgent()
  {
    navMeshAgent.isStopped = true;
  }

  //funcion que se genera para saber si el enemigo llega o no al waypoint
  public bool HaLlegado()
  {     //distancia que falta para llegar al punto d destino, si es menor que la distancia que se tiene para llegar a cierto waypoint, significa que se ha llegado al destino
    return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending; //-> funcion que establece que no hay camino sobrante para recorrer
  }

}
