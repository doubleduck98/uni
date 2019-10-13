//
// Created by szipi on 2019-05-10.
//

#ifndef LISTA7_WYMIERNA_H
#define LISTA7_WYMIERNA_H

#include <iostream>
#include "wyjatki_wymierne.h"

namespace obliczenia {
    class wymierna {
    private:
        int licznik, mianownik;

        void uprosc();

        void skroc();

        wymierna() = default;
    public:

        wymierna(int licz, int mian);

        ~wymierna() = default;

        explicit wymierna(int liczba);

        wymierna(const wymierna &);

        wymierna &operator=(const wymierna &);

        wymierna(wymierna &&) noexcept;

        wymierna &operator=(wymierna &&other) noexcept;

        friend std::ostream &operator<<(std::ostream &wyj, const wymierna &w);

        wymierna &operator!();

        wymierna &operator-();

        explicit operator int();

        explicit operator double();

        friend wymierna operator+(const wymierna &, const wymierna &);

        friend wymierna operator-(const wymierna &, const wymierna &);

        friend wymierna operator*(const wymierna &, const wymierna &);

        friend wymierna operator/(const wymierna &, const wymierna &);

        int getLicz() const { return licznik; };

        int getMian() const { return mianownik; };

        void test();
    };
}


#endif //LISTA7_WYMIERNA_H
