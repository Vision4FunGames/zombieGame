using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowobsChild : MonoBehaviour
{
    public float power;
    FollowLowZombieSc followzombie;
    public bool isGo;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        followzombie = FindObjectOfType<FollowLowZombieSc>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGo)
        {
            rb.AddForce(new Vector3(1,0,0) * 110f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("zombieChild"))
        {
            GameObject tempragdoll = Instantiate(other.GetComponent<ZombiScript>().ragdollobj);
            tempragdoll.transform.position = other.transform.position;
            tempragdoll.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(Vector3.right * power, ForceMode.Impulse);
            tempragdoll.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(Vector3.up * power, ForceMode.Impulse);
            fallZombies(other.gameObject);
        }
    }

    public void fallZombies(GameObject other)
    {
        Destroy(other.gameObject);
        GameObject current = other.gameObject.transform.parent.gameObject;
        followzombie.extraPeople(current);
        // UiManager.Instance.ZombieText.text = followzombie.zombiCount.ToString();
        //followzombie.extraPeople();
    }
}
