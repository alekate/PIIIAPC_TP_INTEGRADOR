using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPatrulla : MonoBehaviour {
 //cargar variable
  public Transform[] WayPoints;

  private MaquinaDeEstados maquinaDeEstados;
  private NavMesh navMesh;
  private ControladorVision controladorVision;
  private int nextWayPoint;

  void Awake()
  {
    maquinaDeEstados = GetComponent<MaquinaDeEstados>();
    navMesh = GetComponent<NavMesh>();
    controladorVision = GetComponent<ControladorVision>();
  }

  void Update()
  {
    //puede ver al jugador?
    RaycastHit hit;
    if (controladorVision.CanSeePlayer(out hit)) 
    {
      navMesh.perseguirObjetivo = hit.transform;
      maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
      return; //-> genera que el estado patrulla no se ejecute cuanto este activo el estado persecucion
    }

    if (navMesh.HaLlegado())
    {
      nextWayPoint = (nextWayPoint + 1) % WayPoints.Length;
      actualizarWayPoint();
    }

  }
     
  void OnEnable()
  {
    actualizarWayPoint();
  }

  void actualizarWayPoint()
  {
    navMesh.ActualizarWaypointNavMeshAgent(WayPoints[nextWayPoint].position);
  }

  //se sabra que el jugador ha entrado en el area del enemigo
  public void OnTriggerEnter(Collider other)
  {
   if (other.gameObject.CompareTag("Player") && enabled)
    {
      maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
    }
  }

}
