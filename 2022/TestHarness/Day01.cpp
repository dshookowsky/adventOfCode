#include "IAdventSolution.h"
#include "Day01.h"
#include "SolutionResponse.h"
#include <algorithm>
#include <numeric>
#include <memory>
#include <string>
#include <sstream>
#include <vector>
std::unique_ptr<SolutionResponse> Day01::RunSolution(std::vector<std::string> lines) {
    std::vector<int> inventory;
    std::string line;

    int elfTotal{};
    for (std::string line : lines) {
        
        if (line.empty()) {
            inventory.push_back(elfTotal);
            elfTotal = 0;
        } else {
            int value = stoi(line);
            elfTotal += value;
        }
    }

    std::sort(inventory.begin(), inventory.end(), std::greater<int>());
    int value{};

    std::stringstream response;
    response << "Max: " << inventory[0] << "\n";
    response << "Top 3: " << std::accumulate(inventory.begin(), inventory.begin() + 3, 0);

    return std::make_unique<SolutionResponse>(response.str());
}
