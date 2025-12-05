using System.Runtime.CompilerServices;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private PlayerStateManager psm;
    [SerializeField] private int screenSnapX = 130;
    [SerializeField] private int screenSnapY = 65;


    private void Start()
    {
            

    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(new Vector3(Mathf.Round(psm.trans.position.x / screenSnapX) * screenSnapX/2 + 50, Mathf.Round(psm.trans.position.y / screenSnapY) * screenSnapX / 4 + 15, transform.position.z), new Quaternion(0, 0, 0, 1));
    }
}