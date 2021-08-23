using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    public float maxSpeed;
    public float nextMove;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButtonUp("Horizontal")) // 속력
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        if (Input.GetButtonDown("Horizontal")) //캐릭터 좌우 반전
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if (Input.GetAxisRaw("Horizontal") == -1) //nextMove 설정
            nextMove = -1;

        if (Input.GetAxisRaw("Horizontal") == 1)
            nextMove = 1;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); //테마 캐릭터 움직임
        rigid.velocity = new Vector2(maxSpeed * h, rigid.velocity.y);

        if (rigid.velocity.x > maxSpeed) //오른쪽 스피드 제한
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) // 왼쪽 스피드 제한
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);


        Vector3 frontVec = new Vector2(rigid.position.x + nextMove * 300f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down * 300, new Color(0, 1, 0)); // 캐릭터의 기준 앞 드로우 레이
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down * 300, 300f, LayerMask.GetMask("Platform"));

        if (rayHit.collider == null)
        {
            maxSpeed= 0;
        }
        else if(rayHit.collider != null)
        {
            maxSpeed = 1000;
        }
    }
}
