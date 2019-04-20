using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgainController : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GameManager.instance.currentGameState == GameManager.GameState.End)
        {
            GameManager.instance.TryAgainClicked();
        }
    }
}