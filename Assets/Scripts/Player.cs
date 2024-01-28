using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public int attackDamageTypeOne; // Dano para o AttackTypeOne
    public int attackDamageTypeTwo; // Dano para o AttackTypeTwo
    public Button attackOne;
    public Button attackTwo;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        //if (Input.GetKeyDown(KeyCode.Space)) // Pressione a tecla Espaço para atacar
        //{
        //    Attack();
        //}
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    //void Attack()
    //{
    //    // Detecta inimigos no alcance do ataque
    //    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers);
        
    //    // Aplica dano a cada inimigo atingido
    //    foreach (Collider2D enemy in hitEnemies)
    //    {
    //        Debug.Log("space");

    //        enemy.GetComponent<AttackBot>()?.TakeDamage(attackDamage);
    //    }
    //}

    public void AttackTypeOne()
    {
        Debug.Log("Ataque Tipo 1");
        PerformAttack(attackDamageTypeOne);
    }

    public void AttackTypeTwo()
    {
        Debug.Log("Ataque Tipo 2");
        PerformAttack(attackDamageTypeTwo); 
    }

    private void PerformAttack(float damage)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<AttackBot>()?.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (transform == null)
            return;

        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
