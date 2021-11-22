using UnityEngine;

public class ZombieFollow : MonoBehaviour
{
    public GameObject[] followMainObj;

    public GameObject[] zombies;

    public float[] offsetZPos;

    void Start()
    {
        zombies = new GameObject[transform.childCount];
        offsetZPos = new float[transform.childCount - 4];
        for (int i = 0; i < zombies.Length; i++)
        {
            zombies[i] = transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < offsetZPos.Length; i++)
        {
            offsetZPos[i] = Random.Range(0f, 2f);
        }
    }

    void Update()
    {
        objFollow();
    }

    public void objFollow()
    {
        zombies[0].transform.position = Vector3.Lerp(zombies[0].transform.position, followMainObj[0].transform.position - zombies[0].transform.forward * 2, 0.025f);
        zombies[1].transform.position = Vector3.Lerp(zombies[1].transform.position, followMainObj[1].transform.position - zombies[1].transform.forward * 2, 0.025f);
        zombies[2].transform.position = Vector3.Lerp(zombies[2].transform.position, followMainObj[2].transform.position - zombies[2].transform.forward * 2, 0.025f);
        zombies[3].transform.position = Vector3.Lerp(zombies[3].transform.position, followMainObj[3].transform.position - zombies[3].transform.forward * 2, 0.025f);

        for (int i = 4; i < zombies.Length; i++)
        {
            zombies[i].transform.position = Vector3.Lerp(zombies[i].transform.position, zombies[i - 4].transform.position - new Vector3(0, 0, offsetZPos[i - 4]), 0.025f);
        }
    }
}
