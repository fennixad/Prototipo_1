using UnityEngine;

public class InterruptorPuerta : MonoBehaviour
{
    public GameObject puerta;
    public bool tieneUnUso;
    bool usado;

    private void OnMouseDown()
    {
        if (tieneUnUso == true)
        {
            if (usado == false)
            {
                usado = true;
                puerta.SetActive(false);
            }
        } else
        {
            if (puerta == null) Debug.Log("La variable puerta esta vacia!");
            else puerta.SetActive(!puerta.activeSelf);
        }
    }
}
