public class Fancy
{
    public Fancy()
    {
        values = new List<int>();
        instructions = new List<Instruction>();
    }

    public void Append(int val)
    {
        values.Add(val);
    }

    public void AddAll(int inc)
    {
        Instruction instruction = new Instruction(Operation.Add, inc);
        instructions.Add(instruction);
    }

    public void MultAll(int m)
    {
        Instruction instruction = new Instruction(Operation.Multiply, m);
        instructions.Add(instruction);
    }

    public int GetIndex(int idx)
    {
        if (idx > values.Count - 1)
        {
            return -1;
        }

        int product = values.ElementAt(idx);

        instructions.ForEach(i =>
        {
            switch (i.operation)
            {
                case Operation.Add:
                    product += i.value;
                    break;
                case Operation.Multiply:
                    product *= i.value;
                    break;
            }
        });

        return product;
    }

    private List<int> values;
    private List<Instruction> instructions;
}

public enum Operation
{
    Multiply,
    Add
}

public readonly struct Instruction
{
    public Instruction(Operation op, int val)
    {
        operation = op;
        value = val;
    }

    public readonly Operation operation;
    public readonly int value;
}