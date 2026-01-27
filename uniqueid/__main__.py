"""CLI for UniqueId: python -m uniqueid <string>"""

import sys

from uniqueid import UniqueId


def usage(prog: str) -> None:
    print(f"Usage: {prog} <string>")


def main() -> int:
    prog = "uniqueid" if (sys.argv and sys.argv[0].endswith("__main__.py")) else (sys.argv[0] if sys.argv else "uniqueid")
    if len(sys.argv) != 2:
        usage(prog)
        return 1
    try:
        uid = UniqueId(sys.argv[1])
        print(f"Id 32bits: {uid.get_id()} 64bits: {uid.get_id64()}")
        return 0
    except ValueError as e:
        print(e)
        return 2


if __name__ == "__main__":
    sys.exit(main())
