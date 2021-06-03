using UnityEngine;

[System.Serializable]
public class Ellipse
{
    [SerializeField] private float xAxis;
    [SerializeField] private float yAxis;

    private float _angle;
    private float _x;
    private float _y;

    public Ellipse(float xAxis, float yAxis)
    {
        this.xAxis = xAxis;
        this.yAxis = yAxis;
    }

    public Vector2 Evaluate(float t)
    {
        _angle = Mathf.Deg2Rad * 360f * t;
        _x = Mathf.Sin(_angle) * xAxis;
        _y = Mathf.Cos(_angle) * yAxis;

        return new Vector2(_x, _y);
    }
}