#!/usr/local/bin/bash


set -Eeuo pipefail

# ------------------------------------------------------------
# Error reporting
# ------------------------------------------------------------

SCRIPT_NAME="$(basename "$0")"
CURRENT_STEP="initialization"

error_report() {
    local rc=$?
    local line="${1:-unknown}"
    local command="${BASH_COMMAND:-unknown}"

    # Avoid recursive ERR trap while reporting.
    trap - ERR
    {
        echo
        echo "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"
        echo "[FATAL] Ошибка выполнения скрипта"
        echo "Script : $SCRIPT_NAME"
        echo "Line   : $line"
        echo "Step   : $CURRENT_STEP"
        echo "Exit   : $rc"
        echo "Command: $command"
        echo "Log    : ${LOG:-не создан}"
        echo "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"
        if [[ -n "${LOG:-}" ]]; then
            echo "[FATAL] См. подробный журнал: $LOG" >&2
        fi
    } >&2
    exit "$rc"
}
trap 'error_report $LINENO' ERR

set -o errtrace

# ============================================================
# Auchan APK Reverse Engineering
# FreeBSD 15.x
#
# Usage:
#   ./decompile_auchan.sh ~/auchan.apk
#
# Optional:
#   ./decompile_auchan.sh ~/auchan.apk ~/AuchanReverseEngineering
# ============================================================

APP_NAME="AuchanReverseEngineering"
APK="${1:-$HOME/auchan.apk}"
ROOT="${2:-$HOME/$APP_NAME}"

JADX="${JADX:-jadx}"
APKTOOL="${APKTOOL:-apktool}"
# Поиск ILSpy на FreeBSD
ILSPYCMD="${ILSPYCMD:-}"

if [ -z "$ILSPYCMD" ]; then
    if command -v ilspycmd >/dev/null 2>&1; then
        ILSPYCMD="$(command -v ilspycmd)"
    elif [ -x "$HOME/.dotnet/tools/ilspycmd" ]; then
        ILSPYCMD="$HOME/.dotnet/tools/ilspycmd"
    elif [ -n "${DOTNET_CLI_HOME:-}" ] &&
         [ -x "$DOTNET_CLI_HOME/.dotnet/tools/ilspycmd" ]; then
        ILSPYCMD="$DOTNET_CLI_HOME/.dotnet/tools/ilspycmd"
    fi
fi

if [ -z "$ILSPYCMD" ] || [ ! -x "$ILSPYCMD" ]; then
    echo "ERROR: ilspycmd не найден!"
    echo "Проверь: $HOME/.dotnet/tools/ilspycmd"
    echo "Установка: dotnet tool install --global ilspycmd --version 9.1.0.7988"
    exit 1
fi

echo "ILSpy найден: $ILSPYCMD"
export DOTNET_ROLL_FORWARD=Major


mkdir -p "$ROOT/logs" "$ROOT/apk_analysis"

LOG="$ROOT/logs/decompile.log"
TEMP="$ROOT/tmp/apk"
DLL_DIR="$ROOT/dotnet/dll"
CS_DIR="$ROOT/dotnet/decompiled"
APKTOOL_DIR="$ROOT/apk_analysis/apktool"
JADX_DIR="$ROOT/apk_analysis/jadx"
NATIVE_DIR="$ROOT/native"
ASSEMBLY_PAYLOAD_DIR="$ROOT/dotnet/assembly_store_payloads"
ASSEMBLY_EXTRACT_DIR="$ROOT/dotnet/dll"

# ------------------------------------------------------------
# Logging
# ------------------------------------------------------------

mkdir -p "$ROOT/logs"

exec > >(tee -a "$LOG") 2>&1
echo "[INFO] Старт: $(date)"
echo "[INFO] Bash: $BASH_VERSION"
echo "[INFO] FreeBSD: $(uname -a)"
echo "[INFO] Лог: $LOG"

info() {
    echo
    echo "============================================================"
    echo "$1"
    echo "============================================================"
}

# Return success only when every report for a research stage already exists
# and is non-empty. Repeated runs then skip completed investigations.
reports_complete() {
    local report
    for report in "$@"; do
        [[ -s "$report" ]] || return 1
    done
    return 0
}

warn() {
    echo "[WARNING] $1"
}

fail() {
    echo "[ERROR] $1"
    exit 1
}

# ------------------------------------------------------------
# Check APK
# ------------------------------------------------------------

CURRENT_STEP="CHECK APK"
info "CHECK APK"

# Fingerprint the APK to reuse decompilation output only for the same input.
file_sha256() {
    if command -v sha256 >/dev/null 2>&1; then
        sha256 -q "$1"
    else
        sha256sum "$1" | awk '{print $1}'
    fi
}
APK_SHA256=""

if [[ ! -f "$APK" ]]; then
    fail "APK not found: $APK"
fi

APK="$(cd "$(dirname "$APK")" && pwd)/$(basename "$APK")"
APK_SHA256="$(file_sha256 "$APK")"
echo "APK SHA256: $APK_SHA256"

echo "APK: $APK"
echo "Output: $ROOT"

mkdir -p "$ROOT"

mkdir -p "$ROOT/apk_analysis" "$ROOT/logs"

if command -v sha256 >/dev/null 2>&1; then
    sha256 "$APK" > "$ROOT/apk_analysis/apk_sha256.txt"
elif command -v sha256sum >/dev/null 2>&1; then
    sha256sum "$APK" > "$ROOT/apk_analysis/apk_sha256.txt"
else
    echo "[ERROR] Не найдена утилита sha256 или sha256sum"
    exit 1
fi

# ------------------------------------------------------------
# Check tools
# ------------------------------------------------------------

CURRENT_STEP="CHECK TOOLS"
info "CHECK TOOLS"

check_command() {
    if command -v "$1" >/dev/null 2>&1; then
        echo "[OK] $1: $(command -v "$1")"
    else
        warn "$1 not found"
        return 1
    fi
}

check_command unzip || fail "Install unzip"
check_command git || fail "Install git"
check_command java || fail "Install OpenJDK"
check_command python3 || fail "Install Python 3"
check_command "$APKTOOL" || fail "Install apktool"
: # ILSpy уже найден и проверен выше

JADX_AVAILABLE=0

if check_command "$JADX"; then
    JADX_AVAILABLE=1
fi

DOTNET_ROLL_FORWARD=Major
export DOTNET_ROLL_FORWARD

# ------------------------------------------------------------
# Create directories
# ------------------------------------------------------------

CURRENT_STEP="CREATE DIRECTORIES"
info "CREATE DIRECTORIES"

mkdir -p write_reference_report write_reference_report write_reference_report write_reference_report write_reference_report write_reference_report write_reference_report write_reference_report write_reference_report write_reference_report \\
    "chequeNumber detail loading references" \\
    'chequeNumber|ChequeNumber|GetTransactionDetailsAsync|GetReceiptDetailsAsync|GetPurchaseDetailsAsync|TransactionDetails|ReceiptDetails|LoyaltyHistory|GetHistoryAsync|Task\.WhenAll|Parallel|foreach|SelectMany|OnAppearing|ItemTapped|SelectionChanged|Load.*Detail|Fetch.*Detail' \\
    "$DEEP_DIR/10_cheque_number_detail_loading_references.txt"\
    "needHash true response references" \\
    'needHash[[:space:]]*=[[:space:]]*true|needHash|NeedHash|checkphone|CheckPhone|HashResponse|PhoneCheck|Challenge|ClientAuth|clientauth' \\
    "$DEEP_DIR/09_needhash_true_response_references.txt"\
    "Device ID and UDID mapping references" \\
    'UDID|Udid|udid|DeviceId|DeviceID|device.?id|UniqueDevice|DeviceInfo|AndroidId|ANDROID_ID|Settings\.Secure|Secure\.AndroidId|IdentifierForVendor|GetIdentifier|InstallationId|device.?identifier' \\
    "$DEEP_DIR/08_device_id_udid_mapping_references.txt"\
    "Token20 client password references" \\
    'Token20|token20|Token20Password|ClientPassword|client.?password|PasswordHash|passwordHash|needHash|NeedHash|clientauth/token|Authorization|X-Token' \\
    "$DEEP_DIR/07_token20_client_password_references.txt"\
    "Loyalty history response references" \\
    'loyalty/history|LoymaxHistoryResponseDto|HistoryResponse|HistoryItem|GetHistoryAsync|GetTransactionDetailsAsync|TransactionDetailsDto|ReceiptDetails|ReceiptItem|ProductDto|ProductItem|ChequeNumber|ReceiptNumber' \\
    "$DEEP_DIR/06_loyalty_history_response_references.txt"\
    "Device ID, needHash and Token80 references" \\
    'device.?id|deviceid|UDID|Udid|UniqueDevice|DeviceInfo|AndroidId|ANDROID_ID|Settings\.Secure|needHash|NeedHash|Token20|token20|Token80|SavedToken80|ITokenService|clientauth/token|checkphone' \\
    "$DEEP_DIR/05_deviceid_needhash_token80_references.txt"\
    "Personal cabinet API references" \\
    'IPersonalCabinetApi|PersonalCabinetApi|PersonalCabinet.*UrlProvider|clientauth|clientprofile|BaseAddress|BaseUrl|BaseURL' \\
    "$DEEP_DIR/04_personal_cabinet_api_references.txt"\
    "Receipt item and detail references" \\
    'GetTransactionDetailsAsync|GetReceiptDetailsAsync|GetPurchaseDetailsAsync|TransactionDetails|ReceiptDetails|ReceiptItem|PurchaseItem|ChequeNumber|ReceiptNumber|ProductName|ProductDto|ProductItem|ItemName|Nomenclature|Sku|Barcode' \\
    "$DEEP_DIR/03_receipt_item_references.txt"\
    "Loymax URL provider references" \\
    'LoymaxLoyaltyProgramUrlProvider|Loymax.*UrlProvider|UrlProvider.*Loymax|ILoymaxLoyaltyApi|LoymaxLoyaltyApi|LoyaltyProgramDependencyRegistry' \\
    "$DEEP_DIR/02_loymax_registration_references.txt"\
    "PinInteractor.SendPin references" \\
    'PinInteractor|SendPin[[:space:]]*\(|BeginVerifyPhone|VerifyPhone|CheckPhone|RequestPin|SendPinAsync' \\
    "$DEEP_DIR/01_pin_interactor_references.txt"
    "$ROOT/original" \
    "$ROOT/tmp" \
    "$ROOT/apk_analysis/manifest" \
    "$ROOT/apk_analysis/resources" \
    "$ROOT/apk_analysis/apktool" \
    "$ROOT/apk_analysis/jadx" \
    "$ROOT/dotnet/dll" \
    "$ROOT/dotnet/decompiled" \
    "$ROOT/dotnet/metadata" \
    "$ROOT/native/arm64-v8a" \
    "$ROOT/scripts" \
    "$ROOT/api" \
    "$ROOT/docs" \
    "$ROOT/logs"

