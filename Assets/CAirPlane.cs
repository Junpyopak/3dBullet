using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 이 예시코드는 
 * 탄환 궤적 알고리즘 테스트 코드이다
 * 
 * 탄환의 예는
 * 1)일반탄환 :제작중에 탄환의 속도가 이미 결정되어 있는탄환
 * 1)조준탄환 :실행중에 발사 시점에 방향을 조준하여 결정하는 탄환
 * 3)원형탄환이 있다 : 원형의 형태의 방향 대로 발사되는 탄환
 * 
 * 이 세가지를 작성할줄 안다면
 * 다른 모든 탄환궤적도 작성 가능하다
 */
public class CAirPlane : MonoBehaviour
{

    [SerializeField] CBullet PFBullet = null;
    // Start is called before the first frame update
    [SerializeField] GameObject mTargetObject = null;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //Dofire();
            //DofireAimed(mTargetObject.transform.position);
            DofireCircled();
        }
    }
    //탄환 발사루틴 
    //i) 발사시작 지점 성정
    //II)탄환의 속도 설정
    //III) 탄환 활성화



    //일반 탄환
    void Dofire()
    {
        Vector3 tPositionFire = Vector3.zero;
        tPositionFire = this.transform.position;

        Vector3 tVelocity = Vector3.zero;
        tVelocity = Vector3.up * 30f;//백터의 스칼라곱셈
        //속도가 제작중에 미리 지정된 탄환

        CBullet tBullet = Instantiate<CBullet>(PFBullet, tPositionFire, Quaternion.identity);
        tBullet.GetComponent<Rigidbody>().AddForce(tVelocity, ForceMode.Impulse);

        //수를 다루는 관점에서 보면,물리가 수학이랑 다른점? 수치에 단위가 붙는다.
        //물리에서 다루는 단위들에 표준은 다움과 같다.
        //1m.1kg,1sec

        //ForceMode.Force <-- 시간단위가 1초이다.물리를 그대로 따른다.
        //ForceMode.Impulse <--시간단위가 1프레임이다. 한프레임에 주어진 힘을 모두 가한다.
    }
    //조준탄환발사
    void DofireAimed(Vector3 tPositionTarget)
    {
        Vector3 tPositionFire = Vector3.zero;
        tPositionFire = this.transform.position;

        Vector3 tVelocity = Vector3.zero;

        //단위백터
        //임의의 크기의 임의의 방향의 백터 = 목적지점 - 시작지점
        //임의의 크기의 임의의 방향의 백터 <--- 정규화하여 크기가 1인 순순한 방향의 백터를 구한다.
        Vector3 tUnitVelocity = (tPositionTarget - tPositionFire).normalized;

        tVelocity = tUnitVelocity * 30f;//백터의 스칼라곱셈
        //속도가 발사시점에 결정되는 탄환

        CBullet tBullet = Instantiate<CBullet>(PFBullet, tPositionFire, Quaternion.identity);
        tBullet.GetComponent<Rigidbody>().AddForce(tVelocity, ForceMode.Impulse);

    }
    //유도탄환
    //유도 탄환은 기본적으로 조준탄과 같다
    //다만 탄환이 스스로 방향을 일정시간 간격으로 재조준하는것이다.


    //원형탄환발사

    void DofireCircled()
    {
        //45도간격 ,8발 가정
        float tAngle = 0f;
        for (int ti = 0; ti < 8; ++ti)
        {
            Vector3 tPositionFire = Vector3.zero;
            tPositionFire = this.transform.position;

            Vector3 tVelocity = Vector3.zero;

            //데카르트 좌표계의 구성성분과 극좌표계의 구성성분과의 관계
            //x = r*cosT
            //y =r*sinT


            //각도의 개념
            //degree 도: 한바퀴를 360등분한것중 하나를 1도라고하자.(측정치)
            //       <--실수의 연산 체계에 적합하기 때문에 수학함수나 게임엔진 에서는 radian을 계산에 사용한다
            //radian 호도 : 반지름이 1인 원의 원주중에 길이가 r인호

            //360도 : 1도 = 2*PI :x
            //x = PI/180 <--- degree to radian,Mathf.Deg2Rad


            //크기가 1인 순순한 방향백터를 구하기위해 r은1
            tVelocity.z = 0;
            tVelocity.x = 1f*Mathf.Cos(tAngle*Mathf.Deg2Rad);
            tVelocity.y = 1f*Mathf.Sin(tAngle* Mathf.Deg2Rad);

            tAngle += 45f;
            tVelocity = tVelocity * 30f;//속력을 스칼라 곱셈

            CBullet tBullet = Instantiate<CBullet>(PFBullet, tPositionFire, Quaternion.identity);
            tBullet.GetComponent<Rigidbody>().AddForce(tVelocity, ForceMode.Impulse);
        }
    }
}


