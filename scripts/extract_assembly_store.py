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
