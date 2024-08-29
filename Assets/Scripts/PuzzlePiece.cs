//using UnityEngine;
//using UnityEngine.UI;

//public class PuzzlePiece : MonoBehaviour
//{
//    public int correctIndex; // Parçanýn doðru pozisyonu
//    public int currentIndex; // Parçanýn mevcut pozisyonu

//    void Start()
//    {
//        // Butonun baþlangýçtaki doðru konumunu ayarla
//        correctIndex = System.Array.IndexOf(GetComponentInParent<PuzzleManager>().puzzleButtons, GetComponent<Button>());

//    }

//    // currentIndex deðerini güncellemek için metot
//    public void UpdateCurrentIndex(int newIndex)
//    {
//        currentIndex = newIndex;
//    }

//    // currentIndex deðerini hesapla
//    public void SetCurrentIndex()
//    {
//        currentIndex = System.Array.IndexOf(GetComponentInParent<PuzzleManager>().puzzleButtons, GetComponent<Button>());
//    }
//}


using UnityEngine;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour
{
    public int correctIndex; // Parçanýn doðru pozisyonu
    public int currentIndex; // Parçanýn mevcut pozisyonu

    void Start()
    {
        // Baþlangýçta currentIndex'i doðru indeks olarak ayarla
        SetCurrentIndex(correctIndex);
    }

    // currentIndex deðerini güncellemek için metot
    public void SetCurrentIndex(int newIndex)
    {
        currentIndex = newIndex;
    }
}
