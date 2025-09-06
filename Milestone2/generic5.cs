using System;
using System.Collections.Generic;

namespace Milestone2
{
    class ServiceToken
    {
        private static int nextId = 1;

        public int TokenID { get; private set; }
        public int Position { get; private set; }
        public DateTime TicketDateTime { get; private set; }
        public string Status { get; set; }

        public ServiceToken(int position)
        {
            TokenID = nextId++;
            Position = position;
            TicketDateTime = DateTime.Now;
            Status = "Pending";
        }

        public override string ToString()
        {
            return $"TokenID: {TokenID}, Position: {Position}, DateTime: {TicketDateTime}, Status: {Status}";
        }
    }

    class TicketManager
    {
        public Queue<ServiceToken> Queue { get; private set; } = new Queue<ServiceToken>();
        private List<ServiceToken> allTokens = new List<ServiceToken>();
        private int positionCounter = 1;

        public void GenerateServiceToken()
        {
            ServiceToken token = new ServiceToken(positionCounter++);
            Queue.Enqueue(token);
            allTokens.Add(token);
            Console.WriteLine("Token Created: " + token.TokenID);
        }

        public void GetNextToken()
        {
            if (Queue.Count > 0)
            {
                var token = Queue.Peek();
                Console.WriteLine("Next Token: " + token.TokenID);
            }
            else
            {
                Console.WriteLine("No tokens in queue.");
            }
        }

        public void UpdateToken(int tokenId)
        {
            ServiceToken token = allTokens.Find(t => t.TokenID == tokenId);
            if (token != null)
            {
                token.Status = "Completed";
                Console.WriteLine("Token Updated to Completed.");
                if (Queue.Count > 0 && Queue.Peek().TokenID == tokenId)
                {
                    Queue.Dequeue();
                }
            }
            else
            {
                Console.WriteLine("Token not found.");
            }
        }

        public void SkipToken()
        {
            if (Queue.Count > 1)
            {
                var skipped = Queue.Dequeue();
                Queue.Enqueue(skipped); // Put skipped token at end
                Console.WriteLine("Skipped Token: " + skipped.TokenID);
                Console.WriteLine("Next Token: " + Queue.Peek().TokenID);
            }
            else if (Queue.Count == 1)
            {
                Console.WriteLine("Only one token in queue. Can't skip.");
            }
            else
            {
                Console.WriteLine("No tokens to skip.");
            }
        }

        public void ListAllTokens()
        {
            foreach (var token in allTokens)
            {
                Console.WriteLine(token);
            }
        }
    }

    class generic5
    {
        static void Main()
        {
            TicketManager manager = new TicketManager();
            int choice;

            do
            {
                Console.WriteLine("\n*********** TOKEN MANAGEMENT SYSTEM ***********");
                Console.WriteLine("1. Create Token");
                Console.WriteLine("2. Get Next Token");
                Console.WriteLine("3. Update Token");
                Console.WriteLine("4. Skip Token");
                Console.WriteLine("5. List all tokens");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your Choice: ");
                bool isValid = int.TryParse(Console.ReadLine(), out choice);

                if (!isValid)
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        manager.GenerateServiceToken();
                        break;
                    case 2:
                        manager.GetNextToken();
                        break;
                    case 3:
                        Console.Write("Enter Token ID to update: ");
                        int id;
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            manager.UpdateToken(id);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case 4:
                        manager.SkipToken();
                        break;
                    case 5:
                        manager.ListAllTokens();
                        break;
                    case 6:
                        Console.WriteLine("Exiting application...");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }

            } while (choice != 6);
        }
    }
}
