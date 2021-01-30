using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboBasura : MonoBehaviour
{
    public float frecuenciaDeBasuras = 1;
    public GameObject Basura;

    IEnumerator Start()
    {
        while (true)
        {
            //------------------------------------------------ APENAS INICIE EL JUEGO
            yield return new WaitForSeconds(frecuenciaDeBasuras);
            //------------------------------------------------ LANZA LA BASURA LUEGO DE LA FRECUENCIA
            GameObject go = Instantiate(Basura, transform.position + Vector3.up * Random.Range(0f, 1f) + Vector3.left * Random.Range(-1f, 1f), Basura.transform.rotation) as GameObject;
            Destroy(go, 10);
        }
    }


}
