using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameController gameController;

    //Portal animation
    void Start()
    {
        gameController = GameController.Instance;
    }


    IEnumerable PlayPortalAnimation()
    {
        yield return new WaitForSeconds(/*animationLength*/5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dreamer"))
        {
            StartCoroutine("PlayPortalAnimation");
            gameController.EndGame();
        }
    }
}
