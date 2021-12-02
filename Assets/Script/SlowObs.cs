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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
            Destroy(temp2, 3f);
            Destroy(transform.gameObject);
        }
    }
}
