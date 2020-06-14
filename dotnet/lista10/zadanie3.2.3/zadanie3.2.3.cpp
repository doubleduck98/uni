#include <iostream>
#include <random>
#include <string>
#include <windows.h>


using namespace std;

HANDLE mutex, tyton, papier, zapalki, koniecPalenia, palaczTyton, palaczPapier, palaczZapalki;
BOOL papierDostepny, tytonDostepny, zapalkiDostepne;

VOID Agent(LPVOID* args) {
	while (TRUE) {
		auto wybor = rand() % 3;
		WaitForSingleObject(koniecPalenia, INFINITE);
		if (wybor == 0) {
			ReleaseSemaphore(tyton, 1, NULL);
			ReleaseSemaphore(papier, 1, NULL);
		}
		else if (wybor == 1) {
			ReleaseSemaphore(zapalki, 1, NULL);
			ReleaseSemaphore(papier, 1, NULL);
		}
		else {
			ReleaseSemaphore(zapalki, 1, NULL);
			ReleaseSemaphore(tyton, 1, NULL);
		}
	}
}

VOID Zapal(string kto) {
	cout << kto << " skreca i zapala papierosa." << endl;
	Sleep(500);
}

VOID PalaczZZapalkami(LPVOID* args) {
	while (TRUE) {
		WaitForSingleObject(palaczZapalki, INFINITE);
		Zapal("Palacz z zapalkami");
		ReleaseSemaphore(koniecPalenia, 1, NULL);
	}
}

VOID PodawaczZap(LPVOID* args) {
	while (TRUE) {
		WaitForSingleObject(zapalki, INFINITE);
		WaitForSingleObject(mutex, INFINITE);
		if (papierDostepny) {
			papierDostepny = FALSE;
			ReleaseSemaphore(palaczTyton, 1, NULL);
		}
		else if (tytonDostepny) {
			tytonDostepny = FALSE;
			ReleaseSemaphore(palaczPapier, 1, NULL);
		}
		else {
			zapalkiDostepne = TRUE;
		}

		ReleaseMutex(mutex);
	}
}

VOID PalaczZTytoniem(LPVOID* args) {
	while (TRUE) {
		WaitForSingleObject(palaczTyton, INFINITE);
		Zapal("Palacz z tytoniem");
		ReleaseSemaphore(koniecPalenia, 1, NULL);
	}
}

VOID PodawaczTyt(LPVOID* args) {
	while (TRUE) {
		WaitForSingleObject(tyton, INFINITE);
		WaitForSingleObject(mutex, INFINITE);
		if (papierDostepny) {
			papierDostepny = FALSE;
			ReleaseSemaphore(palaczZapalki, 1, NULL);
		}
		else if (zapalkiDostepne) {
			zapalkiDostepne = FALSE;
			ReleaseSemaphore(palaczPapier, 1, NULL);
		}
		else {
			tytonDostepny = TRUE;
		}

		ReleaseMutex(mutex);
	}
}

VOID PalaczZPapierem(LPVOID* args) {
	while (TRUE) {
		WaitForSingleObject(palaczPapier, INFINITE);
		Zapal("Palacz z papierem");
		ReleaseSemaphore(koniecPalenia, 1, NULL);
	}
}

VOID PodawaczPap(LPVOID* args) {
	while (TRUE) {
		WaitForSingleObject(papier, INFINITE);
		WaitForSingleObject(mutex, INFINITE);
		if (tytonDostepny) {
			tytonDostepny = FALSE;
			ReleaseSemaphore(palaczZapalki, 1, NULL);
		}
		else if (zapalkiDostepne) {
			zapalkiDostepne = FALSE;
			ReleaseSemaphore(palaczTyton, 1, NULL);
		}
		else {
			papierDostepny = TRUE;
		}

		ReleaseMutex(mutex);
	}
}

VOID Init() {
	mutex = CreateMutex(NULL, FALSE, NULL);
	tyton = CreateSemaphore(NULL, 0, 1, NULL);
	papier = CreateSemaphore(NULL, 0, 1, NULL);
	zapalki = CreateSemaphore(NULL, 0, 1, NULL);
	palaczTyton = CreateSemaphore(NULL, 0, 1, NULL);
	palaczPapier = CreateSemaphore(NULL, 0, 1, NULL);
	palaczZapalki = CreateSemaphore(NULL, 0, 1, NULL);
	koniecPalenia = CreateSemaphore(NULL, 1, 1, NULL);
	papierDostepny = tytonDostepny = zapalkiDostepne = FALSE;
}

void Run() {
	HANDLE hT[7];
	hT[0] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)PalaczZTytoniem, NULL, 0, NULL);
	hT[1] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)PodawaczTyt, NULL, 0, NULL);
	hT[2] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)PalaczZZapalkami, NULL, 0, NULL);
	hT[3] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)PodawaczZap, NULL, 0, NULL);
	hT[4] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)PalaczZPapierem, NULL, 0, NULL);
	hT[5] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)PodawaczPap, NULL, 0, NULL);
	hT[6] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)Agent, NULL, 0, NULL);
	WaitForMultipleObjects(7, hT, TRUE, INFINITE);
}

int main()
{
	Init();
	Run();
}

// Uruchomienie programu: Ctrl + F5 lub menu Debugowanie > Uruchom bez debugowania
// Debugowanie programu: F5 lub menu Debugowanie > Rozpocznij debugowanie

// Porady dotyczące rozpoczynania pracy:
//   1. Użyj okna Eksploratora rozwiązań, aby dodać pliki i zarządzać nimi
//   2. Użyj okna programu Team Explorer, aby nawiązać połączenie z kontrolą źródła
//   3. Użyj okna Dane wyjściowe, aby sprawdzić dane wyjściowe kompilacji i inne komunikaty
//   4. Użyj okna Lista błędów, aby zobaczyć błędy
//   5. Wybierz pozycję Projekt > Dodaj nowy element, aby utworzyć nowe pliki kodu, lub wybierz pozycję Projekt > Dodaj istniejący element, aby dodać istniejące pliku kodu do projektu
//   6. Aby w przyszłości ponownie otworzyć ten projekt, przejdź do pozycji Plik > Otwórz > Projekt i wybierz plik sln
