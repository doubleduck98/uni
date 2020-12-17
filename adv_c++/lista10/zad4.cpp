#include <filesystem>
#include <iostream>

using namespace std;
namespace fs = std::filesystem;

int main(int argc, char* argv[]) {
    if (argc != 2) {
        cerr << "./zad2 <ścieżka katalogu>" << endl;
    }
    auto dir = fs::path(argv[1]);

    if (!fs::exists(dir)) {
        cerr << dir << " nie istnieje" << endl;
        return EXIT_FAILURE;
    } else if (!fs::is_directory(dir)) {
        cerr << dir << " nie jest katalogiem" << endl;
        return EXIT_FAILURE;
    }

    cout << fs::canonical(dir) << ": " << endl;
    for (auto& entry : fs::directory_iterator(dir)) {
        cout << entry.path().filename() << endl;
    }
}