# ------------------------------------------------------------
# Extract APK
# ------------------------------------------------------------

CURRENT_STEP="EXTRACT APK"
info "EXTRACT APK"

rm -rf "$TEMP"
mkdir -p "$TEMP"

unzip -oq "$APK" -d "$TEMP"

unzip -l "$APK" > "$ROOT/apk_analysis/apk_file_list.txt"

# ------------------------------------------------------------
# APK metadata
# ------------------------------------------------------------

CURRENT_STEP="APK METADATA"
info "APK METADATA"

{
    echo "APK: $APK"
    echo "Date: $(date)"
    echo
    echo "SHA256:"
    cat "$ROOT/apk_analysis/apk_sha256.txt"
    echo
    echo "Package information:"
    grep -E 'package:|versionCode|versionName' \
        "$TEMP/AndroidManifest.xml" 2>/dev/null || true
} > "$ROOT/apk_analysis/metadata.txt"

# ------------------------------------------------------------
# Apktool
# ------------------------------------------------------------

CURRENT_STEP="APKTOOL DECOMPILATION"
info "APKTOOL DECOMPILATION"

APKTOOL_MARKER="$APKTOOL_DIR/.decompile_complete"
if [[ -s "$APKTOOL_DIR/AndroidManifest.xml" &&
      -s "$APKTOOL_DIR/apktool.yml" &&
      ( -d "$APKTOOL_DIR/res" || -d "$APKTOOL_DIR/smali" || -d "$APKTOOL_DIR/smali_classes2" ) &&
      ( ! -f "$APKTOOL_MARKER" || "$(cat "$APKTOOL_MARKER" 2>/dev/null)" == "$APK_SHA256" ) ]]; then
    if [[ ! -f "$APKTOOL_MARKER" ]]; then
        printf '%s\n' "$APK_SHA256" > "$APKTOOL_MARKER"
        echo "[SKIP] Найдена готовая декомпиляция Apktool от предыдущего запуска; добавлен маркер."
    else
        echo "[SKIP] Apktool уже декомпилировал этот APK; результат используется повторно."
    fi
else
    echo "[RUN] Apktool: результат отсутствует, неполный или относится к другому APK."
    rm -rf "$APKTOOL_DIR"
    if "$APKTOOL" d -f "$APK" -o "$APKTOOL_DIR"; then
        if [[ -s "$APKTOOL_DIR/AndroidManifest.xml" ]]; then
            printf '%s\n' "$APK_SHA256" > "$APKTOOL_MARKER"
            rm -f "$ROOT/apk_analysis/apktool_exit_code.txt"
            echo "[OK] Apktool completed; marker saved"
        else
            echo "[ERROR] Apktool завершился без AndroidManifest.xml; результат не будет считаться готовым."
            echo "incomplete" > "$ROOT/apk_analysis/apktool_exit_code.txt"
        fi
    else
        rc=$?
        echo "[ERROR] Apktool завершился с кодом $rc (см. журнал выше)"
        echo "$rc" > "$ROOT/apk_analysis/apktool_exit_code.txt"
        warn "Apktool failed; скрипт продолжает работу"
    fi
fi

if [[ -f "$APKTOOL_DIR/AndroidManifest.xml" ]]; then
    cp "$APKTOOL_DIR/AndroidManifest.xml" \
        "$ROOT/apk_analysis/manifest/AndroidManifest.xml"
fi

# ------------------------------------------------------------
# JADX
# ------------------------------------------------------------

CURRENT_STEP="JADX DECOMPILATION"
info "JADX DECOMPILATION"

if [[ "$JADX_AVAILABLE" -eq 1 ]]; then

    JADX_MARKER="$JADX_DIR/.decompile_complete"
    JADX_SOURCE_COUNT=0
    if [[ -d "$JADX_DIR" ]]; then
        JADX_SOURCE_COUNT="$(find "$JADX_DIR" -type f \( -name '*.java' -o -name '*.kt' \) | wc -l | tr -d ' ')"
    fi

    if [[ "$JADX_SOURCE_COUNT" -gt 0 &&
          ( ! -f "$JADX_MARKER" || "$(cat "$JADX_MARKER" 2>/dev/null)" == "$APK_SHA256" ) ]]; then
        if [[ ! -f "$JADX_MARKER" ]]; then
            printf '%s\n' "$APK_SHA256" > "$JADX_MARKER"
            echo "[SKIP] Найдена готовая декомпиляция JADX от предыдущего запуска; найдено исходников: $JADX_SOURCE_COUNT"
        else
            echo "[SKIP] JADX уже декомпилировал этот APK; найдено исходников: $JADX_SOURCE_COUNT"
        fi
    else
        echo "[RUN] JADX: результат отсутствует, неполный или относится к другому APK."
        rm -rf "$JADX_DIR"
        JADX_LOG="$ROOT/logs/jadx.log"
        if "$JADX" -d "$JADX_DIR" --show-bad-code "$APK" > >(tee "$JADX_LOG") 2>&1; then
            JADX_SOURCE_COUNT="$(find "$JADX_DIR" -type f \( -name '*.java' -o -name '*.kt' \) | wc -l | tr -d ' ')"
            if [[ "$JADX_SOURCE_COUNT" -gt 0 ]]; then
                printf '%s\n' "$APK_SHA256" > "$JADX_MARKER"
                rm -f "$ROOT/apk_analysis/jadx_exit_code.txt" "$ROOT/apk_analysis/jadx_errors.txt"
                echo "[OK] JADX completed; исходников: $JADX_SOURCE_COUNT"
            else
                echo "[ERROR] JADX завершился без Java/Kotlin исходников; результат не будет считаться готовым."
                echo "incomplete" > "$ROOT/apk_analysis/jadx_exit_code.txt"
            fi
        else
            rc=$?
            echo "[ERROR] JADX завершился с кодом $rc"
            echo "$rc" > "$ROOT/apk_analysis/jadx_exit_code.txt"
            grep -Ein 'ERROR|WARN|Exception|Caused by|failed|cannot|not supported' "$JADX_LOG" > "$ROOT/apk_analysis/jadx_errors.txt" || true
            echo "[INFO] Полный журнал JADX: $JADX_LOG"
            echo "[INFO] Выжимка ошибок JADX: $ROOT/apk_analysis/jadx_errors.txt"
            warn "JADX reported errors; скрипт продолжает работу"
        fi
    fi

else
    warn "JADX skipped"
fi

# ------------------------------------------------------------
# Extract DEX metadata
# ------------------------------------------------------------

CURRENT_STEP="DEX FILES"
info "DEX FILES"

find "$TEMP" -type f -name '*.dex' \
    > "$ROOT/apk_analysis/dex_files.txt"

cat "$ROOT/apk_analysis/dex_files.txt"

# ------------------------------------------------------------
# Extract available DLL files
# ------------------------------------------------------------

CURRENT_STEP="EXTRACT DOTNET DLL"
info "EXTRACT DOTNET DLL"

find "$TEMP" -type f -iname '*.dll' -print0 |
while IFS= read -r -d '' file; do

    name="$(basename "$file")"

    if [[ ! -f "$DLL_DIR/$name" ]]; then
        cp "$file" "$DLL_DIR/$name"
        echo "Extracted: $name"
    fi

done

# ------------------------------------------------------------
# Reuse previously extracted DLLs
# ------------------------------------------------------------

CURRENT_STEP="CHECK PREVIOUS DLL EXTRACTION"
info "CHECK PREVIOUS DLL EXTRACTION"

if [[ -d "$HOME/auchan_dll" ]]; then

    find "$HOME/auchan_dll" -type f -iname '*.dll' -print0 |
    while IFS= read -r -d '' file; do

        name="$(basename "$file")"

        if [[ ! -f "$DLL_DIR/$name" ]]; then
            cp "$file" "$DLL_DIR/$name"
            echo "Imported previous DLL: $name"
        fi

    done

fi

DLL_COUNT="$(find "$DLL_DIR" -type f -iname '*.dll' | wc -l | tr -d ' ')"

echo "DLL count: $DLL_COUNT"

if [[ "$DLL_COUNT" -eq 0 ]]; then
    warn "No standalone DLL files found."
    warn "Standalone DLL files are absent; the Assembly Store extraction stage will inspect native libraries next."
fi

# ------------------------------------------------------------
# Native libraries
# ------------------------------------------------------------

CURRENT_STEP="NATIVE LIBRARIES"
info "NATIVE LIBRARIES"

for ABI in arm64-v8a armeabi-v7a x86 x86_64; do

    SOURCE="$TEMP/lib/$ABI"

    if [[ -d "$SOURCE" ]]; then

        DEST="$ROOT/native/$ABI"

        mkdir -p "$DEST"

        find "$SOURCE" -type f -name '*.so' -print0 |
        while IFS= read -r -d '' file; do

            name="$(basename "$file")"

            if [[ ! -f "$DEST/$name" ]]; then
                cp "$file" "$DEST/$name"
            fi

        done

    fi

done

find "$NATIVE_DIR" -type f -name '*.so' \
    > "$ROOT/native/native_libraries.txt"

