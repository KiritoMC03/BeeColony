using UnityEngine;

public class BeeMotor : Motor
{
    private Vector2 _input;

    protected override Vector2 Move()
    {
        var movement = (Vector3) (GetInput() * (Time.deltaTime * _moveSpeed));
        _transform.position += movement;
        return movement;
    }

    private static Vector2 GetInput()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        return new Vector2(x, y);
    }
}
