using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Animator animator;
    private int energia;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(energia <= 0){
            animator.SetTrigger("death");
            Invoke("DestroyBody", .5f);
        }
    }

    public void TakeDamage(int damage){
        energia -= damage;
    }

    private void DestroyBody(){
        Destroy(gameObject);
    }
}
