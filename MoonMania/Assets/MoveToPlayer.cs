using Unity.VisualScripting;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{

    public GameObject magnet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        print(other.gameObject.name);
        if (other.gameObject.name == "magneticField")
        {
            Vector2.MoveTowards(transform.position, magnet.transform.position, 5 * Time.deltaTime);
            print("aaaaaaaaaa");
        }
    }
}
