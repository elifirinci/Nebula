using UnityEngine;
using System.Collections; // Add this line

public class GameManager : MonoBehaviour
{
    public Card[] cards; // Array to hold references to the cards
    private Card firstCard, secondCard; // References to the currently selected cards

    private void Start()
    {
        // Initialize or shuffle cards if necessary
    }

    public void SelectCard(Card card)
    {
        if (firstCard == null)
        {
            // Select the first card
            firstCard = card;
            card.FlipCard();
        }
        else if (secondCard == null)
        {
            // Select the second card
            secondCard = card;
            card.FlipCard();

            // Check if the selected cards match
            StartCoroutine(CheckForMatch());
        }
    }

    private IEnumerator CheckForMatch()
    {
        // Wait for a short period to allow the card flip animation to complete
        yield return new WaitForSeconds(0.5f);

        if (firstCard.cardBack.name == secondCard.cardBack.name)
        {
            // If the cards match, hide them or handle the match
            firstCard.gameObject.SetActive(false);
            secondCard.gameObject.SetActive(false);
        }
        else
        {
            // If the cards do not match, flip them back
            firstCard.FlipCard();
            secondCard.FlipCard();
        }

        // Reset selected cards
        firstCard = null;
        secondCard = null;
    }
}
