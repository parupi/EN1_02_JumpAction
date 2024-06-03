using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    private Image arrowImage;
    private Vector3 clickPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            arrowImage.enabled = true;
            Vector3 dist = clickPosition - Input.mousePosition;
            // �x�N�g���̒������Z�o
            float size = dist.magnitude;
            // �x�N�g������p�x�i�ʓx�@�j���Z�o
            float angleRad = Mathf.Atan2(dist.y, dist.x);
            // ���̉摜���N���b�N�����ꏊ�ɉ摜���ړ�
            arrowImage.rectTransform.position = clickPosition;
            // ���̉摜���x�N�g������Z�o�����p�x��x���@�ɕϊ�����Z����]
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
            // ���̉摜�̑傫�����h���b�O���������ɍ��킹��
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
            Debug.Log(dist);
        }
        else
        {
            arrowImage.enabled = false;
        }
    }
}
