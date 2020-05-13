using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personagem3D : MonoBehaviour
{
    public Transform cam, hud;
    public float distanciaCameraX;
    public float camVelocidade;
    public static int aboboras;


    public GameObject character;
    public float speed = 6.0f;       //Velocidade de descolamento
    public float jumpSpeed = 8.0f;   //Impulso do pulo
    public float gravity = 20.0f;     //Gravidade
    private Vector3 moveDirection; //Recebe todos os dados dos eixos XYZ
    private CharacterController c;
    private Animation anim; //Recebe o componente animation da malha do Personagem

    private void Start()
    {
        c = GetComponent<CharacterController>();
        anim = character.GetComponent<Animation>();
        anim.CrossFade("IDLE");
        aboboras = 0;
    }

    void Update()
    {
        //Camera Control
        float d = transform.position.x - cam.transform.position.x;
        float h = transform.position.x - hud.transform.position.x;


        if (Mathf.Abs(d) > distanciaCameraX)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position,
            new Vector3(transform.position.x, cam.transform.position.y, cam.transform.position.z),
            camVelocidade * Time.deltaTime);
        }

        else if (Mathf.Abs(d) > distanciaCameraX)
        {
            hud.transform.position = Vector3.Lerp(hud.transform.position,
            new Vector3(transform.position.x, hud.transform.position.y, hud.transform.position.z),
            camVelocidade * Time.deltaTime);
        }





        cam.transform.position = Vector3.Lerp(cam.transform.position,
            new Vector3(transform.position.x, cam.transform.position.y, cam.transform.position.z),
            camVelocidade * Time.deltaTime);

        //Acesso ao componente character controller
        CharacterController controller = GetComponent<CharacterController>();

        //Verificar colisao com o chao
        if (controller.isGrounded)
        {
            //Acoes quando estiver pisando no chao

            //Coleta os inputs
            moveDirection = new Vector3(
                Input.GetAxis("Horizontal"), 0.0f, 0.0f);

            //Atualiza o character controller
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            //PULAR
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }



        }

        //Gravidade
        moveDirection.y -= gravity * Time.deltaTime;

        //Atribuir todos os valores construidos (mover, pulo e gravidade) no character controller
        controller.Move(moveDirection * Time.deltaTime);

        //Orientacao
        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            character.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
        }
        else if (Input.GetAxis("Horizontal") > 0.0f)
        {
            character.transform.eulerAngles = new Vector3(0.0f, -90.0f, 0.0f);

        }

        else
        {
            character.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }

        //Animacao
        if (moveDirection.x == 0.0f && moveDirection.z == 0.0f)
        {
            anim.CrossFade("IDLE");
        }
        else if (Mathf.Abs(moveDirection.x) > 0.0f || Mathf.Abs(moveDirection.y) > 0.0f)
        {
            anim.CrossFade("RUN");
        }

        if (aboboras == 5)
        {
            SceneManager.LoadScene("Winner");
        }
        
    }

 
    public void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Abobora")
        {
            Destroy(c.gameObject);
            aboboras++;
        }
    }
}


