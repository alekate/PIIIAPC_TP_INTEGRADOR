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
    private RaycastHit hit;
    private float _time;


    void OnEnable()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        navMesh = GetComponent<NavMesh>();
        controladorVision = GetComponent<ControladorVision>();
        _agent = GetComponent<NavMeshAgent>();
        estadoPersecucion = GetComponent<EstadoPersecucion>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _agent.speed = 10f;
        _time = 0f;

    }
    //private void Start()
    //{
    //    Debug.Log("START");
    //    _agent.speed = 10f;
    //    _time = 0f;
        
    //}
   
    // Update is called once per frame
    void Update()
    {
        navMesh.ActualizarWaypointNavMeshAgent();
        _time += Time.deltaTime;
        if (_time >= 3f && controladorVision.CanSeePlayer(out hit, true))
        {
            
            _time = 0f;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            return;
        }
     
        if (!controladorVision.CanSeePlayer(out hit, true)) {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
            return;
        }

    }
}
