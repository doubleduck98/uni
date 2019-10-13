//
// Created by szipi on 2019-04-03.
//

#ifndef LISTA5_WIELOMIAN_H
#define LISTA5_WIELOMIAN_H

#include <fstream>
#include <initializer_list>

using namespace std;

class wielomian {
private:
    double *a;
    int stopien;
public:
    explicit wielomian (int st=0, double wsp=1.0); // konstruktor tworzący jednomian
    wielomian (int st, const double wsp[]); // konstruktor tworzący wielomian
    wielomian (initializer_list<double> wsp); // lista współczynników
    wielomian (const wielomian &w); // konstruktor kopijący
    wielomian (wielomian &&w) noexcept; // konstruktor przenoszący
    wielomian& operator = (const wielomian &w); // przypisanie kopijące
    wielomian& operator = (wielomian &&w) noexcept; // przypisanie przenoszące
    ~wielomian (); // destruktor

    friend istream& operator >> (istream &we, wielomian &w);
    friend ostream& operator << (ostream &wy, const wielomian &w);

    friend wielomian operator + (const wielomian &u, const wielomian &v);
    friend wielomian operator - (const wielomian &u, const wielomian &v);
    friend wielomian operator * (const wielomian &u, const wielomian &v);
    friend wielomian operator * (const wielomian &u, double c);
    wielomian& operator += (const wielomian &v);
    wielomian& operator -= (const wielomian &v);
    wielomian& operator *= (const wielomian &v);
    wielomian& operator *= (double c);

    double operator () (double x) const; // obliczenie wartości wielomianu dla x
    double& operator [] (int i) const; // odczytanie i-tego współczynnika

};


#endif //LISTA5_WIELOMIAN_H
