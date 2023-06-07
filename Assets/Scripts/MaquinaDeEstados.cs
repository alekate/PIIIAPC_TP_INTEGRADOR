using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaDeEstados : MonoBehaviour  {
    
    public MonoBehaviour EstadoPatrulla;
    public MonoBehaviour EstadoAlerta;
    public MonoBehaviour EstadoPersecucion;
    public MonoBehaviour EstadoInicial;

    private MonoBehaviour EstadoActual;


    void Start() {
        ActivarEstado(EstadoInicial);
    }
    public void ActivarEstado(MonoBehaviour NuevoEstado)
    {

      if (EstadoActual!=null) EstadoActual.enabled = false;
         EstadoActual = NuevoEstado;
         EstadoActual.enabled = true;

    }


}
