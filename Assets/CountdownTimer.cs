using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 10f;

    [SerializeField] Text countdownText;
    
    void Start()
    {
        currentTime = startingTime;
    }


    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString ("0"); //actualiza el numero dentro del componente y el "0" numeros enteros

        if(currentTime <= 0) { //Evita mostrar los numeros negativos
            currentTime = 0;
        }
    }
}
