using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{
    private Rigidbody2D jogador;
    public int velocidade;
    public float forcaPulo;
    public bool sensor;

    public Transform posicaoSensor;                                  
    public LayerMask layerChao;

    // Start is called before the first frame update
    void Start()
    {
        jogador = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float movimentoX = Input.GetAxisRaw("Horizontal");
        jogador.velocity = new Vector2(movimentoX * velocidade, jogador.velocity.y);

        if (Input.GetButtonDown("Jump") && sensor == true)
        {
            jogador.AddForce(new Vector2(0, forcaPulo));
        }
    }
    private void FixedUpdate()
    {
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.1f, layerChao);

    }
}
