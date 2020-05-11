using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{

    float attackSpeed = 1f;
    float nextAttackDelay = 0f;
    public Actor peformerActor;
    public Transform peformerTransform;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextAttackDelay > 0f)
        {
            nextAttackDelay -= Time.deltaTime;
            if(nextAttackDelay < 0f)
            {
                nextAttackDelay = 0f;
            }
        }else if(peformerActor.state == "attacking")
        {
            peformerActor.state = null;
        }
    }

    public void PeformBasicAttack()
    {
        Debug.Log(peformerActor.state);
        if(nextAttackDelay == 0f)
        {
            peformerActor.state = "attacking";
            animator.SetTrigger("Attack");
            nextAttackDelay = attackSpeed;
        }
    }
}
