using UnityEngine;

public class PathSumoner : Movable
{
    [SerializeField] Vector3 fromPosition;
    [SerializeField] Vector3 toPosition;
    [SerializeField] bool hasCamera = false;
    [SerializeField] Transform cam;
    [SerializeField] bool isLeaver = true;
    [SerializeField] Movable nextTargetMovable;
    [SerializeField] float magnitudeSpeedCampare = 0.3f;

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

        if (velocity.magnitude < magnitudeSpeedCampare)
        {
            engage = false;
            if (cam != null)
                cam.gameObject.SetActive(false);
            if (isLeaver)
                if (nextTargetMovable != null)
                {
                    Debug.Log("next movable");
                    nextTargetMovable.SetEngage(true);
                }
        }
    }
}