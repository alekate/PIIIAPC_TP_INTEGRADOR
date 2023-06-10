using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorVision : MonoBehaviour
{
   
 public Transform Eyes;
 public float rangoVision = 20f; //20 metros

 public Vector3 offset = new Vector3(0f, 0.75f, 0f); //vision mas elevada, para que no este al raz del suelo
    
 private NavMesh navMesh;

  void Awake()
  {
    navMesh = GetComponent<NavMesh>();
  }

  public bool CanSeePlayer(out RaycastHit hit, bool lookToPlayer = false) //se agrega una variable donde la vision se dirija hacia el jugador, y no solo hacia adelante
  {                              //forward -> hacia adelante
    Vector3 vectorDirection;
    if (lookToPlayer)
    {                            //a la posicion del jugador, se le debe restar la posicion de los ojos
      vectorDirection = (navMesh.perseguirObjetivo.position + offset) - Eyes.position;
    } else
    {
      vectorDirection = Eyes.forward;
    }

    return Physics.Raycast(Eyes.position, vectorDirection, out hit, rangoVision) && hit.collider.CompareTag("Player"); //se devuelve true si impacta con un collider, pero en este caso se arma otra funcion que solo colisione con el jugador

   }
 

}
