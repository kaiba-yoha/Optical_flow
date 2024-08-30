using UnityEngine;

public class FloatingCanvas : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float followSpeed = 2f;
    [SerializeField] private float distanceFromCamera = 1f;

    private Vector3 targetPosition;

    void Start()
    {
        playerCamera = Camera.main.transform;
    }

    private void Update()
    {
        // カメラの前方の目標位置を計算
        targetPosition = playerCamera.position + playerCamera.forward * distanceFromCamera;

        // 現在の位置から目標位置へゆっくり移動
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);

        // カメラの方向を向く
        transform.rotation = Quaternion.Lerp(transform.rotation, playerCamera.rotation, Time.deltaTime * followSpeed);
    }
}
