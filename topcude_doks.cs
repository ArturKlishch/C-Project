//biblioteki Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class topcude : MonoBehaviour
{
    //te linie sa odpowiedzialne za określenie dowolnego klawisza do przesuwania naszych kostek
    [SerializeField] KeyCode keyOne;
    [SerializeField] KeyCode keyTwo;
    [SerializeField] Vector3 moveDirection;
    //ta funkcja służy do:
    private void FixedUpdate()
    {
        //jeśli mamy wciśnięty keyOne to dodamy kierunek vector3 do prędkości naszego sześcianu
        if (Input.GetKey(keyOne))
        {
            GetComponent<Rigidbody>().velocity += moveDirection;
        }
        //jeśli mamy wciśnięty keyTwo to dodamy kierunek vector3 do prędkości naszego sześcianu
        if (Input.GetKey(keyTwo))
        {
            GetComponent<Rigidbody>().velocity -= moveDirection;
        }
        //gdybyśmy kliknęli przycisk R
        if (Input.GetKey(KeyCode.R))
        {
            //to wtedy nasz poziom zostanie zrestartowany
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //gdybyśmy kliknęli przycisk Q
        if (Input.GetKey(KeyCode.Q))
        {
            //to wtedy nasz poziom zostanie wzrośniony o 1
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    //ta funkcja działa jak przełącznik poziomu dla naszej gry!
    private void OnTriggerEnter(Collider other)
    {
        //jeśli naszym obiektem jest Player, a obiekt, którego dotykamy się jest Finishem,
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            //wtedy poziom wzrasta o +1, czyli przechodzi do następnego
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //tutaj piszemy małą poprawkę, jeśli nasze kostki stykają się ze sobą
        if (this.CompareTag("Cube") && other.CompareTag("Cube"))
        {
            //jeśli się dotkną, nie będziemy mogli nacisnąć przycisków
            foreach (act button in FindObjectsOfType<act>())
            {
                button.canPush = false;
            }
            //gdy nasza kostka z podpisem "Player" dotknie kostkę z podpisem "Respawn" gra wraca do menu głównego
            if (this.CompareTag("Player") && other.CompareTag("Respawn"))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
    ////tutaj piszemy małą poprawkę, jeśli nasze kostki nie stykają się ze sobą
    private void OnTriggerExit(Collider other)
    {
        if (this.CompareTag("Cube") && other.CompareTag("Cube"))
        {
            //jeśli się nie dotkną,będziemy mogli nacisnąć przycisków
            foreach (act button in FindObjectsOfType<act>())
            {
                button.canPush = true;
            }
        }
    }
}
