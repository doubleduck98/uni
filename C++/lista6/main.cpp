#include <iostream>
#include <map>
#include "stala.h"
#include "zmienna.h"
#include "sinus.h"
#include "dodawanie.h"
#include "dziel.h"
#include "mnoz.h"
#include "odejmowanie.h"
#include "liczba.h"
#include "cosinus.h"
#include "potega.h"
#include "e.h"

int main() {
    wyrazenie *w1 = new dziel(
            new mnoz(
                    new odejmowanie(
                            new zmienna("x"),
                            new liczba(1)),
                    new zmienna("x")),
            new liczba(2));
    wyrazenie *w2 = new dziel(
            new dodawanie(
                    new liczba(3),
                    new liczba(5)),
            new dodawanie(
                    new liczba(2),
                    new mnoz(
                            new zmienna("x"),
                            new liczba(7))));
    wyrazenie *w3 = new odejmowanie(
            new dodawanie(
                    new liczba(2),
                    new mnoz(
                            new zmienna("x"),
                            new liczba(7))),
            new dodawanie(
                    new mnoz(
                            new zmienna("y"),
                            new liczba(3)),
                    new liczba(5)));
    wyrazenie *w4 = new dziel(
            new cosinus(
                    new mnoz(
                            new dodawanie(
                                    new zmienna("x"),
                                    new liczba(1)),
                            new zmienna("x"))),
            new potega(
                    new e(),
                    new potega(
                            new zmienna("x"),
                            new liczba(2))));


    wyrazenie *test = new dodawanie(
            new odejmowanie(new liczba(2), new liczba(1)),
            new mnoz(new liczba(4), new liczba(2))
            );
    cout << w1->opis() << endl;
    double val = 0;
    while (val <= 1) {
        cout << val << ":\t" << w1->oblicz({{"x", val}}) << endl;
        val += 0.01;
    }

    return 0;
}