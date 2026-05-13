# File: src/Scripts/Wrap-LogCalls.ps1
# Purpose: Find and safely rewrite simple one-line logger calls to CityWatchdog LogUtils wrappers.

[CmdletBinding()]
param(
    [switch]$Apply,
    [switch]$IncludeDebugConsole
)

$ErrorActionPreference = "Stop"

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot "..")
$repoRoot = $repoRoot.Path

$scanRoots = @(
    (Join-Path $repoRoot ".")
)

if ($IncludeDebugConsole) {
    $scanRoots += (Join-Path $repoRoot "..\DebugConsole")
}

$excludePathParts = @(
    "\bin\",
    "\obj\",
    "\.vs\",
    "\.idea\",
    "\Utils\LogUtils.cs"
)

function Test-ExcludedPath {
    param([string]$Path)

    $normalized = $Path.Replace("/", "\")
    foreach ($part in $excludePathParts) {
        if ($normalized.IndexOf($part, [StringComparison]::OrdinalIgnoreCase) -ge 0) {
            return $true
        }
    }

    return $false
}

function Convert-LoggerLine {
    param(
        [string]$Line,
        [string]$Path,
        [int]$LineNumber
    )

    if ($Line -match "LogUtils\.(Info|Warn|Debug)\(") {
        return [pscustomobject]@{
            Changed = $false
            NewLine = $Line
            Report = $null
        }
    }

    # Skip obvious format/error APIs. These need manual review because parameter shapes differ.
    if ($Line -match "\.(InfoFormat|WarnFormat|Error|ErrorFormat|Trace|Verbose)\(") {
        if ($Line -match "\.(InfoFormat|WarnFormat|Error|ErrorFormat|Trace|Verbose)\(") {
            return [pscustomobject]@{
                Changed = $false
                NewLine = $Line
                Report = "$Path:$LineNumber MANUAL: $($Line.Trim())"
            }
        }
    }

    # Only rewrite one-line calls ending with a semicolon.
    # Avoid multiline lambdas, comments, and statements with extra chained calls.
    $patterns = @(
        @{
            Regex = '^(?<indent>\s*)Logger\.(?<level>Info|Warn|Debug)\((?<arg>.+)\);\s*$'
            Target = 'global::CityWatchdog.LogUtils.{0}(global::CityWatchdog.Mod.s_Log, () => {1});'
        },
        @{
            Regex = '^(?<indent>\s*)Mod\.s_Log\.(?<level>Info|Warn|Debug)\((?<arg>.+)\);\s*$'
            Target = 'global::CityWatchdog.LogUtils.{0}(global::CityWatchdog.Mod.s_Log, () => {1});'
        },
        @{
            Regex = '^(?<indent>\s*)s_Log\.(?<level>Info|Warn|Debug)\((?<arg>.+)\);\s*$'
            Target = 'global::CityWatchdog.LogUtils.{0}(global::CityWatchdog.Mod.s_Log, () => {1});'
        }
    )

    foreach ($pattern in $patterns) {
        $match = [regex]::Match($Line, $pattern.Regex)
        if (-not $match.Success) {
            continue
        }

        $arg = $match.Groups["arg"].Value.Trim()

        # Keep risky calls manual: comma usually means multiple args or format call.
        if ($arg.Contains(",")) {
            return [pscustomobject]@{
                Changed = $false
                NewLine = $Line
                Report = "$Path:$LineNumber MANUAL comma args: $($Line.Trim())"
            }
        }

        $level = $match.Groups["level"].Value
        $indent = $match.Groups["indent"].Value
        $replacement = $indent + [string]::Format($pattern.Target, $level, $arg)

        return [pscustomobject]@{
            Changed = $true
            NewLine = $replacement
            Report = "$Path:$LineNumber AUTO $level: $($Line.Trim())"
        }
    }

    if ($Line -match "\b(Logger|Mod\.s_Log|s_Log)\.(Info|Warn|Debug)\(") {
        return [pscustomobject]@{
            Changed = $false
            NewLine = $Line
            Report = "$Path:$LineNumber MANUAL complex: $($Line.Trim())"
        }
    }

    return [pscustomobject]@{
        Changed = $false
        NewLine = $Line
        Report = $null
    }
}

$files = foreach ($root in $scanRoots) {
    if (Test-Path $root) {
        Get-ChildItem -Path $root -Recurse -File -Filter "*.cs" |
            Where-Object { -not (Test-ExcludedPath $_.FullName) }
    }
}

$reports = New-Object System.Collections.Generic.List[string]
$changedFiles = New-Object System.Collections.Generic.List[string]

foreach ($file in $files) {
    $text = [System.IO.File]::ReadAllText($file.FullName)
    $newline = if ($text.Contains("`r`n")) { "`r`n" } else { "`n" }

    $lines = $text -split "`r?`n", -1
    $changed = $false

    for ($i = 0; $i -lt $lines.Count; $i++) {
        $result = Convert-LoggerLine -Line $lines[$i] -Path $file.FullName -LineNumber ($i + 1)

        if ($null -ne $result.Report) {
            $reports.Add($result.Report)
        }

        if ($result.Changed) {
            $lines[$i] = $result.NewLine
            $changed = $true
        }
    }

    if ($changed) {
        $changedFiles.Add($file.FullName)

        if ($Apply) {
            $backupPath = $file.FullName + ".logwrap.bak"
            if (-not (Test-Path $backupPath)) {
                Copy-Item -LiteralPath $file.FullName -Destination $backupPath
            }

            [System.IO.File]::WriteAllText($file.FullName, ($lines -join $newline), [System.Text.UTF8Encoding]::new($false))
        }
    }
}

$reportPath = Join-Path $repoRoot "LogWrapReport.txt"
$reports | Set-Content -Path $reportPath -Encoding UTF8

Write-Host ""
Write-Host "Log wrap scan complete."
Write-Host "Report: $reportPath"
Write-Host "Auto-change candidates: $($changedFiles.Count) file(s)."
Write-Host ""

if ($Apply) {
    Write-Host "Applied simple one-line replacements."
    Write-Host "Backup files created beside changed files with .logwrap.bak suffix."
}
else {
    Write-Host "Dry run only. No files changed."
    Write-Host "Run again with -Apply to rewrite simple one-line calls."
}

Write-Host ""
Write-Host "Changed/candidate files:"
foreach ($path in $changedFiles) {
    Write-Host "  $path"
}

Write-Host ""
Write-Host "Manual-review lines are listed in LogWrapReport.txt."
