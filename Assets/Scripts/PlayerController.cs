using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed; //Variable numérica decimal para guardar la velocidad de movimiento
    public float jumpForce; //Nueva variable decimal para guardar la fuerza de salto
    private bool canDoubleJump; //Variable booleana para saber si se puede hacer doble salto o no (se usa cuando estás o no en el suelo)

    public Rigidbody2D RigidB; //Variable de tipo RigidBody2d, hace referencia al conponente del cuerpo del player

    public bool isGrounded; //Variable booleana, para saber si el layer estyá tocando el suelo o no
    public Transform groundCheckpoint; //Variable de tipo tranforms, que hace referencia al componente transform que tienen los objetos en unity
    public LayerMask whatIsGround; //Variable de tipo layer para decir que un tipo de layermask, sea o no el suelo.

    //Variables usadas para las Animaciones
    private Animator anim; //Variable que se usa para las animaciones más abajo
    private SpriteRenderer SpriteRender; //VariableAttributes para más adelante poder ponerle un objeto de tipo spriterenderer

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    private void Awake()
    {
        instance = this;    
    }


    // Todo lo que hay dentro de esta función, se ejecuta solo una vez, cuando comienza la escena.
    void Start()
    {
        anim = GetComponent<Animator>(); //Cuando comienza la escena, con esta linea de código, busca el componente de animador de esa escena
        SpriteRender = GetComponent<SpriteRenderer>(); //Hace lo mismo que la anterior, pero busca el componente del sprite renderer
    }

    // Todo lo que hay dentro de esta función, se ejecuta en todo momento mientras se ejecuta la escena (paralelamente a todo lo demás)
    void Update()
    {
        if (!PauseMenu.instance.isPaused){
            if (knockBackCounter <= 0)
            {
                //Con esta linea se cambia la velocidad del RB, dandole solo un valor al eje y, haciendo así, que el player se mueva en este eje (derecha e izquierda)
                //Se usa el GetAxis("horizontal") para hacer referencia al sistema que tiene unity de inputs en este caso las flechas del teclado.
                RigidB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), RigidB.velocity.y);

                //Esta línea, crea un circulo trasparaente debajo del jugador, que se encarga de ser el que detecte el suelo.
                isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, whatIsGround);

                if (isGrounded) //Si la variable isGrounded está activa, hace lo siguiente:
                {
                    canDoubleJump = true; //La variable booleana de poder dar dos saltos, se pone activa
                }

                //De la misma forma que se hizo el getAxis de las teclas "flechas", se hace esta linea usando el input manager,
                //Pero esta vez, usando el "Jump", que detecta la tecla de "space"(Espacio) [Todo está dentro de un if]
                if (Input.GetButtonDown("Jump")) //Si, pulsamos la tecla de espacio, hace lo siguiente:
                {
                    if (isGrounded) //Se abre un if, y si está activa la variable "isGrounded" (es decir, estamos tocando el suelo), hace lo siguiente:
                    {
                        //Esta linea se encarga del salto, funciona exactamente igual que la de andar, pero aplicamos velocidad al eje x,
                        //de esta forma se mueve hacia arriba y parece que salta. (además se multiplica * la fuerza de salto que se le de en unity)
                        RigidB.velocity = new Vector2(RigidB.velocity.x, jumpForce);
                        AudioManager.instance.PlaySFX(2);

                    }
                    else //Si no, hace esto otro:
                    {
                        if (canDoubleJump)//Si la variable de doble salto está activa:
                        {
                            RigidB.velocity = new Vector2(RigidB.velocity.x, jumpForce); //Vuelve a dejar dar un salto, para tener el doble salto del player
                            AudioManager.instance.PlaySFX(2);
                            canDoubleJump = false; //Después de dar el segundo salto, esta variable, se desactiva para evitar que se siga saltando, hasta que no se toque el suelo de nuevo.
                        }
                    }

                }

                //Si el valor de velocity es inferior a 0 (es decir pulsamos la tecla de izquierda) el sprite hace un flip para mirar hacia la izquierda
                if (RigidB.velocity.x < 0)
                {
                    SpriteRender.flipX = true; //Esta linea es la que rota el sprite del player usando el sprite renderer que creamos al principio

                }
                else if (RigidB.velocity.x > 0) //En caso contrario, quiere decir que estamos aplicando la fuerza de manera positiva (es decir pulsando la tecla de derecha)
                {
                    SpriteRender.flipX = false; //Y de este modo, no se aplica ningún flip al spite de la rana.
                }
            }
            else
            {
                knockBackCounter -= Time.deltaTime;
                if (!SpriteRender.flipX)
                {
                    RigidB.velocity = new Vector2(-knockBackForce, RigidB.velocity.y);
                }
                else
                {
                    RigidB.velocity = new Vector2(knockBackForce, RigidB.velocity.y);
                }

            }
        }
        
        
        //Estas dos lineas sirven para las variables que se utilizan en la parte de las animaciones
        anim.SetFloat("moveSpeed", Mathf.Abs(RigidB.velocity.x)); //Una var que se una para que la animación comience cuando se aplica velocidad al eje horizontal
        anim.SetBool("isGrounded", isGrounded); //Igual que la enterior, pero detecta cuando se salta o no, para dar comienzo a la anim del salto
    }

    public void Knockback()
    {
        knockBackCounter = knockBackLength;
        RigidB.velocity = new Vector2(0f, knockBackForce);
    }
}
