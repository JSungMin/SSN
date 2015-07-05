//Copyright ⓒ 2013 Soonsoon. All rights Reserved
//해당 스크립트에 대한 모든 저작권은 순순디자인에 있습니다
//상업적인 용도, 공모전, 개인 과제용으로 저작권자의 허락없이 사용할수없습니다
//http://www.soonsoons.com // soonsoon@lvzero.com

//플레이어를 따라다니는 카메라 스크립트
//로보로보 전용 스크립트
using UnityEngine;
using System.Collections;

public class CameraSmooth : MonoBehaviour
{
    // 타겟 오브젝트 변수 선언
    public GameObject _target;
    // 초기 좌표 변수 선언
    public Vector3 _iniPos;
    // 현재 좌표 변수 선언
    public Vector3 _nowPos;

    // Use this for initialization
    void Start()
    {
        // 최초 카메라의 좌표값 저장
        _iniPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 카메라가 최초 좌표만끔 떨어져서 오브젝트 따라다님
       	transform.position = _iniPos + _target.transform.position;

    }
}
