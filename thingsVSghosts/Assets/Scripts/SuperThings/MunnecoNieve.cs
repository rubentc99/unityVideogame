using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunnecoNieve : MonoBehaviour
{

    public float cadencia = 3;
    public GameObject BolaDeNieve;
    public Transform cañon;
    public LayerMask layerFantasma;

    IEnumerator Start()
    {
        while (true)
        {
            //------------------------------------------------ APENAS INICIE EL JUEGO
            yield return new WaitForSeconds(cadencia);
            //------------------------------------------------ LANZA LA BASURA LUEGO DE LA FRECUENCIA

            //DISTANCIA DEL MUÑECO AL FANTASMA A LA QUE EMPIEZA A DISPARAR
            RaycastHit2D hit = Physics2D.Raycast(cañon.position, Vector3.right, 50, layerFantasma);
            if (hit.collider != null)
            {
                GameObject go = Instantiate(BolaDeNieve, cañon.position, BolaDeNieve.transform.rotation) as GameObject;
                Destroy(go, 10);
            }

        }
    }
}