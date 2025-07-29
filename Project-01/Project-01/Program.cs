using System.ComponentModel;

namespace Project_01
{
    public class PatientVisit
    {
        public string name { get; set; }
        public string visitDate { get; set; }
        public string visitType { get; set; }
        public string description { get; set; }
        public string doctorName { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PatientVisit> visits = new List<PatientVisit>
            {
                new PatientVisit { name = "Najeed", visitDate = "2025-07-20", visitType = "Consultation", description="Acidity due to unhealthy diet.", doctorName="Kashif" },
                new PatientVisit { name = "Shahmeer", visitDate = "2025-07-21", visitType = "Emergency" , description="Change in weather prompted flu. Medicine prescribed", doctorName="Anam"},
                new PatientVisit { name = "Bukhari", visitDate = "2025-07-22", visitType = "Follow-up" , description="Excessive screen time led to migrane", doctorName="Kashif"}
            };

            bool running = true;
            while (running == true)
            {
                Console.WriteLine("1. Add Visit");
                Console.WriteLine("2. Search Visit");
                Console.WriteLine("3. Update Visit");
                Console.WriteLine("4. Delete Visit");
                Console.WriteLine("5. Display all data (Categorized by visit type)");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option (1–6): ");
                string choice = Console.ReadLine();
                bool found = false;
                switch (choice)
                {
                    case "1":
                        PatientVisit newVisit = new PatientVisit();
                        Console.Write("Enter patient name: ");
                        newVisit.name = Console.ReadLine();
                        Console.Write("Enter visit date(format: YYYY-MM-DD): ");
                        newVisit.visitDate = Console.ReadLine();
                        Console.Write("Enter Visit Type(Consultation, Follow-up, Emergency): ");
                        newVisit.visitType = Console.ReadLine();
                        Console.Write("Enter Description: ");
                        newVisit.description = Console.ReadLine();
                        Console.Write("Enter Doctor's name:Dr. ");
                        newVisit.doctorName = Console.ReadLine();
                        visits.Add(newVisit);
                        Console.WriteLine("Visit added.");
                        break;

                    case "2":
                        Console.WriteLine("Search by: ");
                        Console.WriteLine("1 Patient Name ");
                        Console.WriteLine("2. Doctor Name");
                        Console.WriteLine("3. Date");
                        Console.WriteLine("4. Visit Type");
                        Console.Write("Enter search choice(1-4): ");
                        string searchChoice = Console.ReadLine();
                        switch (searchChoice)
                        {
                            case "1":
                                Console.Write("Enter patient name to search: ");
                                string searchName = Console.ReadLine();
                                Console.WriteLine("---------------------");
                                foreach (var visit in visits)
                                {
                                    if (visit.name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                                    {
                                        Console.WriteLine("Name: " + visit.name + "\nDate: " + visit.visitDate + "\nVisit Type: " +
                                            visit.visitType + "\nDoctor's Notes/Description:" + visit.description + "\nDoctor Name:Dr. " + visit.doctorName);
                                        Console.WriteLine("---------------------");
                                        found = true;
                                    }
                                }
                                if (!found)
                                    Console.WriteLine("No visit found.");
                                Console.WriteLine("---------------------");
                                break;
                            case "2":
                                Console.Write("Enter Doctor's name to search: ");
                                string searchNameDoctor = Console.ReadLine();
                                Console.WriteLine("---------------------");
                                foreach (var visit in visits)
                                {
                                    if (visit.doctorName.Equals(searchNameDoctor, StringComparison.OrdinalIgnoreCase))
                                    {
                                        Console.WriteLine("Name: " + visit.name + "\nDate: " + visit.visitDate + "\nVisit Type: " +
                                            visit.visitType + "\nDoctor's Notes/Description:" + visit.description + "\nDoctor Name:Dr. " + visit.doctorName);
                                        Console.WriteLine("---------------------");
                                        found = true;
                                    }
                                }
                                if (!found)
                                    Console.WriteLine("No visit found.");
                                Console.WriteLine("---------------------");
                                break;
                            case "3":
                                Console.Write("Enter date to search (format: YYYY-MM-DD): ");
                                string searchDate = Console.ReadLine();
                                Console.WriteLine("---------------------");
                                foreach (var visit in visits)
                                {
                                    if (visit.visitDate.Equals(searchDate, StringComparison.OrdinalIgnoreCase))
                                    {
                                        Console.WriteLine("Name: " + visit.name + "\nDate: " + visit.visitDate + "\nVisit Type: " +
                                            visit.visitType + "\nDoctor's Notes/Description:" + visit.description + "\nDoctor Name:Dr. " + visit.doctorName);
                                        Console.WriteLine("---------------------");
                                        found = true;
                                    }
                                }
                                if (!found)
                                    Console.WriteLine("No visit found.");
                                Console.WriteLine("---------------------");
                                break;
                            case "4":
                                Console.Write("Enter Doctor's name to search: ");
                                string searchVisit = Console.ReadLine();
                                Console.WriteLine("---------------------");
                                foreach (var visit in visits)
                                {
                                    if (visit.visitType.Equals(searchVisit, StringComparison.OrdinalIgnoreCase))
                                    {
                                        Console.WriteLine("Name: " + visit.name + "\nDate: " + visit.visitDate + "\nVisit Type: " +
                                            visit.visitType + "\nDoctor's Notes/Description:" + visit.description + "\nDoctor Name:Dr. " + visit.doctorName);
                                        Console.WriteLine("---------------------");
                                        found = true;
                                    }
                                }
                                if (!found)
                                    Console.WriteLine("No visit found.");
                                Console.WriteLine("---------------------");
                                break;
                            default:
                                Console.WriteLine("Invalid Input");
                                Console.WriteLine("---------------------");
                                break;
                        }

                        break;

                    case "3":
                        Console.Write("Enter patient name to update thier record: ");
                        string updateName = Console.ReadLine();
                        foreach (var visit in visits)
                        {
                            if (visit.name.Equals(updateName, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("---------- Record found ----------");
                                Console.WriteLine("Name: " + visit.name + "\nDate: " + visit.visitDate + "\nVisit Type: " +
                                            visit.visitType + "\nDoctor's Notes/Description:" + visit.description + "\nDoctor Name:Dr. " + visit.doctorName);
                                Console.WriteLine("---------------------");
                                Console.WriteLine("Do you want to update the record of this visit?(y/n):");
                                string YorN = Console.ReadLine();
                                if (YorN == "y")
                                {
                                    Console.Write("Enter new visit date(format: YYYY-MM-DD): ");
                                    visit.visitDate = Console.ReadLine();
                                    Console.Write("Enter new visit type(if any): ");
                                    visit.visitType = Console.ReadLine();
                                    Console.Write("Enter new visit description: ");
                                    visit.description = Console.ReadLine();
                                    Console.Write("Enter new doctor name(if applicable): ");
                                    visit.doctorName = Console.ReadLine();
                                    Console.WriteLine("Visit updated.");
                                }
                                else
                                {
                                    continue;
                                }

                                found = true;
                                break;
                            }
                        }
                        if (!found)
                            Console.WriteLine("No visit found.");
                        Console.WriteLine("---------------------");
                        break;

                    case "4":
                        Console.Write("Enter patient name to delete thier record: ");
                        string deleteName = Console.ReadLine();
                        for(int i=0;i<visits.Count;i++)
                        {
                            if (visits[i].name.Equals(deleteName, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("---------- Visit found ----------");
                                Console.WriteLine("Name: " + visits[i].name + "\nDate: " + visits[i].visitDate + "\nVisit Type: " +
                                    visits[i].visitType + "\nDoctor's Notes/Description:" + visits[i].description + "\nDoctor Name:Dr. " + visits[i].doctorName);
                                Console.WriteLine("---------------------");
                                Console.WriteLine("Do you want to delete this?(y/n):");
                                string YorN = Console.ReadLine();
                                if (YorN == "y")
                                {
                                    visits.RemoveAt(i);
                                    Console.WriteLine("Visit Deleted");
                                    Console.WriteLine("---------------------");
                                }
                                else
                                {
                                    continue;
                                }
                                found = true;
                            }
                        }
                        if (!found)
                            Console.WriteLine("No visit found.");
                        Console.WriteLine("---------------------");
                        break;
                    case "5":
                        DisplayData(visits);
                        break;

                    case "6":
                        Console.WriteLine("********** Thank you for using patient visit manager **********");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            
        }


        static void DisplayData(List<PatientVisit> visits)
        {
            Console.WriteLine("----------------- Visit List -----------------");
            Console.WriteLine("---------------------");
            var sortedVisits = visits.OrderBy(v => v.visitType).ToList();
            foreach (var visit in sortedVisits)
            {
                
                Console.WriteLine("Name: " + visit.name + "\nDate: " + visit.visitDate + "\nVisit Type: " +
                        visit.visitType + "\nDoctor's Notes/Description:" + visit.description + "\nDoctor Name:Dr. " + visit.doctorName);
                Console.WriteLine("---------------------");
            }
            Console.WriteLine("----------------- List End -----------------");
        }
    }
}