# ------------------------------------------------------------
# Assembly Store extraction (ELF payload -> XABA -> managed DLL)
# ------------------------------------------------------------

CURRENT_STEP="ASSEMBLY STORE EXTRACTION"
info "ASSEMBLY STORE EXTRACTION"

mkdir -p "$ASSEMBLY_PAYLOAD_DIR" "$ASSEMBLY_EXTRACT_DIR"

cat > "$ROOT/scripts/extract_assembly_store.py" <<'PYTHON'
#!/usr/bin/env python3
"""Extract managed assemblies from .NET Android Assembly Store ELF wrappers.

Supports little-endian ELF32/ELF64 payload sections and XABA stores.
XALZ blocks need python package `lz4`; XAZS blocks need `zstandard`.
"""
import argparse
import json
import struct
import sys
import subprocess
import shutil
from pathlib import Path

def u32(data, off):
    if off < 0 or off + 4 > len(data):
        raise ValueError(f"u32 outside buffer at offset {off}")
    return struct.unpack_from("<I", data, off)[0]

def extract_elf_payload(blob: bytes):
    if blob.startswith(b"XABA"):
        return blob, "input-is-raw-XABA"
    if len(blob) < 64 or blob[:4] != b"\x7fELF":
        raise ValueError("Input is not ELF and does not start with XABA")

    elf_class = blob[4]
    endian = blob[5]
    if endian != 1:
        raise ValueError("Only little-endian ELF is supported")

    if elf_class == 2:  # ELF64
        if len(blob) < 64:
            raise ValueError("Truncated ELF64 header")
        shoff = struct.unpack_from("<Q", blob, 40)[0]
        shentsize = struct.unpack_from("<H", blob, 58)[0]
        shnum = struct.unpack_from("<H", blob, 60)[0]
        shstrndx = struct.unpack_from("<H", blob, 62)[0]
        fmt = "<IIQQQQIIQQ"
        min_size = 64
    elif elf_class == 1:  # ELF32
        if len(blob) < 52:
            raise ValueError("Truncated ELF32 header")
        shoff = struct.unpack_from("<I", blob, 32)[0]
        shentsize = struct.unpack_from("<H", blob, 46)[0]
        shnum = struct.unpack_from("<H", blob, 48)[0]
        shstrndx = struct.unpack_from("<H", blob, 50)[0]
        fmt = "<IIIIIIIIII"
        min_size = 40
    else:
        raise ValueError(f"Unsupported ELF class: {elf_class}")

    expected = struct.calcsize(fmt)
    if shentsize < expected or shnum == 0 or shstrndx >= shnum:
        raise ValueError("ELF section table is missing or unsupported")
    if shoff + shentsize * shnum > len(blob):
        raise ValueError("ELF section table extends beyond file")

    sections = []
    for i in range(shnum):
        off = shoff + i * shentsize
        vals = struct.unpack_from(fmt, blob, off)
        if elf_class == 2:
            name, stype, flags, addr, foff, size = vals[:6]
        else:
            name, stype, flags, addr, foff, size = vals[:6]
        sections.append((name, foff, size))

    _, names_off, names_size = sections[shstrndx]
    if names_off + names_size > len(blob):
        raise ValueError("ELF section-name string table is outside file")
    names = blob[names_off:names_off + names_size]

    for name_off, sec_off, sec_size in sections:
        if name_off >= len(names):
            continue
        end = names.find(b"\0", name_off)
        if end < 0:
            continue
        section_name = names[name_off:end].decode("utf-8", "replace")
        if section_name == "payload":
            if sec_off + sec_size > len(blob):
                raise ValueError("ELF payload section extends beyond file")
            payload = blob[sec_off:sec_off + sec_size]
            if not payload.startswith(b"XABA"):
                raise ValueError("ELF payload section does not start with XABA")
            return payload, "ELF-section-payload"

    # Some stripped/older wrappers may not retain section headers. Accept only
    # a unique structurally plausible XABA candidate.
    candidates = []
    pos = 0
    while True:
        pos = blob.find(b"XABA", pos)
        if pos < 0:
            break
        try:
            validate_store_header(blob[pos:])
            candidates.append(pos)
        except Exception:
            pass
        pos += 4
    if len(candidates) == 1:
        return blob[candidates[0]:], "scanned-unique-XABA"
    raise ValueError("ELF payload section not found; no unique valid XABA payload")

def validate_store_header(store):
    if len(store) < 20 or store[:4] != b"XABA":
        raise ValueError("Missing XABA header")
    magic, version, count, index_count, index_size = struct.unpack_from("<IIIII", store, 0)
    fmt_version = version & 0xffff
    if fmt_version != 3:
        raise ValueError(
            f"Unsupported XABA format version {fmt_version} "
            f"(version word 0x{version:08x}); this extractor currently supports v3"
        )
    if count < 1 or count > 100000:
        raise ValueError(f"Implausible assembly count: {count}")
    if index_count > 1000000 or index_size > len(store):
        raise ValueError("Implausible index dimensions")
    index_entry_size = 9 if fmt_version >= 3 else 12
    if 20 + index_size > len(store):
        raise ValueError("Index exceeds payload")
    desc_off = 20 + index_size
    desc_end = desc_off + count * 28
    if desc_end > len(store):
        raise ValueError("Descriptor table exceeds payload")
    return version, count, index_count, index_size, desc_off, desc_end

def safe_filename(name, index):
    name = name.replace("\\", "/").split("/")[-1].strip()
    if not name:
        name = f"assembly_{index:04d}"
    name = "".join(c if c.isalnum() or c in "._-+" else "_" for c in name)
    if not name.lower().endswith(".dll"):
        name += ".dll"
    return name

def lz4_block_decompress(src: bytes, expected_size: int) -> bytes:
    """Small pure-Python decoder for raw LZ4 blocks (not LZ4 frames)."""
    out = bytearray()
    pos = 0
    while pos < len(src):
        token = src[pos]
        pos += 1

        literal_len = token >> 4
        if literal_len == 15:
            while True:
                if pos >= len(src):
                    raise ValueError("Truncated LZ4 literal-length extension")
                extra = src[pos]
                pos += 1
                literal_len += extra
                if extra != 255:
                    break

        if pos + literal_len > len(src):
            raise ValueError("LZ4 literal run exceeds compressed block")
        out.extend(src[pos:pos + literal_len])
        pos += literal_len

        if pos == len(src):
            break
        if pos + 2 > len(src):
            raise ValueError("Truncated LZ4 match offset")

        offset = src[pos] | (src[pos + 1] << 8)
        pos += 2
        if offset == 0 or offset > len(out):
            raise ValueError(f"Invalid LZ4 match offset: {offset}")

        match_len = (token & 0x0f) + 4
        if (token & 0x0f) == 15:
            while True:
                if pos >= len(src):
                    raise ValueError("Truncated LZ4 match-length extension")
                extra = src[pos]
                pos += 1
                match_len += extra
                if extra != 255:
                    break

        for _ in range(match_len):
            out.append(out[-offset])

        if len(out) > expected_size:
            raise ValueError("LZ4 output exceeds declared uncompressed size")

    if len(out) != expected_size:
        raise ValueError(f"LZ4 output size mismatch: got {len(out)}, expected {expected_size}")
    return bytes(out)

def decode_blob(data, index):
    if data.startswith(b"MZ"):
        return data, "raw-PE"
    if len(data) >= 12 and data[:4] == b"XALZ":
        expected = u32(data, 8)
        result = lz4_block_decompress(data[12:], expected)
        if not result.startswith(b"MZ"):
            raise ValueError("XALZ decompression did not produce a valid PE image")
        return result, "XALZ/LZ4"
    if len(data) >= 12 and data[:4] == b"XAZS":
        expected = u32(data, 8)
        try:
            import zstandard
            result = zstandard.ZstdDecompressor().decompress(data[12:], max_output_size=expected)
        except ImportError:
            zstd_cmd = shutil.which("zstd")
            if not zstd_cmd:
                raise RuntimeError("XAZS found but neither Python 'zstandard' module nor 'zstd' command is installed")
            proc = subprocess.run(
                [zstd_cmd, "-d", "-c"],
                input=data[12:],
                stdout=subprocess.PIPE,
                stderr=subprocess.PIPE,
                check=False,
            )
            if proc.returncode != 0:
                raise RuntimeError("zstd failed: " + proc.stderr.decode("utf-8", "replace").strip())
            result = proc.stdout
        if len(result) != expected or not result.startswith(b"MZ"):
            raise ValueError("XAZS decompression did not produce a valid PE image")
        return result, "XAZS/Zstandard"
    raise ValueError(f"Unknown assembly data magic: {data[:4]!r}")

