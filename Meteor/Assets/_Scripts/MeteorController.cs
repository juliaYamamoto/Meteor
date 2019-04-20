using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [Header("Speed")]
    private float movementSpeed = 0.1f;

    [Header("Components")]
    private Animator meteorAnimator;

    [Header("State")]
    private bool isAlive;

    [Header("Limit")]
    public float limitYPosition = -6;

	private void Awake()
	{
        meteorAnimator = GetComponent<Animator>();
	}

	private void Start()
	{
        isAlive = true;
	}

    public void setupMeteor(float movementSpeed){
        this.movementSpeed = movementSpeed;
    }

	private void Update()
	{
        if(isAlive && transform.position.y < limitYPosition){
            isAlive = false;
            GameManager.instance.LoseLife();
            DestroyGameObject();

        }
	}

	private void FixedUpdate()
	{
        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime, Space.World);

        if(GameManager.instance.currentGameState == GameManager.GameState.End){
            DestroyGameObject();
        }
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