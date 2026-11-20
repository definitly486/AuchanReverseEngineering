package androidx.room.util;

import android.annotation.SuppressLint;
import androidx.core.location.LocationRequestCompat;
import java.io.IOException;
import java.nio.channels.FileChannel;
import java.nio.channels.ReadableByteChannel;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: FileUtil.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class FileUtil {
    @SuppressLint({"LambdaLast"})
    public static final void copy(ReadableByteChannel input, FileChannel output) throws IOException {
        Intrinsics.checkNotNullParameter(input, "input");
        Intrinsics.checkNotNullParameter(output, "output");
        try {
            output.transferFrom(input, 0L, LocationRequestCompat.PASSIVE_INTERVAL);
            output.force(false);
        } finally {
            input.close();
            output.close();
        }
    }
}
