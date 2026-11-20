package com.scanflow.datacapture.barinternal.okio.internal;

import com.scanflow.datacapture.barinternal.kotlin.ExceptionsKt;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import com.scanflow.datacapture.barinternal.kotlin.comparisons.ComparisonsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.CharsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Map;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Ref$BooleanRef;
import kotlin.jvm.internal.Ref$LongRef;
import kotlin.jvm.internal.Ref$ObjectRef;
import okhttp3.internal.ws.WebSocketProtocol;
import okio.BufferedSource;
import okio.FileHandle;
import okio.FileSystem;
import okio.Okio;
import okio.Path;
import okio.ZipFileSystem;

/* JADX INFO: compiled from: ZipFiles.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class ZipFilesKt {
    public static /* synthetic */ ZipFileSystem openZip$default(Path path, FileSystem fileSystem, Function1 function1, int i, Object obj) {
        if ((i & 4) != 0) {
            function1 = new Function1() { // from class: com.scanflow.datacapture.barinternal.okio.internal.ZipFilesKt.openZip.1
                @Override // kotlin.jvm.functions.Function1
                public final Boolean invoke(ZipEntry it) {
                    Intrinsics.checkNotNullParameter(it, "it");
                    return Boolean.TRUE;
                }
            };
        }
        return openZip(path, fileSystem, function1);
    }

    public static final ZipFileSystem openZip(Path zipPath, FileSystem fileSystem, Function1 predicate) {
        Throwable th;
        Throwable th2;
        Throwable th3;
        Intrinsics.checkNotNullParameter(zipPath, "zipPath");
        Intrinsics.checkNotNullParameter(fileSystem, "fileSystem");
        Intrinsics.checkNotNullParameter(predicate, "predicate");
        FileHandle fileHandleOpenReadOnly = fileSystem.openReadOnly(zipPath);
        try {
            long size = fileHandleOpenReadOnly.size() - ((long) 22);
            if (size < 0) {
                throw new IOException("not a zip: size=" + fileHandleOpenReadOnly.size());
            }
            long jMax = Math.max(size - 65536, 0L);
            do {
                BufferedSource bufferedSourceBuffer = Okio.buffer(fileHandleOpenReadOnly.source(size));
                try {
                    if (bufferedSourceBuffer.readIntLe() == 101010256) {
                        EocdRecord eocdRecord = readEocdRecord(bufferedSourceBuffer);
                        String utf8 = bufferedSourceBuffer.readUtf8(eocdRecord.getCommentByteCount());
                        bufferedSourceBuffer.close();
                        long j = size - ((long) 20);
                        Throwable th4 = null;
                        if (j > 0) {
                            BufferedSource bufferedSourceBuffer2 = Okio.buffer(fileHandleOpenReadOnly.source(j));
                            try {
                                if (bufferedSourceBuffer2.readIntLe() == 117853008) {
                                    int intLe = bufferedSourceBuffer2.readIntLe();
                                    long longLe = bufferedSourceBuffer2.readLongLe();
                                    if (bufferedSourceBuffer2.readIntLe() != 1 || intLe != 0) {
                                        throw new IOException("unsupported zip: spanned");
                                    }
                                    BufferedSource bufferedSourceBuffer3 = Okio.buffer(fileHandleOpenReadOnly.source(longLe));
                                    try {
                                        int intLe2 = bufferedSourceBuffer3.readIntLe();
                                        if (intLe2 != 101075792) {
                                            throw new IOException("bad zip: expected " + getHex(101075792) + " but was " + getHex(intLe2));
                                        }
                                        eocdRecord = readZip64EocdRecord(bufferedSourceBuffer3, eocdRecord);
                                        Unit unit = Unit.INSTANCE;
                                        if (bufferedSourceBuffer3 != null) {
                                            try {
                                                bufferedSourceBuffer3.close();
                                            } catch (Throwable th5) {
                                                th3 = th5;
                                            }
                                        }
                                        th3 = null;
                                        if (th3 != null) {
                                            throw th3;
                                        }
                                    } catch (Throwable th6) {
                                        if (bufferedSourceBuffer3 != null) {
                                            try {
                                                bufferedSourceBuffer3.close();
                                            } catch (Throwable th7) {
                                                try {
                                                    ExceptionsKt.addSuppressed(th6, th7);
                                                } catch (Throwable th8) {
                                                    th = th8;
                                                    eocdRecord = eocdRecord;
                                                    if (bufferedSourceBuffer2 != null) {
                                                        try {
                                                            bufferedSourceBuffer2.close();
                                                        } catch (Throwable th9) {
                                                            ExceptionsKt.addSuppressed(th, th9);
                                                        }
                                                    }
                                                    th2 = th;
                                                }
                                            }
                                        }
                                        th3 = th6;
                                        eocdRecord = eocdRecord;
                                    }
                                }
                                Unit unit2 = Unit.INSTANCE;
                                if (bufferedSourceBuffer2 != null) {
                                    try {
                                        bufferedSourceBuffer2.close();
                                    } catch (Throwable th10) {
                                        th2 = th10;
                                    }
                                }
                                th2 = null;
                            } catch (Throwable th11) {
                                th = th11;
                            }
                            if (th2 != null) {
                                throw th2;
                            }
                        }
                        ArrayList arrayList = new ArrayList();
                        BufferedSource bufferedSourceBuffer4 = Okio.buffer(fileHandleOpenReadOnly.source(eocdRecord.getCentralDirectoryOffset()));
                        try {
                            long entryCount = eocdRecord.getEntryCount();
                            for (long j2 = 0; j2 < entryCount; j2++) {
                                ZipEntry centralDirectoryZipEntry = readCentralDirectoryZipEntry(bufferedSourceBuffer4);
                                if (centralDirectoryZipEntry.getOffset() >= eocdRecord.getCentralDirectoryOffset()) {
                                    throw new IOException("bad zip: local file header offset >= central directory offset");
                                }
                                if (((Boolean) predicate.invoke(centralDirectoryZipEntry)).booleanValue()) {
                                    arrayList.add(centralDirectoryZipEntry);
                                }
                            }
                            Unit unit3 = Unit.INSTANCE;
                            if (bufferedSourceBuffer4 != null) {
                                try {
                                    bufferedSourceBuffer4.close();
                                } catch (Throwable th12) {
                                    th4 = th12;
                                }
                            }
                        } catch (Throwable th13) {
                            if (bufferedSourceBuffer4 != null) {
                                try {
                                    bufferedSourceBuffer4.close();
                                } catch (Throwable th14) {
                                    ExceptionsKt.addSuppressed(th13, th14);
                                }
                            }
                            th4 = th13;
                        }
                        if (th4 == null) {
                            ZipFileSystem zipFileSystem = new ZipFileSystem(zipPath, fileSystem, buildIndex(arrayList), utf8);
                            if (fileHandleOpenReadOnly != null) {
                                try {
                                    fileHandleOpenReadOnly.close();
                                } catch (Throwable unused) {
                                }
                            }
                            return zipFileSystem;
                        }
                        throw th4;
                    }
                    bufferedSourceBuffer.close();
                    size--;
                } catch (Throwable th15) {
                    bufferedSourceBuffer.close();
                    throw th15;
                }
            } while (size >= jMax);
            throw new IOException("not a zip: end of central directory signature not found");
        } catch (Throwable th16) {
            if (fileHandleOpenReadOnly != null) {
                try {
                    fileHandleOpenReadOnly.close();
                    throw th16;
                } catch (Throwable th17) {
                    ExceptionsKt.addSuppressed(th16, th17);
                    throw th16;
                }
            }
            throw th16;
        }
    }

    private static final Map buildIndex(List list) {
        Path path = Path.Companion.get$default(Path.Companion, "/", false, 1, (Object) null);
        Map mapMutableMapOf = MapsKt.mutableMapOf(TuplesKt.to(path, new ZipEntry(path, true, null, 0L, 0L, 0L, 0, 0L, 0, 0, null, null, null, null, null, null, 65532, null)));
        for (ZipEntry zipEntry : CollectionsKt.sortedWith(list, new Comparator() { // from class: com.scanflow.datacapture.barinternal.okio.internal.ZipFilesKt$buildIndex$$inlined$sortedBy$1
            @Override // java.util.Comparator
            public final int compare(Object obj, Object obj2) {
                return ComparisonsKt.compareValues(((ZipEntry) obj).getCanonicalPath(), ((ZipEntry) obj2).getCanonicalPath());
            }
        })) {
            if (((ZipEntry) mapMutableMapOf.put(zipEntry.getCanonicalPath(), zipEntry)) == null) {
                while (true) {
                    Path pathParent = zipEntry.getCanonicalPath().parent();
                    if (pathParent == null) {
                        break;
                    }
                    ZipEntry zipEntry2 = (ZipEntry) mapMutableMapOf.get(pathParent);
                    if (zipEntry2 != null) {
                        zipEntry2.getChildren().add(zipEntry.getCanonicalPath());
                        break;
                    }
                    ZipEntry zipEntry3 = new ZipEntry(pathParent, true, null, 0L, 0L, 0L, 0, 0L, 0, 0, null, null, null, null, null, null, 65532, null);
                    mapMutableMapOf.put(pathParent, zipEntry3);
                    zipEntry3.getChildren().add(zipEntry.getCanonicalPath());
                    zipEntry = zipEntry3;
                }
            }
        }
        return mapMutableMapOf;
    }

    public static final ZipEntry readCentralDirectoryZipEntry(final BufferedSource bufferedSource) throws IOException {
        Intrinsics.checkNotNullParameter(bufferedSource, "<this>");
        int intLe = bufferedSource.readIntLe();
        if (intLe != 33639248) {
            throw new IOException("bad zip: expected " + getHex(33639248) + " but was " + getHex(intLe));
        }
        bufferedSource.skip(4L);
        short shortLe = bufferedSource.readShortLe();
        int i = shortLe & 65535;
        if ((shortLe & 1) != 0) {
            throw new IOException("unsupported zip: general purpose bit flag=" + getHex(i));
        }
        int shortLe2 = bufferedSource.readShortLe() & 65535;
        int shortLe3 = bufferedSource.readShortLe() & 65535;
        int shortLe4 = bufferedSource.readShortLe() & 65535;
        long intLe2 = ((long) bufferedSource.readIntLe()) & 4294967295L;
        final Ref$LongRef ref$LongRef = new Ref$LongRef();
        ref$LongRef.element = ((long) bufferedSource.readIntLe()) & 4294967295L;
        final Ref$LongRef ref$LongRef2 = new Ref$LongRef();
        ref$LongRef2.element = ((long) bufferedSource.readIntLe()) & 4294967295L;
        int shortLe5 = bufferedSource.readShortLe() & 65535;
        int shortLe6 = bufferedSource.readShortLe() & 65535;
        int shortLe7 = bufferedSource.readShortLe() & 65535;
        bufferedSource.skip(8L);
        final Ref$LongRef ref$LongRef3 = new Ref$LongRef();
        ref$LongRef3.element = ((long) bufferedSource.readIntLe()) & 4294967295L;
        String utf8 = bufferedSource.readUtf8(shortLe5);
        if (StringsKt.contains$default((CharSequence) utf8, (char) 0, false, 2, (Object) null)) {
            throw new IOException("bad zip: filename contains 0x00");
        }
        long j = ref$LongRef2.element == 4294967295L ? 8 : 0L;
        if (ref$LongRef.element == 4294967295L) {
            j += (long) 8;
        }
        if (ref$LongRef3.element == 4294967295L) {
            j += (long) 8;
        }
        final long j2 = j;
        final Ref$ObjectRef ref$ObjectRef = new Ref$ObjectRef();
        final Ref$ObjectRef ref$ObjectRef2 = new Ref$ObjectRef();
        final Ref$ObjectRef ref$ObjectRef3 = new Ref$ObjectRef();
        final Ref$BooleanRef ref$BooleanRef = new Ref$BooleanRef();
        readExtra(bufferedSource, shortLe6, new Function2() { // from class: com.scanflow.datacapture.barinternal.okio.internal.ZipFilesKt.readCentralDirectoryZipEntry.1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(2);
            }

            @Override // kotlin.jvm.functions.Function2
            public /* bridge */ /* synthetic */ Object invoke(Object obj, Object obj2) throws IOException {
                invoke(((Number) obj).intValue(), ((Number) obj2).longValue());
                return Unit.INSTANCE;
            }

            public final void invoke(int i2, long j3) throws IOException {
                if (i2 != 1) {
                    if (i2 != 10) {
                        return;
                    }
                    if (j3 < 4) {
                        throw new IOException("bad zip: NTFS extra too short");
                    }
                    bufferedSource.skip(4L);
                    final BufferedSource bufferedSource2 = bufferedSource;
                    final Ref$ObjectRef ref$ObjectRef4 = ref$ObjectRef;
                    final Ref$ObjectRef ref$ObjectRef5 = ref$ObjectRef2;
                    final Ref$ObjectRef ref$ObjectRef6 = ref$ObjectRef3;
                    ZipFilesKt.readExtra(bufferedSource2, (int) (j3 - 4), new Function2() { // from class: com.scanflow.datacapture.barinternal.okio.internal.ZipFilesKt.readCentralDirectoryZipEntry.1.1
                        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
                        {
                            super(2);
                        }

                        @Override // kotlin.jvm.functions.Function2
                        public /* bridge */ /* synthetic */ Object invoke(Object obj, Object obj2) throws IOException {
                            invoke(((Number) obj).intValue(), ((Number) obj2).longValue());
                            return Unit.INSTANCE;
                        }

                        public final void invoke(int i3, long j4) throws IOException {
                            if (i3 == 1) {
                                Ref$ObjectRef ref$ObjectRef7 = ref$ObjectRef4;
                                if (ref$ObjectRef7.element != null) {
                                    throw new IOException("bad zip: NTFS extra attribute tag 0x0001 repeated");
                                }
                                if (j4 != 24) {
                                    throw new IOException("bad zip: NTFS extra attribute tag 0x0001 size != 24");
                                }
                                ref$ObjectRef7.element = Long.valueOf(bufferedSource2.readLongLe());
                                ref$ObjectRef5.element = Long.valueOf(bufferedSource2.readLongLe());
                                ref$ObjectRef6.element = Long.valueOf(bufferedSource2.readLongLe());
                            }
                        }
                    });
                    return;
                }
                Ref$BooleanRef ref$BooleanRef2 = ref$BooleanRef;
                if (ref$BooleanRef2.element) {
                    throw new IOException("bad zip: zip64 extra repeated");
                }
                ref$BooleanRef2.element = true;
                if (j3 < j2) {
                    throw new IOException("bad zip: zip64 extra too short");
                }
                Ref$LongRef ref$LongRef4 = ref$LongRef2;
                long longLe = ref$LongRef4.element;
                if (longLe == 4294967295L) {
                    longLe = bufferedSource.readLongLe();
                }
                ref$LongRef4.element = longLe;
                Ref$LongRef ref$LongRef5 = ref$LongRef;
                ref$LongRef5.element = ref$LongRef5.element == 4294967295L ? bufferedSource.readLongLe() : 0L;
                Ref$LongRef ref$LongRef6 = ref$LongRef3;
                ref$LongRef6.element = ref$LongRef6.element == 4294967295L ? bufferedSource.readLongLe() : 0L;
            }
        });
        if (j2 > 0 && !ref$BooleanRef.element) {
            throw new IOException("bad zip: zip64 extra required but absent");
        }
        return new ZipEntry(Path.Companion.get$default(Path.Companion, "/", false, 1, (Object) null).resolve(utf8), StringsKt.endsWith$default(utf8, "/", false, 2, (Object) null), bufferedSource.readUtf8(shortLe7), intLe2, ref$LongRef.element, ref$LongRef2.element, shortLe2, ref$LongRef3.element, shortLe4, shortLe3, (Long) ref$ObjectRef.element, (Long) ref$ObjectRef2.element, (Long) ref$ObjectRef3.element, null, null, null, 57344, null);
    }

    private static final EocdRecord readEocdRecord(BufferedSource bufferedSource) throws IOException {
        int shortLe = bufferedSource.readShortLe() & 65535;
        int shortLe2 = bufferedSource.readShortLe() & 65535;
        long shortLe3 = bufferedSource.readShortLe() & 65535;
        if (shortLe3 != (bufferedSource.readShortLe() & 65535) || shortLe != 0 || shortLe2 != 0) {
            throw new IOException("unsupported zip: spanned");
        }
        bufferedSource.skip(4L);
        return new EocdRecord(shortLe3, 4294967295L & ((long) bufferedSource.readIntLe()), bufferedSource.readShortLe() & 65535);
    }

    private static final EocdRecord readZip64EocdRecord(BufferedSource bufferedSource, EocdRecord eocdRecord) throws IOException {
        bufferedSource.skip(12L);
        int intLe = bufferedSource.readIntLe();
        int intLe2 = bufferedSource.readIntLe();
        long longLe = bufferedSource.readLongLe();
        if (longLe != bufferedSource.readLongLe() || intLe != 0 || intLe2 != 0) {
            throw new IOException("unsupported zip: spanned");
        }
        bufferedSource.skip(8L);
        return new EocdRecord(longLe, bufferedSource.readLongLe(), eocdRecord.getCommentByteCount());
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final void readExtra(BufferedSource bufferedSource, int i, Function2 function2) throws IOException {
        long j = i;
        while (j != 0) {
            if (j < 4) {
                throw new IOException("bad zip: truncated header in extra field");
            }
            int shortLe = bufferedSource.readShortLe() & 65535;
            long shortLe2 = ((long) bufferedSource.readShortLe()) & WebSocketProtocol.PAYLOAD_SHORT_MAX;
            long j2 = j - ((long) 4);
            if (j2 < shortLe2) {
                throw new IOException("bad zip: truncated value in extra field");
            }
            bufferedSource.require(shortLe2);
            long size = bufferedSource.getBuffer().size();
            function2.invoke(Integer.valueOf(shortLe), Long.valueOf(shortLe2));
            long size2 = (bufferedSource.getBuffer().size() + shortLe2) - size;
            if (size2 < 0) {
                throw new IOException("unsupported zip: too many bytes processed for " + shortLe);
            }
            if (size2 > 0) {
                bufferedSource.getBuffer().skip(size2);
            }
            j = j2 - shortLe2;
        }
    }

    public static final void skipLocalHeader(BufferedSource bufferedSource) throws IOException {
        Intrinsics.checkNotNullParameter(bufferedSource, "<this>");
        readOrSkipLocalHeader(bufferedSource, null);
    }

    public static final ZipEntry readLocalHeader(BufferedSource bufferedSource, ZipEntry centralDirectoryZipEntry) throws IOException {
        Intrinsics.checkNotNullParameter(bufferedSource, "<this>");
        Intrinsics.checkNotNullParameter(centralDirectoryZipEntry, "centralDirectoryZipEntry");
        ZipEntry orSkipLocalHeader = readOrSkipLocalHeader(bufferedSource, centralDirectoryZipEntry);
        Intrinsics.checkNotNull(orSkipLocalHeader);
        return orSkipLocalHeader;
    }

    private static final ZipEntry readOrSkipLocalHeader(final BufferedSource bufferedSource, ZipEntry zipEntry) throws IOException {
        int intLe = bufferedSource.readIntLe();
        if (intLe != 67324752) {
            throw new IOException("bad zip: expected " + getHex(67324752) + " but was " + getHex(intLe));
        }
        bufferedSource.skip(2L);
        short shortLe = bufferedSource.readShortLe();
        int i = shortLe & 65535;
        if ((shortLe & 1) != 0) {
            throw new IOException("unsupported zip: general purpose bit flag=" + getHex(i));
        }
        bufferedSource.skip(18L);
        long shortLe2 = ((long) bufferedSource.readShortLe()) & WebSocketProtocol.PAYLOAD_SHORT_MAX;
        int shortLe3 = bufferedSource.readShortLe() & 65535;
        bufferedSource.skip(shortLe2);
        if (zipEntry == null) {
            bufferedSource.skip(shortLe3);
            return null;
        }
        final Ref$ObjectRef ref$ObjectRef = new Ref$ObjectRef();
        final Ref$ObjectRef ref$ObjectRef2 = new Ref$ObjectRef();
        final Ref$ObjectRef ref$ObjectRef3 = new Ref$ObjectRef();
        readExtra(bufferedSource, shortLe3, new Function2() { // from class: com.scanflow.datacapture.barinternal.okio.internal.ZipFilesKt.readOrSkipLocalHeader.1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(2);
            }

            @Override // kotlin.jvm.functions.Function2
            public /* bridge */ /* synthetic */ Object invoke(Object obj, Object obj2) throws IOException {
                invoke(((Number) obj).intValue(), ((Number) obj2).longValue());
                return Unit.INSTANCE;
            }

            public final void invoke(int i2, long j) throws IOException {
                if (i2 == 21589) {
                    if (j < 1) {
                        throw new IOException("bad zip: extended timestamp extra too short");
                    }
                    byte b = bufferedSource.readByte();
                    boolean z = (b & 1) == 1;
                    boolean z2 = (b & 2) == 2;
                    boolean z3 = (b & 4) == 4;
                    BufferedSource bufferedSource2 = bufferedSource;
                    long j2 = z ? 5L : 1L;
                    if (z2) {
                        j2 += 4;
                    }
                    if (z3) {
                        j2 += 4;
                    }
                    if (j < j2) {
                        throw new IOException("bad zip: extended timestamp extra too short");
                    }
                    if (z) {
                        ref$ObjectRef.element = Integer.valueOf(bufferedSource2.readIntLe());
                    }
                    if (z2) {
                        ref$ObjectRef2.element = Integer.valueOf(bufferedSource.readIntLe());
                    }
                    if (z3) {
                        ref$ObjectRef3.element = Integer.valueOf(bufferedSource.readIntLe());
                    }
                }
            }
        });
        return zipEntry.copy$okio((Integer) ref$ObjectRef.element, (Integer) ref$ObjectRef2.element, (Integer) ref$ObjectRef3.element);
    }

    public static final long filetimeToEpochMillis(long j) {
        return (j / ((long) 10000)) - 11644473600000L;
    }

    public static final Long dosDateTimeToEpochMillis(int i, int i2) {
        if (i2 == -1) {
            return null;
        }
        return Long.valueOf(_ZlibJvmKt.datePartsToEpochMillis(((i >> 9) & 127) + 1980, (i >> 5) & 15, i & 31, (i2 >> 11) & 31, (i2 >> 5) & 63, (i2 & 31) << 1));
    }

    private static final String getHex(int i) {
        StringBuilder sb = new StringBuilder();
        sb.append("0x");
        String string = Integer.toString(i, CharsKt.checkRadix(16));
        Intrinsics.checkNotNullExpressionValue(string, "toString(...)");
        sb.append(string);
        return sb.toString();
    }
}
