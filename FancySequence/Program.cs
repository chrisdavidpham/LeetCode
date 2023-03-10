using System.Diagnostics;

string[] inputInstructions = new string[] { "append", "getIndex", "multAll", "multAll", "getIndex", "addAll", "append", "append", "getIndex", "append", "append", "addAll", "getIndex", "multAll", "addAll", "append", "addAll", "getIndex", "getIndex", "multAll", "multAll", "multAll", "append", "addAll", "getIndex", "getIndex", "getIndex", "append", "getIndex", "addAll", "multAll", "append", "multAll", "addAll", "getIndex", "append", "append", "addAll", "getIndex", "multAll", "getIndex", "addAll", "getIndex", "multAll", "addAll", "getIndex", "addAll", "append", "append", "append", "multAll", "multAll", "append", "multAll", "addAll", "getIndex", "addAll", "multAll", "multAll", "multAll", "append", "multAll", "append", "multAll", "addAll", "append", "append", "getIndex", "getIndex", "getIndex", "addAll", "multAll", "multAll", "append", "append", "getIndex", "append", "append", "append", "getIndex", "getIndex" };
int[] inputValues = new int[] { 5, 0, 14, 10, 0, 12, 10, 4, 2, 4, 2, 1, 1, 8, 11, 15, 12, 0, 3, 4, 11, 11, 10, 8, 2, 3, 0, 7, 3, 2, 6, 10, 6, 8, 7, 9, 9, 12, 0, 13, 7, 3, 4, 8, 14, 2, 9, 9, 9, 7, 5, 12, 9, 3, 8, 10, 14, 14, 14, 6, 1, 3, 11, 12, 6, 7, 13, 12, 5, 6, 1, 11, 11, 4, 9, 7, 11, 1, 3, 1, 0 };
Fancy fancy = new Fancy();

var sw = new Stopwatch();
sw.Start();

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

sw.Stop();

Console.WriteLine(fancy.PrintSequence());
Console.WriteLine(sw.Elapsed.ToString());

string[] inputInstructions2 = new string[] { "append", "addAll", "getIndex", "append", "getIndex", "append", "multAll", "getIndex", "getIndex", "multAll", "getIndex" };
int[] inputValues2 = new int[] { 7, 10, 0, 8, 0, 5, 8, 2, 0, 3, 2 };
Fancy fancy2 = new Fancy();

sw.Restart();

for (int i = 0; i < inputInstructions2.Length; i++)
{
    switch (inputInstructions2[i])
    {
        case "append":
            fancy2.Append(inputValues2[i]);
            break;
        case "addAll":
            fancy2.AddAll(inputValues2[i]);
            break;
        case "multAll":
            fancy2.MultAll(inputValues2[i]);
            break;
        case "getIndex":
            Console.WriteLine(fancy2.GetIndex(inputValues2[i]));
            break;
    }
}

sw.Stop();

Console.WriteLine(fancy2.PrintSequence());
Console.WriteLine(sw.Elapsed.ToString());