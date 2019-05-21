//
// Created by szipi on 12.03.2019.
//

#ifndef LISTA3_ODCINEK_H
#define LISTA3_ODCINEK_H

#include "punkt.h"

class odcinek {

private:
    punkt a;
    punkt b;
    friend std::ostream& operator<<(std::ostream&, const odcinek&);

public:
    odcinek(punkt a, punkt b);
    odcinek(const odcinek &o);
    punkt get_a(){
        return a;
    }
    punkt get_b(){
        return b;
    }
    void przesun(double wx, double wy);
    void obroc(punkt p, double theta);
    double dlugosc_odcinka();
    bool czy_punkt_lezy_na_odcinku(punkt p);
    punkt srodek_odcinka();
};

inline bool czy_rownolegle(odcinek x, odcinek y){
    double m1 = (x.get_a().get_y() - x.get_b().get_y()) / (x.get_a().get_x() - x.get_b().get_x());
    double m2 = (y.get_a().get_y() - y.get_b().get_y()) / (y.get_a().get_x() - y.get_b().get_x());
    return m1 == m2;
}

inline bool czy_prostopadle(odcinek x, odcinek y){
    double m1 = (x.get_a().get_y() - x.get_b().get_y()) / (x.get_a().get_x() - x.get_b().get_x());
    double m2 = (y.get_a().get_y() - y.get_b().get_y()) / (y.get_a().get_x() - y.get_b().get_x());
    return m1 == -m2;
}


#endif //LISTA3_ODCINEK_H
