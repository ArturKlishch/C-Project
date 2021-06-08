//biblioteki Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class act : MonoBehaviour
{
    //Macierze obiektów w pierwszej grupie
    public GameObject[] firstGroup;
    //Macierze obiektów w drugiej grupie
    public GameObject[] secondGroup;
    //sam przycisk
    public act button;
    //materialy przycisków
    public Material normal;
    public Material transparent;
    //mała poprawka naszej gry, zmienna "canPush" odpowiada za to, że przycisk można wcisnąć tylko gdy kostka nie jest w innej kostce
    public bool canPush;

    //funkcja jest podana:
    private void OnTriggerEnter(Collider other)
    {
        //jeśli kostka nie utknęła w innej kostce, to nasz cykl jest wykonywany
        if (canPush)
        {
            //jeśli przycisk zostanie dotknięty przez normalną lub główną kostkę
            if (other.CompareTag("Cube") || other.CompareTag("Player"))
            {
                //wtedy dla wszystkich materiałów z pierwszej grupy, które tam dodamy, materiał będzie normalny i nie będzie można przez nią przejść
                foreach (GameObject first in firstGroup)
                {
                    first.GetComponent<Renderer>().material = normal;
                    first.GetComponent<Collider>().isTrigger = false;
                }
                //wtedy dla wszystkich materiałów z drugiej grupy, które tam dodamy, materiał będzie transparent i  będzie można przez nią przejść
                foreach (GameObject second in secondGroup)
                {
                    second.GetComponent<Renderer>().material = transparent;
                    second.GetComponent<Collider>().isTrigger = true;
                }
                //materiał pierwszego przyciska
                GetComponent<Renderer>().material = transparent;
                //materiał drugiego przyciska
                button.GetComponent<Renderer>().material = normal;
                button.canPush = true;
            }
        }
    }
}
