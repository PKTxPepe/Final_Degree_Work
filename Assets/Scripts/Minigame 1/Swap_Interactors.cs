using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap_Interactors : MonoBehaviour
{
    public GameObject LeftDirectInteractor;
    public GameObject RightDirectInteractor;
    public GameObject LeftPokeInteractor;
    public GameObject RightPokeInteractor;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            LeftDirectInteractor.SetActive(false);
            RightDirectInteractor.SetActive(false);
            Debug.Log("Directos desactivados");
            LeftPokeInteractor.SetActive(true);
            RightPokeInteractor.SetActive(true);
            Debug.Log("Pokes activados");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            LeftPokeInteractor.SetActive(false);
            RightPokeInteractor.SetActive(false);
            Debug.Log("Pokes desactivados");
            LeftDirectInteractor.SetActive(true);
            RightDirectInteractor.SetActive(true);
            Debug.Log("Directos activados");
        }
    }
}
