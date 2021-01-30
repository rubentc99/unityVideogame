using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperThings : MonoBehaviour
{

    public Sprite superThingAsignado;
    public int precioBasuras;
    public int vida;

    void Morder()
    {
        vida--;
        if (vida <= 0)
            Destroy(gameObject);
    }
}
