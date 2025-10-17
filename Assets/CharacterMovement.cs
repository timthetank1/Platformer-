using Unity.Hierarchy;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    float dx = 0f;
    float dy = 0f;
    float gravity = -50f;
    void Start()
    {
        transform.position = new Vector3(-200, 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(dx, dy, 0) * Time.deltaTime);
        //dy += gravity * Time.deltaTime; -

    }
}
