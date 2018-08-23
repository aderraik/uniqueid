#include "UniqueId.h"

static void usage(const char* prog)
{
	std::cout << "Usage: " << prog << " <string>" << std::endl;
}

int main(const int argc, char *args[])
{
	// Check parameters
	if (argc <= 1)
	{
		usage(args[0]);
		return 1;
	}

	// Generate the id
	try
	{
		const auto id = new unique_id(args[1]);
		std::cout << "Id 32bits: " << id->get_id();
#ifdef USE_64
		std::cout << " 64bits: " << id->get_id64();
#endif
		std::cout << std::endl;

		delete id;
	}
	catch (std::exception& exception)
	{
		std::cout << exception.what();
		return 2;
	}
	return 0;
}
