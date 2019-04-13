using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [Header("Speed")]
    private float movementSpeed = 0.1f;
    private float rotationSpeed = 2;

    [Header("Components")]
    private Animator meteorAnimator;

    [Header("State")]
    private bool isAlive;


	private void Awake()
	{
        meteorAnimator = GetComponent<Animator>();
	}

	private void Start()
	{
        isAlive = true;
	}

    public void setupMeteor(float movementSpeed, float rotationSpeed){
        this.movementSpeed = movementSpeed;
        this.rotationSpeed = rotationSpeed;
    }

	private void FixedUpdate()
	{
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime, Space.World);
	}

	private void OnMouseDown()
    {
        if (isAlive)
        {
            DestroyMeteor();
        }
    }

    private void DestroyMeteor()
    {
        isAlive = false;
        GameManager.instance.AddScore();
        meteorAnimator.SetTrigger("Destroy");
    }

    private void DestroyGameObject()
    {
        GameObject.Destroy(gameObject);
    }
}