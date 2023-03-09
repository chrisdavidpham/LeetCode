string[] inputInstructions = new string[] { "append", "getIndex", "multAll", "multAll", "getIndex", "addAll", "append", "append", "getIndex", "append", "append", "addAll", "getIndex", "multAll", "addAll", "append", "addAll", "getIndex", "getIndex", "multAll", "multAll", "multAll", "append", "addAll", "getIndex", "getIndex", "getIndex", "append", "getIndex", "addAll", "multAll", "append", "multAll", "addAll", "getIndex", "append", "append", "addAll", "getIndex", "multAll", "getIndex", "addAll", "getIndex", "multAll", "addAll", "getIndex", "addAll", "append", "append", "append", "multAll", "multAll", "append", "multAll", "addAll", "getIndex", "addAll", "multAll", "multAll", "multAll", "append", "multAll", "append", "multAll", "addAll", "append", "append", "getIndex", "getIndex", "getIndex", "addAll", "multAll", "multAll", "append", "append", "getIndex", "append", "append", "append", "getIndex", "getIndex" };
int[] inputValues = new int[] { 5, 0, 14, 10, 0, 12, 10, 4, 2, 4, 2, 1, 1, 8, 11, 15, 12, 0, 3, 4, 11, 11, 10, 8, 2, 3, 0, 7, 3, 2, 6, 10, 6, 8, 7, 9, 9, 12, 0, 13, 7, 3, 4, 8, 14, 2, 9, 9, 9, 7, 5, 12, 9, 3, 8, 10, 14, 14, 14, 6, 1, 3, 11, 12, 6, 7, 13, 12, 5, 6, 1, 11, 11, 4, 9, 7, 11, 1, 3, 1, 0 };
Fancy fancy = new Fancy();

for (int i = 0; i < inputInstructions.Length; i++)
{
    switch (inputInstructions[i])
    {
        case "append":
            fancy.Append(inputValues[i]);
            break;
        case "addAll":
            fancy.AddAll(inputValues[i]);
            break;
        case "multAll":
            fancy.MultAll(inputValues[i]);
            break;
        case "getIndex":
            fancy.GetIndex(inputValues[i]);
            break;
    }
}
Console.WriteLine(fancy.PrintSequence());

public interface IFancy
{
    public void Append(int val);
    public void AddAll(int inc);
    public void MultAll(int m);
    public long GetIndex(int idx);
}

public class Fancy : IFancy
{
    private List<List<int>> _sequence;
    private List<Instruction> _instructions;

    public Fancy()
    {
        _sequence = new List<List<int>>();
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
        _sequence.Add(new List<int> { value });
    }

    public void AddAll(int operand)
    {
        Instruction instruction = new Instruction(Operation.Add, operand, _sequence.Count - 1);
        _instructions.Add(instruction);
    }

    public void MultAll(int operand)
    {
        Instruction instruction = new Instruction(Operation.Multiply, operand, _sequence.Count - 1);
        _instructions.Add(instruction);
    }

    public long GetIndex(int index)
    {
        if (index > _sequence.Count - 1)
        {
            return -1;
        }

        List<int> modProductSumValues = _sequence[index];
        // First number in sequence has no instructions calculated
        int lastCalculatedIndex = modProductSumValues.Count - 1;

        long modProductSumValue = modProductSumValues[lastCalculatedIndex];

        for (int i = lastCalculatedIndex; i < _instructions.Count; i++)
        {
            Instruction instruction = _instructions[i];
            if (!instruction.isApplicable(index))
            {
                continue;
            }

            switch (instruction.operation)
            {
                case Operation.Add:
                    modProductSumValue = (modProductSumValue + instruction.operand) % (1000000000 + 7);
                    break;
                case Operation.Multiply:
                    modProductSumValue = (modProductSumValue * instruction.operand) % (1000000000 + 7);
                    break;
            }

            modProductSumValues.Add((int) modProductSumValue);
        };

        return modProductSumValue;
    }
}

public enum Operation
{
    Multiply,
    Add
}

public readonly struct Instruction
{
    private readonly int _maxApplicableIndex;
    public readonly Operation operation;
    public readonly int operand;

    public Instruction(Operation op, int val, int maxApplicableIndex)
    {
        _maxApplicableIndex = maxApplicableIndex;
        operation = op;
        operand = val;
    }

    public bool isApplicable(int index)
    {
        return index <= _maxApplicableIndex;
    }
}