def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--input", required=True)
    ap.add_argument("--output", required=True)
    ap.add_argument("--payload-dir", required=True)
    ap.add_argument("--report", required=True)
    args = ap.parse_args()

    src = Path(args.input)
    out = Path(args.output)
    payload_dir = Path(args.payload_dir)
    out.mkdir(parents=True, exist_ok=True)
    payload_dir.mkdir(parents=True, exist_ok=True)

    report = {
        "input": str(src),
        "status": "failed",
        "extraction_method": None,
        "store_version_word": None,
        "format_version": None,
        "assembly_count": 0,
        "extracted": [],
        "errors": [],
    }

    try:
        raw = src.read_bytes()
        payload, method = extract_elf_payload(raw)
        report["extraction_method"] = method
        version, count, index_count, index_size, desc_off, names_off = validate_store_header(payload)
        report["store_version_word"] = f"0x{version:08x}"
        report["format_version"] = version & 0xffff
        report["assembly_count"] = count

        payload_path = payload_dir / (src.parent.name + "_" + src.name + ".payload.bin")
        payload_path.write_bytes(payload)
        report["payload_file"] = str(payload_path)

        # Current store layout: header, index, descriptors, length-prefixed names, data.
        descriptors = []
        for i in range(count):
            vals = struct.unpack_from("<IIIIIII", payload, desc_off + i * 28)
            descriptors.append(vals)

        name_pos = names_off
        names = []
        for i in range(count):
            if name_pos + 4 > len(payload):
                raise ValueError(f"Name table truncated at entry {i}")
            nlen = u32(payload, name_pos)
            name_pos += 4
            if nlen > 4096 or name_pos + nlen > len(payload):
                raise ValueError(f"Invalid name length {nlen} at entry {i}")
            name = payload[name_pos:name_pos+nlen].decode("utf-8", "replace")
            name_pos += nlen
            names.append(name)

        for i, (desc, name) in enumerate(zip(descriptors, names)):
            mapping, data_off, data_size, dbg_off, dbg_size, cfg_off, cfg_size = desc
            if not data_off or not data_size or data_off + data_size > len(payload):
                report["errors"].append(f"{name}: invalid assembly data range")
                continue
            try:
                decoded, method = decode_blob(payload[data_off:data_off+data_size], i)
                filename = safe_filename(name, i)
                dest = out / filename
                if dest.exists():
                    dest = out / f"{dest.stem}_{i:04d}{dest.suffix}"
                dest.write_bytes(decoded)
                item = {
                    "name": name,
                    "file": str(dest),
                    "size": len(decoded),
                    "compression": method,
                    "mapping_index": mapping,
                }
                if dbg_off and dbg_size and dbg_off + dbg_size <= len(payload):
                    pdb_name = dest.with_suffix(".pdb")
                    pdb_name.write_bytes(payload[dbg_off:dbg_off+dbg_size])
                    item["pdb"] = str(pdb_name)
                if cfg_off and cfg_size and cfg_off + cfg_size <= len(payload):
                    cfg_name = dest.with_suffix(dest.suffix + ".config")
                    cfg_name.write_bytes(payload[cfg_off:cfg_off+cfg_size])
                    item["config"] = str(cfg_name)
                report["extracted"].append(item)
                print(f"[OK] {name}: {len(decoded)} bytes ({method})")
            except Exception as e:
                report["errors"].append(f"{name}: {e}")
                print(f"[ERROR] {name}: {e}", file=sys.stderr)

        report["status"] = "success" if report["extracted"] else "no-assemblies-extracted"
    except Exception as e:
        report["errors"].append(str(e))
        print(f"[ERROR] {src}: {e}", file=sys.stderr)
    finally:
        Path(args.report).write_text(json.dumps(report, indent=2, ensure_ascii=False) + "\n")
    print(f"[SUMMARY] extracted={len(report['extracted'])}, declared={report['assembly_count']}, errors={len(report['errors'])}")
    return 0 if report["extracted"] else 2

if __name__ == "__main__":
    raise SystemExit(main())
PYTHON

chmod +x "$ROOT/scripts/extract_assembly_store.py"

STORE_COUNT=0
STORE_OK=0
STORE_ERRORS="$ROOT/dotnet/metadata/assembly_store_errors.txt"
: > "$STORE_ERRORS"

while IFS= read -r sofile; do
    [[ -f "$sofile" ]] || continue
    base="$(basename "$sofile")"
    case "$base" in
        libassembly-store.so|libassemblies*.so|libassemblies*.blob.so)
            STORE_COUNT=$((STORE_COUNT + 1))
            abi="$(basename "$(dirname "$sofile")")"
            echo "[INFO] Assembly Store candidate: $sofile"
            report="$ROOT/dotnet/metadata/assembly_store_${abi}.json"
            if python3 "$ROOT/scripts/extract_assembly_store.py" \
                --input "$sofile" \
                --output "$ASSEMBLY_EXTRACT_DIR" \
                --payload-dir "$ASSEMBLY_PAYLOAD_DIR" \
                --report "$report"; then
                STORE_OK=$((STORE_OK + 1))
            else
                rc=$?
                echo "[ERROR] Assembly Store extraction failed: $sofile (exit $rc)"
                printf '%s\t%s\t%s\n' "$sofile" "$rc" "$report" >> "$STORE_ERRORS"
            fi
            ;;
    esac
done < "$ROOT/native/native_libraries.txt"

# Also record legacy store files, if the APK contains them.
find "$TEMP" -type f \( -name 'assemblies.blob' -o -name 'assemblies.*.blob' -o -name 'assemblies.manifest' \) \
    > "$ROOT/dotnet/metadata/legacy_assembly_store_files.txt"

while IFS= read -r legacy; do
    [[ -f "$legacy" ]] || continue
    echo "[INFO] Legacy Assembly Store candidate: $legacy"
    # Legacy v1/v2 blobs require a manifest-aware reader; preserve them and report.
    mkdir -p "$ROOT/dotnet/assembly_store_legacy"
    cp "$legacy" "$ROOT/dotnet/assembly_store_legacy/"
done < "$ROOT/dotnet/metadata/legacy_assembly_store_files.txt"

echo "Assembly Store candidates: $STORE_COUNT"
echo "Assembly Store extracted: $STORE_OK"
if [[ "$STORE_COUNT" -eq 0 ]]; then
    warn "No recognized Assembly Store ELF candidates found."
fi
if [[ -s "$STORE_ERRORS" ]]; then
    warn "Assembly Store extraction errors saved to: $STORE_ERRORS"
fi

# Refresh DLL count after Assembly Store extraction.
DLL_COUNT="$(find "$DLL_DIR" -type f -iname '*.dll' | wc -l | tr -d ' ')"
echo "[INFO] DLL count after Assembly Store extraction: $DLL_COUNT"

# ------------------------------------------------------------
# Native ELF inspection
# ------------------------------------------------------------

CURRENT_STEP="NATIVE ELF INFORMATION"
info "NATIVE ELF INFORMATION"

READELF=""

if command -v llvm-readelf >/dev/null 2>&1; then
    READELF="llvm-readelf"
elif command -v readelf >/dev/null 2>&1; then
    READELF="readelf"
fi

if [[ -n "$READELF" ]]; then

    while IFS= read -r file; do

        [[ -f "$file" ]] || continue

        {
            echo
            echo "================================================"
            echo "$file"
            echo "================================================"

            "$READELF" -h "$file" 2>/dev/null || true
            "$READELF" -d "$file" 2>/dev/null || true

        } >> "$ROOT/native/elf_report.txt"

    done < "$ROOT/native/native_libraries.txt"

else
    warn "readelf not found"
fi

# ------------------------------------------------------------
# Mono AOT native-image analysis (strings + targeted API indicators)
# ------------------------------------------------------------

CURRENT_STEP="MONO AOT NATIVE-IMAGE ANALYSIS"
info "MONO AOT NATIVE-IMAGE ANALYSIS"

STRINGS_CMD=""
if command -v strings >/dev/null 2>&1; then
    STRINGS_CMD="strings"
fi

AOT_DIR="$ROOT/native/aot_analysis"
mkdir -p "$AOT_DIR/strings"
AOT_INDEX="$AOT_DIR/aot_libraries.txt"
: > "$AOT_INDEX"

find "$NATIVE_DIR" -type f -name 'libaot-*.so' -print0 |
while IFS= read -r -d '' aotfile; do
    echo "$aotfile" >> "$AOT_INDEX"
    name="$(basename "$aotfile")"
    if [[ -n "$STRINGS_CMD" ]]; then
        "$STRINGS_CMD" -a -n 5 "$aotfile" > "$AOT_DIR/strings/$name.strings.txt" 2>&1 || true
    fi
done

if [[ -n "$STRINGS_CMD" ]]; then
    grep -RniE \
        'https?://|/ecom/|/lk/|loyalty|history|clientauth|checkphone|Token80|X-Token-CMD|Refit|HttpClient|Authorization' \
        "$AOT_DIR/strings" \
        > "$AOT_DIR/interesting_strings.txt" 2>/dev/null || true
else
    warn "strings utility not found; Mono AOT string extraction skipped"
fi

echo "Mono AOT native-image libraries: $(wc -l < "$AOT_INDEX" | tr -d ' ')"
echo "Mono AOT string report: $AOT_DIR"
echo "[INFO] Raw string dumps are local-only and will be excluded from Git."

# ------------------------------------------------------------
# DLL metadata
# ------------------------------------------------------------

CURRENT_STEP="DLL METADATA"
info "DLL METADATA"

find "$DLL_DIR" -type f -iname '*.dll' \
    > "$ROOT/dotnet/metadata/dll_list.txt"

while IFS= read -r dll; do

    name="$(basename "$dll")"

    {
        echo
        echo "========================================"
        echo "$name"
        echo "========================================"

        file "$dll" 2>/dev/null || true

    } >> "$ROOT/dotnet/metadata/dll_report.txt"

done < "$ROOT/dotnet/metadata/dll_list.txt"

# ------------------------------------------------------------
# ILSpy decompilation
# ------------------------------------------------------------

CURRENT_STEP="ILSPY C# DECOMPILATION"
info "ILSPY C# DECOMPILATION"

while IFS= read -r dll; do

    [[ -f "$dll" ]] || continue

    name="$(basename "$dll" .dll)"
    DEST="$CS_DIR/$name"
    DLL_MARKER="$DEST/.decompile_complete"
    DLL_SHA256="$(file_sha256 "$dll")"
    EXISTING_CS=0
    if [[ -d "$DEST" ]]; then
        EXISTING_CS="$(find "$DEST" -type f -name '*.cs' | wc -l | tr -d ' ')"
    fi

    # Reuse legacy C# output too; new results receive per-DLL hash markers.
    if [[ "$EXISTING_CS" -gt 0 ]]; then
        if [[ -f "$DLL_MARKER" ]]; then
            if [[ "$(cat "$DLL_MARKER" 2>/dev/null)" == "$DLL_SHA256" ]]; then
                echo "[SKIP] ILSpy: $name уже декомпилирован (C# файлов: $EXISTING_CS)"
                continue
            fi
            echo "[RUN] ILSpy: DLL $name изменилась — повторная декомпиляция."
        else
            printf '%s\n' "$DLL_SHA256" > "$DLL_MARKER"
            echo "[SKIP] ILSpy: $name уже имеет C# исходники (старый результат без маркера); принят как готовый."
            continue
        fi
    else
        echo "[RUN] ILSpy: декомпиляция $name"
    fi

    mkdir -p "$DEST"
    rm -f "$DLL_MARKER"
    if "$ILSPYCMD" -p -o "$DEST" "$dll"; then
        NEW_CS="$(find "$DEST" -type f -name '*.cs' | wc -l | tr -d ' ')"
        if [[ "$NEW_CS" -gt 0 ]]; then
            printf '%s\n' "$DLL_SHA256" > "$DLL_MARKER"
            echo "[OK] ILSpy: $name; C# файлов: $NEW_CS"
        else
            echo "[ERROR] ILSpy: $name завершился без C# исходников."
            printf '%s\t%s\n' "$name" "no-source-files" >> "$ROOT/dotnet/metadata/ilspy_errors.tsv"
        fi
    else
        rc=$?
        echo "[ERROR] ILSpy failed for $name (exit code $rc)"
        printf '%s\t%s\n' "$name" "$rc" >> "$ROOT/dotnet/metadata/ilspy_errors.tsv"
        warn "ILSpy failed: $name; скрипт продолжает работу"
    fi

