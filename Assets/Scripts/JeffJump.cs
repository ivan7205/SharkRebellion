using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeffJump : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 1f;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float velocidadX = Input.GetAxis("Horizontal")*TimedSelfDestruct.deltaTime*velocidad;

        //if (velocidadX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //if (velocidadX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        } 

        Vector3 posicion = transform.position;

        //transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);
    }
}
