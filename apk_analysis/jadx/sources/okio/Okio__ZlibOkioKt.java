package okio;

import com.scanflow.datacapture.barinternal.okio.internal.ZipFilesKt;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: ZlibOkio.kt */
/* JADX INFO: loaded from: classes3.dex */
abstract /* synthetic */ class Okio__ZlibOkioKt {
    public static final FileSystem openZip(FileSystem fileSystem, Path zipPath) {
        Intrinsics.checkNotNullParameter(fileSystem, "<this>");
        Intrinsics.checkNotNullParameter(zipPath, "zipPath");
        return ZipFilesKt.openZip$default(zipPath, fileSystem, null, 4, null);
    }
}
