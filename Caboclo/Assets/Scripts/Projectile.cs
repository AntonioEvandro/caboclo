using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int dano;
    [SerializeField] private float tempoVida;
    [SerializeField] private float distacia;
    private LayerMask layerEnemy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestruirProjetil", tempoVida);
    }

    // Update is called once per frame
    void Update()
    {/*
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distacia, layerInimigo);
        if(hitInfo.collider != null){
            if(hitInfo.collider.CompareTag("Inimigo")){
                hitInfo.collider.GetComponent<EnemyAI>().TakeDamage(dano);
            }
            DestroyProjectile();
        }*/
    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
