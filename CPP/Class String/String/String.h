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
	bool compare(String str);
	bool compare(char str[]);
	bool operator==(const String& other) const;
	bool operator==(const char* cstr) const;
	String operator+(const String& str);
	char& operator[](size_t index);
	const char& operator[](size_t index) const;
	friend std::istream& operator>>(std::istream& is, String& str);
	friend std::ostream& operator<<(std::ostream& os, const String& str);
private:
	char* str_;
	size_t length_;
};
