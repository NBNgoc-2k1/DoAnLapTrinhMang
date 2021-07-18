#include <iostream>
#include <stdio.h>
#include <stdlib.h>
using namespace std;

int numberinInteger(int sample);
void SetMatrixNegative(int** matrix, int column, int row);
int FIFOmethod(int** matrix, int column, int row, int* array);
int LRAmethod(int** matrix, int column, int row, int* array);
int OPTmethod(int** matrix, int column, int row, int* array);
void CreateArrayWithInt(int* array, int n,int numberinInteger);
void PrintResult(int** matrix, int column, int row, int* array);
int FindReplacePos(int** matrix, int* array, int column, int row, int currentIndex, string method);

int main() {
	int refSeqOption = 0, algorithmOption = 0;
	int pageFrame,numberElementRefSeq = 11;
	int *refSeq = new int[numberElementRefSeq];
	int** result;
	cout << "--- Page Replacement algorithm ---\n";
	cout << "1. Default reference sequence\n";
	cout << "2. Manual input sequence\n";
	cin >> refSeqOption;
	switch (refSeqOption)
	{
	case 1: {
		int studentId;
		int numberinStudentId;
		cout << "Enter your student ID:";
		cin >> studentId;
		system("CLS");
		numberinStudentId = numberinInteger(studentId);
		int* arrayStudentId = new int[numberinStudentId];
		CreateArrayWithInt(arrayStudentId, studentId,numberinStudentId);
		for (int i = 0; i < numberinStudentId; i++) {
				refSeq[i] = arrayStudentId[i];
		}
		for (int i = numberinStudentId; i < numberElementRefSeq; i++) {
			if (i < numberElementRefSeq - 1) {
				refSeq[i] = 0;
			}
			if (i == numberElementRefSeq - 1)
				refSeq[i] = 7;
		}
		break;
	}
	case 2: {
		int numberElementInRefSeq;
		cout << "Enter the number of refernce sequence:";
		cin >> numberElementInRefSeq;
		system("CLS");
		numberElementRefSeq = numberElementInRefSeq;
		refSeq = new int(numberElementInRefSeq);
		for (int i = 0; i < numberElementInRefSeq; i++) {
			cin >> refSeq[i];
		}
		break;
	}
	default:
		break;
	}
	cout << "--- Page Replacement algorithm ---\n";
	cout << "Input Page Frame:";
	cin >> pageFrame;
	system("CLS");
	result = new int*[numberElementRefSeq];
	for (int i = 0; i < numberElementRefSeq; i++) {
		result[i] = new int[pageFrame];
	}
	SetMatrixNegative(result, numberElementRefSeq, pageFrame);
	int numberFaults = 0;
	cout << "--- Page Replacement algorithm ---\n";
	cout << "1. FIFO algorithm\n";
	cout << "2. OPT algorithm\n";
	cout << "3. LRA algorithm\n";
	cin >> algorithmOption;
	system("CLS");
	switch (algorithmOption)
	{
	case 1: {
		numberFaults = FIFOmethod(result, numberElementRefSeq, pageFrame, refSeq);
		break;
	}
	case 2: {
		numberFaults = OPTmethod(result, numberElementRefSeq, pageFrame, refSeq);
		break;
	}
	case 3: {
		numberFaults = LRAmethod(result, numberElementRefSeq, pageFrame, refSeq);
		break;
	}
	default:
		break;
	}
	PrintResult(result, numberElementRefSeq, pageFrame, refSeq);
	cout << "Number of Page Fault: " << numberFaults;
	for (int i = 0; i < numberElementRefSeq; i++)
		delete[] result[i];

	delete[] refSeq;
	delete[] result;
	return 0;
}

int numberinInteger(int sample) {
	int count = 0;
	while (sample >= 10) {
		sample /= 10;
		count++;
	}
	return count + 1;
}

void CreateArrayWithInt(int* array, int n, int numberinInteger) {
	int index = numberinInteger - 1;
	while (n > 0 && index >= 0) {
		int digit = n % 10;
		n /= 10;
		array[index] = digit;
		index--;
	}
}

