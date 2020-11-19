#include <algorithm>
#include <deque>
#include <iostream>
#include <random>
#include <string>

using namespace std;

class Person {
   public:
    string imie;
    string nazwisko;
    int wiek;
    float waga;
    int wzrost;

    Person(string imie, string nazwisko, int wiek, float waga, int wzrost) {
        this->imie = imie;
        this->nazwisko = nazwisko;
        this->wiek = wiek;
        this->waga = waga;
        this->wzrost = wzrost;
    }

    float bmi() { return waga / (wzrost / 100.0f * wzrost / 100.0f); }
};

int main() {
    deque<Person> q;
    auto p1 = Person("Jan", "Kowalski", 21, 69, 171);
    q.emplace_back(p1);
    auto p2 = Person("Ela", "Wojciechowska", 82, 65, 170);
    q.emplace_back(p2);
    auto p3 = Person("Ignacy", "Kowalczyk", 51, 61, 184);
    q.emplace_back(p3);
    auto p4 = Person("Władysława", "Zawadzka", 55, 66, 172);
    q.emplace_back(p4);
    auto p5 = Person("Fryderyka", "Wysocka", 30, 63, 168);
    q.emplace_back(p5);
    auto p6 = Person("Jarosław", "Zieliński", 77, 83, 177);
    q.emplace_back(p6);
    auto p7 = Person("Grażyna", "Tomaszewska", 26, 49, 165);
    q.emplace_back(p7);
    auto p8 = Person("Antoni", "Pawłowski", 28, 77, 172);
    q.emplace_back(p8);
    auto p9 = Person("Marcin", "Sawicki", 69, 95, 154);
    q.emplace_back(p9);
    auto p10 = Person("Krystian", "Stępień", 22, 88, 192);
    q.emplace_back(p10);
    auto p11 = Person("Bartosz", "Błaszczyk", 22, 82, 183);
    q.emplace_back(p11);

    sort(q.begin(), q.end(),
         [](Person a, Person b) { return a.bmi() < b.bmi(); });
    for (auto p : q) {
        cout << p.imie << " - " << p.bmi() << endl;
    }
    cout << "***" << endl;

    transform(q.begin(), q.end(), q.begin(), [](Person p) {
        Person p2 = p;
        p2.waga *= 0.9;
        return p2;
    });
    for (auto p : q) {
        cout << p.imie << " - " << p.waga << endl;
    }
    cout << "***" << endl;

    auto it =
        partition(q.begin(), q.end(), [](Person p) { return p.waga < 60; });
    for (auto b = q.begin(); b < it; b++) {
        cout << b->imie << " - " << b->waga << endl;
    }
    cout << "---" << endl;
    for (; it < q.end(); it++) {
        cout << it->imie << " - " << it->waga << endl;
    }
    cout << "***" << endl;

    nth_element(q.begin(), q.begin() + q.size() / 2, q.end(),
                [](Person p1, Person p2) { return p1.wzrost < p2.wzrost; });
    for (auto p : q) {
        cout << p.imie << " - " << p.wzrost << endl;
    }
    cout << "***" << endl;

    random_device rd;
    mt19937 g(rd());
    shuffle(q.begin(), q.begin() + 5, g);
    shuffle(q.begin() + 5, q.begin() + 5 + 5, g);
    for (auto p : q) {
        cout << p.imie << " " << p.nazwisko << endl;
    }
    cout << "***" << endl;

    auto minmax = minmax_element(q.begin(), q.end(), [](Person p1, Person p2) {
        return p1.wiek < p2.wiek;
    });
    cout << "najwięcej lat ma " << minmax.second->imie << " - "
         << minmax.second->wiek << endl;
    cout << "najmniej lat ma " << minmax.first->imie << " - "
         << minmax.first->wiek << endl;
    cout << "***" << endl;
}