using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum slowtype { wall, barrier }
public class SlowObs : MonoBehaviour
{
    public slowtype myslowtype;
    public Collider[] walls;
    public float radius;
    public float power;
    public GameObject destroyObj;
    void Start()
    {

    }

    void Update()
    {

    }

    public void ActiveSlowTypeAction(GameObject tr)
    {
        GameObject temp = Instantiate(GameManager.Instance.puffparticle);
        temp.transform.position = transform.position - new Vector3(0, +2, 12);
        Destroy(temp, 3f);
        if (myslowtype == slowtype.wall)
        {
            Vector3 explosionPos = transform.position;
            foreach (Collider hit in walls)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                }
            }
        }
        else
        {
            GameObject temp2 = Instantiate(GameManager.Instance.puffparticle);
            temp2.transform.position = transform.position - new Vector3(0, +2, 12);
            destroyObj.SetActive(true);
            Destroy(temp2, 3f);
            Destroy(transform.GetChild(0).GetChild(0).gameObject);
            Destroy(transform.gameObject,5f);
            Destroy(transform.GetChild(1).GetChild(0).gameObject);
        }
    }
}
