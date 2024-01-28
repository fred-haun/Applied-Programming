#include <iostream>
#include <vector>
#include <string>
#include <ctime>
#include <list>

using namespace std;

long year() {
    long years;
    //create the variable for the year
    cout << "Please choose a year past 1797: ";
    //prompt user for year
    cin >> years;
    //user chooses year
    while (years < 1797) {
        cout << "Invalid response. Please choose a year past 1797: ";
        cin >> years;
    //if response is invalid, it will ask the user to try again
    } 
    return years;
}

int month() {
    int months;
    //create the variable for the month
    cout << "Select a month by typing the month number (1-12): ";
    //prompt user for month by diget
    cin >> months;
    //user inputs month
    while (months > 12 || months < 1){
        cout << "Invalid response. Please enter a month number between 1 - 12: ";
        cin >> months;
    //checks for valid input, loops if invalid
    }
    return months;
}

bool is_leap_year(long years) {
    bool leap_year;
    if ((years % 4 == 0 && years % 100 != 0 ) || (years % 4 == 0 && years % 400 == 0 )) {
        leap_year = 1;
    //if a the year is a leap year it sets the bool flag to true
    } else {
        leap_year = 0;
    //false if the year is not a leap year
    }
    return leap_year;
}

long offset(long years, int months, bool leap_year) {
    long offsets = 0;
    //set the value for the offset of the calendar. 
    for (long i = 1797; i < years; i++){
        if ((i % 4 == 0 && i % 100 != 0 ) || (i % 4 == 0 && i % 400 == 0 )) {
            offsets += 366;
        } else {
            offsets += 365;
        }
    //this loop counts up all the days in each year up until the year you are looking for starting from 1797. It checks if the year is a leap year to count the proper number of days.
    }
    vector<long> month_offset = {0,31,59,90,120,151,181,212,243,273,304,334};
    // this is a list of the days added to the offset depending on the month chosen.
    offsets += month_offset[months - 1];
    //add the proper number of days to the offset
    if (leap_year == 1 && months > 2){
        offsets += 1;
    }
    //if the year chosen is a leap year, and the month is after February, It'll add one more to the offset. 
    return offsets;
}

void cal(int months, bool leap_year, long offsets) {
    vector<long> days_list; 
    if (leap_year == 0){
        days_list = {31,28,31,30,31,30,31,31,30,31,30,31};
    // a list of the days of the month for a non leap year.
    } else {
        days_list = {31,29,31,30,31,30,31,31,30,31,30,31};
    //a list of the days of the month for a leap year.
    }
    vector<string> month_list = {"Janurary", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
    //a list of the months of the year
    cout << "         " << month_list[months - 1] << endl;
    // displays the name of the month
    cout << " Su  Mo  Tu  We  Th  Fr  Sa " << endl;
    //displays the weekdays
    int t = 1;
    //this variable will count up in the next loop, and be used to know when to go to the next line
    bool error = false;
    for (long i = 1 -(offsets % 7); i <= days_list[months-1]; i++ && t++) {
    //the loop for displaying the calendar using the offset found. If the offet % 7 is 0, it'll start counting on a sunday
        if (t == 7 && ((offsets % 7) == 0) && error == false){
            t-=1;
            error = true;
        }
    //This is a error correction. Without this, if the first day is on a sunday, the look would skip the first saturday.
        if (t % 7 == 0){
            cout << endl;
        }
    //when the loop has looped 7 times, it'll start a new line
        if (i < 1) {
            cout << "    ";
        } else if (i < 10) {
        cout << "  " << i << " ";
        } else {
            cout << " " << i << " ";
        }
    //this code gives proper spacing to the numbers
    }
}

void time_date()
{
    time_t ttime = time(0);
    char* date_time = ctime(&ttime);
    cout << "The current local date and time is: " << date_time << endl;
    // This just displays the date and time in a military fashion
}

int main() {
    cout << "Enter 1 for the calendar, or 2 for current time and date: ";
    int choice;
    cin >> choice;
    //user input for calendar or date time.
    while (choice > 2 || choice < 1){
        cout << "Not a vaild choice, try again: "; 
        cin >> choice;
    }
    //checks for valid choice
    if (choice == 1){
        long years = year();
        long months = month();
        long leap_year = is_leap_year(years);
        long offsets = offset(years, months, leap_year);
        cal(months, leap_year, offsets);
        exit(0);
    //calendar program
    } else {
        time_date();
        exit(0);
    }
    //date program
}