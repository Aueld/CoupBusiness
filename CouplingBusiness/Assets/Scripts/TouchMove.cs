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
        // ���������� �Ÿ� ����
        float distance = Vector3.Distance(TargetPos, mainCamera.transform.position);
        Quaternion quat = Quaternion.Euler(Rot);
 
        // �ش� ���ʹϾ��� rotation���� ����
        mainCamera.transform.rotation = quat;
        mainCamera.transform.position = TargetPos;

        // �����庤�͸� quat���� ȸ����Ű��, �ش� ���� �������� distance��ŭ �ڷ� �̵�
        mainCamera.transform.position -= quat * Vector3.forward * distance; 
        
        // �̵�ó�� �� �������� �ٶ󺻴�
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
