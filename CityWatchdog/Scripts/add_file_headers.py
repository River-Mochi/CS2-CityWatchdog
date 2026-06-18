"""
Add standard River-Mochi MIT file headers to C# files.

Dry run by default.

Common use:
  py -3 CityWatchdog/Scripts/add_file_headers.py
  py -3 CityWatchdog/Scripts/add_file_headers.py --apply
  py -3 CityWatchdog/Scripts/add_file_headers.py --apply --replace-existing
  py -3 CityWatchdog/Scripts/add_file_headers.py --check

Behavior:
  - Adds the header to .cs files that do not have one.
  - Skips files that already have a <copyright file= header.
  - Replaces existing top-of-file copyright headers only when --replace-existing is used.
  - Does not remove old "// File: ..." lines.
  - Does not try to manage repo-wide encoding or line-ending policy.
"""

from __future__ import annotations

import argparse
import re
import sys
from pathlib import Path


HEADER_TEMPLATE = """// <copyright file="{file_name}" company="River-Mochi">
// Copyright (c) {year} River-Mochi.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

"""

SKIP_DIRS = {
    ".git",
    ".vs",
    "bin",
    "obj",
    "generated",
    "node_modules",
    "packages",
}

COPYRIGHT_BLOCK_RE = re.compile(
    r"^\s*//\s*<copyright file=.*?//\s*</copyright>\s*\n*",
    re.DOTALL,
)


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


def has_copyright_header(text: str) -> bool:
    """Return true if a copyright header appears near the top of the file."""
    return "<copyright file=" in text[:1000]


def remove_existing_header(text: str) -> str:
    """Remove a top-of-file copyright block if present."""
    return COPYRIGHT_BLOCK_RE.sub("", text, count=1)


def process_file(path: Path, year: int, replace_existing: bool) -> tuple[bool, str]:
    """Return whether the file would change and the new file text."""
    original = path.read_text(encoding="utf-8")
    text = original

    header_exists = has_copyright_header(text)

    if header_exists and not replace_existing:
        return False, original

    if header_exists and replace_existing:
        text = remove_existing_header(text)

    # Make sure the copyright header starts on line 1.
    text = text.lstrip("\n")

    header = HEADER_TEMPLATE.format(file_name=path.name, year=year)
    new_text = header + text

    return new_text != original, new_text


def main() -> int:
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

    for path in sorted(root.rglob("*.cs")):
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
            path.write_text(new_text, encoding="utf-8", newline="")
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
