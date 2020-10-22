#include <iostream>
#include <string>
#include <fstream>
#include <memory>
#include <vector>

using namespace std;

class line_writer
{
private:
    ofstream *file;

public:
    line_writer(string path, ios_base::openmode mode)
    {
        try
        {
            this->file = new ofstream(path.c_str(), mode);
        }
        catch (const ofstream::failure &)
        {
            cerr << "błąd przy otwieraniu pliku" << endl;
        }
    }
    ~line_writer()
    {
        this->file->close();
        delete this->file;
        cerr << "destruktor" << endl;
    }
    void write(string msg)
    {
        *this->file << msg;
    }
};

int main()
{
    vector<shared_ptr<line_writer>> ptrs;
    auto lw = make_shared<line_writer>("test.txt", ios::out | ios::trunc);
    for (int i = 0; i < 5; ++i)
    {
        ptrs.emplace_back(lw);
    }
    for (auto ptr : ptrs)
    {
        ptr->write("essa\n");
    }

    ptrs[2] = nullptr;
    for (auto ptr : ptrs)
    {
        if (ptr != nullptr)
            ptr->write("essa2\n");
    }
}