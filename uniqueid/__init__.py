"""UniqueId: create a unique 32- or 64-bit integer from a string via MD5(ASCII(s))."""

import hashlib

__all__ = ["UniqueId"]

_INVALID_MSG = "Invalid input string. Couldn't be empty or white space."


def _create_md5(s: str) -> str:
    return hashlib.md5(s.encode("ascii")).hexdigest()


class UniqueId:
    """
    Create unique 32- and 64-bit integer ids from a string.
    Uses MD5(ASCII(input)); first 8 hex chars → 32-bit id, first 16 → 64-bit id.
    """

    def __init__(self, s: str) -> None:
        if s is None or not s.strip():
            raise ValueError(_INVALID_MSG)
        self._origin = s
        self._hash = _create_md5(s)
        self._id = int(self._hash[:8], 16) & 0xFFFFFFFF
        self._id64 = int(self._hash[:16], 16) & 0xFFFFFFFFFFFFFFFF

    def get_origin(self) -> str:
        """Return the original input string."""
        return self._origin

    def get_id(self) -> int:
        """Return the 32-bit id."""
        return self._id

    def get_id64(self) -> int:
        """Return the 64-bit id."""
        return self._id64

    def get_hash(self) -> str:
        """Return the MD5 hash as a hex string."""
        return self._hash
