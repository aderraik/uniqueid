#ifndef UNIQUEID_H
#define UNIQUEID_H

#include <string>
#include <sstream>
#include <stdexcept> // for use of std::invalid_argument

#include "md5.h"

class unique_id {

private:
	/// <summary>
	/// The origin string
	/// </summary>
	std::string origin_;

#ifdef USE_64
	/// <summary>
	/// Return the 64bits created Id
	/// </summary>
	/// <returns></returns>
	unsigned long long id64_;
#endif

	/// <summary>
	/// Return the 32bits created Id
	/// </summary>
	/// <returns></returns>
	unsigned int id_;

	/// <summary>
	/// Return the MD5 hash created
	/// </summary>
	/// <returns></returns>
	std::string hash_;

public:
	/// <summary>
	/// The origin string
	/// </summary>
	std::string get_origin() const { return origin_; }

#ifdef USE_64
	/// <summary>
	/// Return the 64bits created Id
	/// </summary>
	/// <returns></returns>
	unsigned long long get_id64() const { return id64_; }
#endif

	/// <summary>
	/// Return the 32bits created Id
	/// </summary>
	/// <returns></returns>
	unsigned get_id() const { return id_; }

	/// <summary>
	/// Return the MD5 hash created
	/// </summary>
	/// <returns></returns>
	std::string get_hash() const { return hash_; }

	/// <summary>
	/// Create the UniqueId object from a string
	/// </summary>
	/// <param name="str">String reference to create ids.</param>
	explicit unique_id(std::string str) : id_(0)
#ifdef USE_64
	, id64_(0)
#endif
	{
		// Check input
		if (str.empty())
			throw new std::invalid_argument("Invalid input string. Couldn't be empty or white space.");
		// Create the hash
		origin_ = str;
		hash_ = md5(str);

		// Create the 32bits id using the first 8 characters
		std::stringstream ss;
		ss << std::hex << hash_.substr(0, 8);
		ss >> id_;

#ifdef USE_64
		// Create the 64bits id using the first 16 characters
		id64_ = strtoull(hash_.substr(0, 16).c_str(), nullptr, 16);
#endif
	}

};

#endif
