using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EstadoPersecucion : MonoBehaviour
{
  private MaquinaDeEstados maquinaDeEstados;
  private NavMesh navMesh;
  private ControladorVision controladorVision;
    
    
  void Awake()
  {
    maquinaDeEstados = GetComponent<MaquinaDeEstados>();
    navMesh = GetComponent<NavMesh>();  
    controladorVision = GetComponent<ControladorVision>();
  }

   
  void Update()            //enemigo vaya a la posicion donde este el jugador
  {                             //estado alerta cuando el enemigo no ve al jugador
    RaycastHit hit;
    if(!controladorVision.CanSeePlayer(out hit, true))
    {
     maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
     return; //para que no se actualice el waypoint navmeshagent
    }

    navMesh.ActualizarWaypointNavMeshAgent(); 
    
  }
}
