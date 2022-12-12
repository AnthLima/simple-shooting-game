using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offset;

    // Update is called once per frame
    void Update()
    {
        HandleAiming();
    }

    private void HandleAiming () {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle =  Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
