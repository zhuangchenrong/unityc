using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{

    public Transform targetPosition;

    Vector3 distance; //摄像机和玩家的距离三维

    // Update is called once per frame
    private void Start()
    {
        //摄像机和玩家间的距离
        distance = targetPosition.transform.position - transform.position;
    }

    void Update()
    {
        CameraFollow();
    }

    void CameraFollow()
    {
        //用摄像机和玩家的距离求出根据当前玩家位置求出摄像机位置
        float currentX = targetPosition.transform.position.x - distance.x;
        float currentY = targetPosition.transform.position.y - distance.y;
        Vector3 temp = new Vector3(currentX, currentY, -10.31f);
        transform.position = temp;
    }
}