done < "$ROOT/dotnet/metadata/dll_list.txt"

# ------------------------------------------------------------
# Search API endpoints
# ------------------------------------------------------------

CURRENT_STEP="SEARCH API ENDPOINTS"
info "SEARCH API ENDPOINTS"

if reports_complete "$ROOT/api/endpoints_search.txt"; then
    echo "[SKIP] SEARCH API ENDPOINTS: отчёты уже существуют и непустые."
else

grep -RniE \
    'clientauth/token|checkphone|loyalty/history|loyalty/operations' \
    "$CS_DIR" \
    --include='*.cs' \
    > "$ROOT/api/endpoints_search.txt" || true

fi

# ------------------------------------------------------------
# Search authentication
# ------------------------------------------------------------

CURRENT_STEP="SEARCH AUTHENTICATION"
info "SEARCH AUTHENTICATION"

if reports_complete "$ROOT/api/authentication_search.txt"; then
    echo "[SKIP] SEARCH AUTHENTICATION: отчёты уже существуют и непустые."
else

grep -RniE \
    'SavedToken80|Token80|SendSms|ConfirmSms|VerifyCode|GetToken|Authentication|CheckPhone|PhoneNumber|SmsCode|VerificationCode|Otp|SecureStorage' \
    "$CS_DIR" \
    --include='*.cs' \
    > "$ROOT/api/authentication_search.txt" || true

fi

# ------------------------------------------------------------
# SMS authentication research: endpoint, request, response and call-flow search
# ------------------------------------------------------------

CURRENT_STEP="SEARCH SMS AUTHENTICATION"
info "SEARCH SMS AUTHENTICATION"

if reports_complete "$ROOT/api/sms_auth/sms_vocabulary_search.txt" "$ROOT/api/sms_auth/auth_endpoint_search.txt" "$ROOT/api/sms_auth/http_request_search.txt" "$ROOT/api/sms_auth/serialization_and_routes_search.txt" "$ROOT/api/sms_auth/auth_classes_and_storage_search.txt" "$ROOT/api/sms_auth/android_layer_search.txt"; then
    echo "[SKIP] SEARCH SMS AUTHENTICATION: отчёты уже существуют и непустые."
else

SMS_DIR="$ROOT/api/sms_auth"
mkdir -p "$SMS_DIR"

# Broad vocabulary search. Keep each report separate so that the next
# inspection can follow the call chain rather than relying on one huge grep.
grep -RniE \
    'sms|smscode|sms_code|sms-code|one.?time.?password|otp|verification.?code|verify.?code|confirmation.?code|phone.?number|phone.?verification|mobile.?phone|check.?phone|send.?code|resend.?code|confirm.?phone|validate.?phone' \
    "$CS_DIR" --include='*.cs' \
    > "$SMS_DIR/sms_vocabulary_search.txt" || true

grep -RniE \
    'clientauth|client.?auth|checkphone|check.?phone|send.?sms|sendsms|send.?code|request.?code|confirm.?sms|confirmsms|verify.?sms|verify.?code|validate.?code|auth.?token|token.*phone|phone.*token' \
    "$CS_DIR" --include='*.cs' \
    > "$SMS_DIR/auth_endpoint_search.txt" || true

grep -RniE \
    'Http(Get|Post|Put|Patch|Delete)|GetAsync|PostAsync|SendAsync|RequestUri|BaseAddress|QueryString|FormUrlEncodedContent|StringContent|JsonContent|PostAsJsonAsync|GetFromJsonAsync|Authorization|X-Token|Token80|Content-Type' \
    "$CS_DIR" --include='*.cs' \
    > "$SMS_DIR/http_request_search.txt" || true

grep -RniE \
    'JsonPropertyName|JsonProperty|DataMember|FromQuery|FromBody|Query|[Jj]sonSerializer|[Nn]ewtonsoft|System.Text.Json|RestMethod|Get\("|Post\("|[Hh]eader' \
    "$CS_DIR" --include='*.cs' \
    > "$SMS_DIR/serialization_and_routes_search.txt" || true

grep -RniE \
    'class .*Auth|interface .*Auth|AuthenticationService|AuthService|LoginService|Phone.*Service|Sms.*Service|Verification.*Service|TokenService|ITokenService|SavedToken|SecureStorage|Preferences|Keychain|Keystore' \
    "$CS_DIR" --include='*.cs' \
    > "$SMS_DIR/auth_classes_and_storage_search.txt" || true

# Search the Android/MAUI layer too: SMS flows can be started by a ViewModel,
# command, page, deep link or platform-specific callback.
grep -RniE \
    'sms|verification|verify.?code|confirm.?code|phone.?number|clientauth|checkphone|SendSms|ConfirmSms|GetToken|Authentication' \
    "$JADX_DIR" "$APKTOOL_DIR" \
    --include='*.java' --include='*.kt' --include='*.xml' --include='*.smali' \
    > "$SMS_DIR/android_layer_search.txt" 2>/dev/null || true

# Strings from AOT/native libraries may contain routes or JSON field names
# that are absent from the decompiled managed source.
if [[ -d "$AOT_DIR/strings" ]]; then
    grep -RniE \
        'sms|otp|verification|verify|confirm|phone|clientauth|checkphone|token|code|/lk/' \
        "$AOT_DIR/strings" \
        > "$SMS_DIR/aot_sms_strings_search.txt" 2>/dev/null || true
fi

# Record relevant endpoint-like string literals from all decompiled C#.
# Keep the character class portable across GNU grep and FreeBSD grep.
# Square brackets are deliberately excluded: they were escaped inside a
# bracket expression and caused BSD grep's "repetition-operator operand invalid".
grep -RniE \
    '(/|https?://)[A-Za-z0-9._~:/?#@!$&()*+,;=%{}-]*(sms|phone|auth|token|code|verify|confirm)[A-Za-z0-9._~:/?#@!$&()*+,;=%{}-]*' \
    "$CS_DIR" --include='*.cs' \
    > "$SMS_DIR/endpoint_literals_search.txt" 2> "$SMS_DIR/endpoint_literals_search_errors.txt" || {
        rc=$?
        echo "[WARNING] Поиск URL-строк завершился с кодом $rc; подробности: $SMS_DIR/endpoint_literals_search_errors.txt"
    }


cat > "$SMS_DIR/README.md" <<'EOF'
# SMS authentication investigation

This directory contains search indexes generated from the decompiled app.
A grep hit is only a lead: it is not proof that the code belongs to the
interactive SMS login flow.

## Investigation order

1. Start with `auth_endpoint_search.txt` and `endpoint_literals_search.txt`.
   Locate the API interface declarations and their HTTP attributes.
2. Find the ViewModel/command/page that starts login. Follow the command into
   the authentication service; this establishes the actual call order.
3. Follow the phone-check request. Record HTTP method, relative route, query
   parameters, headers and response DTO.
4. Follow the SMS-send request. Determine whether the phone is sent as JSON,
   form data or query parameters, and whether a challenge/hash/device ID is
   required. Do not infer these fields from names alone.
5. Follow the code-confirmation request. Record the exact request DTO, route,
   response DTO and error mapping.
6. Follow token creation/refresh. Determine whether `/lk/clientauth/token`
   is called before or after SMS confirmation and how the resulting token is
   associated with the authenticated phone/account.
7. Follow token persistence. Identify whether the app uses SecureStorage,
   Preferences, cookies or an in-memory token service. Never copy real values.
8. Compare managed C# findings with `android_layer_search.txt` and
   `aot_sms_strings_search.txt` when the managed call chain is incomplete.

## Evidence table to complete manually

| Stage | Evidence to record |
|---|---|
| Phone pre-check | method, full URL after resolving the correct base URL, query/body, response |
| SMS dispatch | method, route, body, required headers, response/challenge |
| SMS confirmation | method, route, body, response/error cases |
| Token acquisition | route, order in flow, token response fields |
| Token storage | storage API and key names only; never real values |
| Authenticated API call | how the token is attached to subsequent requests |

## Important

- The existing notes mention `GET /lk/clientauth/token` and
  `GET /lk/clientprofile/checkphone?needHash=False`; their role in the
  complete SMS flow is not yet proven by these strings alone.
- Do not assume that `checkphone` sends an SMS. It may only check the phone
  or return a hash/challenge.
- Do not guess missing routes, request fields, headers or token semantics.
- Do not commit phone numbers, SMS codes, tokens, cookies, HAR/PCAP captures,
  or real account responses.
EOF

fi

# ------------------------------------------------------------
# Search purchase history
# ------------------------------------------------------------

CURRENT_STEP="SEARCH PURCHASE HISTORY"
info "SEARCH PURCHASE HISTORY"

if reports_complete "$ROOT/api/purchase_history_search.txt"; then
    echo "[SKIP] SEARCH PURCHASE HISTORY: отчёты уже существуют и непустые."
else

