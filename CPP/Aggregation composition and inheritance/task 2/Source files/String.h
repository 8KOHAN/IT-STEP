#pragma once
#include <iostream>

class String
{
public:
	explicit String(const char* str = "");
	String(const String& str);
	String(String&& str) noexcept;
	String& operator = (const String& str);
	String& operator = (String&& str) noexcept;
	~String();

	size_t length() const;
	char* begin() const;
	char* end() const;
	bool empty() const;
	char front() const;
	char back() const;
	void clear();
	size_t find(char arr[], int size);
	bool compare(String str) const;
	bool compare(char str[]) const;
	bool operator==(const String& other) const;
	bool operator==(const char* cstr) const;
	bool operator!=(const String& other) const;
	bool operator!=(const char* cstr) const;
	String operator+(const String& str) const;
	String& operator+=(const String& str);
	char& operator[](size_t index);
	const char& operator[](size_t index) const;

	friend std::istream& operator>>(std::istream& is, String& str);
	friend std::ostream& operator<<(std::ostream& os, const String& str);
	friend bool operator==(const char* cstr, const String& str);
	friend bool operator!=(const char* cstr, const String& str);
protected:
	char* str_;
	size_t length_;
};

class BitString : public String
{
public:
	BitString();
	BitString(const char* str);
	BitString(const BitString& other);
	BitString& operator=(const BitString& other);

	void invertSign();

	BitString operator+(const BitString& other) const;
    BitString& operator+=(const BitString& other);

private:
    static bool isValidBinary(const char* str);
    int toInt() const;
    void toTwosComplement();
    static BitString fromInt(int value);
};
