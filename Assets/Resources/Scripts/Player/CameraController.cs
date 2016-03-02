using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Transform cameraTarget;
    private float x = 0.0f;
    private float y = 0.0f;
    private int mouseXSpeedMod = 5;
    private int mouseYSpeedMod = 3;

    public float maxViewDist = 25.0f;
    public float minViewDist = 1.0f;
    public int zoomRate = 30;
    private float dist = 3.0f;
    private float desiredDist;
    private float correctedDist;
    private float currentDist;
    private float lerpRate = 5.0f;
    private float targetHeight = 1.6f; //Height of the player, the camera will follow
    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;

        currentDist = dist;
        correctedDist = dist;
        desiredDist = dist;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            x += Input.GetAxis("Mouse X") * mouseXSpeedMod;
            y -= Input.GetAxis("Mouse Y") * mouseYSpeedMod;
        }
        else if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            float targetRotationAngle = cameraTarget.eulerAngles.y;
            float cameraRotationAngle = transform.eulerAngles.y;
            x = Mathf.LerpAngle(cameraRotationAngle, targetRotationAngle, lerpRate * Time.deltaTime);
        }

        y = ClampAngle(y, -50, 80);
        Quaternion rotation = Quaternion.Euler(y, x, 0);

        desiredDist -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDist);
        desiredDist = Mathf.Clamp(desiredDist, minViewDist, maxViewDist);
        correctedDist = desiredDist;

        Vector3 pos = cameraTarget.position - (rotation*Vector3.forward*desiredDist);

        RaycastHit collisionHit;
        Vector3 cameraTargetPos = new Vector3(cameraTarget.position.x, cameraTarget.position.y + targetHeight, cameraTarget.position.z);
        bool isCorrected = false;
        if(Physics.Linecast(cameraTargetPos, pos, out collisionHit))
        {
            pos = collisionHit.point;
            correctedDist = Vector3.Distance(cameraTargetPos, pos);
            isCorrected = true;
        }

        currentDist = !isCorrected || correctedDist > currentDist ? Mathf.Lerp(currentDist, correctedDist, Time.deltaTime * zoomRate) : correctedDist;

        pos = cameraTarget.position - (rotation * Vector3.forward * currentDist + new Vector3(0, -targetHeight, 0));

        transform.rotation = rotation;
        transform.position = pos;
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }

        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
