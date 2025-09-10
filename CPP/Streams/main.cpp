#include <iostream>
#include <string>
#include <fstream>

class Matrix {
public:
    Matrix(int x, int y) : size_x(x), size_y(y) {
        nums = new int* [size_x];
        for (int index_x = 0; index_x < size_x; ++index_x) {
            nums[index_x] = new int[size_y];
            for (int index_y = 0; index_y < size_y; ++index_y) {
                nums[index_x][index_y] = rand() % 1000;
            }
        }
    }

    Matrix() { }

    Matrix& operator=(const Matrix& other) {
        if (this != &other) {
            for (int i = 0; i < size_x; ++i) {
                delete[] nums[i];
            }
            delete[] nums;
            size_x = other.size_x;
            size_y = other.size_y;
            nums = new int* [size_x];
            for (int i = 0; i < size_x; ++i)
                nums[i] = new int[size_y];
            for (int i = 0; i < size_x; ++i)
                for (int j = 0; j < size_y; ++j)
                    nums[i][j] = other.nums[i][j];
        }
        return *this;
    }

    void saveToFile(const std::string& filename) const {
        std::ofstream file(filename);
        if (!file) {
            std::cerr << "Ошибка открытия файла для записи!" << std::endl;
            return;
        }
        file << "cols: " << size_x << " rows: " << size_y << "\n\n";
        for (int i = 0; i < size_x; ++i) {
            for (int y = 0; y < size_y; ++y) {
                file << nums[i][y] << " ";
            }
            file << std::endl;
        }
    }

    ~Matrix() {
        for (int i = 0; i < size_x; ++i) {
            delete[] nums[i];
        }
        delete[] nums;
    }

    friend std::ostream& operator << (std::ostream& os, Matrix& mat) {
        for (int index_x = 0; index_x < mat.size_x; ++index_x) {
            for (int index_y = 0; index_y < mat.size_y; ++index_y) {
                os << mat.nums[index_x][index_y] << " ";
            }
            os << std::endl;
        }
        return os;
    }

    friend std::istream& operator>>(std::istream& is, Matrix& mat) {
        int x, y;
        std::cout << "inpute size x - " << std::endl;
        std::cin >> x;
        std::cout << "inpute size y - " << std::endl;
        std::cin >> y;
        Matrix matrix(x, y);
        for (int i = 0; i < matrix.size_x; ++i) {
            for (int y = 0; y < matrix.size_y; ++y) {
                std::cout << "inpute num [" << i + 1 << "][" << y + 1 << "]: ";
                is >> matrix.nums[i][y];
            }
        }
        mat = matrix;
        return is;
    }


private:
    int** nums;
    int size_x;
    int size_y;
};

int main()
{
    Matrix mat;
    std::cin >> mat;
    std::cout << mat;
    mat.saveToFile("save_MATRIX");
}
