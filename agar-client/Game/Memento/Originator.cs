using System;

public class Originator
{
    private string state;

	public Originator()
	{
	}

    public Memento CreateMemento()
    {
        return new Memento(this.state);
    }

    public void SetMemento(Memento memento)
    {
        this.state = memento.GetState();
    }

    public void SetState(string st)
    {
        this.state = st;
    }

    public string GetState()
    {
        return this.state;
    }
}
