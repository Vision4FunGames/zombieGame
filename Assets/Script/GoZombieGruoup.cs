using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoZombieGruoup : MonoBehaviour
{
    public GameObject target;
    bool isGo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGo)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.5f);
            transform.LookAt(target.transform.position);
            transform.localScale= new Vector3(transform.localScale.x-0.001f,transform.localScale.y - 0.001f, transform.localScale.z - 0.001f);
        }
    }

    public void starGo(GameObject crrntTarget)
    {
        isGo = true;
        target = crrntTarget;
        GetComponent<Animator>().SetBool("run1", true);
    }
}
