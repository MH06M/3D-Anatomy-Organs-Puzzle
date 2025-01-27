using UnityEngine;

public class Randomize : MonoBehaviour
{
    public Transform trans;
    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = new Vector3(0, Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        trans.position = trans.position + offset;
    }

    // Update is called once per frame
    void Update()
    {

    }
}