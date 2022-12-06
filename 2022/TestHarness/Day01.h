#pragma once
#include <memory>
#include <string>
#include <vector>
#include "SolutionResponse.h"
class Day01 {

public:
	std::unique_ptr<SolutionResponse> RunSolution(std::vector<std::string> lines);
};

