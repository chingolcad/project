using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    //public float speed;
    Transform target;
    NavMeshAgent playerAgent;

    //private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    //    rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (target !=null)
        {
            playerAgent.SetDestination(target.position);
            FaceTarget();
        }
    }
    public void MovetoPoint(Vector3 point)
    {
        playerAgent.SetDestination(point);
    }

    public void FollowTarget (Interactable newTarget)
    {
        playerAgent.stoppingDistance = newTarget.radius * .8f;
        playerAgent.updateRotation = false;

        target = newTarget.transform;
    }

    public void StopFollowingTarget ()
    {
        playerAgent.stoppingDistance = 0;
        playerAgent.updateRotation = true;

        target = null;
    }

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    //void FixedUpdate()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");
     //   float moveVertical = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    //    rb.AddForce(movement * speed);
    //}
}
