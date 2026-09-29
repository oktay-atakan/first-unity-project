using UnityEngine;

public class Collectible : MonoBehaviour
{

    public float rotation_speed = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotation_speed * Time.deltaTime);
    }
}
