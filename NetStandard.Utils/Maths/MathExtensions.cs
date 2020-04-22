namespace NetStandard.Utils.Maths
{
    public static class MathExtensions
    {
        public static int Factorial(this int i){
            if (i<=0) return 0;
            if (i==1) return 1;
            return i
                   * (--i).Factorial();
        }
    }
}