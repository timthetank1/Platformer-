using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private PlayerStateManager psm;
    void Start()
    {
       
        psm = GameObject.Find("Player").GetComponent<PlayerStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(psm.inputX);
        if (psm.trans.position.x > 0)
        {
            transform.position = Vector3.right * (200);
        }
    }
}