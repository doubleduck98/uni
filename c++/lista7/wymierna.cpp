//
// Created by szipi on 2019-05-10.
//

#include "wymierna.h"
#include <numeric>
#include <map>

using namespace std;

namespace obliczenia {
    void wymierna::uprosc() {
        if (this->mianownik < 0) {
            this->licznik *= -1;
            this->mianownik *= -1;
        }
    }

    void wymierna::skroc() {
        int x = gcd(this->licznik, this->mianownik);
        this->licznik /= x;
        this->mianownik /= x;
    }

    wymierna::wymierna(int licz, int mian) {
        if (mian == 0) {
            throw dzielenie_przez_0();
        }
        licznik = licz;
        mianownik = mian;
        this->uprosc();
        this->skroc();
    }

    wymierna::wymierna(int liczba) {
        this->licznik = liczba;
        this->mianownik = 1;
    };

    wymierna::wymierna(const wymierna &w) {
        this->licznik = w.licznik;
        this->mianownik = w.mianownik;
    }

    wymierna &wymierna::operator=(const wymierna &w) = default;

    wymierna::wymierna(wymierna &&w) noexcept
            : licznik(0), mianownik(0) {
        this->licznik = w.licznik;
        this->mianownik = w.mianownik;

        w.licznik = 0;
        w.mianownik = 0;
    }

    wymierna &wymierna::operator=(wymierna &&other) noexcept {
        if (this != &other) {
            this->licznik = other.licznik;
            this->mianownik = other.mianownik;

            other.licznik = 0;
            other.mianownik = 0;
        }
        return *this;
    }

    wymierna &wymierna::operator!() {
        if (this->licznik == 0) {
            return *this;
        }
        swap(this->licznik, this->mianownik);
        this->uprosc();
        return *this;
    }

    wymierna &wymierna::operator-() {
        this->licznik *= -1;
        return *this;
    }

    wymierna::operator int() {
        return (this->licznik / this->mianownik);
    }

    wymierna::operator double() {
        return (double) this->licznik
               / (double) this->mianownik;
    }

    bool overflowPlus(int a, int b) {
        return ((a >> 31) & 1) == ((b >> 31) & 1)
               && ((a >> 31) & 1) != (((a + b) >> 31) & 1);
    }

    bool overflowMinus(int a, int b) {
        return ((a >> 31) & 1) != ((b >> 31) & 1)
               && ((a >> 31) & 1) != (((a - b) >> 31) & 1);
    }

    bool overflowMnoz(int a, int b) {
        return ((a * b) / b) != a;
    }

    //TODO: i teraz tak o tu mam wszytsko sprawdzac? XD
    wymierna operator+(const wymierna &w, const wymierna &v) {
        if (overflowMnoz(w.licznik, v.mianownik)
            || overflowMnoz(v.licznik, w.mianownik)
            || overflowMnoz(w.mianownik, v.mianownik)
            || overflowPlus(w.licznik * v.mianownik, v.licznik * w.mianownik))
            throw przekroczenie_zakresu();
        wymierna tmp(w.licznik * v.mianownik + v.licznik * w.mianownik,
                     w.mianownik * v.mianownik);
        tmp.uprosc();
        tmp.skroc();
        return tmp;
    }

    wymierna operator-(const wymierna &w, const wymierna &v) {
        if (overflowMnoz(w.licznik, v.mianownik)
            || overflowMnoz(v.licznik, w.mianownik)
            || overflowMnoz(w.mianownik, v.mianownik)
            || overflowMinus(w.licznik * v.mianownik, v.licznik * w.mianownik))
            throw przekroczenie_zakresu();
        wymierna tmp(w.licznik * v.mianownik - v.licznik * w.mianownik,
                     w.mianownik * v.mianownik);
        tmp.uprosc();
        tmp.skroc();
        return tmp;
    }

    wymierna operator*(const wymierna &w, const wymierna &v) {
        if (overflowMnoz(w.licznik, v.licznik)
            || overflowMnoz(w.mianownik, v.mianownik))
            throw przekroczenie_zakresu();
        wymierna tmp(w.licznik * v.licznik,
                     w.mianownik * v.mianownik);
        tmp.uprosc();
        tmp.skroc();
        return tmp;
    }

    wymierna operator/(const wymierna &w, const wymierna &v) {
        if (v.licznik == 0) {
            throw dzielenie_przez_0();
        }
        if (overflowMnoz(w.licznik, v.mianownik)
            || overflowMnoz(w.mianownik, v.licznik))
            throw przekroczenie_zakresu();
        wymierna tmp = wymierna(w.licznik * v.mianownik,
                                w.mianownik * v.licznik);
        tmp.uprosc();
        tmp.skroc();
        return tmp;
    }

    std::ostream &operator<<(std::ostream &wyj, const wymierna &w) {
        if (w.mianownik == 1)
            return wyj << w.licznik;
        else if (w.licznik == 0)
            return wyj << 0;
        else
            return wyj << w.licznik << "/" << w.mianownik;
    }
}

