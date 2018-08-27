#ifndef UNIQUE_ID_BIND_H
#define UNIQUE_ID_BIND_H

#ifdef __cplusplus
extern "C" {
#endif

/// <summary>
/// </summary>
/**
 * \brief 
 * \param label 
 * \return 
 */
void* unique_id_c(const char* label);

/**
 * \brief Create the UniqueId object
 * \param id String to use 
 * \return Pointer to the new object
 */
void unique_id_release_c(const void* id);

/**
 * \brief Get the 32 bits Id
 * \param id The id object pointer
 * \return A 32 bits number or 0, on error
 */
unsigned int unique_id_get(const void* id);

#ifdef USE_64
/**
 * \brief Get the 64 bits Id
 * \param id The id object pointer
 * \return A 64 bits number or 0, on error
 */
	unsigned long long unique_id_get64(const void *id);
#endif

#ifdef __cplusplus
}
#endif

#endif
