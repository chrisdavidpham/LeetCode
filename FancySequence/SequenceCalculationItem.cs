public class SequenceCalculationItem
{
    public int startValue { get; private set; }
    private int _instructionStartIndex;
    private int _currentValue;

    public SequenceCalculationItem(int startValue, int instructionStartIndex)
    {
        this.startValue = startValue;
        _instructionStartIndex = instructionStartIndex;
        _currentValue = startValue;
    }

    public int GetModProductSum(List<Instruction> instructions)
    {
        var modProductSum = _currentValue;

        for (int i = _instructionStartIndex; i < instructions.Count; i++)
        {
            switch (instructions[i].operation)
            {
                case Operation.Add:
                    long longSum = (long) modProductSum + instructions[i].operand;
                    modProductSum = (int) (longSum % (1000000000 + 7));
                    break;
                case Operation.Multiply:
                    long longProduct = (long) modProductSum * instructions[i].operand;
                    modProductSum = (int) (longProduct % (1000000000 + 7));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        // Remember the current modProductSum to avoid redundant calculations next time GetModSumProduct is invoked
        _currentValue = modProductSum;
        _instructionStartIndex = instructions.Count;

        return modProductSum;
    }
}