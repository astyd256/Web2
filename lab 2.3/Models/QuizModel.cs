namespace lab_2._3.Models
{
    public class QuizModel
    {
        public int[] numberOne { get; set; }
        public int[] numberTwo { get; set; }
        public string[] operand { get; set; }
        public int[] correctAnswers { get; set; }
        public int correctAnswersAmount { get; set; }
        public int[] userAnswers { get; set; }
        public int currentQuestion { get; set; }
        public int answersAmount { get {return 4; }}
        public QuizModel()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            numberOne = new int[answersAmount];
            numberTwo = new int[answersAmount];
            operand = new string[answersAmount];
            correctAnswers = new int[answersAmount];
            userAnswers = new int[answersAmount];
            correctAnswersAmount = 0;
            currentQuestion = 0;

            for (int i = 0; i < answersAmount; i++)
            {
                numberOne[i] = rand.Next(1, 100);
                numberTwo[i] = rand.Next(1, 100);

                switch (rand.Next(1, 5))
                {
                    case 1: 
                    correctAnswers[i] = numberOne[i] + numberTwo[i]; 
                    operand[i] = "+";
                    break;
                    case 2: 
                    correctAnswers[i] = numberOne[i] - numberTwo[i]; 
                    operand[i] = "-";
                    break;
                    case 3: 
                    correctAnswers[i] = numberOne[i] * numberTwo[i]; 
                    operand[i] = "*";
                    break;
                    case 4: 
                    correctAnswers[i] = numberOne[i] / numberTwo[i]; 
                    operand[i] = "/";
                    break;
                }
                userAnswers[i] = 0;
            }
        }
        public void CheckAnswer(int answer)
        {
            if (answer == correctAnswers[currentQuestion]) correctAnswersAmount++;
            userAnswers[currentQuestion] = answer;
        }
        public void GetNextQuestion()
        {
            currentQuestion++;
        }
    }
}
