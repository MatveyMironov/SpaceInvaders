using UnityEngine;

public class Enemy : MonoBehaviour, IDestroyable
{
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
