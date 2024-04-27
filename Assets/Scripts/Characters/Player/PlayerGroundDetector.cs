using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    //[SerializeField] float coyoteDetect = 0.3f;
    [SerializeField] float detectionRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;
    Ray groundDetect;

    Collider[] colliders = new Collider[1];
    public bool IsGrounded => Physics.OverlapSphereNonAlloc(transform.position,detectionRadius,colliders,groundLayer) != 0;
    //public bool IsCoyote => Physics.Raycast(groundDetect, coyoteDetect, groundLayer);

    // TODO:利用射线来进行地面检测
    //public bool IsGrounded => Physics.Raycast(groundDetect,0.15f,groundLayer);
//          void Awake()
//          {
//              groundDetect = new Ray(transform.position, Vector3.down);
//          }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        //Gizmos.DrawRay(transform.position,Vector3.down*coyoteDetect);
    }

}
