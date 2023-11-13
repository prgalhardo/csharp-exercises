public class GuessNumber
{
    //In this way we are passing the random number generator by dependency injection
    private IRandomGenerator random;
    public GuessNumber() : this(new DefaultRandom()){}
    public GuessNumber(IRandomGenerator obj)
    {
        this.random = obj;

        userValue = 0;
        randomValue = 0;
    }

    //user variables
    public int userValue;
    public int randomValue;

    public int maxAttempts = 5;
    public int currentAttempts = 0;

    public int difficultyLevel = 1;

    public int minNumber;
    public int maxNumber;

    public bool gameOver;

    //1 - Imprima uma mensagem de saudação
    public string Greet()
    {
        string message = "---Bem-vindo ao Guessing Game--- /n Para começar, tente adivinhar o número que eu pensei, entre -100 e 100!";
        return message;
    }

    //2 - Receba a entrada da pessoa usuária e converta para Int
    //5 - Adicione um limite de tentativas
    public string ChooseNumber(string userEntry)
    {
        currentAttempts++;

        if (currentAttempts > maxAttempts) {
            gameOver = true;
            return "Você excedeu o número máximo de tentativas! Tente novamente.";
        }
        
        bool canConvert = Int32.TryParse(userEntry, out userValue);

        if (canConvert != true) {
            return "Entrada inválida! Não é um número.";
        }
        if (userValue > 100 || userValue < -100) {
            userValue = 0;
            return "Entrada inválida! Valor não está no range.";
        }
        else {
            return "Número escolhido!";
        }
    }

    //3 - Gere um número aleatório
    public string RandomNumber()
    {
        randomValue = random.GetInt(-100, 100);
        return "A máquina escolheu um número de -100 à 100!";
    }

    //6 - Adicione níveis de dificuldade
    public string RandomNumberWithDifficult()
    {
        switch (difficultyLevel)
        {
            case 2: 
            minNumber = -500;
            maxNumber = 500;
            break;
            case 3:
            minNumber = -1000;
            maxNumber = 1000;
            break;
            default:
            minNumber = -100;
            maxNumber = 100;
            break;
        }

        randomValue = random.GetInt(minNumber, maxNumber);
        return $"A máquina escolheu um número de {minNumber} à {maxNumber}!";
    }

    //4 - Verifique a resposta da jogada
    public string AnalyzePlay()
    {
        if (userValue < randomValue) {
            return "Tente um número MAIOR";
        }
        if (userValue > randomValue) {
            return "Tente um número MENOR";
        }
        else {
            gameOver = true;
            return "ACERTOU!";
        } 
    }

    //7 - Adicione uma opção para reiniciar o jogo
    public void RestartGame()
    {
        userValue = 0;
        randomValue = 0;
        maxAttempts = 5;
        currentAttempts = 0;
        difficultyLevel = 1;
        gameOver = false;

    }
}