void PrintResult(int** matrix, int column, int row, int* array) {
	cout << "--- Page Replacement algorithm ---\n";
	for (int i = 0; i < column; i++) {
		cout << array[i] << " ";
	}
	cout << "\n";
	for (int i = 0; i < row; i++) {
		for (int j = 0; j < column; j++) {
				cout << matrix[j][i] << " ";
		}
		cout << "\n";
	}
	cout << "* * * * * * *     * * \n";
}

void SetMatrixNegative(int** matrix, int column, int row) {
	for (int i = 0; i < column; i++) {
		for (int j = 0; j < row; j++) {
			matrix[i][j] = -1;
		}
	}
}

int FIFOmethod(int **matrix,int column,int row, int *array) {
	int fault = 0;
	int index = 0;
	for (int i = 0; i < column; i++) {
		bool isExist = false;
		for (int j = 0; j < row; j++) {
			if (array[i] == matrix[i][j]) {
				isExist = true;
				break;
			}
		}
		if (!isExist) {
			matrix[i][index] = array[i];
			fault++;
			if (index < row - 1)
				index++;
			else index = 0;
		}
		if (i < column - 1) {
			for (int j = 0; j < row; j++) {
				matrix[i + 1][j] = matrix[i][j];
			}
		}
	}
	return fault;
}
int LRAmethod(int** matrix, int column, int row, int* array) {
	int fault = 0;
	string algorithm = "LRA";
	for (int i = 0; i < column; i++) {
		bool isExist = false;
		bool isFull = true;
		int replacedIndex = i;
		for (int j = 0; j < row; j++) {
			if (array[i] == matrix[i][j]) {
				isExist = true;
				break;
			}
			if (matrix[i][j] < 0)
				isFull = false;
		}
		if (!isExist) {
			if (isFull)
				replacedIndex = FindReplacePos(matrix, array, column, row, i,algorithm);
			matrix[i][replacedIndex] = array[i];
			fault++;
		}
		if (i < column - 1) {
			for (int j = 0; j < row; j++) {
				matrix[i + 1][j] = matrix[i][j];
			}
		}
	}
	return fault;
}
int OPTmethod(int** matrix, int column, int row, int* array) {
	int faults = 0;
	string algorithm = "OPT";
	for (int i = 0; i < column; i++) {
		bool isExist = false;
		bool isFull = true;
		int replacedIndex = i;
		for (int j = 0; j < row; j++) {
			if (array[i] == matrix[i][j]) {
				isExist = true;
				break;
			}
			if (matrix[i][j] < 0)
				isFull = false;
		}
		if (!isExist) {
			if (isFull)
				replacedIndex = FindReplacePos(matrix, array, column, row, i, algorithm);
			matrix[i][replacedIndex] = array[i];
			faults++;
		}
		if (i < column - 1) {
			for (int j = 0; j < row; j++) {
				matrix[i + 1][j] = matrix[i][j];
			}
		}
	}
	return faults;
}

int FindReplacePos(int** matrix, int* array, int column, int row, int currentIndex,string method) {
	int* mostRecentTime = new int[row];
	for (int j = 0; j < row; j++) {
		mostRecentTime[j] = -1;
	}
	int replacePos = 0;

	if (method == "LRA") {
		for (int j = 0; j < row; j++) {
			for (int i = 0; i <= currentIndex; i++) {
				if (array[i] == matrix[currentIndex][j])
					mostRecentTime[j] = i;
			}
		}
		for (int i = 1; i < row; i++) {
			if (mostRecentTime[i] < mostRecentTime[replacePos])
				replacePos = i;
		}
	}
	if (method == "OPT") {
		for (int j = 0; j < row; j++) {
			for (int i = currentIndex; i < column; i++) {
				if (array[i] == matrix[currentIndex][j])
					mostRecentTime[j] = i;
			}
		}
		for (int i = 0; i < row; i++) {
			if (mostRecentTime[i] > mostRecentTime[replacePos]) 
				replacePos = i;
			if (mostRecentTime[i] < 0) {
				replacePos = i;
				break;
			}
		}
	}

	delete[] mostRecentTime;
	return replacePos;
}
