    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject myNose;
    [SerializeField]
    private float attackSpeed=2;

    private Vector3 attackPos = -Vector3.up;
    private PlayerInput playerInput;
    private bool attacking = false; 

    private void Start()
    {
        playerInput = gameObject.GetComponent<PlayerInput>();
        playerInput.del_Attack = NoseAttack;
    }

    public void NoseAttack()
    {
        if (attacking) return;
        StartCoroutine(NoseFoward());
        Debug.Log("°ø°ÝÁß");
    }
    IEnumerator NoseFoward()
    {
        attacking = true;
        while (true)
        {
             myNose.transform.Translate(attackPos*Time.deltaTime* attackSpeed);
            yield return null;
            if (Vector3.Distance(myNose.transform.position, gameObject.transform.position) > 0.9) break;
        }
        StartCoroutine(NoseBack());
        yield break ;
    }

    IEnumerator NoseBack()
    {
        while (true)
        {
            myNose.transform.Translate(-attackPos * Time.deltaTime * attackSpeed);
            yield return null;
            if (Vector3.Distance(myNose.transform.position, gameObject.transform.position) < 0.05f) break;
        }
        attacking = false;
        yield break;
    }
}