grep -RniE \
    'GetHistoryAsync|GetTransactionDetailsAsync|LoyaltyHistory|PagedDataLoader' \
    "$CS_DIR" \
    --include='*.cs' \
    > "$ROOT/api/purchase_history_search.txt" || true

fi

# ------------------------------------------------------------
# Search DTO
# ------------------------------------------------------------

CURRENT_STEP="SEARCH DTO"
info "SEARCH DTO"

if reports_complete "$ROOT/api/dto_search.txt"; then
    echo "[SKIP] SEARCH DTO: отчёты уже существуют и непустые."
else

grep -RniE \
    'TransactionDetailsDto|ProductDto|OrderDetailsDto|HistoryFilter|LoymaxHistoryResponseDto' \
    "$CS_DIR" \
    --include='*.cs' \
    > "$ROOT/api/dto_search.txt" || true

fi

# ------------------------------------------------------------
# Search Loymax client registration, base URL and token flow
# ------------------------------------------------------------

CURRENT_STEP="SEARCH LOYMAX CONFIGURATION"
info "SEARCH LOYMAX CONFIGURATION"

if reports_complete "$ROOT/api/loymax_registration_search.txt" "$ROOT/api/base_url_search.txt" "$ROOT/api/token_flow_search.txt" "$ROOT/api/receipt_details_search.txt"; then
    echo "[SKIP] SEARCH LOYMAX CONFIGURATION: отчёты уже существуют и непустые."
else

# These reports intentionally collect source locations and code references;
# they do not assume that a similarly named provider belongs to Loymax.
grep -RniE \
    'ILoymaxLoyaltyApi|LoymaxLoyaltyApi|LoyaltyProgramDependencyRegistry|LoyaltyProgram.*Registry' \
    "$CS_DIR" --include='*.cs' \
    > "$ROOT/api/loymax_registration_search.txt" || true

grep -RniE \
    'IEnvironmentBaseUrlProvider|BaseUrlForEnvironment|EnvironmentHttpClient|mobile\.auchan\.ru|ecom\.auchan\.ru' \
    "$CS_DIR" --include='*.cs' \
    > "$ROOT/api/base_url_search.txt" || true

grep -RniE \
    'interface ITokenService|class .*TokenService|ITokenService|SavedToken80|Token80|X-Token-CMD|token80' \
    "$CS_DIR" --include='*.cs' \
    > "$ROOT/api/token_flow_search.txt" || true

grep -RniE \
    'GetTransactionDetailsAsync|chequeNumber|ChequeNumber|TransactionDetails|Receipt|ReceiptItem|PurchaseItem|ProductName|ItemName' \
    "$CS_DIR" --include='*.cs' \
    > "$ROOT/api/receipt_details_search.txt" || true

# Compact index to make the next manual inspection straightforward.
cat > "$ROOT/api/auchan_purchase_research.md" <<'EOF'
# Auchan purchase-history reverse-engineering index

This file is generated from the decompiled C# source. Search reports contain
file paths and matching lines; inspect the referenced methods before treating
any request shape or host as confirmed.

## Reports

- `purchase_history_search.txt` — history service methods and API calls
- `endpoints_search.txt` — endpoint attributes and route strings
- `dto_search.txt` — response/request DTO references
- `loymax_registration_search.txt` — registration of `ILoymaxLoyaltyApi`
- `base_url_search.txt` — environment URL providers and HTTP client setup
- `token_flow_search.txt` — `ITokenService`, Token80 and request header references
- `receipt_details_search.txt` — receipt-detail methods and product-line models
- `authentication_search.txt` — authentication-related source references
- `sms_auth/` — expanded SMS-login investigation indexes and workflow checklist

## What must be established

1. Find the exact dependency-registration method that constructs
   `ILoymaxLoyaltyApi` and identify the URL provider passed to it.
2. Follow that provider for the Production environment. Do not infer the
   Loymax host from an unrelated provider such as feedback or personal cabinet.
3. Inspect `ILoymaxLoyaltyApi.cs` for the exact route attribute and header.
4. Inspect `LoyaltyProgramPurchasesHistoryService.cs` for the serialized
   request body used by both history and receipt-detail methods.
5. Follow `ITokenService` to determine where the app obtains and stores its
   Token80. Never commit a real token, cookie, phone number or SMS code.
6. Follow the response DTO and mapper to identify the receipt identifier and
   the product rows returned by the detail request.

## Important distinction

A history response is not necessarily a receipt with itemized products.
The list of purchases and the contents of each receipt may require separate
requests. Verify the detail method and its DTO before implementing that step.

## Endpoint notation

The route attribute in the API interface is a relative path. The final URL is
formed by combining it with the base URL of the exact registered HTTP client.
Do not add or remove `/ecom` until that registration has been verified.
EOF

fi

# ------------------------------------------------------------
# Deep purchase-history investigation: SMS order, Loymax URL, receipt items
# ------------------------------------------------------------

CURRENT_STEP="DEEP PURCHASE HISTORY RESEARCH"
info "DEEP PURCHASE HISTORY RESEARCH"

if reports_complete "$ROOT/api/deep_purchase_research/01_pin_interactor_sendpin.txt" "$ROOT/api/deep_purchase_research/02_loymax_url_provider.txt" "$ROOT/api/deep_purchase_research/03_receipt_items_and_details.txt" "$ROOT/api/deep_purchase_research/04_personal_cabinet_api_and_auth_server.txt" "$ROOT/api/deep_purchase_research/05_deviceid_needhash_token80.txt" "$ROOT/api/deep_purchase_research/06_loyalty_history_response_and_receipt_details.txt" "$ROOT/api/deep_purchase_research/01_pin_interactor_references.txt" "$ROOT/api/deep_purchase_research/02_loymax_registration_references.txt" "$ROOT/api/deep_purchase_research/03_receipt_item_references.txt" "$ROOT/api/deep_purchase_research/04_personal_cabinet_api_references.txt" "$ROOT/api/deep_purchase_research/05_deviceid_needhash_token80_references.txt" "$ROOT/api/deep_purchase_research/06_loyalty_history_response_references.txt" "$ROOT/api/deep_purchase_research/07_token20_client_password.txt" "$ROOT/api/deep_purchase_research/07_token20_client_password_references.txt" "$ROOT/api/deep_purchase_research/08_device_id_udid_mapping.txt" "$ROOT/api/deep_purchase_research/08_device_id_udid_mapping_references.txt" "$ROOT/api/deep_purchase_research/09_needhash_true_response.txt" "$ROOT/api/deep_purchase_research/09_needhash_true_response_references.txt" "$ROOT/api/deep_purchase_research/10_cheque_number_detail_loading.txt" "$ROOT/api/deep_purchase_research/10_cheque_number_detail_loading_references.txt"; then
    echo "[SKIP] DEEP PURCHASE HISTORY RESEARCH: все отчёты уже существуют и непустые."
else

DEEP_DIR="$ROOT/api/deep_purchase_research"
mkdir -p "$DEEP_DIR"

write_context_report() {
    local label="$1"
    local pattern="$2"
    local output="$3"
    if [[ -s "$output" ]]; then
        echo "[SKIP] $label: готовый отчёт уже существует: $output"
        return 0
    fi
    local source_dirs=()
    local dir

    for dir in "$CS_DIR" "$JADX_DIR" "$APKTOOL_DIR" "$AOT_DIR/strings"; do
        [[ -d "$dir" ]] && source_dirs+=("$dir")
    done

    {
        echo "# $label"
        echo "# Generated: $(date)"
        echo "# Search expression: $pattern"
        echo
        if [[ "${#source_dirs[@]}" -gt 0 ]]; then
            grep -RniE -B 10 -A 24 "$pattern" "${source_dirs[@]}" \
                --include='*.cs' --include='*.java' --include='*.kt' \
                --include='*.smali' --include='*.xml' --include='*.txt' \
                2>/dev/null || true
        fi
    } > "$output"

    if ! grep -qE ':[0-9]+:' "$output"; then
        echo "[NOT FOUND] Совпадений в доступных исходниках нет." >> "$output"
        echo "[WARNING] $label: совпадений не найдено; см. $output"
    else
        echo "[OK] $label: $output"
    fi
}

# Write a lightweight C# reference report only when it is missing or empty.
# This prevents recursive source scans on every repeated run.
write_reference_report() {
    local label="$1"
    local pattern="$2"
    local output="$3"

    if [[ -s "$output" ]]; then
        echo "[SKIP] $label: готовый отчёт уже существует: $output"
        return 0
    fi

    {
        echo "# $label"
        echo "# Generated: $(date)"
        echo "# Search expression: $pattern"
        echo
        if [[ -d "$CS_DIR" ]]; then
            grep -RniE "$pattern" "$CS_DIR" --include='*.cs' 2>/dev/null || true
        else
            echo "[WARNING] C# source directory not found: $CS_DIR"
        fi
    } > "$output"

    echo "[OK] $label: $output"
}

# 1. SMS flow: locate the exact PinInteractor implementation and all callers.
write_context_report \
    "PinInteractor.SendPin call chain" \
    'PinInteractor|SendPin[[:space:]]*\(|BeginVerifyPhone|VerifyPhone|CheckPhone|RequestPin|SendPinAsync' \
    "$DEEP_DIR/01_pin_interactor_sendpin.txt"

grep -RniE \
    'PinInteractor|SendPin[[:space:]]*\(|BeginVerifyPhone|VerifyPhone|CheckPhone|RequestPin|SendPinAsync' \
    "$CS_DIR" --include='*.cs' \
    > "$DEEP_DIR/01_pin_interactor_references.txt" || true

# 2. Loymax URL: follow the exact provider name, constructors, DI registration
# and Production/environment selection. Do not treat other base URL providers
# (for example PersonalCabinetBaseUrlProvider) as the Loymax host.
write_context_report \
    "LoymaxLoyaltyProgramUrlProvider and registration" \
    'LoymaxLoyaltyProgramUrlProvider|Loymax.*UrlProvider|UrlProvider.*Loymax|ILoymaxLoyaltyApi|LoymaxLoyaltyApi|AddRefitClient|AddHttpClient|BaseAddress|Production' \
    "$DEEP_DIR/02_loymax_url_provider.txt"

