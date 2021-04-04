namespace Player
{
    public class Engine : IEngine
    {
        public float Speed { get; private set; }

        public Engine(float speed)
        {
            Speed = speed;
        }

        public float Move(float vertical)
        {
            return vertical * Speed;
        }
    }
}