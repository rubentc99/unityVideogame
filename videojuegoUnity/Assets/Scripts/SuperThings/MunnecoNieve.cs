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
            //------------------------------------------------ LANZA EL SOL LUEGO DE LA FRECUENCIA


            RaycastHit2D hit = Physics2D.Raycast(cañon.position, Vector3.right, 12, layerFantasma);
            if (hit.collider != null)
            {
                GameObject go = Instantiate(BolaDeNieve, cañon.position, BolaDeNieve.transform.rotation) as GameObject;
                Destroy(go, 10);
            }

        }
    }
}