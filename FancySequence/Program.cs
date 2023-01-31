Fancy fancy = new Fancy();
fancy.Append(2);   // fancy sequence: [2]
fancy.AddAll(3);   // fancy sequence: [2+3] -> [5]
fancy.Append(7);   // fancy sequence: [5, 7]
fancy.MultAll(2);  // fancy sequence: [5*2, 7*2] -> [10, 14]
fancy.AddAll(3);   // fancy sequence: [10+3, 14+3] -> [13, 17]
fancy.Append(10);  // fancy sequence: [13, 17, 10]
fancy.MultAll(2);  // fancy sequence: [13*2, 17*2, 10*2] -> [26, 34, 20]
Console.WriteLine(fancy.PrintSequence());
Console.WriteLine("done");

string[] inputInstructions = new string[] { "append", "append", "getIndex", "append", "getIndex", "addAll", "append", "getIndex", "getIndex", "append", "append", "getIndex", "append", "getIndex", "append", "getIndex", "append", "getIndex", "multAll", "addAll", "getIndex", "append", "addAll", "getIndex", "multAll", "getIndex", "multAll", "addAll", "addAll", "append", "multAll", "append", "append", "append", "multAll", "getIndex", "multAll", "multAll", "multAll", "getIndex", "addAll", "append", "multAll", "addAll", "addAll", "multAll", "addAll", "addAll", "append", "append", "getIndex" };
int[] inputValues = new int[] { 12, 8, 1, 12, 0, 12, 8, 2, 2, 4, 13, 4, 12, 6, 11, 1, 10, 2, 3, 1, 6, 14, 5, 6, 12, 3, 12, 15, 6, 7, 8, 13, 15, 15, 10, 9, 12, 12, 9, 9, 9, 9, 4, 8, 11, 15, 9, 1, 4, 10, 9 };
Fancy fancy2 = new Fancy();

for (int i = 0; i < inputInstructions.Length; i++)
{
    switch (inputInstructions[i])
    {
        case "append":
            fancy2.Append(inputValues[i]);
            break;
        case "addAll":
            fancy2.AddAll(inputValues[i]);
            break;
        case "multAll":
            fancy2.MultAll(inputValues[i]);
            break;
        case "getIndex":
            fancy2.GetIndex(inputValues[i]);
            break;
    }
}
Console.WriteLine(fancy2.PrintSequence());

public interface IFancy
{
    public void Append(int val);
    public void AddAll(int inc);
    public void MultAll(int m);
    public long GetIndex(int idx);
}

public class Fancy: IFancy
{
    private List<int> _sequence;
    private List<Instruction> _instructions;

    public Fancy()
    {
        _sequence = new List<int>();
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
        _sequence.Add(value);
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

        long productAndSum = _sequence.ElementAt(index);

        for (int i = 0; i < _instructions.Count; i++)
        {
            Instruction instruction = _instructions[i];
            if (!instruction.isApplicable(index))
            {
                continue;
            }

            switch (instruction.operation)
            {
                case Operation.Add:
                    productAndSum += instruction.operand;
                    break;
                case Operation.Multiply:
                    productAndSum *= instruction.operand;
                    break;
            }
        };

        return productAndSum;
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