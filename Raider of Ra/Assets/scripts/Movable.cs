using UnityEngine;

public abstract class Movable : MonoBehaviour
{
    public bool engage = false;
    [SerializeField] protected float speed = 5f;
    public void SetEngage(bool e)
    {
        engage = e;
    }
    protected abstract void Engage();

    void Update()
    {
        if (engage)
            Engage();
    }

    
}
