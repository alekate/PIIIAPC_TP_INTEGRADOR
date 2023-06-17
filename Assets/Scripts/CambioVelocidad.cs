using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;



public class CambioVelocidad : MonoBehaviour
{


  private MaquinaDeEstados maquinaDeEstados;
  private NavMesh navMesh;
  private ControladorVision controladorVision;
  private EstadoPersecucion estadoPersecucion;
  private PlayerController playerController;
  private NavMeshAgent _agent;


  private Color color; // Variable local para almacenar el color


  public Color colorMax = Color.red;
  public Color colorMedia = Color.yellow;
  public Color colorMin = Color.green;

  public float velMaxima = 7f;
  public float velMedia = 5f;
  public float velMinima = 2f;


  void OnEnable()
  {
    maquinaDeEstados = GetComponent<MaquinaDeEstados>();
    navMesh = GetComponent<NavMesh>();
    controladorVision = GetComponent<ControladorVision>();
    estadoPersecucion = GetComponent<EstadoPersecucion>();
    playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    

  }

  MeshRenderer meshRenderer;

  void Start()
  {
    //Asegurarse de que el objeto tiene un componente MeshRenderer
    meshRenderer = GetComponent<MeshRenderer>();
    if (meshRenderer == null)
    {
      Debug.LogError("El objeto no tiene un componente MeshRenderer.");
    }
    _agent = GetComponent<NavMeshAgent>();
  }

  void Update()
  {

    float velocidadActual = _agent.velocity.magnitude; // Variable local para almacenar la velocidad actual
    
    // Calcula la velocidad actual del agente
    velocidadActual = _agent.velocity.magnitude;

      
    if (velocidadActual >= velMaxima)
    {
      color = colorMax;
    }
    else if (velocidadActual >= velMedia)
    {
      color = colorMedia;
    }
    else
    {
      color = colorMin;
    }

    meshRenderer.material.color = color;
    

  }


}