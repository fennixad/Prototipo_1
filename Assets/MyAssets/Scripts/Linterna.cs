using UnityEngine;

public class Linterna : MonoBehaviour
{
    #region 1) DEF. VARIABLES
    public float bateria;
    public bool bateriaAgotada;
    public float bateriaMaxima;
    public GameObject luz;
    #endregion

    #region 2) FUNC. UNITY

    void Start()
    {
        bateriaMaxima = 1.5f;
        bateria = bateriaMaxima;   
        bateriaAgotada = false;
        luz.SetActive(false);
    }


    void Update()
    {
        if (bateriaAgotada == false)
        {
            if (Input.GetMouseButton(1))
            {
                bateria -= Time.deltaTime;
                Debug.Log("Linterna en uso. Bateria consumiendo...");

                if (luz.activeSelf == false) luz.SetActive(true);
            }

            if (bateria <= 0f)
            {
                Debug.Log("Bateria agotada");
                bateriaAgotada = true;
                bateria = 0f;
                luz.SetActive(false);
            }
        }
        if (Input.GetMouseButtonUp(1))
            {

            }

        if (bateria <= bateriaMaxima)
        {
            Debug.Log("Cargando bateria");
            bateria += Time.deltaTime;
        }
    }
    #endregion
    #region 3) FUNC. PROPIAS

    #endregion
}
