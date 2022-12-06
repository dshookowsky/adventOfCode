#include "SolutionResponse.h"
#include <string>

std::string m_responseString{};

SolutionResponse::SolutionResponse(std::string responseString) {
	m_responseString = responseString;
};

std::string SolutionResponse::GetOutputString() {
	return m_responseString;
}
