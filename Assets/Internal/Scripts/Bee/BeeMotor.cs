using UnityEngine;

public class BeeMotor : Motor // мотор пчелки зависит от общего мотора...
{
    private Vector2 _input;

    protected override Vector2 Move() // а вот это отвечает за движение именно пчелки
    {
        var movement = (Vector3) (GetInput() * (Time.deltaTime * _moveSpeed));
        _transform.position += movement;
        return movement;
    }//)))))))))))))))))))))

    private static Vector2 GetInput()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        return new Vector2(x, y);
    }
}
