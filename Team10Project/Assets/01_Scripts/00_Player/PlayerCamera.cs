using System.Collections;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform playerTransform;
    [SerializeField] float cameraMoveSpeed = 5;

    [SerializeField] float m_roughness; // ��ĥ�� ����
    [SerializeField] float m_magnitude; // ������ ����

    Vector3 originalPosition; // �÷��̾� ��ġ ����� ����

    bool isShake;

    int cameraPos = 6;

    void Start()
    {
        originalPosition = playerTransform.position; // �÷��̾� ��ġ �ʱ�ȭ
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            cameraPos = 10;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            cameraPos = -10;
        }
        else
        {
            cameraPos = 6;
        }
        // ������ �÷��̾� ��ġ�� �̵�������, ��鸲 �ڷ�ƾ ���� ���̶�� originalPosition���� �̵�
        Vector3 targetPosition = isShake ? originalPosition : new Vector3(playerTransform.position.x, playerTransform.position.y + cameraPos, -10);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraMoveSpeed);

    }

    
    public void ShakeCamera(float duration)
    {
        if (!isShake)
            StartCoroutine(Shake(duration));
    }

    IEnumerator Shake(float duration)
    {
        isShake = true;

        float elapsed = 0f;
        Vector3 originalCameraPosition = transform.position; // ī�޶� �ʱ� ��ġ ����
        float tick = Random.Range(-10f, 10f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            tick += Time.deltaTime * m_roughness;
            float offsetX = Mathf.PerlinNoise(tick, 0) - .5f;
            float offsetY = Mathf.PerlinNoise(0, tick) - .5f;
            transform.position = originalCameraPosition + new Vector3(offsetX, offsetY, 0f) * m_magnitude;

            yield return null;
        }

        isShake = false;
    }
}
