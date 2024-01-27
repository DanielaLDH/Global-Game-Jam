using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCard : MonoBehaviour
{
    public Card card;

    // Start is called before the first frame update
    void Start()
    {
        card = gameObject.GetComponent<Card>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Card") 
        {
            Debug.Log(collision);
            collision.transform.position = transform.position;
            // Obtém o componente Card da carta colidida e altera sua variável played
            Card collidedCard = collision.GetComponent<Card>();
            if (collidedCard != null)
            {
                Debug.Log(collidedCard);
                collidedCard.played = true;
            }
        }
    }

}
