using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Password : MonoBehaviour
{
    private List<int> girilenRakamlar = new List<int>(); // Girilen rakamlarý tutacak liste
    private int dogruSifre = 3254; // Doðru þifre integer olarak
    private string girilenSifreGorunumu = "****"; // Þifre görüntüsü için

    public TextMeshProUGUI password3Text;
    public GameObject numberPanel;
    bool isActive;
    bool isCorrectCheck;
    private void Awake()
    {
        numberPanel.SetActive(false);
    }
    private void Update()
    {
        if (numberPanel.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.E) && Movement.isPass && !isCorrectCheck)
        {
            isActive = !isActive;
            
        }
        numberPanel.SetActive(isActive);
        password3Text.text = girilenSifreGorunumu;
    }
    public void ButtonClicked(int indexDegeri)
    {
        // Girilen rakamý listeye ekle
        girilenRakamlar.Add(indexDegeri);

        // Girilen rakamlar kadar þifre görüntüsünü güncelle
        char[] sifreGorunumu = girilenSifreGorunumu.ToCharArray();
        sifreGorunumu[girilenRakamlar.Count - 1] = (char)('0' + indexDegeri); // Girilen rakamý uygun yere koy
        girilenSifreGorunumu = new string(sifreGorunumu);


        // Girilen rakamlar doðru þifrenin uzunluðuna ulaþtýðýnda kontrol yap
        if (girilenRakamlar.Count == dogruSifre.ToString().Length)
        {
            // Girilen rakamlarý integer olarak birleþtir
            int girilenSifre = 0;
            for (int i = 0; i < girilenRakamlar.Count; i++)
            {
                girilenSifre = girilenSifre * 10 + girilenRakamlar[i];
            }

            // Girilen þifre ile doðru þifreyi karþýlaþtýr
            if (girilenSifre == dogruSifre)
            {
                isActive = false;
                numberPanel.SetActive(isActive);
                isCorrectCheck  = true;
                Debug.Log("Doðru þifre!");
                // Doðru þifre için yapýlacak iþlemler
            }
            else
            {

                Debug.Log("Yanlýþ þifre.");
                // Yanlýþ þifre için yapýlacak iþlemler
            }

            // Sonraki deneme için listeyi temizle ve þifre görüntüsünü sýfýrla
            girilenRakamlar.Clear();
            girilenSifreGorunumu = "****";
        }
    }

    public void FalseCheckFNC()
    {
        Debug.Log("er");
        isActive = false;
    }
}
