using agar_server.Hubs;
using System;

public class ChatUser: Colleague
{
    public ChatUser(Mediator mediator, String newName) : base(mediator, newName)
    {
    }

    public override void sendMessage(String msg, GameHub hub)
    {
        this.m.broadcastMessage(this, msg, hub);
    }

    public override void receiveMessage(String msg, GameHub hub, Colleague sender)
    {
        Console.WriteLine(name + " received: " + msg);
        object[] args = { sender.name, msg };
        hub.Clients.Others.SendCoreAsync("ReceiveChatMessage", args );
        hub.Clients.Caller.SendCoreAsync("ReceiveChatMessage", args);
    }
}
