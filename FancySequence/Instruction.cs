public readonly struct Instruction
{
    public readonly Operation operation;
    public readonly int operand;

    public Instruction(Operation op, int val)
    {
        operation = op;
        operand = val;
    }
}