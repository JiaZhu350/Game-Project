using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;
    private Vector2 dirc;


    // Update is called once per frame
    void Update()
    {
        dirc = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (dirc.magnitude < 0.1f)
        {
            return;
        }
        float angle = Mathf.Atan2(dirc.y, dirc.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed * Time.deltaTime);
    }
}
