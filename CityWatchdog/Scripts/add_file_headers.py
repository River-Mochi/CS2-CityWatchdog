# <copyright file="add_file_headers.py" company="River-Mochi">
# Copyright (c) 2026 River-Mochi, MIT License.
# See LICENSE file in the project root for full license info.
# </copyright>

"""
Add standard River-Mochi MIT file headers to source files.

Dry run by default.

Common use:
  py -3 CityWatchdog/Scripts/add_file_headers.py
  py -3 CityWatchdog/Scripts/add_file_headers.py --apply
  py -3 CityWatchdog/Scripts/add_file_headers.py --apply --replace-existing
  py -3 CityWatchdog/Scripts/add_file_headers.py --check
  py -3 CityWatchdog/Scripts/add_file_headers.py --check --replace-existing
"""

from __future__ import annotations

import argparse
import sys
from pathlib import Path


SKIP_DIRS = {
    ".git",
    ".vs",
    "bin",
    "obj",
    "generated",
    "node_modules",
    "packages",
}

SUPPORTED_SUFFIXES = {
    ".cs": "//",
    ".py": "#",
}


def find_repo_root(script_path: Path) -> Path:
    """Find the repo root by walking upward from this script."""
    for parent in [script_path.parent, *script_path.parents]:
        if (parent / ".git").exists() or (parent / ".editorconfig").exists():
            return parent

    return Path.cwd().resolve()


def should_skip(path: Path) -> bool:
    """Return true for generated/build files that should not be edited."""
    if path.name.endswith(".g.cs"):
        return True

    parts = {part.lower() for part in path.parts}
    return any(skip_dir in parts for skip_dir in SKIP_DIRS)


def normalize_lf(text: str) -> str:
    """Normalize line endings in files the script writes."""
    return text.replace("\r\n", "\n").replace("\r", "\n")


def has_copyright_header(text: str) -> bool:
    """Return true if a copyright header appears near the top of the file."""
    return "<copyright file=" in text[:1000]


def is_header_start(line: str) -> bool:
    """Return true for a copyright header opening line."""
    stripped = line.strip()
    return stripped.startswith("// <copyright file=") or stripped.startswith("# <copyright file=")


def is_header_end(line: str) -> bool:
    """Return true for a copyright header closing line."""
    stripped = line.strip()
    return stripped == "// </copyright>" or stripped == "# </copyright>"


def remove_existing_header(text: str) -> str:
    """Remove an existing top-of-file copyright block, including bad blank-line versions."""
    lines = text.split("\n")

    start = 0
    while start < len(lines) and lines[start].strip() == "":
        start += 1

    if start >= len(lines) or not is_header_start(lines[start]):
        return text

    end = start
    while end < len(lines):
        if is_header_end(lines[end]):
            end += 1
            break

        end += 1

    while end < len(lines) and lines[end].strip() == "":
        end += 1

    return "\n".join(lines[end:])


def make_header(path: Path, year: int) -> str:
    """Create the exact header for this source file."""
    prefix = SUPPORTED_SUFFIXES[path.suffix.lower()]

    return (
        f'{prefix} <copyright file="{path.name}" company="River-Mochi">\n'
        f"{prefix} Copyright (c) {year} River-Mochi, MIT License.\n"
        f"{prefix} See LICENSE file in the project root for full license info.\n"
        f"{prefix} </copyright>\n"
        "\n"
    )


def process_file(path: Path, year: int, replace_existing: bool) -> tuple[bool, str]:
    """Return whether the file would change and the new file text."""
    original = path.read_text(encoding="utf-8-sig")
    text = normalize_lf(original)

    header_exists = has_copyright_header(text)

    if header_exists and not replace_existing:
        return False, original

    if header_exists and replace_existing:
        text = remove_existing_header(text)

    text = text.lstrip("\n")
    new_text = make_header(path, year) + text

    return new_text != original, new_text


def main() -> int:
    """Run the file header tool."""
    default_root = find_repo_root(Path(__file__).resolve())

    parser = argparse.ArgumentParser()
    parser.add_argument("--apply", action="store_true", help="Write changes.")
    parser.add_argument("--check", action="store_true", help="Fail if files need header updates.")
    parser.add_argument(
        "--replace-existing",
        action="store_true",
        help="Replace existing top-of-file copyright headers.",
    )
    parser.add_argument(
        "--root",
        default=str(default_root),
        help="Repo root. Default: auto-detected from this script.",
    )
    parser.add_argument("--year", type=int, default=2026)
    args = parser.parse_args()

    if args.apply and args.check:
        print("ERROR: Use either --apply or --check, not both.", file=sys.stderr)
        return 2

    root = Path(args.root).resolve()
    changed_count = 0

    for path in sorted(root.rglob("*")):
        if not path.is_file():
            continue

        if path.suffix.lower() not in SUPPORTED_SUFFIXES:
            continue

        rel = path.relative_to(root)

        if should_skip(rel):
            continue

        changed, new_text = process_file(
            path=path,
            year=args.year,
            replace_existing=args.replace_existing,
        )

        if not changed:
            continue

        changed_count += 1

        if args.apply:
            path.write_text(new_text, encoding="utf-8", newline="\n")
            print(f"Updated: {rel}")
        else:
            print(f"Would update: {rel}")

    print()

    if args.check:
        if changed_count:
            print(f"Header check failed. {changed_count} file(s) need header updates.")
            return 1

        print("Header check passed.")
        return 0

    if args.apply:
        print(f"Updated {changed_count} file(s).")
    else:
        print(f"Dry run only. {changed_count} file(s) would be updated.")
        print("Re-run with --apply to write changes.")

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
