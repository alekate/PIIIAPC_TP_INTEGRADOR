using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;



public class CambioVelocidad : MonoBehaviour
{

    public enum Estado
   {
     Alerta,
     Patrulla,
     Persecucion
    }

    public Estado estadoActual = Estado.Persecucion;


    private MaquinaDeEstados maquinaDeEstados;
    private NavMesh navMesh;
    private ControladorVision controladorVision;
    private EstadoPersecucion estadoPersecucion;
    private PlayerController playerController;
    private NavMeshAgent _agent;
    private RaycastHit hit;
    private float _time;

    public float velocidadActual = 0.0f;
   // private State estadoActual;

   // public float minSpeed = 0.5f;
   // public float maxSpeed = 5f;
   // public MeshRenderer cubeRenderer;

    public Color colorMax = Color.red;
    public Color colorMedia = Color.yellow;
    public Color colorMin = Color.green;

    public float velMaxima = 10.0f;
    public float velMedia = 5.0f;
    public float velMinima = 2.0f;


    void OnEnable()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        navMesh = GetComponent<NavMesh>();
        controladorVision = GetComponent<ControladorVision>();
        _agent = GetComponent<NavMeshAgent>();
        estadoPersecucion = GetComponent<EstadoPersecucion>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _agent.speed = 10f;

    }
MeshRenderer meshRenderer;

   void Start()
   {
      // Asegurarse de que el objeto tiene un componente MeshRenderer
      meshRenderer = GetComponent<MeshRenderer>();
      if (meshRenderer == null)
      {
         Debug.LogError("El objeto no tiene un componente MeshRenderer.");
      }
    }

    void Update()
    {
      if (estadoActual == Estado.Persecucion)
       {
         Color color;

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


}