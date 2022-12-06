#include <memory>
#include <string>
#include <vector>
#include "SolutionResponse.h"
#pragma once

class IAdventSolution
{
public:
	virtual std::unique_ptr<SolutionResponse> RunSolution(std::vector<std::string> lines) = 0;
};

