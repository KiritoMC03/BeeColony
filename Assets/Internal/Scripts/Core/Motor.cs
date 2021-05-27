using UnityEngine;
using UnityEngine.Events;

public abstract class Motor : MonoBehaviour
{
    public UnityEvent OnDirectionChange;
    
    /// <returns>
    /// Vector2.right or Vector2.left
    /// </returns>
    public Vector2 LastDirection { get; private set; }
    
    [SerializeField] protected float _moveSpeed = 5f;
    
    protected Transform _transform;
    
    private Vector2 _tempDirection = new Vector2();
    
    private void Awake()
    {
        InitFields();
        AwakeWork();
        LastDirection = new Vector2(_transform.localScale.x, 0).normalized;
    }
    
    private void InitFields()
    {
        _transform = transform;
    }
    
    private void Update()
    {
        var moveResult = Move();
        _tempDirection = new Vector2(moveResult.x, 0).normalized;
        
        if (_tempDirection.x != 0f && _tempDirection != LastDirection)
        {
            OnDirectionChange?.Invoke();
            LastDirection = _tempDirection;
        }
    }

    protected abstract Vector2 Move(); // вот это отвечает за движение.
                                       // Это - общий метод.
    protected virtual void AwakeWork() {}
}
