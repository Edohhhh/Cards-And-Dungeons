using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    [SerializeField] private float vida;
    private Vector2 rightAttackOffset;
    private float offsetY = 1.0f;  // Puedes ajustar el valor según tus necesidades.

    public enum AttackDirection { Left, Right, Up, Down }

    private void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.position;
        swordCollider.enabled = false;  // Asegúrate de deshabilitar el collider inicialmente.
    }

    public void attack(AttackDirection direction)
    {
        switch (direction)
        {
            case AttackDirection.Left:
                AttackLeft();
                break;
            case AttackDirection.Right:
                AttackRight();
                break;
            case AttackDirection.Up:
                AttackUp();
                break;
            case AttackDirection.Down:
                AttackDown();
                break;
        }
    }

    private void AttackRight()
    {
        swordCollider.enabled = true;
        transform.position = rightAttackOffset;
    }

    private void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.position = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    private void AttackUp()
    {
        swordCollider.enabled = true;
        transform.position = new Vector3(rightAttackOffset.x, rightAttackOffset.y + offsetY);
    }

    private void AttackDown()
    {
        swordCollider.enabled = true;
        transform.position = new Vector3(rightAttackOffset.x, rightAttackOffset.y - offsetY);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
        transform.position = rightAttackOffset;  // Restablece la posición original.
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemigos"))
        {
            other.GetComponent<Enemigos>().TomarDaño(vida);
        }
    }
}
