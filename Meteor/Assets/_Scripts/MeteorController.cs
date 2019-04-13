using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    private Animator meteorAnimator;
    private bool isAlive;

	private void Awake()
	{
        meteorAnimator = GetComponent<Animator>();
	}

	private void Start()
	{
        isAlive = true;
	}

	private void OnMouseDown()
    {
        if (isAlive)
        {
            DestroyMeteor();
        }
    }

    private void DestroyMeteor(){
        isAlive = false;
        meteorAnimator.SetTrigger("Destroy");
    }

    private void DestroyGameObject()
    {
        GameObject.Destroy(gameObject);
    }
}
