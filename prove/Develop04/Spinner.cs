class Spinner
{
    private int _currentAnimationFrame;

    public Spinner()
    {
        SpinnerAnimationFrames = new[] { '/', '-', '\\', '|' };
    }

    public char[] SpinnerAnimationFrames { get; }

    public void Turn()
    {
        _currentAnimationFrame++;
    
        if (_currentAnimationFrame == SpinnerAnimationFrames.Length)
        {
            _currentAnimationFrame = 0;
        }
    
        Console.Write(SpinnerAnimationFrames[_currentAnimationFrame]);
        if (Console.CursorLeft > 0)
        {
            try
            {
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
            catch (ArgumentOutOfRangeException)
            {
                // Ignore the exception
            }
        }
    }
}