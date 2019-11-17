using UnityEngine;

public class DreamerMovement : MonoBehaviour, IMovable
{
    //finish target where is dreamer going
    [SerializeField] private GameObject target;
    public void Move()
    {
        Debug.Log ("Dreamer Moves");
    }
}