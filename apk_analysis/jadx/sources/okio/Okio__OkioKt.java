package okio;

import com.scanflow.datacapture.barinternal.kotlin.ExceptionsKt;
import java.io.Closeable;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.InlineMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Okio.kt */
/* JADX INFO: loaded from: classes3.dex */
abstract /* synthetic */ class Okio__OkioKt {
    public static final BufferedSource buffer(Source source) {
        Intrinsics.checkNotNullParameter(source, "<this>");
        return new RealBufferedSource(source);
    }

    public static final BufferedSink buffer(Sink sink) {
        Intrinsics.checkNotNullParameter(sink, "<this>");
        return new RealBufferedSink(sink);
    }

    public static final Sink blackhole() {
        return new BlackholeSink();
    }

    /* JADX WARN: Multi-variable type inference failed */
    /* JADX WARN: Type inference failed for: r4v2, types: [java.lang.Throwable] */
    /* JADX WARN: Type inference failed for: r4v4 */
    /* JADX WARN: Type inference failed for: r4v5 */
    public static final Object use(Closeable closeable, Function1 block) {
        ?? r4;
        Intrinsics.checkNotNullParameter(block, "block");
        Object th = null;
        try {
            Object objInvoke = block.invoke(closeable);
            InlineMarker.finallyStart(1);
            if (closeable != null) {
                try {
                    closeable.close();
                } catch (Throwable th2) {
                    th = th2;
                }
            }
            InlineMarker.finallyEnd(1);
            Object obj = th;
            th = objInvoke;
            r4 = obj;
        } catch (Throwable th3) {
            InlineMarker.finallyStart(1);
            if (closeable != null) {
                try {
                    closeable.close();
                } catch (Throwable th4) {
                    ExceptionsKt.addSuppressed(th3, th4);
                }
            }
            InlineMarker.finallyEnd(1);
            r4 = th3;
        }
        if (r4 == 0) {
            return th;
        }
        throw r4;
    }
}
