using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryMonster : ScaryThings
{
    private Camera cam;
    [SerializeField] private Transform spot;
    [SerializeField] private GameObject abilityButton;

    int groundLayer;
    private Vector2 monsterPosition;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        groundLayer = LayerMask.NameToLayer("Ground");//LayerMask.GetMask("Ground");
        Debug.Log("Ground layer: " + groundLayer);
    }

    public void LookForMonsterSpot()
    {
       // Debug.Log("look for monster");

        spot.gameObject.SetActive(true);
        StartCoroutine("FollowMouse");
    }

    private IEnumerator FollowMouse()
    {
        //Debug.Log("corutine");

        while (!Input.GetMouseButtonDown(0))
        {
            spot.position = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
            yield return null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (CanSetMonster(ray))
        {
            monsterPosition = ray.origin;
            SetMonster();
        }
        FinishSetting();
    }

    private bool CanSetMonster(Ray ray)
    {
       // Debug.Log("can set");
        if (Physics2D.Raycast(ray.direction, ray.origin, 100, groundLayer))
        {
            return true;
        }
        Debug.Log("NOT HIT");
        return false;
/*        RaycastHit2D hit = Physics2D.Raycast(ray.direction, ray.origin); //Physics2D.Raycast(ray.origin, ray.direction);
        if (hit)
        {
            Debug.Log("Layer hitted: " + hit.transform.gameObject.layer);
            if (hit.transform.gameObject.layer == groundLayer)
            {
                return true;
            }
        }
        return false;
*/    }

    private void SetMonster()
    {
        Debug.Log("set monster");
        transform.position = monsterPosition;
        Scare();
    }

    private void FinishSetting()
    {
       // Debug.Log("finish setting");
        StopAllCoroutines();
        spot.gameObject.SetActive(false);
        abilityButton.SetActive(true);
    }
}
