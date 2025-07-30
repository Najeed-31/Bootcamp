// ConsoleApplication1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <fstream>
#include <iostream>
#include<vector>
#include <string>
#include <algorithm> // for transform
using namespace std;

class PatientVisit {
public:
    string name;
    string visitDate;
    string visitType;
    string description;
    string doctorName;
};

string toLower(const string& str) {
    string lowerStr = str;
    transform(lowerStr.begin(), lowerStr.end(), lowerStr.begin(), [](unsigned char c) {
        return tolower(c);
        });
    return lowerStr;
}
vector<PatientVisit> ReadVisitsFromFile(const string& filename) {
    vector<PatientVisit> visits;
    ifstream file(filename);
    if (!file.is_open()) {
        cerr << "Failed to open file: " << filename << endl;
        return visits;
    }

    string line;
    while (getline(file, line)) {
        if (line.rfind("Name:", 0) == 0) {
            PatientVisit visit;
            visit.name = line.substr(6);

            getline(file, line);
            visit.visitDate = line.substr(6);

            getline(file, line);
            visit.visitType = line.substr(12);

            getline(file, line);
            visit.description = line.substr(27);

            getline(file, line);
            visit.doctorName = line.substr(16); // after "Doctor Name: Dr. "

            visits.push_back(visit);

            // Skip the separator
            getline(file, line);
        }
    }

    return visits;
}

void DisplayData(vector<PatientVisit> visits) {

    // Sort visits case-insensitively by visitType
    sort(visits.begin(), visits.end(), [](const PatientVisit& a, const PatientVisit& b) {
        return toLower(a.visitType) < toLower(b.visitType);
        });

    // Display visits in formatted output
    cout << "----------------- Visit List -----------------" << endl;
    cout << "---------------------" << endl;
    for (const auto& visit : visits) {
        cout << "Name: " << visit.name << endl;
        cout << "Date: " << visit.visitDate << endl;
        cout << "Visit Type: " << visit.visitType << endl;
        cout << "Doctor's Notes/Description: " << visit.description << endl;
        cout << "Doctor Name: Dr. " << visit.doctorName << endl;
        cout << "---------------------" << endl;
    }
    cout << "----------------- List End -----------------" << endl;
}

void WriteVisitsToFile(const vector<PatientVisit>& visits, const string& filename) {

    sort(visits.begin(), visits.end(), [](const PatientVisit& a, const PatientVisit& b) {
        return toLower(a.visitType) < toLower(b.visitType);
        });
    ofstream file(filename);
    
    if (!file.is_open()) {
        cerr << "Failed to open file: " << filename << endl;
        return;
    }
    
    file << "----------------- Visit List -----------------" << endl;
    file << "---------------------" << endl;

    for (const auto& visit : visits) {
        file << "Name: " << visit.name << "\nDate: " << visit.visitDate
            << "\nVisit Type: " << visit.visitType
            << "\nDoctor's Notes/Description: " << visit.description
            << "\nDoctor Name: Dr. " << visit.doctorName
            << "\n---------------------" << endl;
    }

    file << "----------------- List End -----------------" << endl;
    file.close();
}




