#include "Reservoir.h"
#include <vector>
#include <fstream>
#include <windows.h>

int main() {
    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);

    std::vector<Reservoir> reservoirs;
    int choice;
    do {
        std::cout << "\n1. Add reservoir\n2. Delete reservoir\n3. Show all\n4. Compare area\n0. Exit\n> ";
        std::cin >> choice;

        if (choice == 1) {
            std::string name, type;
            double w, l, d;
            std::cout << "Name: "; std::cin >> name;
            std::cout << "Type: "; std::cin >> type;
            std::cout << "Width: "; std::cin >> w;
            std::cout << "Length: "; std::cin >> l;
            std::cout << "Depth: "; std::cin >> d;
            reservoirs.emplace_back(name, type, w, l, d);
        }

        else if (choice == 2) {
            int idx;
            std::cout << "Index to delete: ";
            std::cin >> idx;
            if (idx >= 0 && idx < reservoirs.size()) reservoirs.erase(reservoirs.begin() + idx);
        }

        else if (choice == 3) {
            for (int i = 0; i < reservoirs.size(); ++i) {
                std::cout << "\n[" << i << "] ";
                reservoirs[i].display();
            }
        }

        else if (choice == 4) {
            if (reservoirs.size() < 2) {
                std::cout << "Need at least 2 reservoirs to compare.\n";
                continue;
            }

            int i1, i2;
            std::cout << "Enter first index: ";
            std::cin >> i1;
            std::cout << "Enter second index: ";
            std::cin >> i2;

            if (i1 >= 0 && i1 < reservoirs.size() && i2 >= 0 && i2 < reservoirs.size()) {
                int result = reservoirs[i1].compareArea(reservoirs[i2]);
                if (result == -2) {
                    std::cout << "Reservoirs are of different types.\n";
                }
                else if (result == 0) {
                    std::cout << "Reservoirs have equal surface area.\n";
                }
                else if (result > 0) {
                    std::cout << "Reservoir [" << i1 << "] has greater surface area.\n";
                }
                else {
                    std::cout << "Reservoir [" << i2 << "] has greater surface area.\n";
                }
            }
            else {
                std::cout << "Invalid indexes.\n";
            }
        }

    } while (choice != 0);

    return 0;
}
