#include "UniqueId.h"
#include "unique_id.h"

void* unique_id_c(const char *label)
{
	const auto id = new unique_id(label);
	return id;
}

void unique_id_release_c(const void* id)
{
	if (id == nullptr) return;

	const auto uid = (unique_id*)id;
	delete uid;
}

unsigned int unique_id_get(const void *id)
{
	if (id == nullptr) return 0;

	const auto uid = (unique_id*)id;
	return uid->get_id();
}

#ifdef USE_64
unsigned long long unique_id_get64(const void *id)
{
	if (id == nullptr) return 0;

	const auto uid = (unique_id*)id;
	return uid->get_id64();
}
#endif
