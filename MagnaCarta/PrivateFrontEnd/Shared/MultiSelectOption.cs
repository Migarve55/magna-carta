namespace PrivateFrontEnd.Shared;

public class MultiSelectOption
{
    public MultiSelectOption(int value, string text)
    {
        Value = value;
        Text = text;
    }

    public int Value { get; }
    public string Text { get; }
}