using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{

    //bool
    //int
    //string
    //float

    SpriteRenderer sp;
    //Rigidbody2D
    //BoxCollider2D
    //Animator

    //GameObject



    public string a;

    //cek pada unity pastikan bisa melompat dalam kondisi menyentuh dataran
    [SerializeField] private LayerMask platformLaterMask;

    [SerializeField] GameObject savePoin;


    Animator an;
    Rigidbody2D rb;
    BoxCollider2D bx;
    bool lompat;
    bool hadapKanan;

    float dirX;
    float dirY;

    float initdirX;
   

    Vector2 resetPosisi;


    public void proses(float param)
    {
        a = "bla bla bla";
        initdirX = param;
    }

    private void Awake()
    {
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bx = GetComponent<BoxCollider2D>();
        sp = gameObject.GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        hadapKanan = true;
        lompat = false;
        dirX = 0;
        dirY = 0;
        initdirX = 7;
        
        resetPosisi = savePoin.transform.position;

        //resetPosisi = new Vector2(savePoin.transform.position.x,savePoin.transform.position.y);
    }


    public void resetInit()
    {
        gameObject.transform.position = resetPosisi;
    }

    // Update is called once per frame
    void Update()
    {
        
        //untuk lompat pastikan karakter berada dalam ground/dataran
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            dirY = 8;
            lompat = true;
        }

        //gerak kekanan
        if (Input.GetKeyDown(KeyCode.D))
        {
            dirX = initdirX;
            an.SetBool("sedangJalan", true);
        }
        
        //gerak kekiri
        if (Input.GetKeyDown(KeyCode.A))
        {
            dirX = -initdirX;
            an.SetBool("sedangJalan", true);
        }

        //jika tidak bergerak
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            dirX = 0;
            an.SetBool("sedangJalan", false);
        }
    }

    //fungsi ini digunakan untuk mengecek kondisi lompat karakter
    private bool IsGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(bx.bounds.center, bx.bounds.size, 0f, Vector2.down, 1f, platformLaterMask);
        return raycastHit2D.collider != null;
    }

    //fungsi ini digunakan untuk mengecek arah pandang/flip jika karakter kekanan dan kekiri
    private void cekArahPandang()
    {
        //cek flip/arah pandang dengan menentukan posisi localscale
        Vector3 localScale = gameObject.transform.localScale;
        if (dirX > 0)
        { hadapKanan = true; }
        else if (dirX < 0)
        {    hadapKanan = false; }
        if (((hadapKanan) && (localScale.x < 0)) || ((!hadapKanan) && (localScale.x > 0)))
        { localScale.x *= -1; }
        transform.localScale = localScale;
    }

    private void FixedUpdate()
    {
        //cek batas berada di ground gunanya untuk membuat lompatan cuman 1x,
        //kondisi lompatan mengubah nilai dirY dan harus dikembalikan ke 0
        if (lompat)
        {
            //kembalikan lompat=false untuk tidak dalam kondisi melompat
            lompat = false;
            rb.velocity = Vector2.up * dirY;
        }

        //cek arah pandang karakter
        cekArahPandang();

        //cek gerak jalan karakter
        rb.velocity = new Vector2(dirX, rb.velocity.y);

    }

}
