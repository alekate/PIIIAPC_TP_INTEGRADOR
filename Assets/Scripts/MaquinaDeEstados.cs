using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MaquinaDeEstados : MonoBehaviour  {   
  
  public MonoBehaviour EstadoPatrulla;      //publicas en mayus, priv en minusc
  public MonoBehaviour EstadoAlerta;
  public MonoBehaviour EstadoPersecucion;
  public MonoBehaviour EstadoInicial;
  public MonoBehaviour CambioVelocidad;
  private NavMeshAgent _agent;
  private MonoBehaviour estadoActual;
  

  public void Start() {
    ActivarEstado(EstadoInicial);
  }

  public void ActivarEstado(MonoBehaviour nuevoEstado)
  {
    if(estadoActual != null) estadoActual.enabled = false;
    {
      estadoActual = nuevoEstado;
      estadoActual.enabled = true;
    }

  }

  public MonoBehaviour getEstadoActual
  { 
   get { return estadoActual; }
   set { estadoActual = value; }
  }

  public MonoBehaviour getPersecucion
  {
    get { return EstadoPersecucion; }
  }

}
