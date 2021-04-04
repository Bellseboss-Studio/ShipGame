namespace View.BulletFactory
{
    public interface IBullet
    {
        float GetDamage();
        void AddDamage(float increment);
    }
}