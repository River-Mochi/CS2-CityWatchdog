# File: src/Scripts/wrap_log_calls_no_global.py
# Purpose: Find and safely rewrite simple one-line logger calls to CityWatchdog LogUtils wrappers.

from __future__ import annotations

import argparse
import re
from pathlib import Path
from typing import NamedTuple


class ConvertResult(NamedTuple):
    changed: bool
    new_line: str
    report: str | None


def is_excluded(path: Path) -> bool:
    parts = {part.lower() for part in path.parts}
    if "bin" in parts or "obj" in parts or ".vs" in parts or ".idea" in parts:
        return True

    normalized = str(path).replace("\\", "/").lower()
    if normalized.endswith("/utils/logutils.cs"):
        return True

    return False


def convert_line(line: str, path: Path, line_number: int) -> ConvertResult:
    if re.search(r"LogUtils\.(Info|Warn|Debug)\(", line):
        return ConvertResult(False, line, None)

    # Clean up any old generated prefix if it ever exists.
    cleaned = line.replace("global::CityWatchdog.", "")

    if re.search(r"\.(InfoFormat|WarnFormat|Error|ErrorFormat|Trace|Verbose)\(", cleaned):
        return ConvertResult(
            cleaned != line,
            cleaned,
            f"{path}:{line_number} MANUAL: {cleaned.strip()}",
        )

    patterns = [
        (
            re.compile(r"^(?P<indent>\s*)Logger\.(?P<level>Info|Warn|Debug)\((?P<arg>.+)\);\s*$"),
            "LogUtils.{level}(Mod.s_Log, () => {arg});",
        ),
        (
            re.compile(r"^(?P<indent>\s*)Mod\.s_Log\.(?P<level>Info|Warn|Debug)\((?P<arg>.+)\);\s*$"),
            "LogUtils.{level}(Mod.s_Log, () => {arg});",
        ),
        (
            re.compile(r"^(?P<indent>\s*)s_Log\.(?P<level>Info|Warn|Debug)\((?P<arg>.+)\);\s*$"),
            "LogUtils.{level}(Mod.s_Log, () => {arg});",
        ),
    ]

    for pattern, template in patterns:
        match = pattern.match(cleaned)
        if not match:
            continue

        arg = match.group("arg").strip()
        if "," in arg:
            return ConvertResult(
                cleaned != line,
                cleaned,
                f"{path}:{line_number} MANUAL comma args: {cleaned.strip()}",
            )

        level = match.group("level")
        indent = match.group("indent")
        new_line = indent + template.format(level=level, arg=arg)
        return ConvertResult(
            True,
            new_line,
            f"{path}:{line_number} AUTO {level}: {cleaned.strip()}",
        )

    if re.search(r"\b(Logger|Mod\.s_Log|s_Log)\.(Info|Warn|Debug)\(", cleaned):
        return ConvertResult(
            cleaned != line,
            cleaned,
            f"{path}:{line_number} MANUAL complex: {cleaned.strip()}",
        )

    return ConvertResult(cleaned != line, cleaned, None)


def find_src_root(script_path: Path) -> Path:
    # Expected location: src/Scripts/wrap_log_calls_no_global.py
    if script_path.parent.name.lower() == "scripts" and script_path.parent.parent.name.lower() == "src":
        return script_path.parent.parent

    # Fallback: current working directory can be repo root or src.
    cwd = Path.cwd().resolve()
    if cwd.name.lower() == "src":
        return cwd

    if (cwd / "src").is_dir():
        return cwd / "src"

    return cwd


def main() -> int:
    parser = argparse.ArgumentParser(
        description="Rewrite simple logger calls to LogUtils wrappers without global:: prefixes."
    )
    parser.add_argument("--apply", action="store_true", help="Write changes to files.")
    args = parser.parse_args()

    src_root = find_src_root(Path(__file__).resolve())

    reports: list[str] = []
    changed_files: list[Path] = []

    for path in sorted(src_root.rglob("*.cs")):
        if is_excluded(path):
            continue

        text = path.read_text(encoding="utf-8-sig")
        newline = "\r\n" if "\r\n" in text else "\n"
        lines = text.splitlines(keepends=False)

        changed = False
        new_lines: list[str] = []

        for index, line in enumerate(lines, start=1):
            result = convert_line(line, path, index)
            if result.report:
                reports.append(result.report)
            if result.changed:
                changed = True
            new_lines.append(result.new_line)

        if changed:
            changed_files.append(path)
            if args.apply:
                backup = path.with_name(path.name + ".logwrap.bak")
                if not backup.exists():
                    backup.write_text(text, encoding="utf-8")

                path.write_text(newline.join(new_lines) + newline, encoding="utf-8")

    report_path = src_root / "LogWrapReport.txt"
    report_path.write_text("\n".join(reports) + ("\n" if reports else ""), encoding="utf-8")

    print()
    print("Log wrap scan complete.")
    print(f"Source root: {src_root}")
    print(f"Report: {report_path}")
    print(f"Auto-change candidate files: {len(changed_files)}")
    print()

    if args.apply:
        print("Applied simple one-line replacements without global:: prefixes.")
        print("Backup files created beside changed files with .logwrap.bak suffix.")
    else:
        print("Dry run only. No files changed.")
        print("Run again with --apply to rewrite simple one-line calls.")

    print()
    print("Changed/candidate files:")
    for path in changed_files:
        print(f"  {path}")

    print()
    print("Manual-review lines are listed in LogWrapReport.txt.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
