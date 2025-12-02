using System.Runtime.CompilerServices;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private PlayerStateManager psm;
    [SerializeField] private int screenSnapX = 128;
    [SerializeField] private int screenSnapY = 81;


    void Start()
    {
        psm = GameObject.Find("Player").GetComponent<PlayerStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(new Vector3(Mathf.Round(psm.trans.position.x/screenSnapX)*screenSnapX,Mathf.Round(psm.trans.position.y/screenSnapY)*screenSnapY, -10), new Quaternion(0,0,0,1));
    }
}