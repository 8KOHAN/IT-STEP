#include "String.h"
#include <string>

String::String(const char* str) : length_(strlen(str)) {
	str_ = new char[length_ + 1];
	strcpy_s(str_, length_ + 1, str);
}
String::String(const String& str) : length_(str.length_) {
	str_ = new char[length_ + 1];
	strcpy_s(str_, length_ + 1, str.str_);
}
String::String(String&& str) noexcept : str_(str.str_), length_(str.length_) {
	delete[] str.str_;
	str.length_ = 0;
}
String& String::operator=(const String& str) {
	if (this == &str) return *this;
	delete[] str_;
	length_ = str.length_;
	str_ = new char[length_ + 1];
	strcpy_s(str_, length_ + 1, str.str_);
	return *this;
}
String& String::operator=(String&& str) noexcept {
	if (this == &str) return *this;
	delete[] str_;
	str_ = str.str_;
	length_ = str.length_;
	str.str_ = nullptr;
	str.length_ = 0;
	return *this;
}
String::~String() { if (str_) delete str_; }
size_t String::length() const { return length_; }
char* String::begin() const { return &str_[0]; }
char* String::end() const { return &str_[length_]; }
bool String::empty() const { return length_; }
char String::front() const { return str_[0]; }
char String::back() const { return str_[length_ - 1]; }
size_t String::find(char arr[], int size) {
	for (int i = 0; i < length_; ++i) {
		if (str_[i] == arr[0]) {
			int count = 0;
			for (int j = 0; j < size; ++j) {
				if (str_[i + j] == arr[j]) ++count;
			}
			if (count == size) return i;
		}
	}
	return -1;
}
bool String::compare(String str) const{
	if (length_ != str.length_) return false;
	return strcmp(str_, str.str_) == 0;
}
bool String::compare(char str[]) const{
	if (!str) return false;
	if (length_ != std::strlen(str)) return false;
	return strcmp(str_, str) == 0;
}
bool String::operator==(const String& other) const {
	if (length_ != other.length_) return false;
	return strcmp(str_, other.str_) == 0;
}
bool String::operator==(const char* cstr) const {
	if (!cstr) return false;
	if (length_ != std::strlen(cstr)) return false;
	return strcmp(str_, cstr) == 0;
}
String String::operator+(const String& str) {
	size_t new_len = length_ + str.length_;
	char* new_str = new char[new_len + 1];
	strcpy_s(new_str, length_+1,str_);
	strcat_s(new_str, length_+1,str.str_);
	String result;
	result.str_ = new_str;
	result.length_ = new_len;
	return result;
}
char& String::operator[](size_t index) { return str_[index]; }
const char& String::operator[](size_t index) const { return str_[index]; }
std::istream& operator>>(std::istream& is, String& str) {
	std::string temp;
	getline(is, temp);
	delete[] str.str_;
	str.length_ = temp.length();
	str.str_ = new char[str.length_ + 1];
	strcpy_s(str.str_, temp.length()+1, temp.c_str());
	return is;
}
std::ostream& operator<<(std::ostream& os, const String& str) {
	os << str.str_;
	return os;
}
