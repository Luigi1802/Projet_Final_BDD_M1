using GamesAPI.Exceptions;

namespace GamesAPI;

public class Mastermind
{
    public enum GameResult
    {
        Won = 0,
        Lost = 1,
    }

    private readonly List<string> _secretCombination;
    private int _remainingAttempts;
    private GameResult? _gameResult;
    private readonly List<string> _validColors = new List<string> 
    { 
        "Red", "Green", "Blue", "White", "Pink", "Purple", "Orange", "Yellow" 
    };

    public Mastermind()
    {
        _remainingAttempts = 10;
        _secretCombination = GenerateRandomCombination();
        _gameResult = null;
    }

    public Mastermind(int numberOfAttempts)
    {
        if (numberOfAttempts <= 0)
        {
            throw new InvalidAttemptsNumberException("Number of attempts must be greater than 0");
        }
        
        _remainingAttempts = numberOfAttempts;
        _secretCombination = GenerateRandomCombination();
        _gameResult = null;
    }

    public Mastermind(int numberOfAttempts, List<string> customCombination)
    {
        if (numberOfAttempts <= 0)
        {
            throw new InvalidAttemptsNumberException("Number of attempts must be greater than 0");
        }

        ValidateCombination(customCombination);
        
        _remainingAttempts = numberOfAttempts;
        _secretCombination = new List<string>(customCombination);
        _gameResult = null;
    }

    public int GetRemainingAttemptsNumber()
    {
        return _remainingAttempts;
    }

    public GameResult? GetGameResult()
    {
        return _gameResult;
    }

    public List<int> AddGuess(List<string> combination)
    {
        // Vérifier si le jeu est en cours
        if (_gameResult.HasValue)
        {
            throw new GameNotInProgressException("Game is not in progress");
        }

        // Valider la combinaison du joueur
        ValidateCombination(combination);

        // Calculer les indicateurs rouge et blanc
        var indicators = CalculateIndicators(combination);

        // Vérifier si le joueur a gagné
        if (indicators[0] == 4) // 4 indicateurs rouges = victoire
        {
            _gameResult = GameResult.Won;
            _remainingAttempts = 0;
        }
        else
        {
            _remainingAttempts--;
            
            // Vérifier si le joueur a perdu (plus d'essais)
            if (_remainingAttempts == 0)
            {
                _gameResult = GameResult.Lost;
            }
        }

        return indicators;
    }

    private void ValidateCombination(List<string> combination)
    {
        // Vérifier la longueur (doit être exactement 4)
        if (combination.Count != 4)
        {
            throw new InvalidCombinationException("Combination must have exactly 4 colors");
        }

        // Vérifier qu'il n'y a pas de doublons
        if (combination.Count != combination.Distinct().Count())
        {
            throw new InvalidCombinationException("Combination cannot have duplicate colors");
        }

        // Vérifier que toutes les couleurs sont valides
        foreach (var color in combination)
        {
            if (!_validColors.Contains(color))
            {
                throw new InvalidCombinationException($"Invalid color: {color}");
            }
        }
    }

    private List<int> CalculateIndicators(List<string> guess)
    {
        int redIndicators = 0;
        int whiteIndicators = 0;

        var secretCopy = new List<string>(_secretCombination);
        var guessCopy = new List<string>(guess);

        // Calculer les indicateurs rouges (bonne couleur, bonne position)
        for (int i = 0; i < 4; i++)
        {
            if (guessCopy[i] == secretCopy[i])
            {
                redIndicators++;
                secretCopy[i] = null; // Marquer comme utilisé
                guessCopy[i] = null;  // Marquer comme utilisé
            }
        }

        // Calculer les indicateurs blancs (bonne couleur, mauvaise position)
        for (int i = 0; i < 4; i++)
        {
            if (guessCopy[i] != null)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (secretCopy[j] != null && guessCopy[i] == secretCopy[j])
                    {
                        whiteIndicators++;
                        secretCopy[j] = null; // Marquer comme utilisé
                        break;
                    }
                }
            }
        }

        return new List<int> { redIndicators, whiteIndicators };
    }

    private List<string> GenerateRandomCombination()
    {
        var random = new Random();
        var combination = new List<string>();
        var availableColors = new List<string>(_validColors);

        for (int i = 0; i < 4; i++)
        {
            var index = random.Next(availableColors.Count);
            combination.Add(availableColors[index]);
            availableColors.RemoveAt(index); // Éviter les doublons
        }

        return combination;
    }
}