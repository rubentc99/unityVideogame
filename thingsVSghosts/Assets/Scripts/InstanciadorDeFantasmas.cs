using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorDeFantasmas : MonoBehaviour
{
    public int[] tiempos;

    public GameObject Fantasma;

    void Start()
    {
        for (int i = 0; i < tiempos.Length; i++)
        {
            Invoke("InstanciarFantasma", tiempos[i]);
        }
    }
    void InstanciarFantasma()
    {
        Instantiate(Fantasma, transform.position, Fantasma.transform.rotation);
    }
}



