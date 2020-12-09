using System;
using agar_server.Hubs;

public abstract class Colleague
{

    protected Mediator m;
    public String name;

    public Colleague(Mediator mediator, String newName)
    {
        m = mediator;
        name = newName;
    }

    public abstract void sendMessage(String msg, GameHub hub);

    public abstract void receiveMessage(String msg, GameHub hub, Colleague sender);

}
