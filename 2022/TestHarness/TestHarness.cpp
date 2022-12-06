#include <iostream>
#include <memory>
#include <string>
#include <vector>
#include "Day01.h"
#include <fstream>
int main()
{
	std::string line;
	std::vector<std::string> lines;

	std::ifstream input_file("C:/Projects/AdventOfCode/2022/Day01/input.txt");
	while (getline(input_file, line)) {
	//while (getline(std::cin, line)) {
		lines.push_back(line);
	}

	std::unique_ptr<Day01> solution;
	
	solution = std::make_unique<Day01>();

	std::unique_ptr<SolutionResponse> response = (*solution).RunSolution(lines);

	std::cout << (*response).GetOutputString();
}