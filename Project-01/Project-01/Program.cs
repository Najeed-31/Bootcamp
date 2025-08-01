using System;
using System.ComponentModel;
using System.Text;
using System.Text.Json;

namespace Project_01
{
    public class Rates
    {
        public string type { get; set; }
        public int rate { get; set; }
    }
    public class PatientVisit
    {
        public string name { get; set; }
        public string visitDate { get; set; }
        public string visitType { get; set; }
        public string description { get; set; }
        public string doctorName { get; set; }
        public string duration { get; set; }
        public string fee { get; set; }  
    }

    public class PatientVisitHistory
    {
        public string action { get; set; }
        public string name { get; set; }
        public string visitDate { get; set; }
        public string visitType { get; set; }
        public string description { get; set; }
        public string doctorName { get; set; }
    }

    public class Credentials
    {
        public string type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    public class Activity
    {
        public string action { get; set; }
        public string name { get; set; }
        public string visitDate { get; set; }
        public string visitType { get; set; }
        public string description { get; set; }
        public string doctorName { get; set; }
        public string status { get; set;}
        public string timeStamp { get; set; }
    }
    internal class Program
    {
        public static List<Activity> ReadActivityFromFile(string filename)
        {
            List<Activity> activities = new List<Activity>();

            if (!File.Exists(filename))
            {
                Console.Error.WriteLine("Failed to open file: " + filename);
                return activities;
            }

            using (StreamReader file = new StreamReader(filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    /*Console.WriteLine(line);*/
                    if (line.StartsWith("Action:"))
                    {
                        Activity activity = new Activity();
                        activity.action = line.Substring(8);
                       /* Console.WriteLine(activity.action);*/
                        line = file.ReadLine();
                        activity.name = line.Substring(6);
                        line = file.ReadLine();
                        activity.visitDate = line.Substring(6);
                        line = file.ReadLine();
                        activity.visitType = line.Substring(12);
                        line = file.ReadLine();
                        activity.description = line.Substring(28);
                        line = file.ReadLine();
                        activity.doctorName = line.Substring(17);
                        line = file.ReadLine();
                        activity.status = line.Substring(8);
                        line = file.ReadLine();
                        activity.timeStamp = line.Substring(12);
                        activities.Add(activity);
                        file.ReadLine();
                    }
                }
            }

            return activities;
        }

