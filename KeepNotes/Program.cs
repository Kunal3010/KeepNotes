using System.Runtime.CompilerServices;

namespace KeepNotes
{
    class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }

    class Management
    {
        List<Note> notes;
        public Management()
        {
            notes = new List<Note>()
            {
                new Note { Id = 1, Title = "Meeting", Description = "Meeting with Client", Date = DateTime.Now},
            };
        }


        public void AddNote(Note note)
        {
            notes.Add(note);
        }

        public int GenerateId()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1, 9999);
            return randomNumber;
        }

        public Note GetNote(int id)
        {
            foreach (Note n in notes)
            {
                if (n.Id == id)
                    return n;
            }
            return null;
        }

        public bool UpdateNote(int id)
        {
            foreach (Note n in notes)
            {
                if (n.Id == id)
                {
                    Console.WriteLine("Enter Title");
                    n.Title = Console.ReadLine();
                    Console.WriteLine("Enter Description");
                    n.Description = Console.ReadLine();
                    n.Date = DateTime.Now;
                    return true;
                }

            }
            return false;
        }

        public List<Note> GetNotes()
        {
            return notes;
        }

        public bool DeleteNote(int id)
        {
            foreach (Note n in notes)
            {
                if (n.Id == id)
                {
                    notes.Remove(n);
                    return true;
                }
            }
            return false;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Management obj = new Management();
            string ans = "";
            try
            {
                do
                {
                    Console.WriteLine("Welcome to Keep Note App");
                    Console.WriteLine("1. Create Note");
                    Console.WriteLine("2. View Notes");
                    Console.WriteLine("3. View All Notes");
                    Console.WriteLine("4. Update Note");
                    Console.WriteLine("5. Delete Note");
                    int choice = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter Title");
                                string title = Console.ReadLine();
                                Console.WriteLine("Enter Description");
                                string description = Console.ReadLine();
                                int id = obj.GenerateId();
                                Console.WriteLine($"Your Id: {id}");
                                DateTime date = DateTime.Now;
                                Console.WriteLine($"Date: {date}");
                                obj.AddNote(new Note() { Id = id, Title = title, Description = description, Date = date });
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Enter Id");
                                int id = Convert.ToInt16(Console.ReadLine());
                                Note? c = obj.GetNote(id);
                                if (c == null)
                                {
                                    Console.WriteLine("Notes with specified id does not exists");
                                }
                                else
                                {
                                    Console.WriteLine("id \t\t title \t\t description \t\t\t date");
                                    Console.WriteLine($"{c.Id} \t\t {c.Title} \t\t {c.Description} \t\t {c.Date}");
                                }
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("id \t\t title \t\t description \t\t\t date");
                                int count = 0;
                                foreach (var c in obj.GetNotes())
                                {
                                    Console.WriteLine($"{c.Id} \t\t {c.Title} \t\t {c.Description} \t\t {c.Date}");
                                    ++count;
                                }
                                Console.WriteLine($"Total Notes: {count}");
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Enter Id");
                                int id = Convert.ToInt16(Console.ReadLine());
                                if (obj.UpdateNote(id))
                                {
                                    Console.WriteLine("Notes Updated Successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Note with specified id does not exist");
                                }
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Enter ID");
                                int id = Convert.ToInt16(Console.ReadLine());
                                if (obj.DeleteNote(id))
                                {
                                    Console.WriteLine("Note Deleted Successfully!!");
                                }
                                else
                                {
                                    Console.WriteLine("Note with specified id does not exist");
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid choice!!!!");
                                break;
                            }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Do you wish to continue? [y/n] ");
                    ans = Console.ReadLine();
                    Console.WriteLine();
                    
                } while (ans.ToLower() == "y");
            }
            catch (FormatException)
            {
                Console.WriteLine("Only Number are allowed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            finally 
            {
                Console.WriteLine("Program Ends"); 
            }
        }
        }
    }
