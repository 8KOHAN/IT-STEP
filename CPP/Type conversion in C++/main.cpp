#include <iostream>

//1
template <typename T>
void type(T type) {
	std::cout << typeid(type).name() << std::endl;
}

//2
void intToASCII(int num) {
	std::cout << reinterpret_cast<char*>(&num) << std::endl;
}


int main()
{
	//1
	{
		type("f");
		size_t num = 5;
		type(num);
	}

	//2
	{
		intToASCII(65);
		intToASCII(99);
	}
}
