using JFramework;

public class AttributeControl : Controller<Role>
{
    public int Hp { get; private set; }

    public int Mp { get; private set; }

    public float Speed { get; private set; }

    public float Acceleration { get; private set; }

    public float Deceleration { get; private set; }


    protected override void Start()
    {
        Hp = 100;

        Mp = 100;
        
        Speed = 10;

        Acceleration = 2;

        Deceleration = 2;
    }
    
    
    
    
}