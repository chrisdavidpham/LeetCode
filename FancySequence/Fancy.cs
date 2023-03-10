public class Fancy : IFancy
{
    private List<SequenceCalculationItem> _sequence;
    private List<Instruction> _instructions;

    public Fancy()
    {
        _sequence = new List<SequenceCalculationItem>();
        _instructions = new List<Instruction>();
    }

    public string PrintSequence()
    {
        string sequence = String.Empty;

        for (int i = 0; i < _sequence.Count; i++)
        {
            long calculatedValue = GetIndex(i);
            sequence += $"{calculatedValue} ";
        }

        return sequence;
    }

    public void Append(int value)
    {
        // Add the value to the sequence and the index of future instructions
        _sequence.Add(new SequenceCalculationItem(value, _instructions.Count));
    }

    public void AddAll(int operand)
    {
        _instructions.Add(new Instruction(Operation.Add, operand));
    }

    public void MultAll(int operand)
    {
        _instructions.Add(new Instruction(Operation.Multiply, operand));
    }

    public long GetIndex(int index)
    {
        return index >= _sequence.Count
            ? -1 
            : _sequence[index].GetModProductSum(_instructions);
    }
}