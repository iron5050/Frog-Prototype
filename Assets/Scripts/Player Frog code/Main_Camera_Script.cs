using UnityEngine;

public class Main_Camera_Script : MonoBehaviour
{

    [SerializeField] Transform Frog_Player;
    [SerializeField] float MouseSpeed = 3;
    [SerializeField] float orbitDamping = 10;

    Vector3 localRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Frog_Player.position;
        
        localRot.x += Input.GetAxis("Mouse X") * MouseSpeed;
        localRot.y -= Input.GetAxis("Mouse X") * MouseSpeed;

        localRot.y = Mathf.Clamp(localRot.y, 0f, 80f);

        Quaternion QT = Quaternion.Euler(localRot.x, localRot.y, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDamping);
    }
}
