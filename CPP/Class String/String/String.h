#pragma once

#include <iostream>

class String
{
private:
	char* str_;
	int size_;
public:
	explicit String(const char* str = "");

	String(const String& str);
	String(String&& str) noexcept;
	String& operator = (String& str);
	String& operator = (String&& str) noexcept;
	~String();

	char* begin() const;
	char* end() const;
	bool empty() const;
	char front() const;
	char back() const;
	void clear();

	void insert(char arr[]);
	void erase(char arr[]);
	void replace(char arr[]);
	bool find(char arr[]);

	bool compare(String str);
	bool compare(char str[]);

};



//begin / end - получить итератор для строки
//empty - проверка на пустоту
//clear - очистка строки
//front / back - получить первый / последний символ
//insert - вставить подстроку
//erase - удалить подстроку
//replace - изменить подстроку
//find - найти подстроку
//compare - сравнить две строки
