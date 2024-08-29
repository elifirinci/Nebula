using UnityEngine;

public class SnapPiece : MonoBehaviour
{
    public float snapDistance = 0.5f;

    void OnMouseUp()
    {
        GameObject[] snapPoints = GameObject.FindGameObjectsWithTag("SnapPoint");
        foreach (GameObject snapPoint in snapPoints)
        {
            if (Vector3.Distance(transform.position, snapPoint.transform.position) < snapDistance)
            {
                transform.position = snapPoint.transform.position;
                break;
            }
        }
    }
}