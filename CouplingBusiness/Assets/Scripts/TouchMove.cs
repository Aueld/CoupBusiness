using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchMove : MonoBehaviour , IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    private float speed = 0.5f;

    private GameObject mainCamera;
    private GameObject target;

    private Vector2 dragPos;

    private void Start()
    {
        mainCamera = Camera.main.gameObject;
        target = Manager.Instance.obj;
    }

    private void Update()
    {
        if (Input.touchCount == 2)
            return;

        RotationFromTarget(dragPos * speed, target.transform.position);
    }

    private void RotationFromTarget(Vector3 Rot, Vector3 TargetPos)
    {
        // 기준점과의 거리 저장
        float distance = Vector3.Distance(TargetPos, mainCamera.transform.position);
        Quaternion quat = Quaternion.Euler(Rot);
 
        // 해당 쿼터니언을 rotation으로 지정
        mainCamera.transform.rotation = quat;
        mainCamera.transform.position = TargetPos;

        // 포워드벡터를 quat으로 회전시키고, 해당 축을 기준으로 distance만큼 뒤로 이동
        mainCamera.transform.position -= quat * Vector3.forward * distance; 
        
        // 이동처리 후 기준점을 바라본다
        mainCamera.transform.LookAt(TargetPos);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {6
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragPos.x = eventData.position.y;
        dragPos.y = eventData.position.x;
    }
}
