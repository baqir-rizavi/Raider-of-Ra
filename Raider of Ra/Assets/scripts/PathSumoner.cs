using UnityEngine;

public class PathSumoner : Movable
{
    [SerializeField] Vector3 fromPosition;
    [SerializeField] Vector3 toPosition;
    [SerializeField] bool hasCamera = false;
    [SerializeField] Transform cam;

    protected override void Engage()
    {
        fromPosition = transform.position;
        if (hasCamera)
            if (cam != null)
                cam.gameObject.SetActive(true);
        LinearMovement();
    }
    protected void LinearMovement()
    {
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(fromPosition, toPosition, ref velocity, 0.2f, speed * Time.deltaTime);

        if (velocity.magnitude < 0.2)
        {
            engage = false;
            if (cam != null)
                cam.gameObject.SetActive(false);
        }
    }
}