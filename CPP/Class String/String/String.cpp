#include "String.h"

explicit String::String(const char* str) : length_(strlen(str)) {
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
String& String::operator = (const String& str) {
	length_ = str.length_;
	str_ = new char[length_ + 1];
	strcpy_s(str_, length_ + 1, str.str_);
}
String& String::operator = (String&& str) noexcept {
	str_ = str.str_;
	length_ = str.length_;
	delete[] str.str_;
	str.length_ = 0;
}
String::~String() {
	delete str_;
}
size_t String::length() const {
	return length_;
}
char* String::begin() const {

}
char* String::end() const {

}
bool String::empty() const {

}
char String::front() const {

}
char String::back() const {

}
void String::clear() {

}
void String::insert(char arr[]) {

}
void String::erase(char arr[]) {

}
void String::replace(char arr[]) {

}
bool String::find(char arr[]) {

}
bool String::compare(String str) {

}
bool String::compare(char str[]) {

}
