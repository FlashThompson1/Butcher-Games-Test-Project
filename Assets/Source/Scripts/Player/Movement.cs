using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float swipeSpeed = 10f; 
    [SerializeField] private float xOffset = 2f;

    [Header("Dresses")]
    [SerializeField] private GameObject _poorDress;
    [SerializeField] private GameObject _middleDress;
    [SerializeField] private GameObject _blingDress;

    [Header("Animator")]
    [SerializeField] private Animator _characterAnimator;

    private int currentPointIndex = 0;
    private Vector3 targetPosition; 
    private float startXPosition; 
    private bool isDragging = false; 
    private float dragStartX; 


    public Progress progress;

    private void Start()
    {
        if (points.Count > 0)
        {
            transform.position = points[0].position; // Start at the first point
            targetPosition = points[1].position; // Set the initial target position
            startXPosition = transform.position.x; // Store the initial x position
        }
    }

    private void Update()
    {
       
        if (currentPointIndex < points.Count - 1)
        {
            MoveTowardsTarget();
        }

        HandleMouseInput();
        Dresschanging();
    }

    private void MoveTowardsTarget()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 move = direction * speed * Time.deltaTime;
        move.x = 0; // Prevent movement in the x direction

        transform.position += move;

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentPointIndex++;
            if (currentPointIndex < points.Count - 1)
            {
                targetPosition = points[currentPointIndex + 1].position;
                startXPosition = transform.position.x; // Update startXPosition when reaching a new point
                if (isDragging)
                {
                    dragStartX = Input.mousePosition.x; // Update dragStartX when reaching a new point
                }
            }
        }
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            dragStartX = Input.mousePosition.x;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            startXPosition = transform.position.x;
        }

        if (isDragging)
        {
            float mouseX = Input.mousePosition.x;
            float deltaX = mouseX - dragStartX;
            float newPositionX = Mathf.Clamp(startXPosition + (deltaX / Screen.width) * swipeSpeed, startXPosition - xOffset, startXPosition + xOffset);
            Vector3 newPosition = transform.position;
            newPosition.x = newPositionX;
            transform.position = newPosition;
        }
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            progress.CollectMoney();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("LoseMoney"))
        {
            progress.LoseMoney();
            Destroy(other.gameObject);
        }


    }

   

    private void Dresschanging() {

        if (progress.collectedElements <= 39) {
            _characterAnimator.SetBool("IsSad", true);
            _characterAnimator.SetBool("IsMiddle", false);
            _poorDress.SetActive(true);
            _middleDress.SetActive(false);
        }
        else if (progress.collectedElements <= 79)
        {
            _characterAnimator.SetBool("IsSad", false);
            _characterAnimator.SetBool("IsMiddle", true);
            _characterAnimator.SetBool("IsRich", false);
            _poorDress.SetActive(false);
                _middleDress.SetActive(true);
            _blingDress.SetActive(false);
        }
        else if (progress.collectedElements >= 80)
        {
            _characterAnimator.SetBool("IsRich", true);
            _characterAnimator.SetBool("IsMiddle", false);
                _middleDress.SetActive(false);
                _blingDress.SetActive(true);
        }
    }


    private void OnDrawGizmos()
    {
        if (points == null || points.Count == 0)
            return;

        Gizmos.color = Color.red;
        for (int i = 0; i < points.Count; i++)
        {
            if (points[i] != null)
            {
                Gizmos.DrawSphere(points[i].position, 0.2f); 

                if (i < points.Count - 1 && points[i + 1] != null)
                {
                    Gizmos.DrawLine(points[i].position, points[i + 1].position);
                }
            }
        }
    }
}