explicit String::String(const char* str) {

}
String::String(const String& str) {

}
String::String(String&& str) noexcept {

}

String& String::operator = (String& str) {

}
String& String::operator = (String&& str) noexcept {

}

String::~String() {
	delete str_;
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
