namespace Player
{
    public class SampleWeapon : IWeapon
    {
        public string GetBulletId()
        {
            return "GenericBullet";
        }

        public float GetDamage()
        {
            return 2;
        }
    }
}