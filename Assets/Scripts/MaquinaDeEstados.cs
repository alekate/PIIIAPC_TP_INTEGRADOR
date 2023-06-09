using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaDeEstados : MonoBehaviour  {
    
    public MonoBehaviour EstadoPatrulla;
    public MonoBehaviour EstadoAlerta;
    public MonoBehaviour EstadoPersecucion;
    public MonoBehaviour EstadoInicial;

    private MonoBehaviour estadoActual;


    public void Start() {
        ActivarEstado(EstadoInicial);
    }

    public void ActivarEstado(MonoBehaviour nuevoEstado)
    {

      if (estadoActual!=null) estadoActual.enabled = false;
         estadoActual = nuevoEstado;
         estadoActual.enabled = true;

    }


}
