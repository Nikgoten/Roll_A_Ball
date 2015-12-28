using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    [SerializeField]
    private float heightOffset;
    [SerializeField]
    private float slerpSpeed;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
        PlayerController.EventChangedGravity += AdjustCameraToPlane;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset + (transform.up * heightOffset);
    }

    private void AdjustCameraToPlane(RaycastHit hit)
    {
        Vector3 curEuler = hit.transform.rotation.eulerAngles;
        curEuler.z -= 90f;

        //Adjust camera height
        StopAllCoroutines();
        StartCoroutine(SlerpToNewRotation(Quaternion.Euler(curEuler)));
    }

    private IEnumerator SlerpToNewRotation(Quaternion quat)
    {
        float counter = 0.0f;
        float newHeight = transform.up.y * heightOffset;

        while (counter < 1.0f)
        {
            counter += Time.deltaTime * slerpSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, quat, counter);

            yield return null;
        }
    }
}