grep -RniE \
    'LoymaxLoyaltyProgramUrlProvider|Loymax.*UrlProvider|UrlProvider.*Loymax|ILoymaxLoyaltyApi|LoymaxLoyaltyApi|LoyaltyProgramDependencyRegistry' \
    "$CS_DIR" --include='*.cs' \
    > "$DEEP_DIR/02_loymax_registration_references.txt" || true

# 3. Itemized receipt: follow history item -> receipt/transaction identifier
# -> details endpoint -> response DTO -> mapper -> individual product rows.
write_context_report \
    "Receipt detail and itemized product call chain" \
    'GetTransactionDetailsAsync|GetReceiptDetailsAsync|GetPurchaseDetailsAsync|TransactionDetails|ReceiptDetails|ReceiptItem|PurchaseItem|LoyaltyHistory|ChequeNumber|ReceiptNumber|ProductName|ProductDto|ProductItem|ItemName|Nomenclature|Sku|Barcode' \
    "$DEEP_DIR/03_receipt_items_and_details.txt"

grep -RniE \
    'GetTransactionDetailsAsync|GetReceiptDetailsAsync|GetPurchaseDetailsAsync|TransactionDetails|ReceiptDetails|ReceiptItem|PurchaseItem|ChequeNumber|ReceiptNumber|ProductName|ProductDto|ProductItem|ItemName|Nomenclature|Sku|Barcode' \
    "$CS_DIR" --include='*.cs' \
    > "$DEEP_DIR/03_receipt_item_references.txt" || true

# 4. Personal cabinet API and authentication server.
write_context_report \
    "IPersonalCabinetApi and authentication server" \
    'IPersonalCabinetApi|PersonalCabinetApi|PersonalCabinet.*Api|PersonalCabinet.*UrlProvider|clientauth|clientprofile|BaseAddress|BaseUrl|BaseURL|HttpClient|Refit|/lk/' \
    "$DEEP_DIR/04_personal_cabinet_api_and_auth_server.txt"

grep -RniE \
    'IPersonalCabinetApi|PersonalCabinetApi|PersonalCabinet.*UrlProvider|clientauth|clientprofile|BaseAddress|BaseUrl|BaseURL' \
    "$CS_DIR" --include='*.cs' \
    > "$DEEP_DIR/04_personal_cabinet_api_references.txt" || true

# 5. deviceid, needHash and Token80 generation/acquisition/storage.
write_context_report \
    "deviceid, needHash and Token80" \
    'device.?id|deviceid|UDID|Udid|UniqueDevice|DeviceInfo|AndroidId|ANDROID_ID|Settings\.Secure|needHash|NeedHash|Token20|token20|Token80|SavedToken80|ITokenService|clientauth/token|checkphone|Hash|SecureStorage|Preferences' \
    "$DEEP_DIR/05_deviceid_needhash_token80.txt"

grep -RniE \
    'device.?id|deviceid|UDID|Udid|UniqueDevice|DeviceInfo|AndroidId|ANDROID_ID|Settings\.Secure|needHash|NeedHash|Token20|token20|Token80|SavedToken80|ITokenService|clientauth/token|checkphone' \
    "$CS_DIR" --include='*.cs' \
    > "$DEEP_DIR/05_deviceid_needhash_token80_references.txt" || true

# 6. /lk/loyalty/history response DTO and itemized receipt detail chain.
write_context_report \
    "/lk/loyalty/history response and receipt details" \
    'loyalty/history|LoymaxHistoryResponseDto|HistoryResponse|HistoryItem|PurchaseHistory|GetHistoryAsync|GetTransactionDetailsAsync|TransactionDetailsDto|ReceiptDetails|ReceiptItem|ProductDto|ProductItem|ChequeNumber|chequeNumber|ReceiptNumber|ProductName|Quantity|UnitPrice|TotalPrice|Discount|foreach|SelectMany|Task\.WhenAll' \
    "$DEEP_DIR/06_loyalty_history_response_and_receipt_details.txt"

grep -RniE \
    'loyalty/history|LoymaxHistoryResponseDto|HistoryResponse|HistoryItem|GetHistoryAsync|GetTransactionDetailsAsync|TransactionDetailsDto|ReceiptDetails|ReceiptItem|ProductDto|ProductItem|ChequeNumber|ReceiptNumber' \
    "$CS_DIR" --include='*.cs' \
    > "$DEEP_DIR/06_loyalty_history_response_references.txt" || true

# 7. Token20: exact client-password value and wire format.
write_context_report \
    "Token20 client password and serialization format" \
    'Token20|token20|Token20Password|ClientPassword|client.?password|PasswordHash|passwordHash|needHash|NeedHash|clientauth/token|Authorization|X-Token' \
    "$DEEP_DIR/07_token20_client_password.txt"

grep -RniE \
    'Token20|token20|Token20Password|ClientPassword|client.?password|PasswordHash|passwordHash|needHash|NeedHash|clientauth/token|Authorization|X-Token' \
    "$CS_DIR" --include='*.cs' \
    > "$DEEP_DIR/07_token20_client_password_references.txt" || true

# 8. Compare the generated Device ID with the original UDID source.
write_context_report \
    "Device ID generation and original UDID mapping" \
    'UDID|Udid|udid|DeviceId|DeviceID|device.?id|UniqueDevice|DeviceInfo|AndroidId|ANDROID_ID|Settings\.Secure|Secure\.AndroidId|IdentifierForVendor|GetIdentifier|InstallationId|device.?identifier' \
    "$DEEP_DIR/08_device_id_udid_mapping.txt"

grep -RniE \
    'UDID|Udid|udid|DeviceId|DeviceID|device.?id|UniqueDevice|DeviceInfo|AndroidId|ANDROID_ID|Settings\.Secure|Secure\.AndroidId|IdentifierForVendor|GetIdentifier|InstallationId|device.?identifier' \
    "$CS_DIR" --include='*.cs' \
    > "$DEEP_DIR/08_device_id_udid_mapping_references.txt" || true

# 9. Isolate needHash=true and capture request/response DTOs and error handling.
write_context_report \
    "needHash=true request and server response" \
    'needHash[[:space:]]*=[[:space:]]*true|needHash|NeedHash|checkphone|CheckPhone|HashResponse|PhoneCheck|Challenge|ClientAuth|clientauth' \
    "$DEEP_DIR/09_needhash_true_response.txt"

grep -RniE \
    'needHash[[:space:]]*=[[:space:]]*true|needHash|NeedHash|checkphone|CheckPhone|HashResponse|PhoneCheck|Challenge|ClientAuth|clientauth' \
    "$CS_DIR" --include='*.cs' \
    > "$DEEP_DIR/09_needhash_true_response_references.txt" || true

# 10. Follow chequeNumber from each history row into the detail API call.
# Record loops/batching and whether detail requests are automatic or on-demand.
write_context_report \
    "chequeNumber detail loading and automatic per-receipt requests" \
    'chequeNumber|ChequeNumber|GetTransactionDetailsAsync|GetReceiptDetailsAsync|GetPurchaseDetailsAsync|TransactionDetails|ReceiptDetails|LoyaltyHistory|GetHistoryAsync|Task\.WhenAll|Parallel|foreach|SelectMany|OnAppearing|ItemTapped|SelectionChanged|Load.*Detail|Fetch.*Detail' \
    "$DEEP_DIR/10_cheque_number_detail_loading.txt"

grep -RniE \
    'chequeNumber|ChequeNumber|GetTransactionDetailsAsync|GetReceiptDetailsAsync|GetPurchaseDetailsAsync|TransactionDetails|ReceiptDetails|LoyaltyHistory|GetHistoryAsync|Task\.WhenAll|Parallel|foreach|SelectMany|OnAppearing|ItemTapped|SelectionChanged|Load.*Detail|Fetch.*Detail' \
    "$CS_DIR" --include='*.cs' \
    > "$DEEP_DIR/10_cheque_number_detail_loading_references.txt" || true

cat > "$DEEP_DIR/README.md" <<'EOF'
# Deep purchase-history investigation

Generated automatically by decompile_auchan.sh.

## Reports

1. 01_pin_interactor_sendpin.txt — surrounding source for the SMS PIN
   interactor, phone checks, SMS dispatch and verification methods.
2. 01_pin_interactor_references.txt — exact C# references/call sites.
3. 02_loymax_url_provider.txt — provider, environment selection, HTTP
   client setup and API registration with surrounding source.
4. 02_loymax_registration_references.txt — C# registration/provider hits.
5. 03_receipt_items_and_details.txt — receipt-detail methods, response
   models, product fields and mapping code.
6. 03_receipt_item_references.txt — focused C# references.
7. 07_token20_client_password.txt — Token20 source, format and serialization.
8. 07_token20_client_password_references.txt — focused C# references.
9. 08_device_id_udid_mapping.txt — generated Device ID vs original UDID.
10. 08_device_id_udid_mapping_references.txt — focused C# references.
11. 09_needhash_true_response.txt — needHash=true request and response.
12. 09_needhash_true_response_references.txt — focused C# references.
13. 10_cheque_number_detail_loading.txt — chequeNumber details call chain,
    automatic/on-demand loading, loops and batching.
14. 10_cheque_number_detail_loading_references.txt — focused C# references.

## Questions the source must answer

### SMS
- Does SendPin() first call CheckPhone()?
- Which method actually sends the SMS?
- Is the SMS request made before or after Token80 acquisition?
- Which token is passed to each call, and what are the exact headers,
  query parameters and request body?
- What is Token20 exactly: source value, byte/string format, transformations
  (hashing/encoding), and serialized location in the request?
- What does the UI/ViewModel await before accepting the four-digit code?

### Loymax URL
- Which dependency-registration method constructs ILoymaxLoyaltyApi?
- Which exact provider is passed to that registration?
- What URL does that provider return for Production?
- Is /ecom part of the base URL or the relative API route?
- Confirm the final URL by joining the registered base URL and route
  attribute; do not infer it from another API client.

