//using UnityEngine;
//
//public class CannonFollow : MonoBehaviour
//{
//    public SpringJoint2D springJoint;
//    public Transform playerTransform;
//    public Transform cannonTransform;
//
//    private void Awake()
//    {
//        springJoint = GetComponent<SpringJoint2D>();
//        playerTransform = springJoint.connectedBody.transform;
//        cannonTransform = transform;
//    }
//
//    private void LateUpdate()
//    {
//        if (springJoint.connectedBody != null)
//        {
//            cannonTransform.position = playerTransform.position;
//            cannonTransform.rotation = playerTransform.rotation;
//            // Adjust any additional transformations if needed
//        }
//    }
//}
//
