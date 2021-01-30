using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<SuperThings> superThingsAUsar;

    public GameObject Deck;
    public GameObject PrefabCarta;

    public Text TxtBasuras;

    int Basuras = 200;
    int SuperThingAusar = 0;

    void Start()
    {
        ActualizarBasuras(0);
        for (int i = 0; i < superThingsAUsar.Count; i++)
        {
            GameObject go = Instantiate(PrefabCarta) as GameObject;
            go.transform.SetParent(Deck.transform);
            go.transform.position = Vector3.zero;
            go.transform.localScale = Vector3.one;

            Image img = go.GetComponent<Image>();
            img.sprite = superThingsAUsar[i].superThingAsignado;

            Button bot = go.GetComponent<Button>();
            bot.onClick.RemoveAllListeners();
            int u = i;
            bot.onClick.AddListener(() => { SuperThingAusar = u; });
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(r.origin, r.direction);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Cuadricula"))
                {
                    Transform t = hit.collider.transform;
                    CrearSuperThing(SuperThingAusar, t);
                }
                else if (hit.collider.CompareTag("Basura"))
                {
                    ActualizarBasuras(50);
                    Destroy(hit.collider.gameObject);
                }
            }
        }

    }

    void CrearSuperThing(int numero, Transform t)
    {
        if (superThingsAUsar[numero].precioBasuras > Basuras)
            return;
        if (t.childCount != 0)
            return;

        GameObject g = Instantiate(superThingsAUsar[SuperThingAusar].gameObject, t.position, gameObject.transform.rotation) as GameObject;
        g.transform.SetParent(t);

        ActualizarBasuras(-superThingsAUsar[numero].precioBasuras);
    }

    public void ActualizarBasuras(int Add)
    {
        Basuras += Add;
        TxtBasuras.text = Basuras.ToString();
    }


}