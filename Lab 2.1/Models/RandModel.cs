namespace lab_2._1.Models
{
    public class RandModel
    {
        public int firstval;
        public int secondval;

        public RandModel ()
        {   
            Random random = new Random ();
            firstval = random.Next() % 11;
            secondval = random.Next() % 11;
        }

        public string Add() 
        {
            return Convert.ToString(firstval + secondval);
        }
        public string Sub()
        {
            return Convert.ToString(firstval - secondval);
        }
        public string Mult() 
        {
            return Convert.ToString(firstval * secondval);
        }
        public string Div() 
        {
            return Convert.ToBoolean(secondval) ? Convert.ToString(firstval / secondval) : "Error!";
        }

    }
}
