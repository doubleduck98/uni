//
// Created by szipi on 2019-05-10.
//

#ifndef LISTA7_WYJATKI_WYMIERNE_H
#define LISTA7_WYJATKI_WYMIERNE_H

#include <exception>

using namespace std;

namespace obliczenia {
    class wyjatek_wymierny : public exception {
    };

    class dzielenie_przez_0 : public wyjatek_wymierny {
    public:
        const char *what() const noexcept override {
            return "Dzielenie przez 0!";
        }
    };

    class przekroczenie_zakresu : public wyjatek_wymierny {
    public:
        const char *what() const noexcept override {
            return "Przekroczony zakres!";
        }
    };
}


#endif //LISTA7_WYJATKI_WYMIERNE_H
