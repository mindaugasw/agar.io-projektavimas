using System;

public class Memento
{
    private string state;

    public Memento(string st)
	{
        this.state = st;
	}

    public string GetState()
    {
        return this.state;
    }

    public void SetState(string st)
    {
        this.state = st;
    }
}
