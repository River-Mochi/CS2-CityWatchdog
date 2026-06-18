#!/usr/bin/env python3
"""
Add standard River-Mochi MIT file headers to C# files.

Dry run by default.
Use --apply to write changes.
Use --replace-existing to replace an existing top-of-file copyright block.
"""

from __future__ import annotations

import argparse
import re
from pathlib import Path


HEADER_TEMPLATE = """// <copyright file="{file_name}" company="River-Mochi">
// Copyright (c) {year} River-Mochi. Licensed under MIT License.
// See LICENSE file in the project root for full info. License must be included in all copies from this code.
// </copyright>

"""

SKIP_DIRS = {
    ".git",
    ".vs",
    "bin",
    "obj",
    "Generated",
    "node_modules",
    "packages",
}

COPYRIGHT_BLOCK_RE = re.compile(
    r"^\ufeff?\s*//\s*<copyright file=.*?//\s*</copyright>\s*\n*",
    re.DOTALL,
)


def normalize_lf(text: str) -> str:
    """Normalize all line endings to LF."""
    return text.replace("\r\n", "\n").replace("\r", "\n")


def should_skip(path: Path) -> bool:
    """Return true for generated/build files that should not be edited."""
    if path.name.endswith(".g.cs"):
        return True

    return any(part in SKIP_DIRS for part in path.parts)


def remove_existing_header(text: str) -> str:
    """Remove a top-of-file copyright block if present."""
    return COPYRIGHT_BLOCK_RE.sub("", text, count=1)


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--apply", action="store_true", help="Write changes.")
    parser.add_argument(
        "--replace-existing",
        action="store_true",
        help="Replace existing top-of-file copyright headers.",
    )
    parser.add_argument("--root", default=".", help="Repo root. Default: current directory.")
    parser.add_argument("--year", type=int, default=2026)
    args = parser.parse_args()

    root = Path(args.root).resolve()
    changed = 0

    for path in sorted(root.rglob("*.cs")):
        rel = path.relative_to(root)

        if should_skip(rel):
            continue

        original = path.read_text(encoding="utf-8-sig")
        text = normalize_lf(original)

        first_chunk = text[:1000]
        has_header = "<copyright file=" in first_chunk

        if has_header and not args.replace_existing:
            continue

        if args.replace_existing:
            text = remove_existing_header(text)

        # Make sure the header starts on line 1.
        text = text.lstrip("\n")

        header = HEADER_TEMPLATE.format(file_name=path.name, year=args.year)
        new_text = header + text

        if new_text != original:
            changed += 1
            if args.apply:
                path.write_text(new_text, encoding="utf-8", newline="\n")
                print(f"Updated: {rel}")
            else:
                print(f"Would update: {rel}")

    if not args.apply:
        print()
        print(f"Dry run only. {changed} file(s) would be updated.")
        print("Re-run with --apply to write changes.")
    else:
        print()
        print(f"Updated {changed} file(s).")

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
