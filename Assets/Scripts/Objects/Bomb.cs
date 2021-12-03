using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _timeDestroy = 5;


    private void OnEnable()
    {
        Destroy(gameObject, _timeDestroy);
    }
}