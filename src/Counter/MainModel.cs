namespace Counter;

internal partial record Countable(int Count, int Step)
{
    public Countable Increment() => this with { Count = Count + Step };
}

internal partial record MainModel
{
    public IState<Countable> Countable => State.Value(this, () => new Countable(Count: 0, Step: 1));
    public ValueTask IncrementCounter() => Countable.UpdateAsync(c => c?.Increment());
}
