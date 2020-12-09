using System;
using System.Collections.Generic;
using agar_server.Hubs;

public class ConcreteMediator: Mediator
{

    List<Colleague> list = new List<Colleague>();
	

    public void addUser(Colleague user)
    {
        list.Add(user);
    }

    public void broadcastMessage(Colleague sender, String msg, GameHub hub)
    {
        foreach (Colleague receiver in list)
        {
            receiver.receiveMessage(msg, hub, sender);
        }
    }
}
