using System.Collections;
using System.Collections.Generic;
using System.Drawing.Design;
using UnityEngine;
using UnityEngine.AI;

public class CueMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    //Touch touch;
    //Quaternion rotationY;
    bool dragging = false;
    Rigidbody rb;

    //void Update()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        touch = Input.GetTouch(0);
    //        //if (touch.phase == TouchPhase.Began)
    //        //{

    //        //    transform.LookAt(touch.position, new Vector3(transform.rotation.x, -1, transform.rotation.z));
    //        //    //transform.localRotation = Quaternion.Euler(new Vector3(transform.rotation.x, touch.position.y, transform.rotation.z));
    //        //}

    //        //this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3 (touch.position.x, touch.position.y, -3));
    //        //}
    //        if (touch.phase == TouchPhase.Moved)
    //        {
    //        //Ray ray = Camera.main.ScreenPointToRay(touch.position);
    //        //RaycastHit hit;

    //        //if (Physics.Raycast(ray, out hit))
    //        //{
    //        //    navMeshAgent.destination = hit.point;
    //        //}
    //        ////transform.LookAt(touch.position, new Vector3(transform.rotation.x, -1, transform.rotation.z));
    //        //transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.x, touch.position.y * speed * Time.deltaTime, transform.localRotation.z)); 
    //            Debug.Log("Move");
    //        }
    //    }
    //}

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        dragging = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }

    private void FixedUpdate()
    {
        if (dragging)
        {
            float x = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
            float y = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

            rb.AddTorque(Vector3.down * x);
            rb.AddTorque(Vector3.right * y);

            Debug.Log("rotate");
        }
    }
}
