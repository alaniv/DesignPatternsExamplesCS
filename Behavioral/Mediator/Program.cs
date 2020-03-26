using System;
using System.Collections.Generic;

namespace Mediator
{
    public class ChatRoom
    {
        private Dictionary<String, User> usersMap = new Dictionary<String, User>();
        public void sendMessage(String msg, String userId)
        {
            User u = usersMap.GetValueOrDefault(userId);
            u.receive(msg);
        }
        public void addUser(User user)
        {
            usersMap.Add(user.getId(), user);
        }
    }

    public class User
    {
        private ChatRoom mediator;

        private String id;
        private String name;

        public User(ChatRoom room, String id, String name)
        {
            this.mediator = room;
            this.name = name;
            this.id = id;
        }

        public void send(String msg, String userId)
        {
            Console.WriteLine(this.getName() + " :: Sending Message : " + msg);
            this.getMediator().sendMessage(msg, userId);
        }
        public void receive(String msg)
        {
            Console.WriteLine(this.getName() + " :: Received Message : " + msg);
        }
        public ChatRoom getMediator() => this.mediator;
        public String getId() => this.id;
        public String getName() => this.name;
    }
    class Program
    {
        static void Main(string[] args)
        {
            ChatRoom chatroom = new ChatRoom();

            User user1 = new User(chatroom, "1", "Alex");
            User user2 = new User(chatroom, "2", "Brian");
            User user3 = new User(chatroom, "3", "Charles");
            User user4 = new User(chatroom, "4", "David");

            chatroom.addUser(user1);
            chatroom.addUser(user2);
            chatroom.addUser(user3);
            chatroom.addUser(user4);

            user1.send("Hello brian", "2");
            user2.send("Hey buddy", "1");
        }
    }
}
