//
// Created by szipi on 2019-04-03.
//

#include "wielomian.h"
#include <cmath>
#include <iostream> //debug xd

wielomian::wielomian(int st, double wsp) {
    if (st < 0)
        throw invalid_argument("nie mozna stworzyc wielomianu o stopniu < 0");
    if (wsp == 0 && st > 0)
        throw invalid_argument("wspolczynnik pierwszego wyrazu nie moze byc == 0");
    stopien = st;
    a = new double[st + 1];
    for (int i = 0; i < st; ++i) {
        a[i] = 0;
    }
    a[st] = wsp;
}

//powinno sie przekazac wsp.size jako argument funkcji dla sprawdzenia
wielomian::wielomian(int st, const double *wsp) {
    if (st < 0)
        throw invalid_argument("nie mozna stworzyc wielomianu o stopniu < 0");
    if (wsp[0] == 0 && st > 0)
        throw invalid_argument("wspolczynnik pierwszego wyrazu nie moze byc == 0");
    stopien = st;
    a = new double[stopien + 1];
    //wspolczynniki od lewej do prawej jak w pisanym
    for (int i = stopien, j = 0; i >= 0; --i, ++j) {
        a[i] = wsp[j];
    }
}

//wspolczynniki od lewej do prawej jak w pisanym
wielomian::wielomian(initializer_list<double> wsp) {
    if (wsp.size() <= 0)
        throw invalid_argument("nie mozna stworzyc wielomianu o stopniu < 0");
    if (*wsp.begin() == 0 && wsp.size() != 1)
        throw invalid_argument("wspolczynnik pierwszego wyrazu nie moze byc == 0");
    stopien = wsp.size() - 1;
    a = new double[stopien + 1];
    int i = wsp.size();
    for (const auto &x: wsp) {
        a[i - 1] = x;
        --i;
    }
}

wielomian::wielomian(const wielomian &w) {
    this->stopien = w.stopien;
    this->a = new double[stopien + 1];
    copy(w.a, w.a + stopien + 1, this->a);
}

wielomian::wielomian(wielomian &&w) noexcept
        : a(nullptr), stopien(0) {
    this->stopien = w.stopien;
    this->a = w.a;

    w.stopien = 0;
    w.a = nullptr;
}

wielomian &wielomian::operator=(const wielomian &w) {
    this->stopien = w.stopien;
    this->a = new double[stopien + 1];
    copy(w.a, w.a + stopien + 1, this->a);
    return *this;
};

wielomian &wielomian::operator=(wielomian &&w) noexcept {
    if (this != &w) {
        stopien = w.stopien;
        delete[] a;
        a = w.a;

        w.stopien = 0;
        w.a = nullptr;
    }
    return *this;
}

wielomian::~wielomian() {
    delete[] a;
}

istream &operator>>(istream &we, wielomian &w) {
    we >> w.stopien;
    delete[] w.a; //todo: check
    w.a = new double[w.stopien + 1];
    for (int i = w.stopien; i >= 0; --i) {
        we >> w.a[i];
    }
    return we;
}

ostream &operator<<(ostream &wy, const wielomian &w) {
    string ret;
    if (w.stopien != 0) {
        //milion przypadkow zeby to sie dobrze wypisywalo
        for (int i = w.stopien; i >= 0; --i) {
            if (w.a[i] != 0) {
                if ((w.a[i] != 1 && i > 0) || (i == 0))
                    ret += to_string(w.a[i]);
                if (i != 0)
                    ret += "x";
                if (i > 1)
                    ret += to_string(i);
                if ((i > 1 && w.a[i - 1] >= 0) || (i == 1 && w.a[i - 1] > 0))
                    ret += " +";
                ret += " ";
            }
        }
        if (ret.at(ret.size() - 2) == '+') {
            ret = ret.substr(0, ret.size() - 2);
        }
    } else {
        //zeby dobrze 0 wypisywało
        ret = to_string(w.a[0]);
    }
    return wy << ret;
}

wielomian operator+(const wielomian &u, const wielomian &v) {
    wielomian res;
    //wybieram wiekszy wzgledem stopnia, kopiuje do res i dodaje mniejszy
    if (u.stopien > v.stopien) {
        res = u;
        for (int i = 0; i <= v.stopien; ++i) {
            res.a[i] += v.a[i];
        }
    } else {
        res = v;
        for (int i = 0; i <= u.stopien; ++i) {
            res.a[i] += u.a[i];
        }
    }
    //usuwanie wyrazow ze wspolczynnikiem 0 z przodu
    if (res.a[res.stopien] == 0) {
        while (res.a[res.stopien] == 0) {
            res.stopien -= 1;
        }
        wielomian xd = wielomian(res.stopien);
        copy(res.a, res.a + res.stopien + 1, xd.a);
        delete &res; //todo: check
        return xd;
    }
    return res;
}

wielomian operator-(const wielomian &u, const wielomian &v) {
    //trzeba pamietac o tym, ze odejmowanie nie jest przemienne
    wielomian res = wielomian(max(u.stopien, v.stopien));
    //wypelniam nowy zerami, zeby wspolczynniki z wiekszych wyrazow dobrze sie odjely
    for (int i = 0; i <= res.stopien; ++i) {
        res.a[i] = 0;
    }
    for (int j = 0; j <= max(u.stopien, v.stopien); ++j) {
        res.a[j] = u.a[j] - v.a[j];
    }
    //usuwanie wyrazow ze wspolczynnikiem 0 z przodu
    if (res.a[res.stopien] == 0) {
        while (res.a[res.stopien] == 0) {
            res.stopien -= 1;
        }
        wielomian xd = wielomian(res.stopien);
        copy(res.a, res.a + res.stopien + 1, xd.a);
        delete &res; //todo: check
        return xd;
    }
    return res;
}

wielomian operator*(const wielomian &u, const wielomian &v) {
    wielomian res = wielomian(u.stopien + v.stopien);
    //zeruje bo defaultowo jest 1
    res.a[res.stopien] = 0;
    for (int i = 0; i <= u.stopien; ++i) {
        for (int j = 0; j <= v.stopien; ++j) {
            res.a[i + j] += u.a[i] * v.a[j];
        }
    }
    return res;
}

wielomian operator*(const wielomian &u, double c) {
    if (c == 0)
        return wielomian(initializer_list<double>{0});
    wielomian res = u;
    for (int i = 0; i <= res.stopien; ++i) {
        res.a[i] *= c;
    }
    return res;
}

wielomian &wielomian::operator+=(const wielomian &v) {
    double *p = this->a;
    *this = *this + v;
    delete[] p;
    return *this;
}

wielomian &wielomian::operator-=(const wielomian &v) {
    double *p = this->a;
    *this = *this - v;
    delete[] p;
    return *this;
}

wielomian &wielomian::operator*=(const wielomian &v) {
    double *p = this->a;
    *this = *this * v;
    delete[] p;
    return *this;
}

wielomian &wielomian::operator*=(double c) {
    double *p = this->a;
    *this = *this * c;
    delete[] p;
    return *this;
}

double wielomian::operator()(double x) const {
    double res = this->a[this->stopien];
    for (int i = this->stopien - 1; i >= 0; --i) {
        res = res * x + this->a[i];
    }
    return res;
}

double &wielomian::operator[](int i) const {
    return a[i];
}
