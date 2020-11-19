#include <algorithm>
#include <iostream>
#include <list>
#include <string>

using namespace std;

class Point {
   public:
    int red;
    int green;
    int blue;
    int x;
    int y;
    string name;

    Point(int x, int y, int r, int g, int b, string name) {
        this->x = x;
        this->y = y;
        this->red = r;
        this->green = g;
        this->blue = b;
        this->name = name;
    }

    float luminance() {
        return .3f * (float)red + .59f * (float)green + .11f * (float)blue;
    }

    friend ostream& operator<<(ostream& out, const Point& p) {
        out << p.name << " - (" << p.x << ", " << p.y << "), [r:" << p.red << ", g:"
            << p.green << ", b:" << p.blue << ']';
        return out;
    }
};

int main() {
    list<Point> l;
    l.emplace_back(Point(2, 0, 245, 168, 36, "ear"));
    l.emplace_back(Point(-16, -20, 122, 62, 188, "recipe"));
    l.emplace_back(Point(9, -14, 26, 128, 81, "mom"));
    l.emplace_back(Point(15, 14, 241, 246, 111, "affair"));
    l.emplace_back(Point(-8, -17, 29, 223, 79, "nation"));
    l.emplace_back(Point(8, -5, 178, 160, 142, "town"));
    l.emplace_back(Point(-16, -18, 184, 57, 242, "tea"));
    l.emplace_back(Point(1, 19, 47, 148, 144, "lab"));
    l.emplace_back(Point(8, 19, 173, 17, 196, "wood"));
    l.emplace_back(Point(-7, 16, 123, 22, 74, "mode"));
    l.emplace_back(Point(6, 12, 101, 184, 149, "shake"));
    l.emplace_back(Point(19, 0, 204, 245, 234, "bath"));
    l.emplace_back(Point(-5, 15, 163, 13, 239, "failure"));
    l.emplace_back(Point(17, 12, 200, 153, 111, "cheek"));
    l.emplace_back(Point(18, -3, 162, 43, 31, "pie"));
    l.emplace_back(Point(12, 1, 174, 131, 66, "fling"));
    l.emplace_back(Point(-20, -12, 195, 41, 150, "year"));

    l.remove_if([](Point p) { return p.name.length() > 5; });
    for (auto p : l) {
        cout << p << endl;
    }
    cout << "***" << endl;

    cout << "I cwiartka: ";
    auto r = count_if(l.begin(), l.end(),
                      [](Point p) { return p.x > 0 && p.y > 0; });
    cout << r << endl;

    cout << "II cwiartka: ";
    r = count_if(l.begin(), l.end(),
                 [](Point p) { return p.x < 0 && p.y > 0; });
    cout << r << endl;

    cout << "III cwiartka: ";
    r = count_if(l.begin(), l.end(),
                 [](Point p) { return p.x < 0 && p.y < 0; });
    cout << r << endl;
    
    cout << "IV cwiartka: ";
    r = count_if(l.begin(), l.end(),
                 [](Point p) { return p.x > 0 && p.y < 0; });
    cout << r << endl;
    cout << "***" << endl;

    l.sort([](Point p1, Point p2) { return p1.luminance() < p2.luminance(); });
    for (auto p : l) {
        cout << p.name << " - " << p.luminance() << endl;
    }
    cout << "***" << endl;

    list<Point> dark;
    copy_if(l.begin(), l.end(), back_inserter(dark),
            [](Point p) { return p.luminance() < 64.f; });
    for (auto p : dark) {
        cout << p.name << " - " << p.luminance() << endl;
    }
    cout << "***" << endl;
}