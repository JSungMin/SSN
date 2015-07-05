//Copyright �� 2013 Soonsoon. All rights Reserved
//�ش� ��ũ��Ʈ�� ���� ��� ���۱��� ���������ο� �ֽ��ϴ�
//������� �뵵, ������, ���� ���������� ���۱����� ������� ����Ҽ������ϴ�
//http://www.soonsoons.com // soonsoon@lvzero.com

//�÷��̾ ����ٴϴ� ī�޶� ��ũ��Ʈ
//�κ��κ� ���� ��ũ��Ʈ
using UnityEngine;
using System.Collections;

public class CameraSmooth : MonoBehaviour
{
    // Ÿ�� ������Ʈ ���� ����
    public GameObject _target;
    // �ʱ� ��ǥ ���� ����
    public Vector3 _iniPos;
    // ���� ��ǥ ���� ����
    public Vector3 _nowPos;

    // Use this for initialization
    void Start()
    {
        // ���� ī�޶��� ��ǥ�� ����
        _iniPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ī�޶� ���� ��ǥ���� �������� ������Ʈ ����ٴ�
       	transform.position = _iniPos + _target.transform.position;

    }
}