### Receipt items
- Which identifier in a history row is passed to the details method?
- Is the field named chequeNumber, and is it transformed before the request?
- Are details requested automatically for every history row (loop/batch/
  parallel), or only when a receipt is opened?
- What is the exact details endpoint and request body?
- Which response DTO contains product rows?
- Which mapper converts those rows to UI/domain purchase items?
- Are item name, quantity, unit price, total price, discounts and barcode
  actually returned, or are some fields absent?

### Device identity and needHash

- Which exact platform/API call supplies the original UDID?
- Is Device ID generated, persisted, or read from Android ID?
- Compare source value, format, casing and transformations; do not assume
  UUID-like identifiers are interchangeable.
- What request is made with needHash=true, and what does the server return
  (status, content type, DTO fields, hash/challenge/error)?
- Compare true/false branches without recording real account secrets.

## Evidence rules

A search hit is only a lead. Read the full containing method and its callers.
If a report has no hits, check whether the managed assembly was successfully
extracted and decompiled. Never substitute a guessed route, host, request
field or token type for missing evidence.

Do not commit real phone numbers, SMS codes, access tokens, cookies, HAR/PCAP
captures, account responses or personal purchase receipts.
EOF

echo "[INFO] Detailed purchase research reports: $DEEP_DIR"

fi

# ------------------------------------------------------------
# Count C# files
# ------------------------------------------------------------

CURRENT_STEP="COUNT SOURCE FILES"
info "COUNT SOURCE FILES"

find "$CS_DIR" -type f -name '*.cs' \
    > "$ROOT/dotnet/metadata/csharp_files.txt"

CS_COUNT="$(wc -l < "$ROOT/dotnet/metadata/csharp_files.txt" | tr -d ' ')"

echo "C# files: $CS_COUNT"
echo "DLL files: $DLL_COUNT"

# ------------------------------------------------------------
# Documentation
# ------------------------------------------------------------

CURRENT_STEP="GENERATE DOCUMENTATION"
info "GENERATE DOCUMENTATION"

cat > "$ROOT/docs/application_structure.md" <<'EOF'
# Auchan Android application structure

Package: ru.myauchan.droid

Version: 4.1.2

Framework: .NET MAUI / Xamarin.Android

Main components:

- Android application layer
- .NET assemblies
- Native libraries
- Loyalty services
- API interfaces
- DTO models
- Data mappers

See apk_analysis, dotnet and native directories.
EOF

cat > "$ROOT/api/purchase_history.md" <<'EOF'
# Purchase history API

Source-level findings:

- The decompiled interface declares a relative route for `LoyaltyHistory`.
- The request sends the `X-Token-CMD` header using the Token80 value obtained
  through the application's token service.
- The history service maps `LoymaxHistoryResponseDto` into purchase models.
- Filter id `2` is identified as purchases; filter id `6` as stamp operations
  in the reverse-engineering notes. Verify against the request-building code.

The final URL must be determined from the dependency registration for
`ILoymaxLoyaltyApi`. Do not assume `/ecom` belongs in the route or base URL
until the exact provider used by that client has been identified.

The request body, pagination and receipt-detail request must be verified
against `LoyaltyProgramPurchasesHistoryService.cs` and the related DTOs.
A history record is not necessarily an itemized receipt.
EOF

cat > "$ROOT/api/authentication.md" <<'EOF'
# Authentication research

Known endpoints:

GET /lk/clientauth/token

GET /lk/clientprofile/checkphone?needHash=False

The application uses Token80 in the X-Token-CMD header
for the loyalty history API.

SMS request and verification sequence:
Not yet fully established. The decompilation script generates additional
indexes under `api/sms_auth/` for phone checks, SMS dispatch, code confirmation,
HTTP request construction, DTO serialization, Android entry points and AOT
string literals. Follow the calling ViewModel/service chain before treating
any endpoint or field as confirmed.

Known route strings are leads, not a complete authentication protocol:
- GET /lk/clientauth/token
- GET /lk/clientprofile/checkphone?needHash=False

Do not assume that `checkphone` sends an SMS. Establish the separate SMS-send
and code-confirmation operations from their call sites and request DTOs.

Do not store real phone numbers, SMS codes, tokens or cookies here.
EOF

cat > "$ROOT/docs/reverse_engineering_log.md" <<EOF
# Reverse engineering log

Date: $(date)

APK: $(basename "$APK")

Package: ru.myauchan.droid

Version: 4.1.2

Framework: .NET MAUI

Completed:

- APK extraction
- Apktool analysis
- JADX analysis (if installed)
- DLL discovery
- ILSpy decompilation
- Native library inventory
- Assembly Store detection and extraction attempt
- Mono AOT native-image string and ELF analysis
- API source search

See logs/decompile.log for execution details.
EOF

# ------------------------------------------------------------
# README
# ------------------------------------------------------------

cat > "$ROOT/README.md" <<'EOF'
# Auchan Reverse Engineering

Research project for structural analysis of the Android application
"My Auchan" version 4.1.2.

Package:

ru.myauchan.droid

Framework:

.NET MAUI / Xamarin.Android

## Directories

- apk_analysis: Android resources and decompilation
- dotnet: extracted and decompiled .NET assemblies
- native: native libraries and ELF reports
- api: API and DTO research
- docs: research documentation
- scripts: automation scripts
- logs: decompilation logs

## Tools

- Apktool
- JADX
- ILSpy
- .NET SDK
- Git

## Important

This repository contains reverse-engineering research.

Do not commit personal information, authentication tokens,
cookies, SMS codes, private keys, account data or purchase receipts.

Check applicable copyright and licensing requirements before
redistributing APK-derived source code or binary artifacts.
EOF

# ------------------------------------------------------------
# Git ignore
# ------------------------------------------------------------

CURRENT_STEP="CREATE GITIGNORE"
info "CREATE GITIGNORE"

cat > "$ROOT/.gitignore" <<'EOF'
# APK and temporary data
original/
tmp/
*.apk
*.apks
*.aab

# Binary artifacts
*.dll
*.so
dotnet/assembly_store_payloads/
dotnet/assembly_store_legacy/
native/aot_analysis/strings/
native/aot_analysis/interesting_strings.txt
dotnet/metadata/assembly_store_*.json
*.dylib
*.dex
*.o
*.a
*.class
*.p12
*.pfx
*.pem
*.key

# Personal data
*.har
*.pcap
*.pcapng
*.db
*.sqlite
*.sqlite3
*.cookie
*.cookies
*.token
*.secret
.env
.env.*

# Local build output
bin/
obj/
build/
.gradle/
.idea/
.vscode/

# Python
__pycache__/
*.pyc
.venv/
venv/

# Logs may contain private traffic data
logs/traffic*
EOF

# ------------------------------------------------------------
# Git initialization
# ------------------------------------------------------------

CURRENT_STEP="GIT INITIALIZATION"
info "GIT INITIALIZATION"

cd "$ROOT"

if [[ ! -d .git ]]; then
    git init
    git branch -M main
fi

git add \
    README.md \
    .gitignore \
    apk_analysis \
    dotnet/decompiled \
    dotnet/metadata \
    native/native_libraries.txt \
    native/elf_report.txt \
    native/aot_analysis/aot_libraries.txt \
    api \
    docs \
    scripts

echo
echo "Git status:"
git status --short

# ------------------------------------------------------------
# Final report
# ------------------------------------------------------------

CURRENT_STEP="FINAL REPORT"
info "FINISHED"

echo "Project: $ROOT"
echo
echo "APK files:"
find "$TEMP" -type f | wc -l

echo "DLL files:"
echo "$DLL_COUNT"

echo "C# files:"
echo "$CS_COUNT"

echo "Assembly Store candidates:"
if [[ -f "$ROOT/native/native_libraries.txt" ]]; then
    grep -Ec '/libassembly-store\.so$|/libassemblies.*\.so$' "$ROOT/native/native_libraries.txt" || true
else
    echo "0"
fi

echo "Mono AOT native-image libraries:"
if [[ -f "$ROOT/native/aot_analysis/aot_libraries.txt" ]]; then
    wc -l < "$ROOT/native/aot_analysis/aot_libraries.txt" | tr -d ' '
else
    echo "0"
fi

echo
echo "Ошибки инструментов:"
ERROR_COUNT=0
for error_file in \
    "$ROOT/apk_analysis/apktool_exit_code.txt" \
    "$ROOT/apk_analysis/jadx_exit_code.txt" \
    "$ROOT/apk_analysis/jadx_errors.txt" \
    "$ROOT/dotnet/metadata/assembly_store_errors.txt" \
    "$ROOT/dotnet/metadata/ilspy_errors.tsv"; do
    if [[ -s "$error_file" ]]; then
        echo "[ERROR] $error_file"
        cat "$error_file"
        ERROR_COUNT=$((ERROR_COUNT + 1))
    fi
done

if [[ "$DLL_COUNT" -eq 0 ]]; then
    echo "[WARNING] DLL не найдены: ILSpy не получил управляемые сборки."
    echo "[INFO] Проверь отчёты Assembly Store и Mono AOT в каталогах dotnet/metadata/ и native/aot_analysis/."
fi
if [[ "$CS_COUNT" -eq 0 && "$DLL_COUNT" -gt 0 ]]; then
    echo "[WARNING] DLL есть, но C# исходники не созданы. Проверь ilspy_errors.tsv и журнал."
fi
echo "Категорий ошибок: $ERROR_COUNT"

echo
echo "API search:"
echo "$ROOT/api"

echo
echo "Documentation:"
echo "$ROOT/docs"

echo
echo "Log:"
echo "$LOG"

echo
echo "Next steps:"
echo "1. Inspect git status"
echo "2. Check source redistribution permissions"
echo "3. Commit the research files"
echo "4. Configure GitHub remote"
echo "5. Push to your PUBLIC GitHub repository (after reviewing for secrets and personal data)"

echo
echo "Do not upload the original APK, private traffic captures,"
echo "tokens, cookies or personal purchase data."
