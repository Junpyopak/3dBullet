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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Dofire();
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
}


