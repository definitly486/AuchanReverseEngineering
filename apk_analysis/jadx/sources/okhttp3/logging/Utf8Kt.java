package okhttp3.logging;

import com.scanflow.datacapture.barinternal.kotlin.ranges.RangesKt;
import java.io.EOFException;
import kotlin.jvm.internal.Intrinsics;
import okio.Buffer;

/* JADX INFO: compiled from: utf8.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class Utf8Kt {
    public static final boolean isProbablyUtf8(Buffer buffer) {
        Intrinsics.checkNotNullParameter(buffer, "<this>");
        try {
            Buffer buffer2 = new Buffer();
            buffer.copyTo(buffer2, 0L, RangesKt.coerceAtMost(buffer.size(), 64L));
            for (int i = 0; i < 16 && !buffer2.exhausted(); i++) {
                int utf8CodePoint = buffer2.readUtf8CodePoint();
                if (Character.isISOControl(utf8CodePoint) && !Character.isWhitespace(utf8CodePoint)) {
                    return false;
                }
            }
            return true;
        } catch (EOFException unused) {
            return false;
        }
    }
}
