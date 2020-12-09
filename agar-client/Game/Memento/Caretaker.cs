using System;
using System.Collections.Generic;

public class Caretaker
{
    private List<Memento> mementoList;

	public Caretaker()
	{
        mementoList = new List<Memento>();
        mementoList.Insert(0, new Memento(""));
    }

    public void add(int idx, Memento memento)
    {
        mementoList.Insert(idx, memento);
    }

    public Memento get(int index)
    {
        return mementoList[index];
    }
}
