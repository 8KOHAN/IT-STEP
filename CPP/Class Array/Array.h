#pragma once
#include <iostream>
template <typename T>
class Array {
public:
    explicit Array(int initSize = 0, int growBy = 1)
        : data(initSize > 0 ? new T[initSize] : nullptr), size(initSize), count(0), grow(growBy) {}
    ~Array() { delete[] data; }
    Array(const Array& other)
        : data(new T[other.size]), size(other.size), count(other.count), grow(other.grow) {
        for (int i = 0; i < count; ++i) data[i] = other.data[i];
    }
    Array(Array&& other) noexcept
        : data(other.data), size(other.size), count(other.count), grow(other.grow) {
        other.data = nullptr;
        other.size = other.count = other.grow = 0;
    }
    Array& operator=(const Array& other) {
        if (this != &other) {
            delete[] data;
            size = other.size;
            count = other.count;
            grow = other.grow;
            data = new T[size];
            for (int i = 0; i < count; ++i) data[i] = other.data[i];
        }
        return *this;
    }
    Array& operator=(Array&& other) noexcept {
        if (this != &other) {
            delete[] data;
            data = other.data;
            size = other.size;
            count = other.count;
            grow = other.grow;
            other.data = nullptr;
            other.size = other.count = other.grow = 0;
        }
        return *this;
    }
    T& operator[](int index) { return data[index]; }
    T GetAt(int index) const { return data[index]; }
    T* GetData() { return data; }
    int GetSize() const { return size; }
    int GetUpperBound() const { return count - 1; }
    bool empty() const { return count == 0; }
    void SetSize(int newSize, int growBy = 1) {
        grow = growBy;
        if (newSize == size) return;
        T* newData = newSize > 0 ? new T[newSize] : nullptr;
        int elementsToCopy = (newSize < count) ? newSize : count;
        for (int i = 0; i < elementsToCopy; ++i) newData[i] = data[i];
        delete[] data;
        data = newData;
        size = newSize;
        if (count > size) count = size;
    }
    void FreeExtra() { if (count < size) SetSize(count, grow); }
    void RemoveAll() {
        delete[] data;
        data = nullptr;
        size = count = 0;
    }
    void SetAt(int index, const T& value) {
        if (index < 0 || index >= size) return;
        if (index >= count) count = index + 1;
        data[index] = value;
    }
    const T& operator[](int index) const {
        if (index < 0 || index >= count) throw std::out_of_range("Index out of range");
        return data[index];
    }
    void Add(const T& value) {
        if (count >= size) SetSize(size + grow, grow);
        data[count++] = value;
    }
    void Append(const Array<T>& other) {
        int oldCount = count;
        SetSize(size + other.count, grow);
        for (int i = 0; i < other.count; ++i) data[oldCount + i] = other.data[i];
        count += other.count;
    }
    void InsertAt(int index, const T& value) {
        if (count >= size) SetSize(size + grow, grow);
        for (int i = count; i > index; --i) data[i] = data[i - 1];
        data[index] = value;
        ++count;
    }
    void RemoveAt(int index, int num = 1) {
        for (int i = index; i < count - num; ++i) data[i] = data[i + num];
        count -= num;
    }
private:
    T* data;
    int size;
    int count;
    int grow;
};
