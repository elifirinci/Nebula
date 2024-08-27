using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject cardFront;  // Kartýn ön yüzü
    public GameObject cardBack;   // Kartýn arka yüzü
    public bool isFlipped = false; // Kartýn çevrilip çevrilmediðini kontrol eder

    private void Start()
    {
        // Baþlangýçta sadece cardFront görünür, cardBack görünmez
        cardFront.SetActive(true);
        cardBack.SetActive(false);
    }

    private void OnMouseDown()
    {
        // Kartýn üzerine týklandýðýnda ne olacaðýný kontrol eder
        if (!isFlipped)
        {
            FindObjectOfType<GameManager>().SelectCard(this);
        }
    }

    public void FlipCard()
    {
        // Kartý çevirir (cardFront <-> cardBack)
        isFlipped = !isFlipped;
        cardFront.SetActive(!isFlipped);
        cardBack.SetActive(isFlipped);
    }
}
