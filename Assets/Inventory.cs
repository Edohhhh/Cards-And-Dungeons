using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> Bag = new List<GameObject>();
    public GameObject inv;
    public bool Activar_inv;

    public GameObject Selector;
    public int ID;

    public List<Image> Equipo = new List<Image>();
    public int ID_equipo;
    public int Fases_inv;

    public void Navegar()
    {
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && ID < Bag.Count - 1)
            {
                ID++;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && ID > 0)
            {
                ID--;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && ID >= 4)
            {
                ID -= 4;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && ID < Bag.Count - 4)
            {
                ID += 4;
            }

            Selector.transform.position = Bag[ID].transform.position;
        }


        /* switch (Fases_inv)
         {
             case 0:
                 inv[1].SetActive(false);

                 if (Input.GetKeyUp(KeyCode.UpArrow) && ID_equipo > 0)
                 {
                     ID_equipo--;
                 }
                 if (Input.GetKeyUp(KeyCode.DownArrow) && ID_equipo < Equipo.Count - 1)
                 {
                     ID_equipo++;
                 }

                 Selector.transform.position = Equipo[ID_equipo].transform.position;

                 if (Input.GetKeyDown(KeyCode.M) && Activar_inv)
                 {
                     Fases_inv = 1;
                 }

                 break;

             case 1:
                 inv[1].SetActive(true);

                 if (Input.GetKeyDown(KeyCode.RightArrow) && ID < Bag.Count - 1)
                 {
                     ID++;
                 }
                 if (Input.GetKeyDown(KeyCode.LeftArrow) && ID > 0)
                 {
                     ID--;
                 }
                 if (Input.GetKeyDown(KeyCode.UpArrow) && ID >= 4)
                 {
                     ID -= 4;
                 }
                 if (Input.GetKeyDown(KeyCode.DownArrow) && ID < Bag.Count - 4)
                 {
                     ID += 4;
                 }

                 Selector.transform.position = Bag[ID].transform.position;

                 if (Input.GetKeyDown(KeyCode.G) && Activar_inv)
                 {
                     Fases_inv = 0;
                 }

                 break;
         }
             */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            for (int i = 0; i < Bag.Count; i++)
            {
                if (Bag[i].GetComponent<Image>().enabled == false)
                {
                    Bag[i].GetComponent<Image>().enabled = true;
                    Bag[i].GetComponent<Image>().sprite = collision.GetComponent<SpriteRenderer>().sprite;
                    break;
                }
            }
        }
    }

    void Update()
    {
        Navegar();

        if (Activar_inv)
        {
            inv.SetActive(true);
        }
        else
        {
            //Fases_inv = 0;
            //foreach (var item in inv)
            //{
                inv.SetActive(false);
            //}
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Activar_inv = !Activar_inv;
        }
    }
}
