using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{

    public Transform targetPosition;

    Vector3 distance; //���������ҵľ�����ά

    // Update is called once per frame
    private void Start()
    {
        //���������Ҽ�ľ���
        distance = targetPosition.transform.position - transform.position;
    }

    void Update()
    {
        CameraFollow();
    }

    void CameraFollow()
    {
        //�����������ҵľ���������ݵ�ǰ���λ����������λ��
        float currentX = targetPosition.transform.position.x - distance.x;
        float currentY = targetPosition.transform.position.y - distance.y;
        Vector3 temp = new Vector3(currentX, currentY, -10.31f);
        transform.position = temp;
    }
}
