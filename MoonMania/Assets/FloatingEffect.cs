using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void Update()
    {
        float floatSpeed = 1.8f;
        float floatHeight = 8f;
        transform.position += new Vector3(0, Mathf.Sin(Time.time * floatSpeed) * floatHeight * Time.deltaTime, 0);
    }
}