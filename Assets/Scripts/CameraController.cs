using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    [SerializeField]
    private float heightOffset;
    [SerializeField]
    private float slerpSpeed;
    [SerializeField]
    private LayerMask mask;    

    private float targetArmLength;

    void Start()
    {
        targetArmLength = Vector3.Distance(transform.position, player.transform.position);
        PlayerController.EventChangedGravity += AdjustCameraToPlane;
    }

    void LateUpdate()
    {
        Vector3 IdealPosition = player.transform.position - transform.forward * targetArmLength + transform.up * heightOffset;

        RaycastHit hit;
        if (Physics.Linecast(player.transform.position, IdealPosition, out hit, mask))
        {
            transform.position = hit.point + transform.forward * 0.75f;
        }
        else
        {
            transform.position = IdealPosition;
        }
    }

    private void AdjustCameraToPlane(RaycastHit hit)
    {
        Vector3 curEuler = hit.transform.rotation.eulerAngles;
        curEuler.z -= 90f;
        
        //Adjust camera height
        StopAllCoroutines();
        StartCoroutine(SlerpToNewRotation(Quaternion.Euler(curEuler)));
    }

    private IEnumerator LerpToNewLocation(Quaternion quat)
    {
        Vector3 CameraLookDir = quat.eulerAngles;
        Vector3 CameraNewPosition = Vector3.zero;

        CameraNewPosition = player.transform.position - CameraLookDir * targetArmLength;

        transform.position = CameraNewPosition;
        yield return null;
    }

    private IEnumerator SlerpToNewRotation(Quaternion quat)
    {
        float counter = 0.0f;

        while (counter < 1.0f)
        {
            counter += Time.deltaTime * slerpSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, quat, counter);

            yield return null;
        }
    }

    private void OnDestroy()
    {
        PlayerController.EventChangedGravity -= AdjustCameraToPlane;
    }
}
