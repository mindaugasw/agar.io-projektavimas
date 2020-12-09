using System;
using agar_server.Hubs;

public interface Mediator
{
    public void addUser(Colleague user);
    public void broadcastMessage(Colleague sender, String msg, GameHub hub);
}
