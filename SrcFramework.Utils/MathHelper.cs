
namespace SrcFramework.Utils
{
    public class MathHelper
    {
        public static int Factorial(int value)
        {
            if (value <= 1)
            {
                return 1;
            }
            return value * Factorial(value-1);
        }
    }
}
