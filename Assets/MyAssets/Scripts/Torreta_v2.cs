using UnityEngine;

public class Torreta_v2 : MonoBehaviour
{
    /// <summary>
    /// public class InterruptorPuerta : MonoBehaviouir
    /// {
    /// public GameObject puerta;
    /// private void OnMouseDown()
    /// {
    /// if (puerta == null) Debug.Log("La variable puerta esta vacia");
    /// else puerta.SetActive(!puerta.activeSelf);
    /// </summary>
    [Header("Configuraci�n de la torreta"), Range (0f, 180f)]
    public float anguloMax = 90f; // �ngulo m�ximo de apertura
    public float velRot = 30f; // Velocidad de rotaci�n en grados por segundo
    public Transform cabeza; // Parte de la torreta que rota (opcional)

    private float rotInicial;
    private float angulosIniciales;
    private float dirRot; // 1 = derecha, -1 = izquierda

    void Start()
    {
        if (cabeza == null) cabeza = transform;
        if (anguloMax == 0f) anguloMax = 90f;
        if (velRot == 0f) velRot = 30f;

        dirRot = 1f;

        rotInicial = cabeza.localEulerAngles.y;
    }

    void Update()
    {
        // Incrementar el �ngulo en la direcci�n actual
        angulosIniciales += velRot * dirRot * Time.deltaTime;

        bool limiteAlcanzado = angulosIniciales >= anguloMax / 2f || angulosIniciales <= -anguloMax / 2f;

        if (limiteAlcanzado)
        {
            angulosIniciales = dirRot * anguloMax / 2f;
            dirRot *= -1f; // Cambiar direcci�n de rotacion
        }

        // Aplicar la rotaci�n
        Vector3 newRotation = cabeza.localEulerAngles;
        newRotation.y = rotInicial + angulosIniciales;
        cabeza.localEulerAngles = newRotation;
    }

    private void OnDrawGizmos()
    {
        Vector3 limiteIzq = Quaternion.Euler(Vector3.up * -anguloMax * 0.5f) * transform.forward;
        Vector3 limiteDer = Quaternion.Euler(Vector3.up * anguloMax * 0.5f) * transform.forward;

        Debug.DrawRay(transform.position, limiteIzq, Color.red);
        Debug.DrawRay(transform.position, limiteDer, Color.red);
    }
}


