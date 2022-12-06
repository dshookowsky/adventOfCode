#include "IAdventSolution.h"

class Day02 : public IAdventSolution {
public:
	std::unique_ptr<SolutionResponse> RunSolution(std::vector<std::string> lines);
};