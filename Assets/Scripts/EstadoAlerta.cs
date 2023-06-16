using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAlerta : MonoBehaviour
{
  public float velocitySearch = 120f;
  public float durationSearch = 4;

  private MaquinaDeEstados maquinaDeEstados; 
  private NavMesh navMesh;
  private ControladorVision controladorVision;
  private float timeSearching;

  void Awake()
  {
    maquinaDeEstados = GetComponent<MaquinaDeEstados>();
    navMesh = GetComponent<NavMesh>();
    controladorVision = GetComponent<ControladorVision>();
  }

  void OnEnable(){
    timeSearching = durationSearch;
    navMesh.StopNavMeshAgent();
  }


  void Update()
  {     
        
    RaycastHit hit;
    if (controladorVision.CanSeePlayer(out hit)) 
    {
      navMesh.perseguirObjetivo = hit.transform;
      maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
      return; //-> genera que el estado patrulla no se ejecute cuanto este activo el estado persecucion
    }
        
    //vel en x, z, y
    transform.Rotate(0f, velocitySearch * Time.deltaTime, 0f);
    timeSearching -= Time.deltaTime;

    if(timeSearching <= 0)
    {
      maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPatrulla);
      timeSearching = durationSearch;
      return; //evitar problema por si se quiere agregar mas codigo debajo, que no se ejecute
    }

  }
}
