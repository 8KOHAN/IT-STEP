#include <iostream>
#include "TrafficDatabase.h"

int main() {
    TrafficDatabase db;

    db.addViolation("AA1234BB", "Speeding");
    db.addViolation("AA1234BB", "Red light");
    db.addViolation("BC5678CC", "Parking violation");
    db.addViolation("AK9999ZZ", "No insurance");

    std::cout << "=== Full database ===\n";
    db.printDatabase();

    std::cout << "\n=== Data for AA1234BB ===\n";
    db.printByNumber("AA1234BB");

    std::cout << "\n=== Cars from 'AA1000AA' to 'BC6000CC' ===\n";
    db.printByRange("AA1000AA", "BC6000CC");

    return 0;
}