        public static void WriteVisitsToActivityFile(List<Activity> activities,string filename)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(filename))
                {
                    file.WriteLine("----------------- Activity Log -----------------");
                    file.WriteLine("---------------------");
                    foreach (var activity in activities)
                    {
                        file.WriteLine("Action: " + activity.action);
                        file.WriteLine("Name: " + activity.name);
                        file.WriteLine("Date: " + activity.visitDate);
                        file.WriteLine("Visit Type: " + activity.visitType);
                        file.WriteLine("Doctor's Notes/Description: " + activity.description);
                        file.WriteLine("Doctor Name: Dr. " + activity.doctorName);
                        file.WriteLine("Status: " + activity.status);
                        file.WriteLine("Time Stamp: " + activity.timeStamp);
                        file.WriteLine("---------------------");
                    }
                    file.WriteLine("----------------- List End -----------------");
                }
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Failed to open file: " + filename);
            }
        }
        public static List<PatientVisit> ReadVisitsFromFile(string filename)
        {
            List<PatientVisit> visits = new List<PatientVisit>();

            if (!File.Exists(filename))
            {
                Console.Error.WriteLine("Failed to open file: " + filename);
                return visits;
            }

            using (StreamReader file = new StreamReader(filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("Name:"))
                    {
                        PatientVisit visit = new PatientVisit();
                        visit.name = line.Substring(6);
                        line = file.ReadLine();
                        visit.visitDate = line.Substring(6);
                        line = file.ReadLine();
                        visit.visitType = line.Substring(12);
                        line = file.ReadLine();
                        visit.description = line.Substring(28);
                        line = file.ReadLine();
                        visit.doctorName = line.Substring(17);
                        line = file.ReadLine();
                        visit.duration = line.Substring(16);
                        line = file.ReadLine();
                        visit.fee = line.Substring(5);
                        visits.Add(visit);
                        file.ReadLine();
                    }
                }
            }

            return visits;
        }


        public static List<Credentials> ReadCredentialsFromFile(string filename)
        {
            List<Credentials> creds = new List<Credentials>();

            if (!File.Exists(filename))
            {
                Console.Error.WriteLine("Failed to open file: " + filename);
                return creds;
            }

            using (StreamReader file = new StreamReader(filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    /*Console.WriteLine(line);*/
                    if (line.StartsWith("Type:"))
                    {
                        Credentials cred = new Credentials();
                        cred.type = line.Substring(6);
                        /*Console.WriteLine(cred.type);*/
                        line = file.ReadLine();
                        cred.username = line.Substring(10);
                        line = file.ReadLine();
                        cred.password = line.Substring(10);
                        creds.Add(cred);
                    }
                }
            }

            return creds;
        }

        public static List<PatientVisitHistory> ReadVisitsFromHistoryFile(string filename)
        {
            List<PatientVisitHistory> visitHistory = new List<PatientVisitHistory>();

            if (!File.Exists(filename))
            {
                Console.Error.WriteLine("Failed to open file: " + filename);
                return visitHistory;
            }

            using (StreamReader file = new StreamReader(filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.StartsWith("Action")) 
                    {
                        PatientVisitHistory history = new PatientVisitHistory();
                        history.action = line.Substring(8);
                        line = file.ReadLine();
                        history.name = line.Substring(6);
                        line = file.ReadLine();
                        history.visitDate = line.Substring(6);
                        line = file.ReadLine();
                        history.visitType = line.Substring(12);
                        line = file.ReadLine();
                        history.description = line.Substring(28);
                        line = file.ReadLine();
                        history.doctorName = line.Substring(17);
                        visitHistory.Add(history);
                        file.ReadLine();
                    }
                    
                }
            }

            return visitHistory;
        }


        public static void WriteVisitsToFile(List<PatientVisit> visits, string filePath)
        {
            var sortedVisits = visits.OrderBy(v => v.visitType.ToLower()).ToList();
            try
            {
                using (StreamWriter file = new StreamWriter(filePath))
                {
                    file.WriteLine("----------------- Visit List -----------------");
                    file.WriteLine("---------------------");
                    foreach (var visit in sortedVisits)
                    {
                        file.WriteLine("Name: " + visit.name);
                        file.WriteLine("Date: " + visit.visitDate);
                        file.WriteLine("Visit Type: " + visit.visitType);
                        file.WriteLine("Doctor's Notes/Description: " + visit.description);
                        file.WriteLine("Doctor Name: Dr. " + visit.doctorName);
                        file.WriteLine("Duration(Mins): " + visit.duration);
                        file.WriteLine("Fee: " + visit.fee);
                        file.WriteLine("---------------------");
                    }
                    file.WriteLine("----------------- List End -----------------");
                }
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Failed to open file: " + filePath);
            }
        }

        public static void WriteVisitsToHistoryFile(List<PatientVisitHistory> visitHistory, string filePath)
        {
            try
            {
                int index = 1;
                using (StreamWriter file = new StreamWriter(filePath))
                {
                    file.WriteLine("----------------- History List -----------------");
                    file.WriteLine("---------------------");
                    foreach (var history in visitHistory)
                    {
                        file.WriteLine("Action "+index+": " + history.action);
                        file.WriteLine("Name: " + history.name);
                        file.WriteLine("Date: " + history.visitDate);
                        file.WriteLine("Visit Type: " + history.visitType);
                        file.WriteLine("Doctor's Notes/Description: " + history.description);
                        file.WriteLine("Doctor Name: Dr. " + history.doctorName);
                        file.WriteLine("---------------------");
                        index++;
                    }
                    file.WriteLine("----------------- List End -----------------");
                }
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Failed to open file: " + filePath);
            }
        }

        public static List<Rates> ReadFromJsonFile(string filePath) 
        {
            string json = File.ReadAllText(filePath);
            var dict = JsonSerializer.Deserialize<Dictionary<string, int>>(json);
            List<Rates> rates = new List<Rates>();
            foreach (var kvp in dict)
            {
                rates.Add(new Rates { type = kvp.Key, rate = kvp.Value });
            }

            return rates;
        }

        static void Main(string[] args)
        {
            /*List<Rates> rates = new List<Rates>
            {
                new Rates {type = "Consultation", rate = 500},
                 new Rates {type = "Follow-up", rate = 300},
                  new Rates {type = "Emergency", rate = 1000}
            };
            string jsonString = JsonSerializer.Serialize(rates, new JsonSerializerOptions { WriteIndented = true });

            // Define the file path
            string jsonPath = "C:\\Users\\6611\\source\\repos\\najeed-mubasher-6611\\Project-01\\Project-01\\rates.json";

            // Write the JSON string to the file
            File.WriteAllText(jsonPath, jsonString);*/

            /*List<PatientVisit> visits = new List<PatientVisit>
            {
                new PatientVisit { name = "Najeed", visitDate = "2025-07-20", visitType = "Consultation", description="Acidity due to unhealthy diet.", doctorName="Kashif" },
                new PatientVisit { name = "Shahmeer", visitDate = "2025-07-21", visitType = "Emergency" , description="Change in weather prompted flu. Medicine prescribed", doctorName="Anam"},
                new PatientVisit { name = "Bukhari", visitDate = "2025-07-22", visitType = "Follow-up" , description="Excessive screen time led to migrane", doctorName="Kashif"}
            };*/
            string filePath = "C:\\Users\\6611\\source\\repos\\najeed-mubasher-6611\\Project-01\\Project-01\\data.txt";
            string historyPath = "C:\\Users\\6611\\source\\repos\\najeed-mubasher-6611\\Project-01\\Project-01\\history.txt";
            string credPath = "C:\\Users\\6611\\source\\repos\\najeed-mubasher-6611\\Project-01\\Project-01\\credentials.txt";
            string activityPath= "C:\\Users\\6611\\source\\repos\\najeed-mubasher-6611\\Project-01\\Project-01\\activity_log.txt";
            string jsonPath = "C:\\Users\\6611\\source\\repos\\najeed-mubasher-6611\\Project-01\\Project-01\\rates.json";
            List<PatientVisit> visits = ReadVisitsFromFile(filePath);
            List<PatientVisitHistory> history = ReadVisitsFromHistoryFile(historyPath);
            List<Credentials> creds = ReadCredentialsFromFile(credPath);
            List<Activity> activities = ReadActivityFromFile(activityPath);
            List<Rates> rates = ReadFromJsonFile(jsonPath);
            /*foreach(var rate in rates)
            {
                Console.WriteLine(rate.type + " " + rate.rate);
            }*/
            /*Console.WriteLine(creds.Count);
            foreach (var cred in creds)
            {

                Console.WriteLine("Type: " + cred.type + "\nuname: " + cred.username + "\np: " +
                        cred.password );
                Console.WriteLine("---------------------");
            }*/
            string user = "";
            bool ufound = false;
            while(ufound!=true&&user!="0")
            {
                Console.WriteLine("Enter Username(admin user or Receptionist user)\nEnter 0 to terminate:");
                string uname = Console.ReadLine();
                if(uname=="0")
                {
                    break;
                }
                Console.WriteLine("Enter Password: ");
                string pass = Console.ReadLine();
                foreach (var cred in creds)
                {
                    if (cred.username==uname&&
                        cred.password==pass)
                    {
                        Console.WriteLine("Login Successfull!");
                        Console.WriteLine("---------------------");
                        user = cred.type;
                        ufound = true;
                    }
                }
                if (!ufound)
                    Console.WriteLine("Invalid Username or Password");
                Console.WriteLine("---------------------");
            }
            

            
            bool running = true;
            while (running == true)
            {
                
                if(user=="Admin")
                {
                    Activity newActivity = new Activity();
                    /*DateTime timeStamp = DateTime.Now;*/
                    PatientVisitHistory newHistory = new PatientVisitHistory();
                    Console.WriteLine("1. Add Visit");
                    Console.WriteLine("2. Search Visit");
                    Console.WriteLine("3. Update Visit");
                    Console.WriteLine("4. Delete Visit");
                    Console.WriteLine("5. Display all data (Categorized by visit type)");
                    Console.WriteLine("6. Visit Action History(Last 10 actions):");
                    Console.WriteLine("7. Exit");
                    Console.Write("Choose an option (1–7): ");
                    string choice = Console.ReadLine();
                    bool found = false;
                    switch (choice)
                    {
                        case "1":
                            string proceed = "y";
                            PatientVisit newVisit = new PatientVisit();
                            Console.Write("Enter patient name: ");
                            newVisit.name = Console.ReadLine();
                            newVisit.visitDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                            foreach (var visit in visits)
                            {
                                if (visit.name.Equals(newVisit.name, StringComparison.OrdinalIgnoreCase) &&
                                    visit.visitDate.Substring(0, 10) == DateTime.Now.ToString("MM/dd/yyyy HH:mm").Substring(0, 10) && 
                                    Math.Abs(Convert.ToInt32(visit.visitDate.Substring(11, 2)) - Convert.ToInt32(DateTime.Now.ToString("MM/dd/yyyy HH:mm").Substring(11,2))) < 1)
                                {
                                    Console.Write("Warning: This patient has another visit within an hour. Proceed? (Y/N)");
                                    proceed=Console.ReadLine();
                                    while(proceed!="y"&&proceed!="n")
                                    {
                                        Console.WriteLine("Enter either y or n:");
                                        proceed = Console.ReadLine();
                                    }
                                    found = true;
                                    break;
                                }
                            }
                            /*Console.Write("Enter visit date(format: YYYY-MM-DD): ");*/

                            if (proceed=="y")
                            {
                                Console.Write("Enter Visit Type(Consultation, Follow-up, Emergency): ");
                                newVisit.visitType = Console.ReadLine();

                                Console.Write("Enter Description: ");
                                newVisit.description = Console.ReadLine();

                                Console.Write("Enter Doctor's name:Dr. ");
                                newVisit.doctorName = Console.ReadLine();
                                Console.Write("Enter Duration in Minutes ");
                                newVisit.duration = Console.ReadLine();
                                if(newVisit.visitType.Equals("consultation", StringComparison.OrdinalIgnoreCase))
                                {
                                    newVisit.fee = Convert.ToString(Convert.ToInt32(newVisit.duration) * rates[0].rate);
                                }
                                else if(newVisit.visitType.Equals("follow-up", StringComparison.OrdinalIgnoreCase))
                                {
                                    newVisit.fee = Convert.ToString(Convert.ToInt32(newVisit.duration) * rates[1].rate);
                                }
                                else
                                {
                                    newVisit.fee = Convert.ToString(Convert.ToInt32(newVisit.duration) * rates[2].rate);
                                }
                                visits.Add(newVisit);
                                WriteVisitsToFile(visits, filePath);
                                newActivity.action = "Add";
                                newActivity.name = newVisit.name;
                                newActivity.visitDate = newVisit.visitDate;
                                newActivity.visitType = newVisit.visitType;
                                newActivity.description = newVisit.description;
                                newActivity.doctorName = newVisit.doctorName;
                                newActivity.status = "Successful";
                                newActivity.timeStamp = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                                activities.Add(newActivity);
                                WriteVisitsToActivityFile(activities, activityPath);
                                newHistory.action = "Add";
                                newHistory.name = newVisit.name;
                                newHistory.visitDate = newVisit.visitDate;
                                newHistory.visitType = newVisit.visitType;
                                newHistory.description = newVisit.description;
                                newHistory.doctorName = newVisit.doctorName;
                                Console.WriteLine(newHistory.action + " " + newHistory.name);

                                if (history.Count < 10)
                                {
                                    history.Add(newHistory);
                                    WriteVisitsToHistoryFile(history, historyPath);
                                }
                                else
                                {
                                    history.RemoveAt(0);
                                    history.Add(newHistory);
                                    WriteVisitsToHistoryFile(history, historyPath);
                                }

                                Console.WriteLine("Visit added.");
                            }
                            else
                            {
                                Console.WriteLine("Addition Cancelled");
                            }
                            
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
                                    Console.WriteLine("1. By Year");
                                    Console.WriteLine("2. By Year and Month");
                                    Console.WriteLine("3. By Year, Month and Date");
                                    string x = Console.ReadLine();
                                    if (x == "1")
                                    {
                                        Console.Write("Enter Year(e.g 2025) to filter by: ");
                                        string searchYear = Console.ReadLine();
                                        found = false;
                                        Console.WriteLine("---------------------");
                                        foreach (var visit in visits)
                                        {
                                            if (visit.visitDate.Substring(0, 4).Equals(searchYear, StringComparison.OrdinalIgnoreCase))
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
                                    }
                                    else if (x == "2")
                                    {
                                        Console.Write("Enter Year(e.g 2025): ");
                                        string searchYear = Console.ReadLine();
                                        Console.WriteLine("Enter Month(e.g 07 for July, 11 for November): ");
                                        string searchMonth = Console.ReadLine();
                                        found = false;
                                        Console.WriteLine("---------------------");
                                        foreach (var visit in visits)
                                        {
                                            if (visit.visitDate.Substring(0, 4).Equals(searchYear, StringComparison.OrdinalIgnoreCase) &&
                                                visit.visitDate.Substring(5, 2).Equals(searchMonth, StringComparison.OrdinalIgnoreCase))
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
                                    }

                                    else if (x == "3")
                                    {
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
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Input");
                                    }

                                    break;
                                case "4":
                                    Console.Write("Enter visit type(Consultation, Follow-up, Emergency) to search: ");
                                    int cons = 0, fol = 0, emer = 0;
                                    string searchVisit = Console.ReadLine();
                                    Console.WriteLine("---------------------");
                                    foreach (var visit in visits)
                                    {
                                        if (visit.visitType.Equals("consultation", StringComparison.OrdinalIgnoreCase))
                                        {
                                            cons++;
                                        }
                                        else if (visit.visitType.Equals("follow-up", StringComparison.OrdinalIgnoreCase))
                                        {
                                            fol++;
                                        }
                                        else if (visit.visitType.Equals("emergency", StringComparison.OrdinalIgnoreCase))
                                        {
                                            emer++;
                                        }
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
                                    Console.WriteLine("Count per visit type:");
                                    Console.WriteLine("Consultation: " + cons);
                                    Console.WriteLine("Follow-up: " + fol);
                                    Console.WriteLine("Emergency: " + emer);
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

                                        /*Console.Write("Enter new visit date(format: YYYY-MM-DD): ");*/
                                        visit.visitDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                                        Console.Write("Enter new visit type(Consultation, Follow-up, Emergency): ");
                                        visit.visitType = Console.ReadLine();
                                        Console.Write("Enter new visit description: ");
                                        visit.description = Console.ReadLine();
                                        Console.Write("Enter new doctor name(if applicable): ");
                                        visit.doctorName = Console.ReadLine();
                                        Console.Write("Enter Duration in Minutes ");
                                        visit.duration = Console.ReadLine();
                                        if (visit.visitType.Equals("consultation", StringComparison.OrdinalIgnoreCase))
                                        {
                                            visit.fee = Convert.ToString(Convert.ToInt32(visit.duration) * rates[0].rate);
                                        }
                                        else if (visit.visitType.Equals("follow-up", StringComparison.OrdinalIgnoreCase))
                                        {
                                            visit.fee = Convert.ToString(Convert.ToInt32(visit.duration) * rates[1].rate);
                                        }
                                        else
                                        {
                                            visit.fee = Convert.ToString(Convert.ToInt32(visit.duration) * rates[2].rate);
                                        }
                                        WriteVisitsToFile(visits, filePath);
                                        newActivity.action = "Update";
                                        newActivity.name = visit.name;
                                        newActivity.visitDate = visit.visitDate;
                                        newActivity.visitType = visit.visitType;
                                        newActivity.description = visit.description;
                                        newActivity.doctorName = visit.doctorName;
                                        newActivity.status = "Successful";
                                        newActivity.timeStamp = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                                        activities.Add(newActivity);
                                        WriteVisitsToActivityFile(activities, activityPath);
                                        Console.WriteLine("Visit updated.");
                                        newHistory.action = "Update";
                                        newHistory.name = visit.name;
                                        newHistory.visitDate = visit.visitDate;
                                        newHistory.visitType = visit.visitType;
                                        newHistory.description = visit.description;
                                        newHistory.doctorName = visit.doctorName;
                                        if (history.Count < 10)
                                        {
                                            history.Add(newHistory);
                                            WriteVisitsToHistoryFile(history, historyPath);
                                        }
                                        else
                                        {
                                            history.RemoveAt(0);
                                            history.Add(newHistory);
                                            WriteVisitsToHistoryFile(history, historyPath);
                                        }
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
                            for (int i = 0; i < visits.Count; i++)
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
                                        newActivity.action = "Delete";
                                        newActivity.name = visits[i].name;
                                        newActivity.visitDate = visits[i].visitDate;
                                        newActivity.visitType = visits[i].visitType;
                                        newActivity.description = visits[i].description;
                                        newActivity.doctorName = visits[i].doctorName;
                                        newActivity.status = "Successful";
                                        newActivity.timeStamp = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                                        activities.Add(newActivity);
                                        WriteVisitsToActivityFile(activities, activityPath);
                                        newHistory.action = "Delete";
                                        newHistory.name = visits[i].name;
                                        newHistory.visitDate = visits[i].visitDate;
                                        newHistory.visitType = visits[i].visitType;
                                        newHistory.description = visits[i].description;
                                        newHistory.doctorName = visits[i].doctorName;
                                        if (history.Count < 10)
                                        {
                                            history.Add(newHistory);
                                            WriteVisitsToHistoryFile(history, historyPath);
                                        }
                                        else
                                        {
                                            history.RemoveAt(0);
                                            history.Add(newHistory);
                                            WriteVisitsToHistoryFile(history, historyPath);
                                        }
                                        visits.RemoveAt(i);
                                        WriteVisitsToFile(visits, filePath);
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
                            DisplayHistoryData(history);
                            Console.WriteLine("Do you want to undo any of these actions(y/n):");
                            string yn = Console.ReadLine();
                            if (yn == "y")
                            {
                                Console.WriteLine("Which action number do you want undone: ");
                                int ch = Convert.ToInt32(Console.ReadLine());
                                if (history[ch - 1].action == "Add")
                                {
                                    UndoAdd(visits, history, ch);
                                }
                                else if (history[ch - 1].action == "Update")
                                {
                                    UndoUpdate(visits, history, ch);
                                }
                                else
                                {
                                    UndoDelete(visits, history, ch);
                                }
                            }
                            break;
                        case "7":
                            Console.WriteLine("********** Thank you for using patient visit manager **********");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                else if(user=="Receptionist")
                {
                    Activity newActivity = new Activity();
                    PatientVisitHistory newHistory = new PatientVisitHistory();
                    Console.WriteLine("1. Add Visit");
                    Console.WriteLine("2. Search Visit");
                    Console.WriteLine("3. Exit");
                    Console.Write("Choose an option (1–3): ");
                    string choice = Console.ReadLine();
                    bool found = false;
                    switch (choice)
                    {
                        case "1":
                            string proceed = "y";
                            PatientVisit newVisit = new PatientVisit();
                            Console.Write("Enter patient name: ");
                            newVisit.name = Console.ReadLine();
                            newVisit.visitDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                            foreach (var visit in visits)
                            {
                                if (visit.name.Equals(newVisit.name, StringComparison.OrdinalIgnoreCase) &&
                                    visit.visitDate.Substring(0, 10) == DateTime.Now.ToString("MM/dd/yyyy HH:mm").Substring(0, 10) &&
                                    Math.Abs(Convert.ToInt32(visit.visitDate.Substring(11, 2)) - Convert.ToInt32(DateTime.Now.ToString("MM/dd/yyyy HH:mm").Substring(11,2))) < 1)
                                {
                                    Console.Write("Warning: This patient has another visit within an hour. Proceed? (Y/N)");
                                    proceed = Console.ReadLine();
                                    while (proceed != "y" && proceed != "n")
                                    {
                                        Console.WriteLine("Enter either y or n:");
                                        proceed = Console.ReadLine();
                                    }
                                    found = true;
                                    break;
                                }
                            }
                            /*Console.Write("Enter visit date(format: YYYY-MM-DD): ");*/

                            if (proceed == "y")
                            {
                                Console.Write("Enter Visit Type(Consultation, Follow-up, Emergency): ");
                                newVisit.visitType = Console.ReadLine();

                                Console.Write("Enter Description: ");
                                newVisit.description = Console.ReadLine();

                                Console.Write("Enter Doctor's name:Dr. ");
                                newVisit.doctorName = Console.ReadLine();
                                Console.Write("Enter Duration in Minutes ");
                                newVisit.duration = Console.ReadLine();
                                if (newVisit.visitType.Equals("consultation", StringComparison.OrdinalIgnoreCase))
                                {
                                    newVisit.fee = Convert.ToString(Convert.ToInt32(newVisit.duration) * rates[0].rate);
                                }
                                else if (newVisit.visitType.Equals("follow-up", StringComparison.OrdinalIgnoreCase))
                                {
                                    newVisit.fee = Convert.ToString(Convert.ToInt32(newVisit.duration) * rates[1].rate);
                                }
                                else
                                {
                                    newVisit.fee = Convert.ToString(Convert.ToInt32(newVisit.duration) * rates[2].rate);
                                }

                                visits.Add(newVisit);
                                WriteVisitsToFile(visits, filePath);
                                newActivity.action = "Add";
                                newActivity.name = newVisit.name;
                                newActivity.visitDate = newVisit.visitDate;
                                newActivity.visitType = newVisit.visitType;
                                newActivity.description = newVisit.description;
                                newActivity.doctorName = newVisit.doctorName;
                                newActivity.status = "Successful";
                                newActivity.timeStamp = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                                activities.Add(newActivity);
                                WriteVisitsToActivityFile(activities, activityPath);
                                newHistory.action = "Add";
                                newHistory.name = newVisit.name;
                                newHistory.visitDate = newVisit.visitDate;
                                newHistory.visitType = newVisit.visitType;
                                newHistory.description = newVisit.description;
                                newHistory.doctorName = newVisit.doctorName;
                                Console.WriteLine(newHistory.action + " " + newHistory.name);

                                if (history.Count < 10)
                                {
                                    history.Add(newHistory);
                                    WriteVisitsToHistoryFile(history, historyPath);
                                }
                                else
                                {
                                    history.RemoveAt(0);
                                    history.Add(newHistory);
                                    WriteVisitsToHistoryFile(history, historyPath);
                                }

                                Console.WriteLine("Visit added.");
                            }
                            else
                            {
                                Console.WriteLine("Addition Cancelled");
                            }
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
                                    Console.WriteLine("1. By Year");
                                    Console.WriteLine("2. By Year and Month");
                                    Console.WriteLine("3. By Year, Month and Date");
                                    string x = Console.ReadLine();
                                    if (x == "1")
                                    {
                                        Console.Write("Enter Year(e.g 2025) to filter by: ");
                                        string searchYear = Console.ReadLine();
                                        found = false;
                                        Console.WriteLine("---------------------");
                                        foreach (var visit in visits)
                                        {
                                            if (visit.visitDate.Substring(0, 4).Equals(searchYear, StringComparison.OrdinalIgnoreCase))
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
                                    }
                                    else if (x == "2")
                                    {
                                        Console.Write("Enter Year(e.g 2025): ");
                                        string searchYear = Console.ReadLine();
                                        Console.WriteLine("Enter Month(e.g 07 for July, 11 for November): ");
                                        string searchMonth = Console.ReadLine();
                                        found = false;
                                        Console.WriteLine("---------------------");
                                        foreach (var visit in visits)
                                        {
                                            if (visit.visitDate.Substring(0, 4).Equals(searchYear, StringComparison.OrdinalIgnoreCase) &&
                                                visit.visitDate.Substring(5, 2).Equals(searchMonth, StringComparison.OrdinalIgnoreCase))
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
                                    }

                                    else if (x == "3")
                                    {
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
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Input");
                                    }

                                    break;
                                case "4":
                                    Console.Write("Enter visit type(Consultation, Follow-up, Emergency) to search: ");
                                    int cons = 0, fol = 0, emer = 0;
                                    string searchVisit = Console.ReadLine();
                                    Console.WriteLine("---------------------");
                                    foreach (var visit in visits)
                                    {
                                        if (visit.visitType.Equals("consultation", StringComparison.OrdinalIgnoreCase))
                                        {
                                            cons++;
                                        }
                                        else if (visit.visitType.Equals("follow-up", StringComparison.OrdinalIgnoreCase))
                                        {
                                            fol++;
                                        }
                                        else if (visit.visitType.Equals("emergency", StringComparison.OrdinalIgnoreCase))
                                        {
                                            emer++;
                                        }
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
                                    Console.WriteLine("Count per visit type:");
                                    Console.WriteLine("Consultation: " + cons);
                                    Console.WriteLine("Follow-up: " + fol);
                                    Console.WriteLine("Emergency: " + emer);
                                    Console.WriteLine("---------------------");
                                    break;
                                default:
                                    Console.WriteLine("Invalid Input");
                                    Console.WriteLine("---------------------");
                                    break;
                            }


                            break;
                        case "3":
                            Console.WriteLine("************* Thank you For Using Patient Management System *************");
                            running = false; 
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Terminated");
                    running = false;
                }
                
            }

        }

        static void UndoAdd(List<PatientVisit> visits, List<PatientVisitHistory> historyData, int ch)
        {


            foreach (var visit in visits)
            {
                if (visit.name.Equals(historyData[ch-1].name, StringComparison.OrdinalIgnoreCase) && 
                    visit.visitDate.Equals(historyData[ch - 1].visitDate, StringComparison.OrdinalIgnoreCase) &&
                    visit.visitType.Equals(historyData[ch - 1].visitType, StringComparison.OrdinalIgnoreCase) &&
                    visit.description.Equals(historyData[ch - 1].description, StringComparison.OrdinalIgnoreCase) &&
                    visit.doctorName.Equals(historyData[ch - 1].doctorName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Undone Addition of:");
                    Console.WriteLine("Name: " + visit.name + "\nDate: " + visit.visitDate + "\nVisit Type: " +
                        visit.visitType + "\nDoctor's Notes/Description:" + visit.description + "\nDoctor Name:Dr. " + visit.doctorName);
                    Console.WriteLine("---------------------");
                    visits.Remove(visit);
                    
                }
            }
            
            Console.WriteLine("---------------------");
        }

        static void UndoUpdate(List<PatientVisit> visits, List<PatientVisitHistory> historyData, int ch)
        {

        }

        static void UndoDelete(List<PatientVisit> visits, List<PatientVisitHistory> historyData, int ch)
        {

        }



        static void DisplayData(List<PatientVisit> visits)
        {
            Console.WriteLine("----------------- Visit List -----------------");
            Console.WriteLine("---------------------");
            var sortedVisits = visits.OrderBy(v => v.visitType).ToList();
            foreach (var visit in sortedVisits)
            {

                Console.WriteLine("Name: " + visit.name + "\nDate: " + visit.visitDate + "\nVisit Type: " +
                        visit.visitType + "\nDoctor's Notes/Description:" + visit.description + "\nDoctor Name:Dr. " + visit.doctorName
                        + "\nDuration(Mins): " + visit.duration + "\nFee: " + visit.fee);
                Console.WriteLine("---------------------");
            }
            Console.WriteLine("----------------- List End -----------------");
        }
        static void DisplayHistoryData(List<PatientVisitHistory> historyData)
        {
            Console.WriteLine("----------------- Visit List -----------------");
            Console.WriteLine("---------------------");
            foreach (var history in historyData)
            {

                Console.WriteLine("Action: "+ history.action+"\nName: " + history.name + "\nDate: " + history.visitDate + "\nVisit Type: " +
                        history.visitType + "\nDoctor's Notes/Description:" + history.description + "\nDoctor Name:Dr. " + history.doctorName);
                Console.WriteLine("---------------------");
            }
            Console.WriteLine("----------------- List End -----------------");
        }
    }

    
}

