using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * �� �����ڵ�� 
 * źȯ ���� �˰��� �׽�Ʈ �ڵ��̴�
 * 
 * źȯ�� ����
 * 1)�Ϲ�źȯ :�����߿� źȯ�� �ӵ��� �̹� �����Ǿ� �ִ�źȯ
 * 1)����źȯ :�����߿� �߻� ������ ������ �����Ͽ� �����ϴ� źȯ
 * 3)����źȯ�� �ִ� : ������ ������ ���� ��� �߻�Ǵ� źȯ
 * 
 * �� �������� �ۼ����� �ȴٸ�
 * �ٸ� ��� źȯ������ �ۼ� �����ϴ�
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
    //źȯ �߻��ƾ 
    //i) �߻���� ���� ����
    //II)źȯ�� �ӵ� ����
    //III) źȯ Ȱ��ȭ



    //�Ϲ� źȯ
    void Dofire()
    {
        Vector3 tPositionFire = Vector3.zero;
        tPositionFire = this.transform.position;

        Vector3 tVelocity = Vector3.zero;
        tVelocity = Vector3.up * 30f;//������ ��Į�����
        //�ӵ��� �����߿� �̸� ������ źȯ

        CBullet tBullet = Instantiate<CBullet>(PFBullet, tPositionFire, Quaternion.identity);
        tBullet.GetComponent<Rigidbody>().AddForce(tVelocity, ForceMode.Impulse);

        //���� �ٷ�� �������� ����,������ �����̶� �ٸ���? ��ġ�� ������ �ٴ´�.
        //�������� �ٷ�� �����鿡 ǥ���� �ٿ�� ����.
        //1m.1kg,1sec

        //ForceMode.Force <-- �ð������� 1���̴�.������ �״�� ������.
        //ForceMode.Impulse <--�ð������� 1�������̴�. �������ӿ� �־��� ���� ��� ���Ѵ�.
    }
}


