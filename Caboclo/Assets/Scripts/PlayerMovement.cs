using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D body;
    [SerializeField] private Transform posicaoPe;
    [SerializeField] private LayerMask chao;
    [SerializeField] private bool tipoMovimento;
    [SerializeField] private float velocidadeCaminhada;
    [SerializeField] private float velocidadeCorrida;
    [SerializeField] private float forcaPulo;

    private bool taNoChao;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // Cria um circulo na posição do pé, com tamanho 0.3f, testa se tá tendo colisão com a mascara de chao
        taNoChao = Physics2D.OverlapCircle(posicaoPe.position, 0.3f, chao);
        animator.SetBool("noChao", taNoChao);
        animator.SetFloat("pulo", body.velocity.y);

        float speed = 10f;
        /*
            <= = -1
            => = 1
        */
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if(tipoMovimento){
            animator.SetFloat("corrida", Mathf.Abs(horizontalInput));
            speed = velocidadeCorrida;
            if (Input.GetKeyDown(KeyCode.V)){
                animator.SetFloat("corrida", -0.01f);
                tipoMovimento = false;
            }
        }else if(!tipoMovimento){
            animator.SetFloat("caminhada", Mathf.Abs(horizontalInput));
            speed = velocidadeCaminhada;
            if (Input.GetKeyDown(KeyCode.V)){
                animator.SetFloat("caminhada", -0.01f);
                tipoMovimento = true;
            }
        }

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Virar o personagem enquanto move pra direita - esquerda
        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);

        // Se o personagem ta no chão e pressionar o botão barra de espaço
        if(taNoChao && Input.GetKey(KeyCode.Space)){
            // altera a velocidade no eixo y (para cima) multiplicado pela força do pulo
            body.velocity = Vector2.up * forcaPulo; 
            // antiga forma
            //body.velocity = new Vector2(body.velocity.x, speed); 
        }
    }
}