int main()
{

    string filename = "data.txt";

     //Read current visits from file
    vector<PatientVisit> visits = ReadVisitsFromFile(filename);
    DisplayData(visits);

    /*vector<PatientVisit> visits = {
    {"Najeed", "2025-07-20", "Consultation", "Acidity due to unhealthy diet.", "Kashif"},
    {"Shahmeer", "2025-07-21", "Emergency", "Change in weather prompted flu. Medicine prescribed", "Anam"},
    {"Bukhari", "2025-07-22", "Follow-up", "Excessive screen time led to migrane", "Kashif"}
    };

    ofstream file("data.txt");
    if (!file.is_open()) {
        cerr << "Failed to open data.txt for writing." << endl;
        return 1;
    }

    file << "----------------- Visit List -----------------" << endl;
    file << "---------------------" << endl;

    for (const auto& visit : visits) {
        file << "Name: " << visit.name
            << "\nDate: " << visit.visitDate
            << "\nVisit Type: " << visit.visitType
            << "\nDoctor's Notes/Description: " << visit.description
            << "\nDoctor Name: Dr. " << visit.doctorName
            << "\n---------------------" << endl;
    }

    file << "----------------- List End -----------------" << endl;
    file.close();

    cout << "Sorted data written to data.txt" << endl;*/

    bool running = true;
    while (running == true)
    {
        cout << "1. Add Visit" << endl;
        cout << "2. Search Visit" << endl;
        cout << "3. Update Visit" << endl;
        cout << "4. Delete Visit" << endl;
        cout << "5. Display all data (Categorized by visit type)" << endl;
        cout << "6. Exit" << endl;
        cout << "Choose an option (1–6): ";

        int choice;
        cin>> choice;
        bool found = false;
        if (choice == 1)
        {
            PatientVisit newVisit;

            cout << "Enter patient name: ";
            cin >> newVisit.name;

            cout << "Enter visit date (format: YYYY-MM-DD): "; 
            cin >> newVisit.visitDate;

            cout << "Enter Visit Type (Consultation, Follow-up, Emergency): ";
            cin >> newVisit.visitType;

            cout << "Enter Description: ";
            cin >> newVisit.description;

            cout << "Enter Doctor's name: Dr. ";
            cin >> newVisit.doctorName;

            visits.push_back(newVisit);

            cout << "Visit added." << endl;
            
            sort(visits.begin(), visits.end(), [](const PatientVisit& a, const PatientVisit& b) {
                return toLower(a.visitType) < toLower(b.visitType);
                });


            WriteVisitsToFile(visits, filename);
        }

        else if (choice == 2)
        {
            cout << "Search by: " << endl;
            cout << "1. Patient Name" << endl;
            cout << "2. Doctor Name" << endl;
            cout << "3. Date" << endl;
            cout << "4. Visit Type" << endl;
            cout << "Enter search choice (1–4): ";

            int searchChoice;
            cin >> searchChoice;
            if (searchChoice == 1)
            {
                cout << "Enter patient name to search: ";
                string searchName;
                cin>>searchName;

                cout << "---------------------" << endl;
                found = false;
                for (const auto& visit : visits) {
                    string visitNameLower = visit.name;
                    string searchNameLower = searchName;

                    // Convert both strings to lowercase for case-insensitive comparison
                    transform(visitNameLower.begin(), visitNameLower.end(), visitNameLower.begin(), ::tolower);
                    transform(searchNameLower.begin(), searchNameLower.end(), searchNameLower.begin(), ::tolower);

                    if (visitNameLower == searchNameLower) {
                        cout << "Name: " << visit.name << "\nDate: " << visit.visitDate
                            << "\nVisit Type: " << visit.visitType
                            << "\nDoctor's Notes/Description: " << visit.description
                            << "\nDoctor Name: Dr. " << visit.doctorName << endl;
                        cout << "---------------------" << endl;
                        found = true;
                    }
                }

                if (!found)
                    cout << "No visit found." << endl;

                cout << "---------------------" << endl;
            }
            else if (searchChoice == 2)
            {
                cout << "Enter Doctor's name to search: ";
                string searchNameDoctor;
                cin >> searchNameDoctor;

                cout << "---------------------" << endl;
                found = false;

                for (const auto& visit : visits) {
                    string doctorNameLower = visit.doctorName;
                    string searchNameDoctorLower = searchNameDoctor;

                    // Convert both strings to lowercase for case-insensitive comparison
                    transform(doctorNameLower.begin(), doctorNameLower.end(), doctorNameLower.begin(), ::tolower);
                    transform(searchNameDoctorLower.begin(), searchNameDoctorLower.end(), searchNameDoctorLower.begin(), ::tolower);

                    if (doctorNameLower == searchNameDoctorLower) {
                        cout << "Name: " << visit.name << "\nDate: " << visit.visitDate
                            << "\nVisit Type: " << visit.visitType
                            << "\nDoctor's Notes/Description: " << visit.description
                            << "\nDoctor Name: Dr. " << visit.doctorName << endl;
                        cout << "---------------------" << endl;
                        found = true;
                    }
                }

                if (!found)
                    cout << "No visit found." << endl;

                cout << "---------------------" << endl;

            }
            else if (searchChoice == 3)
            {
                cout << "Enter date to search (format: YYYY-MM-DD): ";
                string searchDate;
                cin>>searchDate;

                cout << "---------------------" << endl;

                found = false;

                for (const auto& visit : visits) {
                    string visitDateLower = visit.visitDate;
                    string searchDateLower = searchDate;

                    // Convert both to lowercase to simulate case-insensitive comparison
                    transform(visitDateLower.begin(), visitDateLower.end(), visitDateLower.begin(), ::tolower);
                    transform(searchDateLower.begin(), searchDateLower.end(), searchDateLower.begin(), ::tolower);

                    if (visitDateLower == searchDateLower) {
                        cout << "Name: " << visit.name << "\nDate: " << visit.visitDate
                            << "\nVisit Type: " << visit.visitType
                            << "\nDoctor's Notes/Description: " << visit.description
                            << "\nDoctor Name: Dr. " << visit.doctorName << endl;
                        cout << "---------------------" << endl;
                        found = true;
                    }
                }

                if (!found)
                    cout << "No visit found." << endl;

                cout << "---------------------" << endl;

            }
            else if (searchChoice == 4)
            {
                cout << "Enter Visit Type to search: ";
                string searchVisit;
                cin>>searchVisit;

                cout << "---------------------" << endl;

                found = false;

                for (const auto& visit : visits) {
                    string visitTypeLower = visit.visitType;
                    string searchVisitLower = searchVisit;

                    transform(visitTypeLower.begin(), visitTypeLower.end(), visitTypeLower.begin(), ::tolower);
                    transform(searchVisitLower.begin(), searchVisitLower.end(), searchVisitLower.begin(), ::tolower);

                    if (visitTypeLower == searchVisitLower) {
                        cout << "Name: " << visit.name << "\nDate: " << visit.visitDate
                            << "\nVisit Type: " << visit.visitType
                            << "\nDoctor's Notes/Description: " << visit.description
                            << "\nDoctor Name: Dr. " << visit.doctorName << endl;
                        cout << "---------------------" << endl;
                        found = true;
                    }
                }

                if (!found)
                    cout << "No visit found." << endl;

                cout << "---------------------" << endl;

            }
            else
            {
                cout << "Invalid Input" << endl;
                cout << "---------------------" << endl;
            }

        }
        else if (choice == 3)
        {
            cout << "Enter patient name to update their record: ";
            string updateName;
            cin >> updateName;


            found = false;

            for (auto& visit : visits) {
                string visitNameLower = visit.name;
                string updateNameLower = updateName;

                transform(visitNameLower.begin(), visitNameLower.end(), visitNameLower.begin(), ::tolower);
                transform(updateNameLower.begin(), updateNameLower.end(), updateNameLower.begin(), ::tolower);

                if (visitNameLower == updateNameLower) {
                    cout << "---------- Record found ----------" << endl;
                    cout << "Name: " << visit.name << "\nDate: " << visit.visitDate
                        << "\nVisit Type: " << visit.visitType
                        << "\nDoctor's Notes/Description: " << visit.description
                        << "\nDoctor Name: Dr. " << visit.doctorName << endl;
                    cout << "---------------------" << endl;

                    cout << "Do you want to update the record of this visit? (y/n): ";
                    string YorN;
                    cin >> YorN;

                    if (YorN == "y") {
                        cout << "Enter new visit date (format: YYYY-MM-DD): ";
                        cin>>visit.visitDate;

                        cout << "Enter new visit type (if any): ";
                        cin >> visit.visitType;

                        cout << "Enter new visit description: ";
                        cin >> visit.description;

                        cout << "Enter new doctor name (if applicable): ";
                        cin >> visit.doctorName;

                        DisplayData(visits);
                        WriteVisitsToFile(visits, filename);
                        cout << "Visit updated." << endl;
                    }
                    else {
                        continue;
                    }

                    found = true;
                    break;
                }
            }

            if (!found)
                cout << "No visit found." << endl;

            cout << "---------------------" << endl;

        }
        else if (choice == 4)
        {
            cout << "Enter patient name to delete their record: ";
            string deleteName;
            cin >> deleteName;

            found = false;

            for (size_t i = 0; i < visits.size(); ++i) {
                string visitNameLower = visits[i].name;
                string deleteNameLower = deleteName;

                transform(visitNameLower.begin(), visitNameLower.end(), visitNameLower.begin(), ::tolower);
                transform(deleteNameLower.begin(), deleteNameLower.end(), deleteNameLower.begin(), ::tolower);

                if (visitNameLower == deleteNameLower) {
                    cout << "---------- Visit found ----------" << endl;
                    cout << "Name: " << visits[i].name << "\nDate: " << visits[i].visitDate
                        << "\nVisit Type: " << visits[i].visitType
                        << "\nDoctor's Notes/Description: " << visits[i].description
                        << "\nDoctor Name: Dr. " << visits[i].doctorName << endl;
                    cout << "---------------------" << endl;

                    cout << "Do you want to delete this? (y/n): ";
                    string YorN;
                    cin >> YorN;

                    if (YorN == "y") {
                        visits.erase(visits.begin() + i);

                        WriteVisitsToFile(visits, filename);
                        cout << "Visit Deleted" << endl;
                        cout << "---------------------" << endl;
                        found = true;
                        break; // Exit after deletion
                    }
                    else {
                        continue;
                        cout << "Record not deleted" << endl;
                    }
                }
            }

            if (!found)
                cout << "No visit found." << endl;

            cout << "---------------------" << endl;

        }
        else if (choice == 5)
        {
            DisplayData(visits);
        }
        else if(choice==6)
        {
            cout << "********** Thank you for using patient visit manager **********" << endl;
            running = false;

        }
        else
        {
            cout<<"Invalid option."<<endl;
        }
    }
    
}

